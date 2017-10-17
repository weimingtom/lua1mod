using System;

public static class GlobalMembers
{
	/*
	** strlib.c
	** String library to LUA
	**
	** Waldemar Celes Filho
	** TeCGraf - PUC-Rio
	** 19 May 93
	*/



	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define lua_register(n,f) (lua_pushcfunction(f), lua_storeglobal(n))

	/*
	** Return the position of the first caracter of a substring into a string
	** LUA interface:
	**			n = strfind (string, substring)
	*/
	internal static void str_find()
	{
	 int n;
	 string s1;
	 string s2;
	 Object o1 = lua_getparam(1);
	 Object o2 = lua_getparam(2);
	 if (lua_isstring(o1) == 0 || lua_isstring(o2) == 0)
	 {
		 lua_error("incorrect arguments to function `strfind'");
		 return;
	 }
	 s1 = lua_getstring(o1);
	 s2 = lua_getstring(o2);
	 n = StringFunctions.StrStr(s1,s2) - s1.Substring(1);
	 lua_pushnumber(n);
	}

	/*
	** Return the string length
	** LUA interface:
	**			n = strlen (string)
	*/
	internal static void str_len()
	{
	 Object o = lua_getparam(1);
	 if (lua_isstring(o) == 0)
	 {
		 lua_error("incorrect arguments to function `strlen'");
		 return;
	 }
	 lua_pushnumber(Convert.ToString(lua_getstring(o)).Length);
	}


	/*
	** Return the substring of a string, from start to end
	** LUA interface:
	**			substring = strsub (string, start, end)
	*/
	internal static void str_sub()
	{
	 int start;
	 int end;
	 string s;
	 Object o1 = lua_getparam(1);
	 Object o2 = lua_getparam(2);
	 Object o3 = lua_getparam(3);
	 if (lua_isstring(o1) == 0 || lua_isnumber(o2) == 0 || lua_isnumber(o3) == 0)
	 {
		 lua_error("incorrect arguments to function `strsub'");
		 return;
	 }
	 s = lua_getstring(o1);
	 start = lua_getnumber(o2);
	 end = lua_getnumber(o3);
	 if (end < start || start < 1 || end > s.Length)
	 {
	  lua_pushstring("");
	 }
	 else
	 {
	  s = s.Substring(0, end);
	  lua_pushstring(ref s[start - 1]);
	 }
//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
	 free(s);
	}

	/*
	** Convert a string to lower case.
	** LUA interface:
	**			lowercase = strlower (string)
	*/
	internal static void str_lower()
	{
	 string s;
	 string c;
	 Object o = lua_getparam(1);
	 if (lua_isstring(o) == 0)
	 {
		 lua_error("incorrect arguments to function `strlower'");
		 return;
	 }
	 c = s = lua_getstring(o);
	 while (c != 0)
	 {
	  c = tolower(c);
	  c = c.Substring(1);
	 }
	 lua_pushstring(ref s);
//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
	 free(s);
	}


	/*
	** Convert a string to upper case.
	** LUA interface:
	**			uppercase = strupper (string)
	*/
	internal static void str_upper()
	{
	 string s;
	 string c;
	 Object o = lua_getparam(1);
	 if (lua_isstring(o) == 0)
	 {
		 lua_error("incorrect arguments to function `strlower'");
		 return;
	 }
	 c = s = lua_getstring(o);
	 while (c != 0)
	 {
	  c = toupper(c);
	  c = c.Substring(1);
	 }
	 lua_pushstring(ref s);
//C++ TO C# CONVERTER TODO TASK: The memory management function 'free' has no equivalent in C#:
	 free(s);
	}


	/*
	** Open string library
	*/
	public static void strlib_open()
	{
	 (lua_pushcfunction(str_find), lua_storeglobal("strfind"));
	 (lua_pushcfunction(str_len), lua_storeglobal("strlen"));
	 (lua_pushcfunction(str_sub), lua_storeglobal("strsub"));
	 (lua_pushcfunction(str_lower), lua_storeglobal("strlower"));
	 (lua_pushcfunction(str_upper), lua_storeglobal("strupper"));
	}
}
