/*
** iolib.c
** Input/output library to LUA
**
** Waldemar Celes Filho
** TeCGraf - PUC-Rio
** 19 May 93
*/
using System;

//#if __GNUC__
//#endif

namespace KopiLua
{
	public partial class Lua
	{
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define lua_register(n,f) (lua_pushcfunction(f), lua_storeglobal(n))
	
		internal static FILE @in = null;
		internal static FILE @out = null;
	
		/*
		** Open a file to read.
		** LUA interface:
		**			status = readfrom (filename)
		** where:
		**			status = 1 -> success
		**			status = 0 -> error
		*/
		internal static void io_readfrom()
		{
		 	Object_ o = lua_getparam(1);
		 	if (o == null) // restore standart input
		 	{
		  		if (@in != stdin)
		  		{
		   			fclose(@in);
		   			@in = stdin;
		  		}
		  		lua_pushnumber(1F);
		 	}
		 	else
		 	{
		  		if (lua_isstring(o) == 0)
		  		{
		   			lua_error("incorrect argument to function 'readfrom`");
		   			lua_pushnumber(0F);
		  		}
		  		else
		  		{
		   			FILE fp = fopen(lua_getstring(o),"r");
		   			if (fp == null)
		   			{
						lua_pushnumber(0F);
		   			}
		   			else
		   			{
						if (@in != stdin)
						{
							fclose(@in);
						}
						//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to variables (in C#, the variable no longer points to the original when the original variable is re-assigned):
						//ORIGINAL LINE: in = fp;
						@in = fp;
						lua_pushnumber(1F);
		   			}
		  		}
		 	}
		}
	
	
		/*
		** Open a file to write.
		** LUA interface:
		**			status = writeto (filename)
		** where:
		**			status = 1 -> success
		**			status = 0 -> error
		*/
		internal static void io_writeto()
		{
		 	Object_ o = lua_getparam(1);
		 	if (o == null) // restore standart output
		 	{
		  		if (@out != stdout)
		  		{
		   			fclose(@out);
		   			@out = stdout;
		  		}
		  		lua_pushnumber(1F);
		 	}
		 	else
		 	{
		  		if (lua_isstring(o) == 0)
		  		{
		   			lua_error("incorrect argument to function 'writeto`");
		   			lua_pushnumber(0F);
		  		}
		  		else
		  		{
		   			FILE fp = fopen(lua_getstring(o),"w");
		   			if (fp == null)
		   			{
						lua_pushnumber(0F);
		   			}
		   			else
		   			{
						if (@out != stdout)
						{
							fclose(@out);
						}
						//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to variables (in C#, the variable no longer points to the original when the original variable is re-assigned):
						//ORIGINAL LINE: out = fp;
						@out = fp;
						lua_pushnumber(1F);
		   			}
		  		}
		 	}
		}
	
	
		/*
		** Read a variable. On error put nil on stack.
		** LUA interface:
		**			variable = read ([format])
		**
		** O formato pode ter um dos seguintes especificadores:
		**
		**	s ou S -> para string
		**	f ou F, g ou G, e ou E -> para reais
		**	i ou I -> para inteiros
		**
		**	Estes especificadores podem vir seguidos de numero que representa
		**	o numero de campos a serem lidos.
		*/
		internal static void io_read()
		{
		 	Object o = lua_getparam(1);
//		 	if (o == null) // free format
//		 	{
//		  		int c;
//		  		string s = new string(new char[256]);
//		  		while (isspace(c = fgetc(@in)))
//		  		{
//		   			;
//		  		}
//		  		if (c == '\"')
//		  		{
//		   			if (fscanf(@in, "%[^\"]\"", s) != 1)
//		   			{
//						lua_pushnil();
//						return;
//		   			}
//		  		}
//		  		else if (c == '\'')
//		  		{
//		   			if (fscanf(@in, "%[^\']\'", s) != 1)
//		   			{
//						lua_pushnil();
//						return;
//		   			}
//		  		}
//		  		else
//		  		{
//		   			string ptr;
//		   			double d;
//		   			ungetc(c, @in);
//		   			if (fscanf(@in, "%s", s) != 1)
//		   			{
//						lua_pushnil();
//						return;
//		   			}
//		   			d = strtod(s, ptr);
//		   			if (ptr == null)
//		   			{
//						lua_pushnumber(d);
//						return;
//		   			}
//		  		}
//		  		lua_pushstring(ref s);
//		  		return;
//		 	}
//		 	else // formatted
//		 	{
//				//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
//		  		sbyte * e = lua_getstring(o);
//		  		sbyte t;
//		  		int m = 0;
//		  		while (isspace(*e))
//		  		{
//			  		e++;
//		  		}
//		  		t = e++;
//		  		while (isdigit(*e))
//		  		{
//		   			m = m * 10 + (*e++ - '0');
//		  		}
//	
//		  		if (m > 0)
//		  		{
//		   			string f = new string(new char[80]);
//		  	 		string s = new string(new char[256]);
//		   			f = string.Format("%{0:D}s", m);
//		   			fscanf(@in, f, s);
//		   			switch (tolower(t))
//		   			{
//					case 'i':
//						{
//			 				int l;
//			 				sscanf(s, "%ld", l);
//			 				lua_pushnumber(l);
//						}
//						break;
//			
//					case 'f':
//					case 'g':
//					case 'e':
//						{
//			 				float f;
//			 				sscanf(s, "%f", f);
//			 				lua_pushnumber(f);
//						}
//						break;
//			
//					default:
//			 			lua_pushstring(ref s);
//						break;
//		   			}
//			  	}
//			  	else
//			  	{
//			   		switch (tolower(t))
//			   		{
//					case 'i':
//						{
//				 			int l;
//				 			fscanf(@in, "%ld", l);
//				 			lua_pushnumber(l);
//						}
//						break;
//				
//					case 'f':
//					case 'g':
//					case 'e':
//						{
//							 float f;
//							 fscanf(@in, "%f", f);
//							 lua_pushnumber(f);
//						}
//						break;
//				
//					default:
//						{
//				 			string s = new string(new char[256]);
//				 			fscanf(@in, "%s", s);
//				 			lua_pushstring(ref s);
//						}
//						break;
//			   		}
//			  	}
//		 	}
		}
		
