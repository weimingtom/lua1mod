using System;

namespace KopiLua
{
	using Word = System.UInt16; //unsigned short
	
	public partial class Lua
	{
		public class yysvf
		{
			public yywork yystoff;
			public yysvf yyother;
			//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
			//ORIGINAL LINE: int *yystops;
			public int[] yystops;
			
			public yysvf(yywork yystoff, yysvf yyother, int[] yystops)
			{
				this.yystoff = yystoff;
				this.yyother = yyother;
				this.yystops = yystops;
			}
		}
		
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define YYTYPE char
		public class yywork
		{
			public sbyte verify;
			public sbyte advance;
			
			public yywork(sbyte verify, sbyte advance) 
			{
				this.verify = verify;
				this.advance = advance;
			}
		}
		
//		public const int INITIAL = 0;
//		public const int YYOPTIM = 1;
//		public const int NIL = 257;
//		public const int IF = 258;
//		public const int THEN = 259;
//		public const int ELSE = 260;
//		public const int ELSEIF = 261;
//		public const int WHILE = 262;
//		public const int DO = 263;
//		public const int REPEAT = 264;
//		public const int UNTIL = 265;
//		public const int END = 266;
//		public const int RETURN = 267;
//		public const int LOCAL = 268;
//		public const int NUMBER = 269;
//		public const int FUNCTION = 270;
//		public const int NAME = 271;
//		public const int STRING = 272;
//		public const int DEBUG = 273;
//		public const int NOT = 274;
//		public const int AND = 275;
//		public const int OR = 276;
//		public const int NE = 277;
//		public const int LE = 278;
//		public const int GE = 279;
//		public const int CONC = 280;
//		public const int UNARY = 281;
//		public const int YYNEWLINE = 10;
		
		
		
//		#define YYOPTIM
	
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define U(x) x
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define NLSTATE yyprevious=YYNEWLINE
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define BEGIN yybgin = yysvec + 1 +
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define YYLERR yysvec
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define YYSTATE (yyestate-yysvec-1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define YYLMAX BUFSIZ
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define output(c) putc(c,yyout)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define input() (((yytchar=yysptr>yysbuf?U(*--yysptr):getc(yyin))==10?(yylineno++,yytchar):yytchar)==EOF?0:yytchar)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define unput(c) {yytchar= (c);if(yytchar=='\n')yylineno--;*yysptr++=yytchar;}
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define yymore() (yymorfg=1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define ECHO fprintf(yyout, "%s",yytext)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define REJECT { nstr = yyreject(); goto yyfussy;}
		public static int yyleng;
		//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
		//extern sbyte yytext[];
		public static int yymorfg;
		//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
		//extern sbyte *yysptr, yysbuf[];
		public static int yytchar;
		public static FILE yyin = null;//new FILE(null);
		public static FILE yyout = null;//new FILE(null);
		//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
		//extern int yylineno;
		public static yysvf yyestate;
		//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
		//extern struct yysvf yysvec[], *yybgin;
		
		
		//C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
		//#include "opcode.h"
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define markarray(t) ((t)->mark)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define lua_markstring(s) (*((s)-1))
	
	
		internal static Input input = null;
		internal static Unput unput = null;
	
		public static void lua_setinput(Input fn)
		{
		 	input = fn;
		}
	
		public static void lua_setunput(Unput fn)
		{
		 	unput = fn;
		}
	
		public static string lua_lasttext()
		{
		 	return yytext;
		}
	
		private const int YYNEWLINE = 10;
		//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
		public static int yylex()
		{
//			int nstr;
//			//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
//		//extern int yyprevious;
//		while ((nstr = yylook()) >= 0)
//		{
//		yyfussy:
//		switch (nstr)
//		{
//		case 0:
//		if (yywrap())
//		{
//			return (0);
//		}
//		break;
//		case 1:
//						;
//		break;
//		case 2:
//		{
//						yylval.vInt = 1;
//						return DefineConstants.DEBUG;
//		}
//		break;
//		case 3:
//		{
//						yylval.vInt = 0;
//						return DefineConstants.DEBUG;
//		}
//		break;
//		case 4:
//						lua_linenumber++;
//		break;
//		case 5:
//						;
//		break;
//		case 6:
//						return DefineConstants.LOCAL;
//		break;
//		case 7:
//						return DefineConstants.IF;
//		break;
//		case 8:
//						return DefineConstants.THEN;
//		break;
//		case 9:
//						return DefineConstants.ELSE;
//		break;
//		case 10:
//					return DefineConstants.ELSEIF;
//		break;
//		case 11:
//						return DefineConstants.WHILE;
//		break;
//		case 12:
//						return DefineConstants.DO;
//		break;
//		case 13:
//					return DefineConstants.REPEAT;
//		break;
//		case 14:
//						return DefineConstants.UNTIL;
//		break;
//		case 15:
//		{
//												 yylval.vWord = lua_nfile-1;
//												 return DefineConstants.FUNCTION;
//		}
//		break;
//		case 16:
//						return DefineConstants.END;
//		break;
//		case 17:
//						return DefineConstants.RETURN;
//		break;
//		case 18:
//						return DefineConstants.LOCAL;
//		break;
//		case 19:
//						return DefineConstants.NIL;
//		break;
//		case 20:
//						return DefineConstants.AND;
//		break;
//		case 21:
//						return DefineConstants.OR;
//		break;
//		case 22:
//						return DefineConstants.NOT;
//		break;
//		case 23:
//						return DefineConstants.NE;
//		break;
//		case 24:
//						return DefineConstants.LE;
//		break;
//		case 25:
//						return DefineConstants.GE;
//		break;
//		case 26:
//						return DefineConstants.CONC;
//		break;
//		case 27:
//					case 28:
//					{
//							   yylval.vWord = lua_findenclosedconstant(ref yytext);
//							   return DefineConstants.STRING;
//					}
//		break;
//		case 29:
//		case 30:
//		case 31:
//		case 32:
//		{
//								yylval.vFloat = Convert.ToDouble(yytext);
//								return DefineConstants.NUMBER;
//		}
//		break;
//		case 33:
//		{
//							yylval.vWord = lua_findsymbol(ref yytext);
//							return DefineConstants.NAME;
//		}
//		break;
//		case 34:
//						return *yytext;
//		break;
//		case -1:
//		break;
//		default:
//		fprintf(yyout,"bad switch yylook %d",nstr);
//	break;
//		}
//		}
			return (0);
		}
		/* end of yylex */
		
		
		
		public static int[] yyvstop = {0, 1, 0, 1, 0, 34, 0, 1, 34, 0, 4, 0, 34, 0, 34, 0, 34, 0, 34, 0, 29, 34, 0, 34, 0, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 33, 34, 0, 34, 0, 34, 0, 1, 0, 27, 0, 28, 0, 5, 0, 26, 0, 30, 0, 29, 0, 29, 0, 24, 0, 25, 0, 33, 0, 33, 0, 12, 33, 0, 33, 0, 33, 0, 33, 0, 7, 33, 0, 33, 0, 33, 0, 33, 0, 21, 33, 0, 33, 0, 33, 0, 33, 0, 33, 0, 23, 0, 29, 30, 0, 31, 0, 20, 33, 0, 33, 0, 16, 33, 0, 33, 0, 33, 0, 19, 33, 0, 22, 33, 0, 33, 0, 33, 0, 33, 0, 33, 0, 33, 0, 32, 0, 9, 33, 0, 33, 0, 33, 0, 33, 0, 33, 0, 8, 33, 0, 33, 0, 33, 0, 31, 32, 0, 33, 0, 33, 0, 6, 18, 33, 0, 33, 0, 33, 0, 14, 33, 0, 11, 33, 0, 10, 33, 0, 33, 0, 13, 33, 0, 17, 33, 0, 2, 0, 33, 0, 15, 33, 0, 3, 0, 0};
		public static yywork[] yycrank =
		{
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(1, 3),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(1, 4),
			new yywork(1, 5),
			new yywork(6, 29),
			new yywork(4, 28),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(7, 31),
			new yywork(0, 0),
			new yywork(6, 29),
			new yywork(6, 29),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(7, 31),
			new yywork(7, 31),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(1, 6),
			new yywork(4, 28),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(1, 7),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(1, 3),
			new yywork(6, 30),
			new yywork(1, 8),
			new yywork(1, 9),
			new yywork(0, 0),
			new yywork(1, 10),
			new yywork(6, 29),
			new yywork(7, 31),
			new yywork(8, 33),
			new yywork(0, 0),
			new yywork(6, 29),
			new yywork(0, 0),
			new yywork(7, 32),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(6, 29),
			new yywork(7, 31),
			new yywork(1, 11),
			new yywork(0, 0),
			new yywork(1, 12),
			new yywork(2, 27),
			new yywork(7, 31),
			new yywork(1, 13),
			new yywork(11, 39),
			new yywork(12, 40),
			new yywork(1, 13),
			new yywork(26, 56),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(2, 8),
			new yywork(2, 9),
			new yywork(0, 0),
			new yywork(6, 29),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(6, 29),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(7, 31),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(7, 31),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(2, 11),
			new yywork(0, 0),
			new yywork(2, 12),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(1, 14),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(1, 15),
			new yywork(1, 16),
			new yywork(1, 17),
			new yywork(0, 0),
			new yywork(22, 52),
			new yywork(1, 18),
			new yywork(18, 47),
			new yywork(23, 53),
			new yywork(1, 19),
			new yywork(42, 63),
			new yywork(1, 20),
			new yywork(1, 21),
			new yywork(25, 55),
			new yywork(14, 42),
			new yywork(1, 22),
			new yywork(15, 43),
			new yywork(1, 23),
			new yywork(1, 24),
			new yywork(16, 44),
			new yywork(1, 25),
			new yywork(16, 45),
			new yywork(17, 46),
			new yywork(19, 48),
			new yywork(21, 51),
			new yywork(2, 14),
			new yywork(20, 49),
			new yywork(1, 26),
			new yywork(2, 15),
			new yywork(2, 16),
			new yywork(2, 17),
			new yywork(24, 54),
			new yywork(20, 50),
			new yywork(2, 18),
			new yywork(44, 64),
			new yywork(45, 65),
			new yywork(2, 19),
			new yywork(46, 66),
			new yywork(2, 20),
			new yywork(2, 21),
			new yywork(27, 57),
			new yywork(48, 67),
			new yywork(2, 22),
			new yywork(49, 68),
			new yywork(2, 23),
			new yywork(2, 24),
			new yywork(50, 69),
			new yywork(2, 25),
			new yywork(52, 70),
			new yywork(53, 72),
			new yywork(27, 58),
			new yywork(54, 73),
			new yywork(52, 71),
			new yywork(9, 34),
			new yywork(2, 26),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(9, 35),
			new yywork(10, 36),
			new yywork(55, 74),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(10, 37),
			new yywork(57, 75),
			new yywork(58, 76),
			new yywork(64, 80),
			new yywork(66, 81),
			new yywork(67, 82),
			new yywork(70, 83),
			new yywork(71, 84),
			new yywork(72, 85),
			new yywork(73, 86),
			new yywork(74, 87),
			new yywork(10, 38),
			new yywork(10, 38),
			new yywork(38, 61),
			new yywork(10, 38),
			new yywork(38, 61),
			new yywork(75, 88),
			new yywork(76, 89),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(38, 62),
			new yywork(80, 92),
			new yywork(81, 93),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(82, 94),
			new yywork(83, 95),
			new yywork(84, 96),
			new yywork(10, 38),
			new yywork(10, 38),
			new yywork(86, 97),
			new yywork(10, 38),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(87, 98),
			new yywork(88, 99),
			new yywork(60, 79),
			new yywork(60, 79),
			new yywork(13, 41),
			new yywork(60, 79),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(13, 41),
			new yywork(33, 33),
			new yywork(89, 100),
			new yywork(60, 79),
			new yywork(60, 79),
			new yywork(92, 101),
			new yywork(60, 79),
			new yywork(93, 102),
			new yywork(95, 103),
			new yywork(33, 33),
			new yywork(33, 0),
			new yywork(96, 104),
			new yywork(99, 105),
			new yywork(100, 106),
			new yywork(102, 107),
			new yywork(106, 108),
			new yywork(107, 109),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(35, 35),
			new yywork(108, 110),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(33, 33),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(35, 59),
			new yywork(35, 59),
			new yywork(33, 33),
			new yywork(35, 59),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(33, 33),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(33, 33),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(36, 60),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(33, 33),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(33, 33),
			new yywork(35, 59),
			new yywork(35, 59),
			new yywork(0, 0),
			new yywork(35, 59),
			new yywork(36, 38),
			new yywork(36, 38),
			new yywork(59, 77),
			new yywork(36, 38),
			new yywork(59, 77),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(59, 78),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(61, 62),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(36, 38),
			new yywork(36, 38),
			new yywork(0, 0),
			new yywork(36, 38),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(77, 78),
			new yywork(79, 90),
			new yywork(0, 0),
			new yywork(79, 90),
			new yywork(0, 0),
			new yywork(0, 0),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(79, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(90, 91),
			new yywork(0, 0)
		};
		
		private static yywork yycrankOffset(int off) 
		{
			return null;
		}
		private static yysvf yysvecOffset(int off)
		{
			return null;
		}
		private static int[] yyvstopOffset(int off)
		{
			return null;
		}
		private static yywork yycrankZero() 
		{
			return null;
		}
		private static yysvf yysvecZero()
		{
			return null;
		}
		private static int[] yyvstopZero()
		{
			return null;
		}
		public static yysvf[] yysvec = new yysvf[] {
			new yysvf(yycrankZero(), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(-1), yysvecZero(), yyvstopOffset(1)),
			new yysvf(yycrankOffset(-28), yysvecOffset(1), yyvstopOffset(3)),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(5)),
			new yysvf(yycrankOffset(4), yysvecZero(), yyvstopOffset(7)),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(10)),
			new yysvf(yycrankOffset(-11), yysvecZero(), yyvstopOffset(12)),
			new yysvf(yycrankOffset(-17), yysvecZero(), yyvstopOffset(14)),
			new yysvf(yycrankOffset(7), yysvecZero(), yyvstopOffset(16)),
			new yysvf(yycrankOffset(107), yysvecZero(), yyvstopOffset(18)),
			new yysvf(yycrankOffset(119), yysvecZero(), yyvstopOffset(20)),
			new yysvf(yycrankOffset(6), yysvecZero(), yyvstopOffset(23)),
			new yysvf(yycrankOffset(7), yysvecZero(), yyvstopOffset(25)),
			new yysvf(yycrankOffset(158), yysvecZero(), yyvstopOffset(27)),
			new yysvf(yycrankOffset(4), yysvecOffset(13), yyvstopOffset(30)),
			new yysvf(yycrankOffset(5), yysvecOffset(13), yyvstopOffset(33)),
			new yysvf(yycrankOffset(11), yysvecOffset(13), yyvstopOffset(36)),
			new yysvf(yycrankOffset(5), yysvecOffset(13), yyvstopOffset(39)),
			new yysvf(yycrankOffset(5), yysvecOffset(13), yyvstopOffset(42)),
			new yysvf(yycrankOffset(12), yysvecOffset(13), yyvstopOffset(45)),
			new yysvf(yycrankOffset(21), yysvecOffset(13), yyvstopOffset(48)),
			new yysvf(yycrankOffset(10), yysvecOffset(13), yyvstopOffset(51)),
			new yysvf(yycrankOffset(4), yysvecOffset(13), yyvstopOffset(54)),
			new yysvf(yycrankOffset(4), yysvecOffset(13), yyvstopOffset(57)),
			new yysvf(yycrankOffset(21), yysvecOffset(13), yyvstopOffset(60)),
			new yysvf(yycrankOffset(9), yysvecOffset(13), yyvstopOffset(63)),
			new yysvf(yycrankOffset(9), yysvecZero(), yyvstopOffset(66)),
			new yysvf(yycrankOffset(40), yysvecZero(), yyvstopOffset(68)),
			new yysvf(yycrankOffset(0), yysvecOffset(4), yyvstopOffset(70)),
			new yysvf(yycrankOffset(0), yysvecOffset(6), yyvstopZero()),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(72)),
			new yysvf(yycrankOffset(0), yysvecOffset(7), yyvstopZero()),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(74)),
			new yysvf(yycrankOffset(-280), yysvecZero(), yyvstopOffset(76)),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(78)),
			new yysvf(yycrankOffset(249), yysvecZero(), yyvstopOffset(80)),
			new yysvf(yycrankOffset(285), yysvecZero(), yyvstopOffset(82)),
			new yysvf(yycrankOffset(0), yysvecOffset(10), yyvstopOffset(84)),
			new yysvf(yycrankOffset(146), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(86)),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(88)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(90)),
			new yysvf(yycrankOffset(10), yysvecOffset(13), yyvstopOffset(92)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(94)),
			new yysvf(yycrankOffset(19), yysvecOffset(13), yyvstopOffset(97)),
			new yysvf(yycrankOffset(35), yysvecOffset(13), yyvstopOffset(99)),
			new yysvf(yycrankOffset(27), yysvecOffset(13), yyvstopOffset(101)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(103)),
			new yysvf(yycrankOffset(42), yysvecOffset(13), yyvstopOffset(106)),
			new yysvf(yycrankOffset(35), yysvecOffset(13), yyvstopOffset(108)),
			new yysvf(yycrankOffset(30), yysvecOffset(13), yyvstopOffset(110)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(112)),
			new yysvf(yycrankOffset(36), yysvecOffset(13), yyvstopOffset(115)),
			new yysvf(yycrankOffset(48), yysvecOffset(13), yyvstopOffset(117)),
			new yysvf(yycrankOffset(35), yysvecOffset(13), yyvstopOffset(119)),
			new yysvf(yycrankOffset(61), yysvecOffset(13), yyvstopOffset(121)),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(123)),
			new yysvf(yycrankOffset(76), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(67), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(312), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(183), yysvecOffset(36), yyvstopOffset(125)),
			new yysvf(yycrankOffset(322), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(0), yysvecOffset(61), yyvstopOffset(128)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(130)),
			new yysvf(yycrankOffset(78), yysvecOffset(13), yyvstopOffset(133)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(135)),
			new yysvf(yycrankOffset(81), yysvecOffset(13), yyvstopOffset(138)),
			new yysvf(yycrankOffset(84), yysvecOffset(13), yyvstopOffset(140)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(142)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(145)),
			new yysvf(yycrankOffset(81), yysvecOffset(13), yyvstopOffset(148)),
			new yysvf(yycrankOffset(66), yysvecOffset(13), yyvstopOffset(150)),
			new yysvf(yycrankOffset(74), yysvecOffset(13), yyvstopOffset(152)),
			new yysvf(yycrankOffset(80), yysvecOffset(13), yyvstopOffset(154)),	

			new yysvf(yycrankOffset(78), yysvecOffset(13), yyvstopOffset(156)),
			new yysvf(yycrankOffset(94), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(93), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(341), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(0), yysvecOffset(77), yyvstopOffset(158)),
			new yysvf(yycrankOffset(356), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(99), yysvecOffset(13), yyvstopOffset(160)),
			new yysvf(yycrankOffset(89), yysvecOffset(13), yyvstopOffset(163)),
			new yysvf(yycrankOffset(108), yysvecOffset(13), yyvstopOffset(165)),
			new yysvf(yycrankOffset(120), yysvecOffset(13), yyvstopOffset(167)),
			new yysvf(yycrankOffset(104), yysvecOffset(13), yyvstopOffset(169)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(171)),
			new yysvf(yycrankOffset(113), yysvecOffset(13), yyvstopOffset(174)),
			new yysvf(yycrankOffset(148), yysvecOffset(13), yyvstopOffset(176)),
			new yysvf(yycrankOffset(133), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(181), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(366), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(0), yysvecOffset(90), yyvstopOffset(178)),
			new yysvf(yycrankOffset(183), yysvecOffset(13), yyvstopOffset(181)),
			new yysvf(yycrankOffset(182), yysvecOffset(13), yyvstopOffset(183)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(185)),	
			new yysvf(yycrankOffset(172), yysvecOffset(13), yyvstopOffset(189)),
			new yysvf(yycrankOffset(181), yysvecOffset(13), yyvstopOffset(191)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(193)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(196)),
			new yysvf(yycrankOffset(189), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(195), yysvecZero(), yyvstopZero()),	
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(199)),
			new yysvf(yycrankOffset(183), yysvecOffset(13), yyvstopOffset(202)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(204)),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(207)),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(210)),
			new yysvf(yycrankOffset(178), yysvecZero(), yyvstopZero()),	
			new yysvf(yycrankOffset(186), yysvecOffset(13), yyvstopOffset(212)),
			new yysvf(yycrankOffset(204), yysvecZero(), yyvstopZero()),
			new yysvf(yycrankOffset(0), yysvecOffset(13), yyvstopOffset(214)),
			new yysvf(yycrankOffset(0), yysvecZero(), yyvstopOffset(217)),
			new yysvf(yycrankZero(), yysvecZero(), yyvstopZero()),			
		};
		
		public static yywork yytop = yycrankOffset(423);
		public static yysvf yybgin = yysvecOffset(1);
		public static sbyte[] yymatch = {0x0, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x9, 0xA, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x9, 0x1, (sbyte)'"', 0x1, 0x1, 0x1, 0x1, 0x27, 0x1, 0x1, 0x1, (sbyte)'+', 0x1, (sbyte)'+', 0x1, 0x1, (sbyte)'0', (sbyte)'0', (sbyte)'0', (sbyte)'0', (sbyte)'0', (sbyte)'0', (sbyte)'0', (sbyte)'0', (sbyte)'0', (sbyte)'0', 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'D', (sbyte)'D', (sbyte)'A', (sbyte)'D', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', 0x1, 0x1, 0x1, 0x1, (sbyte)'A', 0x1, (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'D', (sbyte)'D', (sbyte)'A', (sbyte)'D', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', (sbyte)'A', 0x1, 0x1, 0x1, 0x1, 0x1, 0};
		public static sbyte[] yyextra = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
		
