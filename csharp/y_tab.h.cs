using System.Runtime.InteropServices;

//C++ TO C# CONVERTER TODO TASK: Unions are not supported in C#, but the following union can be replicated with the StructLayout and FieldOffset attributes:
//ORIGINAL LINE: union YYSTYPE
[StructLayout(LayoutKind.Explicit)]
public struct YYSTYPE
{
 [FieldOffset(0)]
 public int vInt;
 [FieldOffset(0)]
 public int vLong;
 [FieldOffset(0)]
 public float vFloat;
 [FieldOffset(0)]
 public Word vWord;
//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
//ORIGINAL LINE: Byte *pByte;
 [FieldOffset(0)]
 public Byte pByte;
}

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
//extern YYSTYPE yylval;

internal static class DefineConstants
{
	public const int NIL = 257;
	public const int IF = 258;
	public const int THEN = 259;
	public const int ELSE = 260;
	public const int ELSEIF = 261;
	public const int WHILE = 262;
	public const int DO = 263;
	public const int REPEAT = 264;
	public const int UNTIL = 265;
	public const int END = 266;
	public const int RETURN = 267;
	public const int LOCAL = 268;
	public const int NUMBER = 269;
	public const int FUNCTION = 270;
	public const int NAME = 271;
	public const int STRING = 272;
	public const int DEBUG = 273;
	public const int NOT = 274;
	public const int AND = 275;
	public const int OR = 276;
	public const int NE = 277;
	public const int LE = 278;
	public const int GE = 279;
	public const int CONC = 280;
	public const int UNARY = 281;
}

public static class GlobalMembers
{
private delegate void fnDelegate(ref string s);
}



