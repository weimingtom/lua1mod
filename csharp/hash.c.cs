/*
** hash.c
** hash manager for lua
** Luiz Henrique de Figueiredo - 17 Aug 90
** Modified by Waldemar Celes Filho
** 12 May 93
*/


//C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
#include "opcode.h"
/*
** hash.h
** hash manager for lua
** Luiz Henrique de Figueiredo - 17 Aug 90
** Modified by Waldemar Celes Filho
** 26 Apr 93
*/


public class node
{
 public object @ref;
 public object val;
 public node next;
}

public class Hash
{
 public sbyte mark;
 public uint nhash;
 public node[] list;
}

public static class GlobalMembers
{


/*
** Create a new hash. Return the hash pointer or NULL on error.
*/

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define markarray(t) ((t)->mark)

	public static Hash lua_hashcreate(uint nhash)
	{
//C++ TO C# CONVERTER TODO TASK: The memory management function 'malloc' has no equivalent in C#:
	 Hash t = ((Hash)malloc(sizeof(Hash)));
	 if (t == null)
	 {
	  lua_error("not enough memory");
	  return null;
	 }
	 ((t).nhash) = nhash;
	 ((t).mark) = 0;
//C++ TO C# CONVERTER TODO TASK: The memory management function 'calloc' has no equivalent in C#:
	 ((t).list) = ((node)calloc(nhash,sizeof(node)));
	 if (((t).list) == null)
	 {
	  lua_error("not enough memory");
	  return null;
	 }
	 return t;
	}

/*
** Delete a hash
*/
	public static void lua_hashdelete(Hash h)
	{
	 int i;
	 for (i = 0; i < ((h).nhash); i++)
	 {
	  freelist(((h).list[i]));
	 }
//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
	 free(((h).list));
//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
	 free(h);
	}

/*
** If the hash node is present, return its pointer, otherwise create a new
** node for the given reference and also return its pointer.
** On error, return NULL.
*/
	public static object lua_hashdefine(Hash t, object @ref)
	{
	 int h;
	 node n;
	 h = head(t, @ref);
	 if (h < 0)
	 {
		 return null;
	 }

	 n = present(t, @ref, h);
	 if (n == null)
	 {
//C++ TO C# CONVERTER TODO TASK: The memory management function 'malloc' has no equivalent in C#:
	  n = ((node)malloc(sizeof(node)));
	  if (n == null)
	  {
	   lua_error("not enough memory");
	   return null;
	  }
	  n.@ref = @ref;
	  tag(n.val) = T_NIL;
	  n.next = ((t).list[h]); // link node to head of list
	  ((t).list[h]) = n;
	 }
	 return (n.val);
	}

/*
** Mark a hash and check its elements 
*/
	public static void lua_hashmark(Hash h)
	{
	 int i;

	 ((h).mark) = 1;

	 for (i = 0; i < ((h).nhash); i++)
	 {
	  node n;
	  for (n = ((h).list[i]); n != null; n = n.next)
	  {
	   lua_markobject(n.@ref);
	   lua_markobject(n.val);
	  }
	 }
	}

