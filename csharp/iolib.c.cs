/*
** iolib.c
** Input/output library to LUA
**
** Waldemar Celes Filho
** TeCGraf - PUC-Rio
** 19 May 93
*/

#if __GNUC__
#endif


public static class GlobalMembers
{
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lua_register(n,f) (lua_pushcfunction(f), lua_storeglobal(n))

	internal static FILE in = null;
	internal static FILE @out = null;

	/*
	** Open a file to read.
	** LUA interface:
	**			status = readfrom (filename)
	** where:
	**			status = 1 -> success
	**			status = 0 -> error
	*/
	internal static void io_readfrom()
	{
	 Object o = lua_getparam(1);
	 if (o == null) // restore standart input
	 {
	  if (in != stdin)
	  {
	   fclose(in);
	   in = stdin;
	  }
	  lua_pushnumber(1F);
	 }
	 else
	 {
	  if (lua_isstring(o) == 0)
	  {
	   lua_error("incorrect argument to function 'readfrom`");
	   lua_pushnumber(0F);
	  }
	  else
	  {
	   FILE fp = fopen(lua_getstring(o),"r");
	   if (fp == null)
	   {
		lua_pushnumber(0F);
	   }
	   else
	   {
		if (in != stdin)
		{
			fclose(in);
		}
//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to variables (in C#, the variable no longer points to the original when the original variable is re-assigned):
//ORIGINAL LINE: in = fp;
		in = fp;
		lua_pushnumber(1F);
	   }
	  }
	 }
	}


	/*
	** Open a file to write.
	** LUA interface:
	**			status = writeto (filename)
	** where:
	**			status = 1 -> success
	**			status = 0 -> error
	*/
	internal static void io_writeto()
	{
	 Object o = lua_getparam(1);
	 if (o == null) // restore standart output
	 {
	  if (@out != stdout)
	  {
	   fclose(@out);
	   @out = stdout;
	  }
	  lua_pushnumber(1F);
	 }
	 else
	 {
	  if (lua_isstring(o) == 0)
	  {
	   lua_error("incorrect argument to function 'writeto`");
	   lua_pushnumber(0F);
	  }
	  else
	  {
	   FILE fp = fopen(lua_getstring(o),"w");
	   if (fp == null)
	   {
		lua_pushnumber(0F);
	   }
	   else
	   {
		if (@out != stdout)
		{
			fclose(@out);
		}
//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to variables (in C#, the variable no longer points to the original when the original variable is re-assigned):
//ORIGINAL LINE: out = fp;
		@out = fp;
		lua_pushnumber(1F);
	   }
	  }
	 }
	}


	/*
	** Read a variable. On error put nil on stack.
	** LUA interface:
	**			variable = read ([format])
	**
	** O formato pode ter um dos seguintes especificadores:
	**
	**	s ou S -> para string
	**	f ou F, g ou G, e ou E -> para reais
	**	i ou I -> para inteiros
	**
	**	Estes especificadores podem vir seguidos de numero que representa
	**	o numero de campos a serem lidos.
	*/
	internal static void io_read()
	{
	 Object o = lua_getparam(1);
	 if (o == null) // free format
	 {
	  int c;
	  string s = new string(new char[256]);
	  while (isspace(c = fgetc(in)))
	  {
	   ;
	  }
	  if (c == '\"')
	  {
	   if (fscanf(in, "%[^\"]\"", s) != 1)
	   {
		lua_pushnil();
		return;
	   }
	  }
	  else if (c == '\'')
	  {
	   if (fscanf(in, "%[^\']\'", s) != 1)
	   {
		lua_pushnil();
		return;
	   }
	  }
	  else
	  {
	   string ptr;
	   double d;
	   ungetc(c, in);
	   if (fscanf(in, "%s", s) != 1)
	   {
		lua_pushnil();
		return;
	   }
	   d = strtod(s, ptr);
	   if (ptr == 0)
	   {
		lua_pushnumber(d);
		return;
	   }
	  }
	  lua_pushstring(ref s);
	  return;
	 }
	 else // formatted
	 {
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
	  sbyte * e = lua_getstring(o);
	  sbyte t;
	  int m = 0;
	  while (isspace(*e))
	  {
		  e++;
	  }
	  t = e++;
	  while (isdigit(*e))
	  {
	   m = m * 10 + (*e++ - '0');
	  }

	  if (m > 0)
	  {
	   string f = new string(new char[80]);
	   string s = new string(new char[256]);
	   f = string.Format("%{0:D}s", m);
	   fscanf(in, f, s);
	   switch (tolower(t))
	   {
		case 'i':
		{
		 int l;
		 sscanf(s, "%ld", l);
		 lua_pushnumber(l);
		}
		break;
		case 'f':
	case 'g':
	case 'e':
	{
		 float f;
		 sscanf(s, "%f", f);
		 lua_pushnumber(f);
	}
		break;
		default:
		 lua_pushstring(ref s);
		break;
	   }
	  }
	  else
	  {
	   switch (tolower(t))
	   {
		case 'i':
		{
		 int l;
		 fscanf(in, "%ld", l);
		 lua_pushnumber(l);
		}
		break;
		case 'f':
	case 'g':
	case 'e':
	{
		 float f;
		 fscanf(in, "%f", f);
		 lua_pushnumber(f);
	}
		break;
		default:
		{
		 string s = new string(new char[256]);
		 fscanf(in, "%s", s);
		 lua_pushstring(ref s);
		}
		break;
	   }
	  }
	 }
	}
//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
private static string buildformat_buffer = new string(new char[512]);
//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
private static string buildformat_f = new string(new char[80]);


