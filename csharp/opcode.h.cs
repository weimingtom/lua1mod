/*
** opcode.h
** TeCGraf - PUC-Rio
** 16 Apr 92
*/


//#if ! STACKGAP
//#define STACKGAP
//#endif
namespace KopiLua
{
	public partial class Lua
	{
//		#ifndef STACKGAP
//		#define STACKGAP	128
//		#endif 
		public const int STACKGAP = 128;

//		#ifndef real
//		#define real float
//		#endif
		
//		typedef unsigned char  Byte;
//
//		typedef unsigned short Word;

		public enum OpCode
		{
			NOP,
			PUSHNIL,
			PUSH0, PUSH1, PUSH2,
			PUSHBYTE,
			PUSHWORD,
			PUSHFLOAT,
			PUSHSTRING,
			PUSHLOCAL0, PUSHLOCAL1, PUSHLOCAL2, PUSHLOCAL3, PUSHLOCAL4,
			PUSHLOCAL5, PUSHLOCAL6, PUSHLOCAL7, PUSHLOCAL8, PUSHLOCAL9,
			PUSHLOCAL,
			PUSHGLOBAL,
			PUSHINDEXED,
			PUSHMARK,
			PUSHOBJECT,
			STORELOCAL0, STORELOCAL1, STORELOCAL2, STORELOCAL3, STORELOCAL4,
			STORELOCAL5, STORELOCAL6, STORELOCAL7, STORELOCAL8, STORELOCAL9,
			STORELOCAL,
			STOREGLOBAL,
			STOREINDEXED0,
			STOREINDEXED,
			STOREFIELD,
			ADJUST,
			CREATEARRAY,
			EQOP,
			LTOP,
			LEOP,
			ADDOP,
			SUBOP,
			MULTOP,
			DIVOP,
			CONCOP,
			MINUSOP,
			NOTOP,
			ONTJMP,
			ONFJMP,
			JMP,
			UPJMP,
			IFFJMP,
			IFFUPJMP,
			POP,
			CALLFUNC,
			RETCODE,
			HALT,
			SETFUNCTION,
			SETLINE,
			RESET
		}

		public enum Type
		{
			T_MARK,
		 	T_NIL,
		 	T_NUMBER,
		 	T_STRING,
		 	T_ARRAY,
		 	T_FUNCTION,
		 	T_CFUNCTION,
		 	T_USERDATA
		}

		public delegate void Cfunction();
		public delegate int Input();
		public delegate void Unput(int c);
		
		public struct Value //FIXME:struct?class?
		{
		 	public Cfunction f;
			public float n;
		 	public CharPtr s;
		 	public byte[] b;
		 	public Hash a;
		 	public object u;
			
			public void set(Value v)
		 	{
				this.f = v.f;
				this.n = v.n;
				this.s = v.s;
				this.b = v.b;
				this.a = v.a;
				this.u = v.u;
			}
		}

		public class Object_
		{
		 	public Type tag;
		 	public Value value = new Value();
		 	
		 	public void set(Object_ obj)
		 	{
		 		this.tag = obj.tag;
		 		this.value.set(obj.value);
		 	}
		}

		public class Symbol
		{
		 	public CharPtr name;
		 	public Object_ @object;
		 	
		 	public Symbol() {}
		 	public Symbol(CharPtr name, Type tag, Cfunction f) 
		 	{
		 		this.name = name;
		 		this.@object = new Object_();
		 		this.@object.tag = tag;
		 		this.@object.value.f = f;
		 	}
		}
		
		/* Macros to access structure members */
		//#define tag(o) ((o)->tag)
		public static Type tag(Object_ o) { return o.tag; }
		public static void tag(Object_ o, Type t) { o.tag = t; }		
		//#define nvalue(o) ((o)->value.n)
		public static float nvalue(Object_ o) { return o.value.n; }		
		public static void nvalue(Object_ o, float n) { o.value.n = n; }	
		//#define svalue(o) ((o)->value.s)
		public static CharPtr svalue(Object_ o) { return o.value.s; }
		public static void svalue(Object_ o, CharPtr ptr) { o.value.s = ptr; }
		//#define bvalue(o) ((o)->value.b)
		//#define avalue(o) ((o)->value.a)
		public static Hash avalue(Object_ o) { return o.value.a; }		
		//#define fvalue(o) ((o)->value.f)
		//#define uvalue(o) ((o)->value.u)
	
		/* Macros to access symbol table */
		//#define s_name(i) (lua_table[i].name)
		public static CharPtr s_name(int i) {return lua_table[i].name; }
		public static void s_name(int i, CharPtr ptr) {lua_table[i].name = ptr; }
		//#define s_object(i) (lua_table[i].object)
		public static Object_ s_object(int i) { return lua_table[i].@object; }
		public static void s_object(int i, Object_ o) { lua_table[i].@object.set(o); }
		//#define s_tag(i) (tag(&s_object(i)))
		public static Type s_tag(int i) { return tag(s_object(i)); }
		public static void s_tag(int i, Type t) { tag(s_object(i), t); }
		//#define s_nvalue(i) (nvalue(&s_object(i)))
		//#define s_svalue(i) (svalue(&s_object(i)))
		//#define s_bvalue(i) (bvalue(&s_object(i)))
		//#define s_avalue(i) (avalue(&s_object(i)))
		//#define s_fvalue(i) (fvalue(&s_object(i)))
		//#define s_uvalue(i) (uvalue(&s_object(i)))
		
		
		/* Exported functions */
//		int     lua_execute   (Byte *pc);
//		void    lua_markstack (void);
//		char   *lua_strdup (char *l);
//		
//		void    lua_setinput   (Input fn);	/* from "lua.lex" module */
//		void    lua_setunput   (Unput fn);	/* from "lua.lex" module */
//		char   *lua_lasttext   (void);		/* from "lua.lex" module */
//		int     lua_parse      (void); 		/* from "lua.stx" module */
//		void    lua_type       (void);
//		void 	lua_obj2number (void);
//		void 	lua_print      (void);
	}
}
