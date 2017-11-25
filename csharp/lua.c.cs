﻿/*
** lua.c
** Linguagem para Usuarios de Aplicacao
** TeCGraf - PUC-Rio
** 28 Apr 93
*/
using System;

namespace KopiLua
{
	public partial class Lua
	{
		public static void test()
		{
		  	lua_pushobject(lua_getparam(1));
		  	lua_call("c", 1);
		}

		internal static void callfunc()
		{
		 	Object_ obj = lua_getparam(1);
		 	if (lua_isstring(obj) != 0)
		 	{
			 	lua_call(lua_getstring(obj), 0);
		 	}
		}
	
		internal static void execstr()
		{
		 	Object_ obj = lua_getparam(1);
		 	if (lua_isstring(obj) != 0)
		 	{
			 	lua_dostring(lua_getstring(obj));
		 	}
		}
	
		static void main(int argc, string[] args)
		{
		 	int i;
		 	if (argc < 2)
		 	{
		  		Console.WriteLine("usage: lua filename [functionnames]");
		  		return;
		 	}
//			(lua_pushcfunction(callfunc), lua_storeglobal("callfunc"));
//			(lua_pushcfunction(execstr), lua_storeglobal("execstr"));
//			(lua_pushcfunction(test), lua_storeglobal("test"));
		 	iolib_open();
		 	strlib_open();
		 	mathlib_open();
		 	lua_dofile(args[1]);
		 	for (i = 2; i < argc; i++)
		 	{
		  		lua_call(args[i], 0);
		 	}
		}
	}
}