	/*
	** Write a variable. On error put 0 on stack, otherwise put 1.
	** LUA interface:
	**			status = write (variable [,format])
	**
	** O formato pode ter um dos seguintes especificadores:
	**
	**	s ou S -> para string
	**	f ou F, g ou G, e ou E -> para reais
	**	i ou I -> para inteiros
	**
	**	Estes especificadores podem vir seguidos de:
	**
	**		[?][m][.n]
	**
	**	onde:
	**		? -> indica justificacao
	**			< = esquerda
	**			| = centro
	**			> = direita (default)
	**		m -> numero maximo de campos (se exceder estoura)
	**		n -> indica precisao para
	**			reais -> numero de casas decimais
	**			inteiros -> numero minimo de digitos
	**			string -> nao se aplica
	*/
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'e', so pointers on this parameter are left unchanged:
	internal static string buildformat(sbyte * e, Object o)
	{
	//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
	// static sbyte buffer[512];
	//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
	// static sbyte f[80];
	 string string = buildformat_buffer[255];
	 sbyte t;
	 sbyte j = (sbyte)'r';
	 int m = 0;
	 int n = 0;
	 int l;
	 while (isspace(*e))
	 {
		 e = e.Substring(1);
	 }
	 t = e++;
	 if (*e == (sbyte)'<' || *e == (sbyte)'|' || *e == (sbyte)'>')
	 {
		 j = e++;
	 }
	 while (isdigit(*e))
	 {
	  m = m * 10 + (*e ++ - '0');
	 }
	 e = e.Substring(1); // skip point
	 while (isdigit(*e))
	 {
	  n = n * 10 + (*e ++ - '0');
	 }

	 buildformat_f = "%%";
	 if (j == (sbyte)'<' || j == (sbyte)'|')
	 {
		 StringFunctions.StrChr(buildformat_f,0) = "-";
	 }
	 if (m != 0)
	 {
		 StringFunctions.StrChr(buildformat_f,0) = string.Format("{0:D}", m);
	 }
	 if (n != 0)
	 {
		 StringFunctions.StrChr(buildformat_f,0) = string.Format(".{0:D}", n);
	 }
	 StringFunctions.StrChr(buildformat_f,0) = string.Format("{0}", t);
	 switch (tolower(t))
	 {
	  case 'i':
		  t = (sbyte)'i';
	   sprintf(string, buildformat_f, (int)lua_getnumber(o));
	  break;
	  case 'f':
	case 'g':
	case 'e':
		t = (sbyte)'f';
	   sprintf(string, buildformat_f, (float)lua_getnumber(o));
	  break;
	  case 's':
		  t = (sbyte)'s';
	   sprintf(string, buildformat_f, lua_getstring(o));
	  break;
	  default:
		  return "";
	 }
	 l = string.Length;
	 if (m != 0 && l > m)
	 {
	  int i;
	  for (i = 0; i < m; i++)
	  {
	   string[i] = '*';
	  }
	  string = string.Substring(0, i);
	 }
	 else if (m != 0 && j == (sbyte)'|')
	 {
	  int i = l - 1;
	  while (isspace(string[i]))
	  {
		  i--;
	  }
	  string -= (m - i) / 2;
	  i = 0;
	  while (string[i] == 0)
	  {
		  string[i++] = ' ';
	  }
	  string = string.Substring(0, l);
	 }
	 return string;
	}
	internal static void io_write()
	{
	 Object o1 = lua_getparam(1);
	 Object o2 = lua_getparam(2);
	 if (o1 == null) // new line
	 {
	  fprintf(@out, "\n");
	  lua_pushnumber(1F);
	 }
	 else if (o2 == null) // free format
	 {
	  int status = 0;
	  if (lua_isnumber(o1) != 0)
	  {
	   status = fprintf(@out, "%g", lua_getnumber(o1));
	  }
	  else if (lua_isstring(o1))
	  {
	   status = fprintf(@out, "%s", lua_getstring(o1));
	  }
	  lua_pushnumber(status);
	 }
	 else // formated
	 {
	  if (lua_isstring(o2) == 0)
	  {
	   lua_error("incorrect format to function `write'");
	   lua_pushnumber(0F);
	   return;
	  }
	  lua_pushnumber(fprintf(@out, "%s", buildformat(lua_getstring(o2), o1)));
	 }
	}

