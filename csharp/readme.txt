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

