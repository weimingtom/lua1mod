/*
** opcode.h
** TeCGraf - PUC-Rio
** 16 Apr 92
*/


#if ! STACKGAP
#define STACKGAP
#endif

internal static class DefineConstants
{
	public const int STACKGAP = 128;
}

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define real float



public enum OpCode
{
 NOP,
 PUSHNIL,
 PUSH0,
 PUSH1,
 PUSH2,
 PUSHBYTE,
 PUSHWORD,
 PUSHFLOAT,
 PUSHSTRING,
 PUSHLOCAL0,
 PUSHLOCAL1,
 PUSHLOCAL2,
 PUSHLOCAL3,
 PUSHLOCAL4,
 PUSHLOCAL5,
 PUSHLOCAL6,
 PUSHLOCAL7,
 PUSHLOCAL8,
 PUSHLOCAL9,
 PUSHLOCAL,
 PUSHGLOBAL,
 PUSHINDEXED,
 PUSHMARK,
 PUSHOBJECT,
 STORELOCAL0,
 STORELOCAL1,
 STORELOCAL2,
 STORELOCAL3,
 STORELOCAL4,
 STORELOCAL5,
 STORELOCAL6,
 STORELOCAL7,
 STORELOCAL8,
 STORELOCAL9,
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
public delegate void Unput(int NamelessParameter);

//C++ TO C# CONVERTER TODO TASK: Unions are not supported in C#:
//ORIGINAL LINE: union Value
public struct Value
{
 public Cfunction f;
 public float n;
 public string s;
//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
//ORIGINAL LINE: byte *b;
 public byte b;
 public Hash a;
 public object u;
}

public class Object
{
 public Type tag;
 public Value value = new Value();
}

public class Symbol
{
 public string name;
 public object @object;
}
	/* Macros to access structure members */
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define tag(o) ((o)->tag)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define nvalue(o) ((o)->value.n)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define svalue(o) ((o)->value.s)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define bvalue(o) ((o)->value.b)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define avalue(o) ((o)->value.a)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define fvalue(o) ((o)->value.f)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define uvalue(o) ((o)->value.u)

	/* Macros to access symbol table */
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_name(i) (lua_table[i].name)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_object(i) (lua_table[i].object)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_tag(i) (tag(&s_object(i)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_nvalue(i) (nvalue(&s_object(i)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_svalue(i) (svalue(&s_object(i)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_bvalue(i) (bvalue(&s_object(i)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_avalue(i) (avalue(&s_object(i)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_fvalue(i) (fvalue(&s_object(i)))
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define s_uvalue(i) (uvalue(&s_object(i)))


	/* Exported functions */
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//int lua_execute(ref byte pc);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_markstack();
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//string lua_strdup(ref string l);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_setinput(Input fn); // from "lua.lex" module
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_setunput(Unput fn); // from "lua.lex" module
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//string lua_lasttext(); // from "lua.lex" module
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//int lua_parse(); // from "lua.stx" module
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_type();
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_obj2number();
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void lua_print();

