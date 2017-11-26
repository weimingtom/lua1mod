/*
** hash.h
** hash manager for lua
** Luiz Henrique de Figueiredo - 17 Aug 90
** Modified by Waldemar Celes Filho
** 26 Apr 93
*/

namespace KopiLua
{
	public partial class Lua
	{	
		public class node
		{
		 	public Object_ @ref;
		 	public Object_ val;
		 	public node next;
		}
		
		public class Hash
		{
		 	public char mark;
		 	public uint nhash;
		 	public node[] list;
		}
		
		//#define markarray(t) ((t)->mark)
		public static char markarray(Hash t) {return t.mark; }
		public static void markarray(Hash t, char c) {t.mark = c; }
		
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
	}
}