		//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
		private static string buildformat_buffer = new string(new char[512]);
		//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
		private static string buildformat_f = new string(new char[80]);
	
	
		/*
		** Write a variable. On error put 0 on stack, otherwise put 1.
		** LUA interface:
		**			status = write (variable [,format])
		**
		** O formato pode ter um dos seguintes especificadores:
		**
		**	s ou S -> para string
		**	f ou F, g ou G, e ou E -> para reais
		**	i ou I -> para inteiros
		**
		**	Estes especificadores podem vir seguidos de:
		**
		**		[?][m][.n]
		**
		**	onde:
		**		? -> indica justificacao
		**			< = esquerda
		**			| = centro
		**			> = direita (default)
		**		m -> numero maximo de campos (se exceder estoura)
		**		n -> indica precisao para
		**			reais -> numero de casas decimais
		**			inteiros -> numero minimo de digitos
		**			string -> nao se aplica
		*/
		//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'e', so pointers on this parameter are left unchanged:
		internal static string buildformat(CharPtr e, Object o)
		{
//			//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
//			// static sbyte buffer[512];
//			//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
//			// static sbyte f[80];
//		 	string @string = buildformat_buffer[255];
//		 	sbyte t;
//		 	sbyte j = (sbyte)'r';
//		 	int m = 0;
//		 	int n = 0;
//		 	int l;
//		 	while (isspace(*e))
//		 	{
//			 	e = e.Substring(1);
//		 	}
//		 	t = e++;
//		 	if (*e == (sbyte)'<' || *e == (sbyte)'|' || *e == (sbyte)'>')
//		 	{
//			 	j = e++;
//		 	}
//		 	while (isdigit(*e))
//		 	{
//		  		m = m * 10 + (*e ++ - '0');
//		 	}
//		 	e = e.Substring(1); // skip point
//		 	while (isdigit(*e))
//		 	{
//		  		n = n * 10 + (*e ++ - '0');
//		 	}
//	
//		 	buildformat_f = "%%";
//		 	if (j == (sbyte)'<' || j == (sbyte)'|')
//		 	{
//			 	StringFunctions.StrChr(buildformat_f,0) = "-";
//		 	}
//		 	if (m != 0)
//		 	{
//			 	StringFunctions.StrChr(buildformat_f,0) = string.Format("{0:D}", m);
//		 	}
//		 	if (n != 0)
//		 	{
//			 	StringFunctions.StrChr(buildformat_f,0) = string.Format(".{0:D}", n);
//		 	}
//		 	StringFunctions.StrChr(buildformat_f,0) = string.Format("{0}", t);
//		 	switch (tolower(t))
//		 	{
//	  		case 'i':
//		  		t = (sbyte)'i';
//	   			sprintf(@string, buildformat_f, (int)lua_getnumber(o));
//		  		break;
//		  
//		  	case 'f':
//			case 'g':
//			case 'e':
//				t = (sbyte)'f';
//		   		sprintf(@string, buildformat_f, (float)lua_getnumber(o));
//		  		break;
//		  
//		  	case 's':
//				t = (sbyte)'s';
//		   		sprintf(@string, buildformat_f, lua_getstring(o));
//		  		break;
//		  
//		  	default:
//			  	return "";
//		 	}
//		 	l = @string.Length;
//			if (m != 0 && l > m)
//			{
//			  	int i;
//			  	for (i = 0; i < m; i++)
//			  	{
//			   		@string[i] = '*';
//			  	}
//			  	@string = @string.Substring(0, i);
//			}
//			else if (m != 0 && j == (sbyte)'|')
//			{
//			  	int i = l - 1;
//			  	while (isspace(@string[i]))
//			  	{
//				  	i--;
//			  	}
//			  	@string -= (m - i) / 2;
//			  	i = 0;
//			  	while (@string[i] == 0)
//			  	{
//				  	@string[i++] = ' ';
//			  	}
//		  		@string = @string.Substring(0, l);
//		 	}
//		 	return @string;
			return null;
		}
		
