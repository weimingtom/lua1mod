(1) %c

public static int putc(int ch, FILE fp)
		{
			//throw new NotImplementedException();
			//return 0;
			if (fp == null)
			{
				//FIXME:
------>				printf("%c", (char)ch);
			}
			return ch;
		}


				int i__ = input(); yytext[0] = (char)i__; unchecked { yyprevious = (sbyte)i__; }
breakpoint------>				if (yyprevious>0)
------>					output((char)yyprevious);
				yylastch=yytext;



------------------------

(2) debug yyt value

yywork[] yycrank
yyt - yycrank





c#: yyt.index
------
					else if(yyt.isLessThan(yycrank)) {		/* r < yycrank */
						yyr = new yyworkRef(yycrank, (-yyt.minus(yycrank))); yyt = new yyworkRef(yyr);
#if LEXDEBUG
						if(debug!=0)fprintf(yyout,"compressed state\n");
#endif
						yyt = yyt.getRef(yych);
1->						if(yyt.isLessEqualThan(yytop) && new yysvfRef(yyt.get().verify, yysvec).isEquals(yystate)){
							if(new yysvfRef(yyt.get().advance, yysvec).isEquals(YYLERR()))	/* error transitions */
------
			for(;;){
				lsp = new yysvfRef(yylstate, 0);
				yyestate = new yysvfArr(yybgin); yystate = new yysvfArr(yybgin);
				if (yyprevious==YYNEWLINE) yystate.inc();
				for (;;){fprintf(stdout,"state %d\n",yystate.minus(yysvec)-1);
#if LEXDEBUG
				if(debug!=0)fprintf(yyout,"state %d\n",yystate.minus(yysvec)-1);
#endif
					yyt = new yyworkRef(yystate.get().yystoff);
2->					if(yyt.isEquals(yycrank) && yyfirst==0){  /* may not be any transitions */
------
3->				if (yyprevious>0)
					output((char)yyprevious);
------

====>
C: yyt-yycrank or yycrank-yyt(see minus value, for example 3 is -3)
-----
	yyt = yystate->yystoff;
1->			if(yyt == yycrank && !yyfirst){  /* may not be any transitions */
----
# ifdef LEXDEBUG
				if(debug)fprintf(yyout,"compressed state\n");
# endif
				yyt = yyt + yych;
2->				if(yyt <= yytop && yyt->verify+yysvec == yystate){
----
		yyprevious = yytext[0] = input();
3->		if (yyprevious>0)
			output(yyprevious);
----


----------------------------------------------------------------------------------


(3) see state

C#--->				for (;;){fprintf(stdout,"state %d\n",yystate.minus(yysvec)-1);
#if LEXDEBUG


C--->		for (;;){fprintf(stdout,"state %d\n",yystate-yysvec-1);
# ifdef LEXDEBUG

(4) yytext

case 27:
			case 28:
		      {
C bp--->				       yylval.vWord = lua_findenclosedconstant (yytext);
				       return STRING;
				      }
				     

lua_findenclosedconstant
		public static int lua_findenclosedconstant(CharPtr s)
		{
C# breakpoint ->			int i, j, l = (int)strlen(s);



--------------------------------

(5) CALLFUNC: print not found

----------------------------------------------------

(6) vc6 remove //#line //# line
can't put breakpoint

(7) 
sizeof(void *) == 4

(8) 
search Console.WriteLine("================");

(9)
 			yyfirst=1;
 			if (yymorfg==0)
-				yylastch = yytext;
+				yylastch = new CharPtr(yytext);
 			else {
 				yymorfg=0;
-				yylastch = yytext+yyleng;
+				yylastch = new CharPtr(yytext.chars, yytext.index + yyleng);
 			}
 			for(;;
 
 
(10)
  		private static CharPtr yyerror_msg = new CharPtr(new char[256]);
-		public static void yyerror(string s)
+		public static void yyerror(CharPtr s)
 		{
 			//static char msg[256];
+			string lasttext = lua_lasttext ().ToString();
+			lasttext = lasttext.Replace("\r", "\\r");
 			sprintf (yyerror_msg,"%s near \"%s\" at line %d in file \"%s\"",
-			      s, lua_lasttext (), lua_linenumber, lua_filename());
+			         s.ToString(), lasttext, lua_linenumber, lua_filename());
+//			Console.WriteLine("===" + yyerror_msg.ToString());
 			lua_error (yyerror_msg);
 			err = 1;
 		}
 
 
 (11)
  int yylineno =1;
 # define YYU(x) x
 # define NLSTATE yyprevious=YYNEWLINE
-char yytext[YYLMAX];
+char yytext[YYLMAX];const char *yytext_buffer = yytext;

(12) maincode-code == 4356 see align_n: pc+1-code
		private static void align_n (uint size)
		{
		 	if (size > ALIGNMENT) size = ALIGNMENT;
		 	while (((pc+1-code)%size) != 0) // +1 to include BYTECODE
		 		code_byte ((byte)OpCode.NOP);
		}
		
patch--->

 			public BytePtr()
 			{
@@ -109,7 +109,14 @@ namespace KopiLua
 //				return new CharPtr(result);
 //			}
 			public static int operator -(BytePtr ptr1, BytePtr ptr2) {
-				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index - ptr2.index; }
+				//maincode-code == 4356
+				if (ptr1.chars == maincode.chars && ptr2.chars == code.chars)
+				{
+					int result = ptr1.index - ptr2.index + (1024 * 4 + 256 + 4);
+					return result;
+				}
+				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index - ptr2.index;
+			}


(13)
 				{
 					this.yyother = null;
 				}
-				this.yystops = new IntegerPtr(yyref.yystops);
+				if (yyref.yystops != null)
+				{
+					this.yystops = new IntegerPtr(yyref.yystops);
+				}
+				else
+				{
+					this.yystops = null;
+				}
 			}
 
 (14)
  			case 2:
 				//#line 179 "lua.stx"
 				{
-					pc = basepc = maincode;
+					basepc = new BytePtr(maincode); pc = new BytePtr(basepc);
 					nlocalvar = 0;
 				}
 				break;
@@ -1278,7 +1277,7 @@ yydefault:
 			case 6:
 				//#line 184 "lua.stx"
 				{
-					pc = basepc = code;
+					basepc = new BytePtr(code); pc = new BytePtr(basepc);
 					nlocalvar = 0;
 				}
 				break;
 
 
 (15) index overflow
 
 			public yywork get()
			{
				if (this.index >= 0 && this.index < this.arr.Length)
				{
					return this.arr[this.index];
				}
				else
				{
--------->					return new yywork(0, 0);
				}
			}
	
			public void set(yysvfRef v)
			{
				if (arr[index + 0] == null)
				{
--------->					arr[index + 0] = new yysvf(null, null, null);
					arr[index + 0].set(v.get());
				}
				else
				{
					arr[index + 0].set(v.get());
				}
			}
			
(16) sharpdevelop char[] compare always return false


(17) b_   ----> stack
stack[1] point to "print" cfunction

			   	case OpCode.CALLFUNC:
			   		{
						BytePtr newpc;
---->						ObjectRef b_ = top.getRef(-1);
						while (tag(b_.get()) != Type.T_MARK) b_.dec();
						if (b_.obj == stack)
						{
							Console.WriteLine("================");
						}
						if (tag(b_.get(-1)) == Type.T_FUNCTION)
						{
				 			lua_debugline = 0;			/* always reset debug flag */
				 			newpc = bvalue(b_.get(-1));
				 			bvalue(b_.get(-1), pc);		        /* store return code */
				 			nvalue(b_.get(), @base.minus(stack));		/* store base value */
				 			@base = b_.getRef(+1);
				 			pc = newpc;
				 			if (MAXSTACK-@base.minus(stack) < STACKGAP)
				 			{
				  				lua_error ("stack overflow");
				  				return 1;
				 			}
						}
						
---------------------------------------------

(18)
VC6: maincode ---> can chaged, use this:
((Byte *)mainbuffer)[0]