	public static void lua_next()
	{
	 Hash a;
	 object o = lua_getparam(1);
	 object r = lua_getparam(2);
	 if (o == null || r == null)
	 {
		 lua_error("too few arguments to function `next'");
		 return;
	 }
	 if (lua_getparam(3) != null)
	 {
		 lua_error("too many arguments to function `next'");
		 return;
	 }
	 if (tag(o) != T_ARRAY)
	 {
		 lua_error("first argument of function `next' is not a table");
		 return;
	 }
	 a = avalue(o);
	 if (tag(r) == T_NIL)
	 {
	  firstnode(a, 0);
	  return;
	 }
	 else
	 {
	  int h = head(a, r);
	  if (h >= 0)
	  {
	   node n = ((a).list[h]);
	   while (n != null)
	   {
//C++ TO C# CONVERTER TODO TASK: The memory management function 'memcmp' has no equivalent in C#:
		if (memcmp(n.@ref, r, sizeof(object)) == 0)
		{
		 if (n.next == null)
		 {
		  firstnode(a, h + 1);
		  return;
		 }
		 else if (tag(n.next.val) != T_NIL)
		 {
		  lua_pushobject(n.next.@ref);
		  lua_pushobject(n.next.val);
		  return;
		 }
		 else
		 {
		  node next = n.next.next;
		  while (next != null && tag(next.val) == T_NIL)
		  {
			  next = next.next;
		  }
		  if (next == null)
		  {
		   firstnode(a, h + 1);
		   return;
		  }
		  else
		  {
		   lua_pushobject(next.@ref);
		   lua_pushobject(next.val);
		  }
		  return;
		 }
		}
		n = n.next;
	   }
	   if (n == null)
	   {
		lua_error("error in function 'next': reference not found");
	   }
	  }
	 }
	}


	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lua_markstring(s) (*((s)-1))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lua_register(n,f) (lua_pushcfunction(f), lua_storeglobal(n))

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define streq(s1,s2) (strcmp(s1,s2)==0)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define strneq(s1,s2) (strcmp(s1,s2)!=0)

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define new(s) ((s *)malloc(sizeof(s)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define newvector(n,s) ((s *)calloc(n,sizeof(s)))

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define nhash(t) ((t)->nhash)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define nodelist(t) ((t)->list)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define list(t,i) ((t)->list[i])
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ref_tag(n) (tag(&(n)->ref))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ref_nvalue(n) (nvalue(&(n)->ref))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define ref_svalue(n) (svalue(&(n)->ref))

	internal static int head(Hash t, object @ref) // hash function
	{
	 if (tag(@ref) == T_NUMBER)
	 {
		 return (((int)nvalue(@ref)) % ((t).nhash));
	 }
	 else if (tag(@ref) == T_STRING)
	 {
	  int h;
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
	  sbyte * name = svalue(@ref);
	  for (h = 0; * name != 0; name++) // interpret name as binary number
	  {
	   h <<= 8;
	   h += (byte) * name; // avoid sign extension
	   h %= ((t).nhash); // make it a valid index
	  }
	  return h;
	 }
	 else
	 {
	  lua_reportbug("unexpected type to index table");
	  return -1;
	 }
	}

	internal static node present(Hash t, object @ref, int h)
	{
	 node n = null;
	 node p;
	 if (tag(@ref) == T_NUMBER)
	 {
	  for (p = null,n = ((t).list[h]); n != null; p = n, n = n.next)
	  {
	   if ((tag((n).@ref)) == T_NUMBER && nvalue(@ref) == (nvalue((n).@ref)))
	   {
		   break;
	   }
	  }
	 }
	 else if (tag(@ref) == T_STRING)
	 {
	  for (p = null,n = ((t).list[h]); n != null; p = n, n = n.next)
	  {
	   if ((tag((n).@ref)) == T_STRING && (string.Compare(svalue(@ref), (svalue((n).@ref))) == 0))
	   {
		   break;
	   }
	  }
	 }
	 if (n == null) // name not present
	 {
	  return null;
	 }
	#if false
	// if (p!=NULL)				// name present but not first 
	// {
	//  p->next=n->next;			// move-to-front self-organization 
	//  n->next=list(t,h);
	//  list(t,h)=n;
	// }
	#endif
	 return n;
	}

	internal static void freelist(node n)
	{
	 while (n != null)
	 {
	  node next = n.next;
//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
	  free(n);
//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to variables (in C#, the variable no longer points to the original when the original variable is re-assigned):
//ORIGINAL LINE: n = next;
	  n = next;
	 }
	}


	/*
	** Internal function to manipulate arrays. 
	** Given an array object and a reference value, return the next element
	** in the hash.
	** This function pushs the element value and its reference to the stack.
	*/
	internal static void firstnode(Hash a, int h)
	{
	 if (h < ((a).nhash))
	 {
	  int i;
	  for (i = h; i < ((a).nhash); i++)
	  {
	   if (((a).list[i]) != null && tag(((a).list[i]).val) != T_NIL)
	   {
		lua_pushobject(((a).list[i]).@ref);
		lua_pushobject(((a).list[i]).val);
		return;
	   }
	  }
	 }
	 lua_pushnil();
	 lua_pushnil();
	}




}
