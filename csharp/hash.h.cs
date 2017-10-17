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
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define markarray(t) ((t)->mark)

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//Hash lua_hashcreate(uint nhash);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_hashdelete(Hash h);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//object lua_hashdefine(Hash t, object @ref);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_hashmark(Hash h);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_next();