	/*
	** Execute a executable program using "sustem".
	** On error put 0 on stack, otherwise put 1.
	*/
	public static void io_execute()
	{
	 Object o = lua_getparam(1);
	 if (o == null || lua_isstring(o) == 0)
	 {
	  lua_error("incorrect argument to function 'execute`");
	  lua_pushnumber(0F);
	 }
	 else
	 {
	  system(lua_getstring(o));
	  lua_pushnumber(1F);
	 }
	 return;
	}

	/*
	** Remove a file.
	** On error put 0 on stack, otherwise put 1.
	*/
	public static void io_remove()
	{
	 Object o = lua_getparam(1);
	 if (o == null || lua_isstring(o) == 0)
	 {
	  lua_error("incorrect argument to function 'execute`");
	  lua_pushnumber(0F);
	 }
	 else
	 {
	  if (remove(lua_getstring(o)) == 0)
	  {
	   lua_pushnumber(1F);
	  }
	  else
	  {
	   lua_pushnumber(0F);
	  }
	 }
	 return;
	}

	/*
	** Open io library
	*/
	public static void iolib_open()
	{
	 in = stdin;
	 @out = stdout;
	 (lua_pushcfunction(io_readfrom), lua_storeglobal("readfrom"));
	 (lua_pushcfunction(io_writeto), lua_storeglobal("writeto"));
	 (lua_pushcfunction(io_read), lua_storeglobal("read"));
	 (lua_pushcfunction(io_write), lua_storeglobal("write"));
	 (lua_pushcfunction(io_execute), lua_storeglobal("execute"));
	 (lua_pushcfunction(io_remove), lua_storeglobal("remove"));
	}

	/*
	** table.c
	** Module to control static tables
	** TeCGraf - PUC-Rio
	** 11 May 93
	*/


	//C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
	#include "opcode.h"
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define markarray(t) ((t)->mark)
	/*
	** table.c
	** Module to control static tables
	** TeCGraf - PUC-Rio
	** 11 May 93
	*/


//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Symbol *lua_table;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Word lua_ntable;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern sbyte **lua_constant;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Word lua_nconstant;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern sbyte **lua_string;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Word lua_nstring;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Hash **lua_array;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Word lua_narray;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern sbyte *lua_file[];
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern int lua_nfile;

/*
** Given a name, search it at symbol table and return its index. If not
** found, allocate at end of table, checking oveflow and return its index.
** On error, return -1.
*/

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lua_markstring(s) (*((s)-1))


