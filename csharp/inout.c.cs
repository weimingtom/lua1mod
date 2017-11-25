/*
** inout.c
** Provide function to realise the input/output function and debugger 
** facilities.
**
** Waldemar Celes Filho
** TeCGraf - PUC-Rio
** 11 May 93
*/
using System;

namespace KopiLua
{
	public partial class Lua
	{
		//C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
		//#include "opcode.h"
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define markarray(t) ((t)->mark)
	
	
		/* Exported variables */
		public static int lua_linenumber;
		public static int lua_debug;
		public static int lua_debugline;
		public static AnonymousClass[] funcstack = Arrays.InitializeWithDefaultInstances<AnonymousClass>(MAXFUNCSTACK);
		internal static int nfuncstack = 0;
		
	
			
		/* Internal variables */
		//C++ TO C# CONVERTER NOTE: Classes must be named in C#, so the following class has been named AnonymousClass:
		public class AnonymousClass
		{
			public int file;
			public int function;
		}
	
		internal static FILE fp;
		internal static string st;
	
		public delegate void usererrorDelegate(string s);
		internal static usererrorDelegate usererror;
	
		/*
		** Function to set user function to handle errors.
		*/
		public static void lua_errorfunction(usererrorDelegate fn)
		{
		 	usererror = fn;
		}
		
		/*
		** Function to get the next character from the input file
		*/
		internal static int fileinput()
		{
		 	int c = fgetc(fp);
		 	return (c == EOF ? 0 : c);
		}
	
		/*
		** Function to unget the next character from to input file
		*/
		internal static void fileunput(int c)
		{
		 	ungetc(c, fp);
		}
	
		/*
		** Function to get the next character from the input string
		*/
		internal static int stringinput()
		{
		 	st = st.Substring(1);
		 	return (int)st[0]; //(*(st - 1)); //FIXME:
		}
	
		/*
		** Function to unget the next character from to input string
		*/
		internal static void stringunput(int c)
		{
		 	//st--;//FIXME:
		 	st = st.Substring(1);
		}
	
		/*
		** Call user function to handle error messages, if registred. Or report error
		** using standard function (fprintf).
		*/
		public static void lua_error(string s)
		{
		 	if (usererror != null)
		 	{
			 	usererror(s);
		 	}
		 	else
		 	{
			 	Console.Error.Write("lua: {0}\n", s);
		 	}
		}
	
		public const int MAXFUNCSTACK = 32;
	
		/*
		** Function to open a file to be input unit. 
		** Return 0 on success or 1 on error.
		*/
	
		public static int lua_openfile(string fn)
		{
//		 	lua_linenumber = 1;
//		 	lua_setinput(fileinput);
//		 	lua_setunput(fileunput);
//		 	fp = fopen(fn, "r");
//		 	if (fp == null)
//		 	{
//			 	return 1;
//		 	}
//		 	if (lua_addfile(ref fn) != 0)
//		 	{
//			 	return 1;
//		 	}
		 	return 0;
		}
	
		/*
		** Function to close an opened file
		*/
		public static void lua_closefile()
		{
		 	if (fp != null)
		 	{
		  		fclose(fp);
		  		fp = null;
		 	}
		}
	
		/*
		** Function to open a string to be input unit
		*/
		public static int lua_openstring(CharPtr s)
		{
//		 	lua_linenumber = 1;
//		 	lua_setinput(stringinput);
//		 	lua_setunput(stringunput);
//		 	st = s;
//		 	{
//		  		string sn = new string(new char[64]);
//				//C++ TO C# CONVERTER TODO TASK: C# does not allow setting maximum string width in format specifiers:
//				//ORIGINAL LINE: sprintf(sn, "String: %10.10s...", s);
//		  		sn = string.Format("String: {0,10}...", s);
//		  		if (lua_addfile(ref sn) != 0)
//		  		{
//			  		return 1;
//		  		}
//		 	}
		 	return 0;
		}
		
		/*
		** Called to execute  SETFUNCTION opcode, this function pushs a function into
		** function stack. Return 0 on success or 1 on error.
		*/
		public static int lua_pushfunction(int file, int function)
		{
		 	if (nfuncstack >= MAXFUNCSTACK - 1)
		 	{
		  		lua_error("function stack overflow");
		  		return 1;
		 	}
		 	funcstack[nfuncstack].file = file;
		 	funcstack[nfuncstack].function = function;
		 	nfuncstack++;
		 	return 0;
		}
	
		/*
		** Called to execute  RESET opcode, this function pops a function from 
		** function stack.
		*/
		public static void lua_popfunction()
		{
		 	nfuncstack--;
		}
	
		/*
		** Report bug building a message and sending it to lua_error function.
		*/
		public static void lua_reportbug(string s)
		{
		 	string msg = new string(new char[1024]);
		 	msg = s;
		 	if (lua_debugline != 0)
		 	{
		  		int i;
		  		if (nfuncstack > 0)
		  		{
//		   			StringFunctions.StrChr(msg,0) = string.Format("\n\tin statement begining at line {0:D} in function \"{1}\" of file \"{2}\"", lua_debugline, s_name(funcstack[nfuncstack - 1].function), lua_file[funcstack[nfuncstack - 1].file]);
//		   			StringFunctions.StrChr(msg,0) = "\n\tactive stack\n";
		   			for (i = nfuncstack - 1; i >= 0; i--)
		   			{
//						StringFunctions.StrChr(msg,0) = string.Format("\t-> function \"{0}\" of file \"{1}\"\n", s_name(funcstack[i].function), lua_file[funcstack[i].file]);
		   			}
		  		}
		  		else
		  		{
//		   			StringFunctions.StrChr(msg,0) = string.Format("\n\tin statement begining at line {0:D} of file \"{1}\"", lua_debugline, lua_filename());
		  		}
		 	}
		 	lua_error(msg);
		}
	}
}
