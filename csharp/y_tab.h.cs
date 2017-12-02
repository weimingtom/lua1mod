using System;
using System.Runtime.InteropServices;

namespace KopiLua
{
	using Word = System.UInt16; //unsigned short
	
	public partial class Lua
	{
		public class YYSTYPE //FIXME:union
		{
		 	public int vInt;
		 	public long vLong;
		 	public float vFloat;
		 	public Word vWord;
		 	public BytePtr pByte;
		}

		//extern YYSTYPE yylval;
		
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
}