	public static int lua_findsymbol(ref string s)
	{
	 int i;
	 for (i = 0; i < lua_ntable; i++)
	 {
	  if ((string.Compare(s,s_name(i)) == 0))
	  {
	   return i;
	  }
	 }
	 if (lua_ntable >= DefineConstants.MAXSYMBOL - 1)
	 {
	  lua_error("symbol table overflow");
	  return -1;
	 }
	 s_name(lua_ntable) = s;
	 if (s_name(lua_ntable) == null)
	 {
	  lua_error("not enough memory");
	  return -1;
	 }
	 s_tag(lua_ntable++) = T_NIL;

	 return (lua_ntable-1);
	}

/*
** Given a constant string, eliminate its delimeters (" or '), search it at 
** constant table and return its index. If not found, allocate at end of 
** the table, checking oveflow and return its index.
**
** For each allocation, the function allocate a extra char to be used to
** mark used string (it's necessary to deal with constant and string 
** uniformily). The function store at the table the second position allocated,
** that represents the beginning of the real string. On error, return -1.
** 
*/
	public static int lua_findenclosedconstant(ref string s)
	{
	 int i;
	 int j;
	 int l = s.Length;
	 sbyte[] c = new sbyte[l]; // make a copy

	 c++; // create mark space

	 /* introduce scape characters */
	 for (i = 1,j = 0; i < l - 1; i++)
	 {
	  if (s[i] == '\\')
	  {
	   switch (s[++i])
	   {
		case 'n':
			c[j++] = (sbyte)'\n';
			break;
		case 't':
			c[j++] = (sbyte)'\t';
			break;
		case 'r':
			c[j++] = (sbyte)'\r';
			break;
		default :
			c[j++] = (sbyte)'\\';
			c[j++] = c[i];
			break;
	   }
	  }
	  else
	  {
	   c[j++] = s[i];
	  }
	 }
	 c[j++] = 0;

	 for (i = 0; i < lua_nconstant; i++)
	 {
	  if ((string.Compare(c,lua_constant[i]) == 0))
	  {
//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
	   free(c - 1);
	   return i;
	  }
	 }
	 if (lua_nconstant >= DefineConstants.MAXCONSTANT - 1)
	 {
	  lua_error("lua: constant string table overflow");
	  return -1;
	 }
	 lua_constant[lua_nconstant++] = c;
	 return (lua_nconstant - 1);
	}

/*
** Given a constant string, search it at constant table and return its index.
** If not found, allocate at end of the table, checking oveflow and return 
** its index.
**
** For each allocation, the function allocate a extra char to be used to
** mark used string (it's necessary to deal with constant and string 
** uniformily). The function store at the table the second position allocated,
** that represents the beginning of the real string. On error, return -1.
** 
*/
	public static int lua_findconstant(ref string s)
	{
	 int i;
	 for (i = 0; i < lua_nconstant; i++)
	 {
	  if ((string.Compare(s,lua_constant[i]) == 0))
	  {
	   return i;
	  }
	 }
	 if (lua_nconstant >= DefineConstants.MAXCONSTANT - 1)
	 {
	  lua_error("lua: constant string table overflow");
	  return -1;
	 }
	 {
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
//C++ TO C# CONVERTER TODO TASK: The memory management function 'calloc' has no equivalent in C#:
	  sbyte * c = calloc(s.Length + 2,sizeof(sbyte));
	  c++; // create mark space
	  lua_constant[lua_nconstant++] = strcpy(c,s);
 }
	 return (lua_nconstant - 1);
	}

/*
** Mark an object if it is a string or a unmarked array.
*/
	public static void lua_markobject(object o)
	{
	 if (tag(o) == T_STRING)
	 {
	  (*((svalue(o)) - 1)) = 1;
	 }
	 else if (tag(o) == T_ARRAY && ((avalue(o)).mark) == 0)
	 {
	   lua_hashmark(avalue(o));
	 }
	}

/*
** Allocate a new string at string table. The given string is already 
** allocated with mark space and the function puts it at the end of the
** table, checking overflow, and returns its own pointer, or NULL on error.
*/
	public static string lua_createstring(ref string s)
	{
	 if (s == null)
	 {
		 return null;
	 }

	 if (lua_nstring >= DefineConstants.MAXSTRING - 1)
	 {
	  lua_pack();
	  if (lua_nstring >= DefineConstants.MAXSTRING - 1)
	  {
	   lua_error("string table overflow");
	   return null;
	  }
	 }
	 lua_string[lua_nstring++] = s;
	 return s;
	}

/*
** Allocate a new array, already created, at array table. The function puts 
** it at the end of the table, checking overflow, and returns its own pointer,
** or NULL on error.
*/
	public static object lua_createarray(object a)
	{
	 if (a == null)
	 {
		 return null;
	 }

