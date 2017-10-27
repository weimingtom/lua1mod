/*
** LUA - Linguagem para Usuarios de Aplicacao
** Grupo de Tecnologia em Computacao Grafica
** TeCGraf - PUC-Rio
** 19 May 93
*/
namespace KopiLua
{
	public partial class Lua
	{
		public delegate void lua_CFunction();
	
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define lua_register(n,f) (lua_pushcfunction(f), lua_storeglobal(n))
	
	
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//void lua_errorfunction(fnDelegate fn);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//void lua_error(ref string s);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_dofile(ref string filename);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_dostring(ref string string);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_call(ref string functionname, int nparam);
	
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//Object lua_getparam(int number);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//float lua_getnumber(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//string lua_getstring(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//string lua_copystring(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//lua_CFunction lua_getcfunction(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//object lua_getuserdata(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//Object lua_getfield(Object @object, ref string field);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//Object lua_getindexed(Object @object, float index);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//Object lua_getglobal(ref string name);
	
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//Object lua_pop();
	
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_pushnil();
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_pushnumber(float n);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_pushstring(ref string s);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_pushcfunction(lua_CFunction fn);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_pushuserdata(object u);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_pushobject(Object @object);
	
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_storeglobal(ref string name);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_storefield(Object @object, ref string field);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_storeindexed(Object @object, float index);
	
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_isnil(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_isnumber(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_isstring(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_istable(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_iscfunction(Object @object);
	//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
		//int lua_isuserdata(Object @object);
	}
}

