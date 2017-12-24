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
		public class Node
		{
			public Object_ @ref
			{
				get
				{
					return _ref;
				}
				set
				{
					_ref = value;
				}
			}
			public Object_ val
			{
				get
				{
					return _val;
				}
				set
				{
					_val = value;
				}				
			}
			
			private Object_ _ref = new Object_();
		 	private Object_ _val = new Object_();
		 	
		 	public Node next;
		}
		
		public class Hash
		{
		 	public char mark;
		 	public uint nhash;
		 	public Node[] list;
		}
		
		//#define markarray(t) ((t)->mark)
		public static char markarray(Hash t) { return t.mark; }
		public static void markarray(Hash t, char c) { t.mark = c; }
		
//		Hash 	*lua_hashcreate (unsigned int nhash);
//		void 	 lua_hashdelete (Hash *h);
//		Object 	*lua_hashdefine (Hash *t, Object *ref);
//		void 	 lua_hashmark   (Hash *h);
//		
//		void     lua_next (void);
	}
}