	 if (lua_narray >= DefineConstants.MAXARRAY - 1)
	 {
	  lua_pack();
	  if (lua_narray >= DefineConstants.MAXARRAY - 1)
	  {
	   lua_error("indexed table overflow");
	   return null;
	  }
	 }
	 lua_array[lua_narray++] = a;
	 return a;
	}

/*
** Add a file name at file table, checking overflow. This function also set
** the external variable "lua_filename" with the function filename set.
** Return 0 on success or 1 on error.
*/
	public static int lua_addfile(ref string fn)
	{
	 if (lua_nfile >= DefineConstants.MAXFILE-1)
	 {
	  lua_error("too many files");
	  return 1;
	 }
	 if ((lua_file[lua_nfile++] = fn) == null)
	 {
	  lua_error("not enough memory");
	  return 1;
	 }
	 return 0;
	}

/*
** Return the last file name set.
*/
	public static string lua_filename()
	{
	 return lua_file[lua_nfile-1];
	}

/*
** Internal function: return next global variable
*/
	public static void lua_nextvar()
	{
	 int index;
	 object o = lua_getparam(1);
	 if (o == null)
	 {
		 lua_error("too few arguments to function `nextvar'");
		 return;
	 }
	 if (lua_getparam(2) != null)
	 {
		 lua_error("too many arguments to function `nextvar'");
		 return;
	 }
	 if (tag(o) == T_NIL)
	 {
	  index = 0;
	 }
	 else if (tag(o) != T_STRING)
	 {
	  lua_error("incorrect argument to function `nextvar'");
	  return;
	 }
	 else
	 {
	  for (index = 0; index < lua_ntable; index++)
	  {
	   if ((string.Compare(s_name(index),svalue(o)) == 0))
	   {
		   break;
	   }
	  }
	  if (index == lua_ntable)
	  {
	   lua_error("name not found in function `nextvar'");
	   return;
	  }
	  index++;
	  while (index < lua_ntable-1 && tag(s_object(index)) == T_NIL)
	  {
		  index++;
	  }

	  if (index == lua_ntable-1)
	  {
	   lua_pushnil();
	   lua_pushnil();
	   return;
	  }
	 }
	 {
	  object name;
	  tag(name) = T_STRING;
	  svalue(name) = lua_createstring(ref lua_strdup(s_name(index)));
	  if (lua_pushobject(name) != 0)
	  {
		  return;
	  }
	  if (lua_pushobject(s_object(index)) != 0)
	  {
		  return;
	  }
 }
	}


	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lua_register(n,f) (lua_pushcfunction(f), lua_storeglobal(n))

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define streq(s1,s2) (strcmp(s1,s2)==0)

	#if ! MAXSYMBOL
	#define MAXSYMBOL
	#endif
	internal static Symbol[] tablebuffer =
	{
		{
			"type",
			{
				T_CFUNCTION, {lua_type}
			}
		},
		{
			"tonumber",
			{
				T_CFUNCTION, {lua_obj2number}
			}
		},
		{
			"next",
			{
				T_CFUNCTION, {lua_next}
			}
		},
		{
			"nextvar",
			{
				T_CFUNCTION, {lua_nextvar}
			}
		},
		{
			"print",
			{
				T_CFUNCTION, {lua_print}
			}
		}
	};
	public static Symbol[] lua_table = tablebuffer;
	public static Word lua_ntable = 5;

	#if ! MAXCONSTANT
	#define MAXCONSTANT
	#endif
	internal static string[] constantbuffer = {"mark", "nil", "number", "string", "table", "function", "cfunction"};
	public static string[] lua_constant = constantbuffer;
	public static Word lua_nconstant = T_CFUNCTION + 1;

	#if ! MAXSTRING
	#define MAXSTRING
	#endif
	internal static string[] stringbuffer = new string[DefineConstants.MAXSTRING];
	public static string[] lua_string = stringbuffer;
	public static Word lua_nstring = 0;

	#if ! MAXARRAY
	#define MAXARRAY
	#endif
	internal static Hash[] arraybuffer = Arrays.InitializeWithDefaultInstances<Hash>(DefineConstants.MAXARRAY);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: Hash **lua_array = arraybuffer;
	public static Hash[] lua_array = new Hash(arraybuffer);
	public static Word lua_narray = 0;

	public static string[] lua_file = new string[DefineConstants.MAXFILE];
	public static int lua_nfile;

	/*
	** Mark all strings and arrays used by any object stored at symbol table.
	*/
	internal static void lua_marktable()
	{
	 int i;
	 for (i = 0; i < lua_ntable; i++)
	 {
	  lua_markobject(s_object(i));
	 }
	}

	/*
	** Simulate a garbage colection. When string table or array table overflows,
	** this function check if all allocated strings and arrays are in use. If
	** there are unused ones, pack (compress) the tables.
	*/
	internal static void lua_pack()
	{
	 lua_markstack();
	 lua_marktable();

	 { // pack string
	  int i;
	  int j;
	  for (i = j = 0; i < lua_nstring; i++)
	  {
	   if ((*((lua_string[i]) - 1)) == 1)
	   {
		lua_string[j++] = lua_string[i];
		(*((lua_string[i]) - 1)) = 0;
	   }
	   else
	   {
//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
		free(lua_string[i] - 1);
	   }
	  }
	  lua_nstring = j;
	 }

	 { // pack array
	  int i;
	  int j;
	  for (i = j = 0; i < lua_narray; i++)
	  {
	   if (((lua_array[i]).mark) == 1)
	   {
		lua_array[j++] = lua_array[i];
		((lua_array[i]).mark) = 0;
	   }
	   else
	   {
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: lua_hashdelete(lua_array[i]);
		lua_hashdelete(new Hash(lua_array[i]));
	   }
	  }
	  lua_narray = j;
 }
	}

}
