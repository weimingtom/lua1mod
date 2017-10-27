/*
** mathlib.c
** Mathematica library to LUA
**
** Waldemar Celes Filho
** TeCGraf - PUC-Rio
** 19 May 93
*/
using System;

namespace KopiLua
{
	public partial class Lua
	{
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define lua_register(n,f) (lua_pushcfunction(f), lua_storeglobal(n))
	
		internal static void math_abs()
		{
		 	double d;
		 	Object o = lua_getparam(1);
		 	if (o == null)
		 	{
			 	lua_error("too few arguments to function `abs'");
			 	return;
		 	}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `abs'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	if (d < 0)
		 	{
			 	d = -d;
		 	}
		 	lua_pushnumber(d);
		}
	
		internal static void math_sin()
		{
		 	double d;
		 	Object o = lua_getparam(1);
		 	if (o == null)
		 	{
			 	lua_error("too few arguments to function `sin'");
			 	return;
		 	}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `sin'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Sin(d));
		}
	
	
	
		internal static void math_cos()
		{
		 	double d;
		 	Object o = lua_getparam(1);
			if (o == null)
		 	{
			 	lua_error("too few arguments to function `cos'");
			 	return;
		 	}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `cos'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Cos(d));
		}
	
		
		
		internal static void math_tan()
		{
		 	double d;
		 	Object o = lua_getparam(1);
		 	if (o == null)
		 	{
			 	lua_error("too few arguments to function `tan'");
			 	return;
		 	}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `tan'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Tan(d));
		}
			
		internal static void math_asin()
		{
		 	double d;
		 	Object o = lua_getparam(1);
		 	if (o == null)
		 	{
			 	lua_error("too few arguments to function `asin'");
			 	return;
			}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `asin'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Asin(d));
		}
	
	
		internal static void math_acos()
		{
		 	double d;
		 	Object o = lua_getparam(1);
		 	if (o == null)
		 	{
			 	lua_error("too few arguments to function `acos'");
			 	return;
		 	}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `acos'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Acos(d));
		}
	
	
	
		internal static void math_atan()
		{
		 	double d;
		 	Object o = lua_getparam(1);
		 	if (o == null)
		 	{
			 	lua_error("too few arguments to function `atan'");
			 	return;
		 	}
			if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `atan'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Atan(d));
		}
	
	
		internal static void math_ceil()
		{
		 	double d;
		 	Object o = lua_getparam(1);
		 	if (o == null)
		 	{
			 	lua_error("too few arguments to function `ceil'");
			 	return;
		 	}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `ceil'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Ceiling(d));
		}
	
	
		internal static void math_floor()
		{
		 	double d;
		 	Object o = lua_getparam(1);
		 	if (o == null)
		 	{
			 	lua_error("too few arguments to function `floor'");
			 	return;
			}
		 	if (lua_isnumber(o) == 0)
			{
			 	lua_error("incorrect arguments to function `floor'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Floor(d));
		}
	
		internal static void math_mod()
		{
		 	int d1;
		 	int d2;
		 	Object o1 = lua_getparam(1);
		 	Object o2 = lua_getparam(2);
		 	if (lua_isnumber(o1) == 0 || lua_isnumber(o2) == 0)
		 	{
			 	lua_error("incorrect arguments to function `mod'");
			 	return;
		 	}
		 	d1 = (int) lua_getnumber(o1);
		 	d2 = (int) lua_getnumber(o2);
		 	lua_pushnumber(d1 % d2);
		}
	
	
		internal static void math_sqrt()
		{
		 	double d;
		 	Object o = lua_getparam(1);
			if (o == null)
		 	{
			 	lua_error("too few arguments to function `sqrt'");
				return;
			}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `sqrt'");
			 	return;
		 	}
		 	d = lua_getnumber(o);
		 	lua_pushnumber(Math.Sqrt(d));
		}
	
		internal static void math_pow()
		{
		 	double d1;
		 	double d2;
		 	Object o1 = lua_getparam(1);
		 	Object o2 = lua_getparam(2);
		 	if (lua_isnumber(o1) == 0 || lua_isnumber(o2) == 0)
		 	{
			 	lua_error("incorrect arguments to function `pow'");
				return;
		 	}
		 	d1 = lua_getnumber(o1);
		 	d2 = lua_getnumber(o2);
		 	lua_pushnumber(Math.Pow(d1,d2));
		}
	
		internal static void math_min()
		{
		 	int i = 1;
		 	double d;
		 	double dmin;
		 	Object o;
		 	if ((o = lua_getparam(i++)) == null)
		 	{
				lua_error("too few arguments to function `min'");
			 	return;
		 	}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `min'");
			 	return;
		 	}
		 	dmin = lua_getnumber(o);
			while ((o = lua_getparam(i++)) != null)
		 	{
		  		if (lua_isnumber(o) == 0)
		  		{
			  		lua_error("incorrect arguments to function `min'");
			  		return;
		  		}
		  		d = lua_getnumber(o);
		  		if (d < dmin)
		  		{
			  		dmin = d;
		  		}
		 	}
		 	lua_pushnumber(dmin);
		}
	
	
		internal static void math_max()
		{
		 	int i = 1;
		 	double d;
		 	double dmax;
		 	Object o;
		 	if ((o = lua_getparam(i++)) == null)
		 	{
			 	lua_error("too few arguments to function `max'");
			 	return;
		 	}
		 	if (lua_isnumber(o) == 0)
		 	{
			 	lua_error("incorrect arguments to function `max'");
			 	return;
		 	}
		 	dmax = lua_getnumber(o);
		 	while ((o = lua_getparam(i++)) != null)
		 	{
		  		if (lua_isnumber(o) == 0)
		  		{
			  		lua_error("incorrect arguments to function `max'");
			  		return;
		  		}
		  		d = lua_getnumber(o);
		  		if (d > dmax)
		  		{
			  		dmax = d;
		  		}
		 	}
		 	lua_pushnumber(dmax);
		}
	
	
	
		/*
		** Open math library
		*/
		public static void mathlib_open()
		{
//		 	(lua_pushcfunction(math_abs), lua_storeglobal("abs"));
//		 	(lua_pushcfunction(math_sin), lua_storeglobal("sin"));
//		 	(lua_pushcfunction(math_cos), lua_storeglobal("cos"));
//		 	(lua_pushcfunction(math_tan), lua_storeglobal("tan"));
//		 	(lua_pushcfunction(math_asin), lua_storeglobal("asin"));
//		 	(lua_pushcfunction(math_acos), lua_storeglobal("acos"));
//		 	(lua_pushcfunction(math_atan), lua_storeglobal("atan"));
//		 	(lua_pushcfunction(math_ceil), lua_storeglobal("ceil"));
//		 	(lua_pushcfunction(math_floor), lua_storeglobal("floor"));
//		 	(lua_pushcfunction(math_mod), lua_storeglobal("mod"));
//		 	(lua_pushcfunction(math_sqrt), lua_storeglobal("sqrt"));
//		 	(lua_pushcfunction(math_pow), lua_storeglobal("pow"));
//		 	(lua_pushcfunction(math_min), lua_storeglobal("min"));
//		 	(lua_pushcfunction(math_max), lua_storeglobal("max"));
		}
	}
}