		internal static void io_write()
		{
		 	Object_ o1 = lua_getparam(1);
		 	Object_ o2 = lua_getparam(2);
		 	if (o1 == null) // new line
		 	{
		  		fprintf(@out, "\n");
		  		lua_pushnumber(1F);
		 	}
		 	else if (o2 == null) // free format
		 	{
		  		int status = 0;
		  		if (lua_isnumber(o1) != 0)
		  		{
		   			status = fprintf(@out, "%g", lua_getnumber(o1));
		  		}
		  		else if (lua_isstring(o1) != 0)
		  		{
		   			status = fprintf(@out, "%s", lua_getstring(o1));
		  		}
		  		lua_pushnumber(status);
		 	}
		 	else // formated
		 	{
		  		if (lua_isstring(o2) == 0)
		  		{
		   			lua_error("incorrect format to function `write'");
		   			lua_pushnumber(0F);
		   			return;
		  		}
		  		lua_pushnumber(fprintf(@out, "%s", buildformat(lua_getstring(o2), o1)));
		 	}
		}
	
		/*
		** Execute a executable program using "sustem".
		** On error put 0 on stack, otherwise put 1.
		*/
		public static void io_execute()
		{
		 	Object_ o = lua_getparam(1);
		 	if (o == null || lua_isstring(o) == 0)
		 	{
		  		lua_error("incorrect argument to function 'execute`");
		  		lua_pushnumber(0F);
		 	}
		 	else
		 	{
		  		system(lua_getstring(o));
		  		lua_pushnumber(1F);
		 	}
		 	return;
		}
	
		/*
		** Remove a file.
		** On error put 0 on stack, otherwise put 1.
		*/
		public static void io_remove()
		{
		 	Object_ o = lua_getparam(1);
		 	if (o == null || lua_isstring(o) == 0)
		 	{
		  		lua_error("incorrect argument to function 'execute`");
		  		lua_pushnumber(0F);
		 	}
		 	else
		 	{
		  		if (remove(lua_getstring(o)) == 0)
		  		{
		   			lua_pushnumber(1F);
		  		}
		  		else
		  		{
		   			lua_pushnumber(0F);
		  		}
		 	}
		 	return;
		}
		
		/*
		** Open io library
		*/
		public static void iolib_open()
		{
		 	@in = stdin;
		 	@out = stdout;
//		 	(lua_pushcfunction(io_readfrom), lua_storeglobal("readfrom"));
//		 	(lua_pushcfunction(io_writeto), lua_storeglobal("writeto"));
//		 	(lua_pushcfunction(io_read), lua_storeglobal("read"));
//		 	(lua_pushcfunction(io_write), lua_storeglobal("write"));
//		 	(lua_pushcfunction(io_execute), lua_storeglobal("execute"));
//		 	(lua_pushcfunction(io_remove), lua_storeglobal("remove"));
		}
	}
}