//		#if ! lint
		internal static string ncform_sccsid = "@(#)ncform 1.6 88/02/08 SMI"; // from S5R2 1.2
//		#endif
	
		public static int yylineno = 1;
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define YYU(x) x
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define NLSTATE yyprevious=YYNEWLINE
		public static string yytext = new string(new char[BUFSIZ]);
		public static yysvf[] yylstate = new yysvf[BUFSIZ];//Arrays.InitializeWithDefaultInstances<yysvf>(BUFSIZ);
		public static yysvf[] yylsp;
		public static yysvf[] yyolsp;
		public static string yysbuf = new string(new char[BUFSIZ]);
		//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
		public static string yysptr = yysbuf;
		//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
		public static int[] yyfnd;
		//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
		//extern struct yysvf *yyestate;
		public static int yyprevious = YYNEWLINE;
		//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
		public static void yylook()
		{
//	//C++ TO C# CONVERTER NOTE: 'register' variable declarations are not supported in C#:
//	//ORIGINAL LINE: register struct yysvf *yystate, **lsp;
//			yysvf yystate;
//			yysvf[] lsp;
//	//C++ TO C# CONVERTER NOTE: 'register' variable declarations are not supported in C#:
//	//ORIGINAL LINE: register struct yywork *yyt;
//			yywork yyt;
//			yysvf yyz;
//			int yych;
//			int yyfirst;
//			yywork yyr;
//		#if LEXDEBUG
//			int debug;
//		#endif
//			string yylastch;
//			/* start off machines */
//		#if LEXDEBUG
//			debug = 0;
//		#endif
//			yyfirst = 1;
//			if (yymorfg == 0)
//			{
//				yylastch = yytext;
//			}
//			else
//			{
//				yymorfg = 0;
//				yylastch = yytext.Substring(yyleng);
//			}
//			for (;;)
//			{
//				lsp = yylstate;
//				yyestate = yystate = yybgin;
//				if (yyprevious == DefineConstants.YYNEWLINE)
//				{
//					yystate++;
//				}
//				for (;;)
//				{
//		#if LEXDEBUG
//					if (debug != 0)
//					{
//						fprintf(yyout,"state %d\n",yystate - yysvec - 1);
//					}
//		#endif
//					yyt = yystate.yystoff;
//					if (yyt == yycrank && yyfirst == 0)
//					{ // may not be any transitions
//						yyz = yystate.yyother;
//						if (yyz == 0)
//						{
//							break;
//						}
//						if (yyz.yystoff == yycrank)
//						{
//							break;
//						}
//					}
//					yylastch ++= yych = (((yytchar = yysptr > yysbuf != 0?*--yysptr:getc(yyin)) == 10?(yylineno++,yytchar):yytchar) == EOF?0:yytchar);
//					yyfirst = 0;
//				tryagain:
//		#if LEXDEBUG
//					if (debug != 0)
//					{
//						fprintf(yyout,"char ");
//						allprint(yych);
//						Console.Write('\n');
//					}
//		#endif
//	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to variables (in C#, the variable no longer points to the original when the original variable is re-assigned):
//	//ORIGINAL LINE: yyr = yyt;
//					yyr = yyt;
//					if ((int)yyt > (int)yycrank)
//					{
//						yyt = yyr + yych;
//						if (yyt <= yytop != null && yyt.verify + yysvec == yystate)
//						{
//							if (yyt.advance + yysvec == yysvec) // error transitions
//							{
//									{
//										yytchar = (*--yylastch);
//										if (yytchar == '\n')
//										{
//											yylineno--;
//										}
//										*yysptr++=yytchar;
//								};
//									break;
//							}
//							lsp[0]++= yystate = yyt.advance + yysvec;
//							goto contin;
//						}
//					}
//		#if YYOPTIM
//					else if ((int)yyt < (int)yycrank)
//					{ // r < yycrank
//						yyt = yyr = yycrank + (yycrank - yyt);
//		#if LEXDEBUG
//						if (debug != 0)
//						{
//							fprintf(yyout,"compressed state\n");
//						}
//		#endif
//						yyt = yyt + yych;
//						if (yyt <= yytop != null && yyt.verify + yysvec == yystate)
//						{
//							if (yyt.advance + yysvec == yysvec) // error transitions
//							{
//									{
//										yytchar = (*--yylastch);
//										if (yytchar == '\n')
//										{
//											yylineno--;
//										}
//										*yysptr++=yytchar;
//								};
//									break;
//							}
//							lsp[0]++= yystate = yyt.advance + yysvec;
//							goto contin;
//						}
//						yyt = yyr + yymatch[yych];
//		#if LEXDEBUG
//						if (debug != 0)
//						{
//							fprintf(yyout,"try fall back character ");
//							allprint(yymatch[yych]);
//							Console.Write('\n');
//						}
//		#endif
//						if (yyt <= yytop != null && yyt.verify + yysvec == yystate)
//						{
//							if (yyt.advance + yysvec == yysvec) // error transition
//							{
//									{
//										yytchar = (*--yylastch);
//										if (yytchar == '\n')
//										{
//											yylineno--;
//										}
//										*yysptr++=yytchar;
//								};
//									break;
//							}
//							lsp[0]++= yystate = yyt.advance + yysvec;
//							goto contin;
//						}
//					}
//					if ((yystate = yystate.yyother) != null && (yyt = yystate.yystoff) != yycrank)
//					{
//		#if LEXDEBUG
//						if (debug != 0)
//						{
//							fprintf(yyout,"fall back to state %d\n",yystate - yysvec - 1);
//						}
//		#endif
//						goto tryagain;
//					}
//		#endif
//					else
//					{
//							{
//								yytchar = (*--yylastch);
//								if (yytchar == '\n')
//								{
//									yylineno--;
//								}
//								*yysptr++=yytchar;
//						};
//							break;
//					}
//				contin:
//		#if LEXDEBUG
//					if (debug != 0)
//					{
//						fprintf(yyout,"state %d char ",yystate - yysvec - 1);
//						allprint(yych);
//						Console.Write('\n');
//					}
//		#endif
//					;
//				}
//		#if LEXDEBUG
//				if (debug != 0)
//				{
//					fprintf(yyout,"stopped at %d with ",*(lsp - 1) - yysvec - 1);
//					allprint(yych);
//					Console.Write('\n');
//				}
//		#endif
//				while (lsp-- > yylstate)
//				{
//					yylastch--= 0;
//					if (lsp[0] != 0 && (yyfnd = lsp.yystops) != 0 && *yyfnd > 0)
//					{
//						yyolsp = lsp;
//						if (yyextra[*yyfnd] != 0)
//						{ // must backup
//							while (yyback(lsp.yystops,-*yyfnd) != 1 && lsp > yylstate)
//							{
//								lsp--;
//								{
//									yytchar = (yylastch--);
//									if (yytchar == '\n')
//									{
//										yylineno--;
//									}
//									*yysptr++=yytchar;
//								};
//							}
//						}
//						yyprevious = yylastch;
//						yylsp = lsp;
//						yyleng = yylastch - yytext.Substring(1);
//						yytext = yytext.Substring(0, yyleng);
//		#if LEXDEBUG
//						if (debug != 0)
//						{
//							fprintf(yyout,"\nmatch ");
//							sprint(yytext);
//							fprintf(yyout," action %d\n",*yyfnd);
//						}
//		#endif
//						return (*yyfnd++);
//					}
//					{
//						yytchar = yylastch;
//						if (yytchar == '\n')
//						{
//							yylineno--;
//						}
//						*yysptr++=yytchar;
//				};
//				}
//				if (yytext[0] == 0)
//				{
//					yysptr = yysbuf;
//					return (0);
//				}
//				yyprevious = yytext[0] = (((yytchar = yysptr > yysbuf != 0?*--yysptr:getc(yyin)) == 10?(yylineno++,yytchar):yytchar) == EOF?0:yytchar);
//				if (yyprevious > 0)
//				{
//					putc(yyprevious,yyout);
//				}
//				yylastch = yytext;
//		#if LEXDEBUG
//				if (debug != 0)
//				{
//					Console.Write('\n');
//				}
//		#endif
//			}
		}
		
		
		
		
		//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
		public static int yyback(int[] p, int m)
		{
//	//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
//		if (p == 0)
//	//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
//			return (0);
//	//C++ TO C# CONVERTER TODO TASK: The following method format was not recognized, possibly due to an unrecognized macro:
//		while (*p)
//		{
//			if (*p++== m)
//			{
//				return (1);
//			}
//		}
//	//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
			return (0);
		}
		
		/* the following are only used in the lex library */
		//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
		public static void yyinput()
		{
//			return ((((yytchar = yysptr > yysbuf != 0?*--yysptr:getc(yyin)) == 10?(yylineno++,yytchar):yytchar) == EOF?0:yytchar));
		}
	
		//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
		public static void yyoutput(int c)
		{
//			//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
//			putc(c,yyout);
		}
	
		//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
		public static void yyunput(int c)
		{
//				{
//		//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
//					yytchar = (c);
//		//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
//					if (yytchar == '\n')
//						public static yylineno--;
//		//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
//					 public static * yysptr++=yytchar;
//				}
		}
	}
}



