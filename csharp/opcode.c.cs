/*
** opcode.c
** TecCGraf - PUC-Rio
** 26 Apr 93
*/
using System;

//#if __GNUC__
//#endif

namespace KopiLua
{
	using lua_Object = KopiLua.Lua.Object_;	
	
	public partial class Lua
	{
		public const int MAXSTACK = 256;
	
		//C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
		//#include "opcode.h"
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define markarray(t) ((t)->mark)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define lua_markstring(s) (*((s)-1))
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define lua_register(n,f) (lua_pushcfunction(f), lua_storeglobal(n))
	
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define tonumber(o) ((tag(o) != T_NUMBER) && (lua_tonumber(o) != 0))
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define tostring(o) ((tag(o) != T_STRING) && (lua_tostring(o) != 0))
	
		internal static Object_[] stack = new Object_[MAXSTACK];
		static Lua() 
		{
			for (int i = 0; i < stack.Length; ++i)
			{
				stack[i] = new Object_();
			}
			stack[0].tag = Type.T_MARK;
		}
		
//		internal static object top = stack + 1;
//		internal static object @base = stack + 1;
	
	
		/*
		** Concatenate two given string, creating a mark space at the beginning.
		** Return the new string pointer.
		*/
		internal static CharPtr lua_strconc(CharPtr l, CharPtr r)
		{
//			//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
//			//ORIGINAL LINE: sbyte *s = calloc(strlen(l)+strlen(r)+2, sizeof(sbyte));
//			//C++ TO C# CONVERTER TODO TASK: The memory management function 'calloc' has no equivalent in C#:
//		 	sbyte s = calloc(l.Length + r.Length + 2, sizeof(sbyte));
//		 	if (s == null)
//		 	{
//		  		lua_error("not enough memory");
//		  		return null;
//		 	}
//		 	s++= 0; // create mark space
//		 	return strcat(strcpy(s,l),r);
			return null;
		}
	
		/*
		** Duplicate a string,  creating a mark space at the beginning.
		** Return the new string pointer.
		*/
		public static CharPtr lua_strdup(CharPtr l)
		{
//			//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
//			//ORIGINAL LINE: sbyte *s = calloc(strlen(l)+2, sizeof(sbyte));
//			//C++ TO C# CONVERTER TODO TASK: The memory management function 'calloc' has no equivalent in C#:
//		 	sbyte s = calloc(l.Length + 2, sizeof(sbyte));
//		 	if (s == null)
//		 	{
//		  		lua_error("not enough memory");
//		  		return null;
//		 	}
//		 	s++= 0; // create mark space
//		 	return strcpy(s,l);
			return null;
		}
	
		/*
		** Convert, if possible, to a number tag.
		** Return 0 in success or not 0 on error.
		*/ 
		internal static int lua_tonumber(Object obj)
		{
//		 	string ptr;
//		 	if (tag(obj) != T_STRING)
//		 	{
//		  		lua_reportbug("unexpected type at conversion to number");
//		  		return 1;
//		 	}
//		 	nvalue(obj) = strtod(svalue(obj), ptr);
//		 	if (ptr != 0)
//		 	{
//		  		lua_reportbug("string to number convertion failed");
//		  		return 2;
//		 	}
//		 	tag(obj) = T_NUMBER;
		 	return 0;
		}
	
		//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
//		private static object lua_convtonumber_cvt;
	
		/*
		** Test if is possible to convert an object to a number one.
		** If possible, return the converted object, otherwise return nil object.
		*/ 
		internal static Object lua_convtonumber(Object obj)
		{
//			//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
//			// static object cvt;
//	
//		 	if (tag(obj) == T_NUMBER)
//		 	{
//		  		lua_convtonumber_cvt = obj;
//		  		return lua_convtonumber_cvt;
//		 	}
//	
//		 	tag(lua_convtonumber_cvt) = T_NIL;
//		 	if (tag(obj) == T_STRING)
//		 	{
//		  		string ptr;
//		  		nvalue(lua_convtonumber_cvt) = strtod(svalue(obj), ptr);
//		  		if (ptr == 0)
//		  		{
//		   			tag(lua_convtonumber_cvt) = T_NUMBER;
//		  		}
//		 	}
//		 	return lua_convtonumber_cvt;
			return null;
		}
	
		//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
		private static string lua_tostring_s = new string(new char[256]);
	
	
	
		/*
		** Convert, if possible, to a string tag
		** Return 0 in success or not 0 on error.
		*/ 
		internal static int lua_tostring(Object obj)
		{
//			//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
//			// static sbyte s[256];
//		 	if (tag(obj) != T_NUMBER)
//		 	{
//		  		lua_reportbug("unexpected type at conversion to string");
//		  		return 1;
//		 	}
//		 	if ((int) nvalue(obj) == nvalue(obj))
//		 	{
//		  		lua_tostring_s = string.Format("{0:D}", (int) nvalue(obj));
//		 	}
//		 	else
//		 	{
//		  		lua_tostring_s = string.Format("{0:g}", nvalue(obj));
//		 	}
//		 	svalue(obj) = lua_createstring(lua_strdup(ref lua_tostring_s));
//		 	if (svalue(obj) == null)
//		 	{
//		  		return 1;
//		 	}
//		 	tag(obj) = T_STRING;
		 	return 0;
		}
	
	
		/*
		** Execute the given opcode. Return 0 in success or 1 on error.
		*/
		//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'pc', so pointers on this parameter are left unchanged:
		public static int lua_execute(BytePtr pc)
		{
		 	while (true)
			{
		 		byte b = pc[0]; pc.inc();
		  		switch ((OpCode) b)
		 	 	{
		   		case OpCode.NOP:
			  		break;
	
		   		case OpCode.PUSHNIL:
//			   		tag(top++) = T_NIL;
			   		break;
	
		   		case OpCode.PUSH0:
//			   		tag(top) = T_NUMBER;
//			   		nvalue(top++) = 0;
			   		break;
		   
			   	case OpCode.PUSH1:
//			   		tag(top) = T_NUMBER;
//			   		nvalue(top++) = 1;
			   		break;
		   
			   	case OpCode.PUSH2:
//			   		tag(top) = T_NUMBER;
//			   		nvalue(top++) = 2;
			   		break;
	
		   		case OpCode.PUSHBYTE:
//			   		tag(top) = T_NUMBER;
//			   		nvalue(top++) = *pc++;
			   		break;
	
		   		case OpCode.PUSHWORD:
//					tag(top) = T_NUMBER;
//					nvalue(top++) = (Word)(pc);
//					pc += sizeof(Word);
		   			break;
	
		   		case OpCode.PUSHFLOAT:
//					tag(top) = T_NUMBER;
//					nvalue(top++) = (float)(pc);
//					pc += sizeof(float);
		   			break;
		   
			   	case OpCode.PUSHSTRING:
//			   		{
//						int w = (Word)(pc);
//						pc += sizeof(Word);
//						tag(top) = T_STRING;
//						svalue(top++) = lua_constant[w];
//			   		}
			   		break;
		
			   	case OpCode.PUSHLOCAL0:
//				   	top++= *(@base + 0);
				   	break;
			   
			   	case OpCode.PUSHLOCAL1:
//				   	top++= *(@base + 1);
				   	break;
			   
				case OpCode.PUSHLOCAL2:
//				   	top++= *(@base + 2);
				   	break;
			   
				case OpCode.PUSHLOCAL3:
//				   	top++= *(@base + 3);
				   	break;
			   
				case OpCode.PUSHLOCAL4:
//				   	top++= *(@base + 4);
				  	break;
			   
				case OpCode.PUSHLOCAL5:
//				   	top++= *(@base + 5);
				   	break;
			   
				case OpCode.PUSHLOCAL6:
//				   	top++= *(@base + 6);
				   	break;
			   
				case OpCode.PUSHLOCAL7:
//				   	top++= *(@base + 7);
				   	break;
			   
				case OpCode.PUSHLOCAL8:
//				   	top++= *(@base + 8);
				   	break;
			   
				case OpCode.PUSHLOCAL9:
//				   	top++= *(@base + 9);
				   	break;
		
			   	case OpCode.PUSHLOCAL:
//				   	top++= *(@base + (*pc++));
				   	break;
		
			   case OpCode.PUSHGLOBAL:
//					top++= s_object((Word)(pc));
//					pc += sizeof(Word);
			   		break;
		
			   case OpCode.PUSHINDEXED:
//					--top;
//					if (tag(top - 1) != T_ARRAY)
//					{
//				 		lua_reportbug("indexed expression not a table");
//				 		return 1;
//					}
//					{
//				 		object h = lua_hashdefine(avalue(top - 1), top);
//				 		if (h == null)
//				 		{
//					 		return 1;
//				 		}
//				 		*(top - 1) = h;
//					}
			   		break;
		
			   	case OpCode.PUSHMARK:
//				   	tag(top++) = T_MARK;
				   	break;
		
			   	case OpCode.PUSHOBJECT:
//				   	top = *(top - 3);
//				  	top++;
				   	break;
		
			   	case OpCode.STORELOCAL0:
//				   	*(@base + 0) = *(--top);
				   	break;
			   
				case OpCode.STORELOCAL1:
//				   	*(@base + 1) = *(--top);
				   	break;
			   
				case OpCode.STORELOCAL2:
//				   	*(@base + 2) = *(--top);
				  	break;
			   
				case OpCode.STORELOCAL3:
//				   	*(@base + 3) = *(--top);
				   	break;
			   
				case OpCode.STORELOCAL4:
//				   	*(@base + 4) = *(--top);
				  	break;
			   
				case OpCode.STORELOCAL5:
//				   	*(@base + 5) = *(--top);
				   	break;
			   
				case OpCode.STORELOCAL6:
//				   	*(@base + 6) = *(--top);
				   	break;
			   
				case OpCode.STORELOCAL7:
//				   	*(@base + 7) = *(--top);
				  	break;
			   
				case OpCode.STORELOCAL8:
//				   	*(@base + 8) = *(--top);
				   	break;
			   
				case OpCode.STORELOCAL9:
//				   	*(@base + 9) = *(--top);
				   	break;
		
			   	case OpCode.STORELOCAL:
//				   	*(@base + (*pc++)) = *(--top);
				   	break;
		
			   	case OpCode.STOREGLOBAL:
//					s_object((Word)(pc)) = *(--top);
//					pc += sizeof(Word);
			   		break;
		
			   	case OpCode.STOREINDEXED0:
//					if (tag(top - 3) != T_ARRAY)
//					{
//				 		lua_reportbug("indexed expression not a table");
//				 		return 1;
//					}
//					{
//				 		object h = lua_hashdefine(avalue(top - 3), top - 2);
//				 		if (h == null)
//				 		{
//					 		return 1;
//				 		}
//				 		h = *(top - 1);
//					}
//					top -= 3;
			   		break;
		
			   	case OpCode.STOREINDEXED:
//			   		{
//						int n = pc++;
//						if (tag(top - 3 - n) != T_ARRAY)
//						{
//				 			lua_reportbug("indexed expression not a table");
//				 			return 1;
//						}
//						{
//				 			object h = lua_hashdefine(avalue(top - 3 - n), top - 2 - n);
//				 			if (h == null)
//				 			{
//					 			return 1;
//				 			}
//				 			h = *(top - 1);
//						}
//						--top;
//			   		}
			   		break;
		
			   	case OpCode.STOREFIELD:
//					if (tag(top - 3) != T_ARRAY)
//					{
//				 		lua_error("internal error - table expected");
//				 		return 1;
//					}
//					(lua_hashdefine(avalue(top - 3), top - 2)) = *(top - 1);
//					top -= 2;
			   		break;
		
			   	case OpCode.ADJUST:
//			   		{
//						object newtop = @base + *(pc++);
//						if (top != newtop)
//						{
//				 			while (top < newtop)
//				 			{
//					 			tag(top++) = T_NIL;
//				 			}
//							//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to variables (in C#, the variable no longer points to the original when the original variable is re-assigned):
//							//ORIGINAL LINE: top = newtop;
//				 			top = newtop;
//						}
//			   		}
			   		break;
		
			   	case OpCode.CREATEARRAY:
//					if (tag(top - 1) == T_NIL)
//					{
//				 		nvalue(top - 1) = 101;
//					}
//					else
//					{
//				 		if (((tag(top - 1) != T_NUMBER) && (lua_tonumber(top - 1) != 0)))
//				 		{
//					 		return 1;
//				 		}
//				 		if (nvalue(top - 1) <= 0)
//				 		{
//					 		nvalue(top - 1) = 101;
//				 		}
//					}
//					avalue(top - 1) = lua_createarray(lua_hashcreate(nvalue(top - 1)));
//					if (avalue(top - 1) == null)
//					{
//				 		return 1;
//					}
//					tag(top - 1) = T_ARRAY;
			   		break;
		
			   	case OpCode.EQOP:
//			   		{
//						object l = top - 2;
//						object r = top - 1;
//						--top;
//						if (tag(l) != tag(r))
//						{
//				 			tag(top - 1) = T_NIL;
//						}
//						else
//						{
//				 			switch (tag(l))
//				 			{
//				  			case T_NIL:
//					  			tag(top - 1) = T_NUMBER;
//					  			break;
//				  
//					  		case T_NUMBER:
//					  			tag(top - 1) = (nvalue(l) == nvalue(r)) ? T_NUMBER : T_NIL;
//					  			break;
//				  
//					  		case T_ARRAY:
//					  			tag(top - 1) = (avalue(l) == avalue(r)) ? T_NUMBER : T_NIL;
//					  			break;
//				  
//					  		case T_FUNCTION:
//					  			tag(top - 1) = (bvalue(l) == bvalue(r)) ? T_NUMBER : T_NIL;
//					  			break;
//				  
//					  		case T_CFUNCTION:
//					  			tag(top - 1) = (fvalue(l) == fvalue(r)) ? T_NUMBER : T_NIL;
//					  			break;
//				  
//					  		case T_USERDATA:
//					  			tag(top - 1) = (uvalue(l) == uvalue(r)) ? T_NUMBER : T_NIL;
//					  			break;
//				  
//					  		case T_STRING:
//					  			tag(top - 1) = (string.Compare(svalue(l), svalue(r)) == 0) ? T_NUMBER : T_NIL;
//					  			break;
//				  
//					  		case T_MARK:
//					  			return 1;
//				 			}
//						}
//						nvalue(top - 1) = 1;
//			   		}
			   		break;
		
			   	case OpCode.LTOP:
//			   		{
//						object l = top - 2;
//						object r = top - 1;
//						--top;
//						if (tag(l) == T_NUMBER && tag(r) == T_NUMBER)
//						{
//				 			tag(top - 1) = (nvalue(l) < nvalue(r)) ? T_NUMBER : T_NIL;
//						}
//						else
//						{
//				 			if (((tag(l) != T_STRING) && (lua_tostring(l) != 0)) || ((tag(r) != T_STRING) && (lua_tostring(r) != 0)))
//				 			{
//				  				return 1;
//				 			}
//				 			tag(top - 1) = (string.Compare(svalue(l), svalue(r)) < 0) ? T_NUMBER : T_NIL;
//						}
//						nvalue(top - 1) = 1;
//			   		}
			   		break;
		
			   	case OpCode.LEOP:
//			   		{
//						object l = top - 2;
//						object r = top - 1;
//						--top;
//						if (tag(l) == T_NUMBER && tag(r) == T_NUMBER)
//						{
//				 			tag(top - 1) = (nvalue(l) <= nvalue(r)) ? T_NUMBER : T_NIL;
//						}
//						else
//						{
//					 		if (((tag(l) != T_STRING) && (lua_tostring(l) != 0)) || ((tag(r) != T_STRING) && (lua_tostring(r) != 0)))
//					 		{
//					  			return 1;
//					 		}
//					 		tag(top - 1) = (string.Compare(svalue(l), svalue(r)) <= 0) ? T_NUMBER : T_NIL;
//						}
//						nvalue(top - 1) = 1;
//				   	}
			   		break;
		
			   case OpCode.ADDOP:
//			   		{
//						object l = top - 2;
//						object r = top - 1;
//						if (((tag(r) != T_NUMBER) && (lua_tonumber(r) != 0)) || ((tag(l) != T_NUMBER) && (lua_tonumber(l) != 0)))
//						{
//				 			return 1;
//						}
//						nvalue(l) += nvalue(r);
//						--top;
//			   		}
			   		break;
		
			  	case OpCode.SUBOP:
//			   		{
//						object l = top - 2;
//						object r = top - 1;
//						if (((tag(r) != T_NUMBER) && (lua_tonumber(r) != 0)) || ((tag(l) != T_NUMBER) && (lua_tonumber(l) != 0)))
//						{
//				 			return 1;
//						}
//						nvalue(l) -= nvalue(r);
//						--top;
//			   		}
			   		break;
		
			   	case OpCode.MULTOP:
//			   		{
//						object l = top - 2;
//						object r = top - 1;
//						if (((tag(r) != T_NUMBER) && (lua_tonumber(r) != 0)) || ((tag(l) != T_NUMBER) && (lua_tonumber(l) != 0)))
//						{
//				 			return 1;
//						}
//						nvalue(l) *= nvalue(r);
//						--top;
//			   		}
			   		break;
		
			   	case OpCode.DIVOP:
//			   		{
//						object l = top - 2;
//						object r = top - 1;
//						if (((tag(r) != T_NUMBER) && (lua_tonumber(r) != 0)) || ((tag(l) != T_NUMBER) && (lua_tonumber(l) != 0)))
//						{
//				 			return 1;
//						}
//						nvalue(l) /= nvalue(r);
//						--top;
//			   		}
			   		break;
		
			   	case OpCode.CONCOP:
//			   		{
//						object l = top - 2;
//						object r = top - 1;
//						if (((tag(r) != T_STRING) && (lua_tostring(r) != 0)) || ((tag(l) != T_STRING) && (lua_tostring(l) != 0)))
//						{
//				 			return 1;
//						}
//						svalue(l) = lua_createstring(lua_strconc(ref svalue(l), ref svalue(r)));
//						if (svalue(l) == null)
//						{
//				 			return 1;
//						}
//						--top;
//			   		}
			   		break;
		
			   	case OpCode.MINUSOP:
//					if (((tag(top - 1) != T_NUMBER) && (lua_tonumber(top - 1) != 0)))
//					{
//				 		return 1;
//					}
//					nvalue(top - 1) = - nvalue(top - 1);
			   		break;
		
			   	case OpCode.NOTOP:
//					tag(top - 1) = tag(top - 1) == T_NIL ? T_NUMBER : T_NIL;
			   		break;
		
			   	case OpCode.ONTJMP:
//			   		{
//						int n = (Word)(pc);
//						pc += sizeof(Word);
//						if (tag(top - 1) != T_NIL)
//						{
//							pc += n;
//						}
//			   		}
			   		break;
		
			   	case OpCode.ONFJMP:
//			   		{
//						int n = (Word)(pc);
//						pc += sizeof(Word);
//						if (tag(top - 1) == T_NIL)
//						{
//							pc += n;
//						}
//			   		}
			   		break;
		
			   	case OpCode.JMP:
//				   	pc += (Word)(pc) + sizeof(Word);
				   	break;
		
			   	case OpCode.UPJMP:
//				   	pc -= (Word)(pc) - sizeof(Word);
				   	break;
		
			   	case OpCode.IFFJMP:
//			   		{
//						int n = (Word)(pc);
//						pc += sizeof(Word);
//						top--;
//						if (tag(top) == T_NIL)
//						{
//							pc += n;
//						}
//			   		}
			   		break;
		
			   	case OpCode.IFFUPJMP:
//			   		{
//						int n = (Word)(pc);
//						pc += sizeof(Word);
//						top--;
//						if (tag(top) == T_NIL)
//						{
//							pc -= n;
//						}
//			   		}
			   		break;
		
			   	case OpCode.POP:
//				   	--top;
				   	break;
		
			   	case OpCode.CALLFUNC:
//			   		{
//						//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
//						//ORIGINAL LINE: Byte *newpc;
//						Byte newpc;
//						//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
//						object * b = top - 1;
//						while (tag(b) != T_MARK)
//						{
//							b--;
//						}
//						if (tag(b - 1) == T_FUNCTION)
//						{
//				 			lua_debugline = 0; // always reset debug flag
//				 			newpc = bvalue(b - 1);
//				 			bvalue(b - 1) = pc; // store return code
//				 			nvalue(b) = (@base - stack); // store base value
//				 			@base = b + 1;
//				 			pc = newpc;
//				 			if (DefineConstants.MAXSTACK - (@base - stack) < STACKGAP)
//				 			{
//				  				lua_error("stack overflow");
//				  				return 1;
//				 			}
//						}
//						else if (tag(b - 1) == T_CFUNCTION)
//						{
//				 			int nparam;
//				 			lua_debugline = 0; // always reset debug flag
//				 			nvalue(b) = (@base - stack); // store base value
//				 			@base = b + 1;
//				 			nparam = top - @base; // number of parameters
//				 			(fvalue(b - 1))(); // call C function
//		
//				 			/* shift returned values */
//							{
//				  				int i;
//				  				int nretval = top - @base - nparam;
//				  				top = @base - 2;
//				  				@base = stack + (int) nvalue(@base-1);
//				  				for (i = 0; i < nretval; i++)
//				  				{
//				   					top = *(top + nparam + 2);
//				   					++top;
//				  				}
//				 			}
//						}
//						else
//						{
//				 			lua_reportbug("call expression not a function");
//				 			return 1;
//						}
//			   		}
			   		break;
		
			   	case OpCode.RETCODE:
//			   		{
//						int i;
//						int shift = pc++;
//						int nretval = top - @base - shift;
//						top = @base - 2;
//						pc = bvalue(@base-2);
//						@base = stack + (int) nvalue(@base-1);
//						for (i = 0; i < nretval; i++)
//						{
//			 				top = *(top + shift + 2);
//			 				++top;
//						}
//		   			}
		   			break;
		
			  	case OpCode.HALT:
			   		return 0; // success
		
			   	case OpCode.SETFUNCTION:
//		   			{
//						int file;
//						int func;
//						file = (Word)(pc);
//						pc += sizeof(Word);
//						func = (Word)(pc);
//						pc += sizeof(Word);
//						if (lua_pushfunction(file, func) != 0)
//						{
//			 				return 1;
//						}
//		   			}
		   			break;
		
		   		case OpCode.SETLINE:
//					lua_debugline = (Word)(pc);
//					pc += sizeof(Word);
		   			break;
	
		   		case OpCode.RESET:
//					lua_popfunction();
		   			break;
	
		   		default:
//					lua_error("internal error - opcode didn't match");
		   			return 1;
			  	}
		 	}
		}
	
	
		/*
		** Mark all strings and arrays used by any object stored at stack.
		*/
		public static void lua_markstack()
		{
//			//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
//		 	object * o;
//		 	for (o = top - 1; o >= stack; o--)
//		 	{
//		  		lua_markobject(o);
//		 	}
		}
	
		/*
		** Open file, generate opcode and execute global statement. Return 0 on
		** success or 1 on error.
		*/
		public static int lua_dofile(string filename)
		{
		 	if (lua_openfile(filename) != 0)
		 	{
			 	return 1;
		 	}
		 	if (lua_parse() != 0)
		 	{
			 	lua_closefile();
			 	return 1;
		 	}
		 	lua_closefile();
		 	return 0;
		}
	
		/*
		** Generate opcode stored on string and execute global statement. Return 0 on
		** success or 1 on error.
		*/
		public static int lua_dostring(CharPtr @string)
		{
		 	if (lua_openstring(@string) != 0)
		 	{
			 	return 1;
		 	}
		 	if (lua_parse() != 0)
		 	{
			 	return 1;
		 	}
		 	return 0;
		}
	
		//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
//		private static Byte[] lua_call_startcode = {CALLFUNC, HALT};
	
		/*
		** Execute the given function. Return 0 on success or 1 on error.
		*/
		public static int lua_call(CharPtr functionname, int nparam)
		{
//			//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
//			// static Byte startcode[] = {CALLFUNC, HALT};
//		 	int i;
//		 	object func = s_object(lua_findsymbol(functionname));
//		 	if (tag(func) != T_FUNCTION)
//		 	{
//			 	return 1;
//		 	}
//		 	for (i = 1; i <= nparam; i++)
//		 	{
//		  		*(top - i + 2) = *(top - i);
//		 	}
//		 	top += 2;
//		 	tag(top - nparam - 1) = T_MARK;
//		 	*(top - nparam - 2) = func;
//		 	return (lua_execute(lua_call_startcode));
			return 0;
		}
	
		/*
		** Get a parameter, returning the object handle or NULL on error.
		** 'number' must be 1 to get the first parameter.
		*/
		public static lua_Object lua_getparam(int number)
		{
//		 	if (number <= 0 || number > top - @base)
//		 	{
//			 	return null;
//		 	}
//		 	return (@base + number - 1);
			return null;
		}
	
		/*
		** Given an object handle, return its number value. On error, return 0.0.
		*/
		public static double lua_getnumber(Object_ @object)
		{
//		 	if (((tag(@object) != T_NUMBER) && (lua_tonumber(@object) != 0)))
//		 	{
//			 	return 0.0;
//		 	}
//		 	else
//		 	{
//			 	return (nvalue(@object));
//		 	}
			return 0;
		}
	
		/*
		** Given an object handle, return its string pointer. On error, return NULL.
		*/
		public static CharPtr lua_getstring(Object_ @object)
		{
//		 	if (((tag(@object) != T_STRING) && (lua_tostring(@object) != 0)))
//		 	{
//			 	return null;
//		 	}
//		 	else
//		 	{
//			 	return (svalue(@object));
//		 	}
			return null;
		}
	
		/*
		** Given an object handle, return a copy of its string. On error, return NULL.
		*/
		public static string lua_copystring(Object_ @object)
		{
//		 	if (((tag(@object) != T_STRING) && (lua_tostring(@object) != 0)))
//		 	{
//			 	return null;
//		 	}
//		 	else
//		 	{
//			 	return (svalue(@object));
//		 	}
			return null;
		}
	
		/*
		** Given an object handle, return its cfuntion pointer. On error, return NULL.
		*/
		public static lua_CFunction lua_getcfunction(Object @object)
		{
//		 	if (tag(@object) != T_CFUNCTION)
//		 	{
//			 	return null;
//		 	}
//		 	else
//		 	{
//			 	return (fvalue(@object));
//		 	}
			return null;
		}
	
		/*
		** Given an object handle, return its user data. On error, return NULL.
		*/
		public static object lua_getuserdata(Object_ @object)
		{
//		 	if (tag(@object) != T_USERDATA)
//		 	{
//			 	return null;
//		 	}
//		 	else
//		 	{
//			 	return (uvalue(@object));
//		 	}
			return null;
		}
	
		/*
		** Given an object handle and a field name, return its field object.
		** On error, return NULL.
		*/
		public static Object lua_getfield(Object_ @object, string field)
		{
//		 	if (tag(@object) != T_ARRAY)
//		 	{
//		  		return null;
//		 	}
//		 	else
//		 	{	
//		  		object @ref;
//		  		tag(@ref) = T_STRING;
//		  		svalue(@ref) = lua_createstring(lua_strdup(ref field));
//		  		return (lua_hashdefine(avalue(@object), @ref));
//		 	}
			return null;
		}
	
		/*
		** Given an object handle and an index, return its indexed object.
		** On error, return NULL.
		*/
		public static Object lua_getindexed(object @object, float index)
		{
//		 	if (tag(@object) != T_ARRAY)
//		 	{
//		  		return null;
//		 	}
//		 	else
//		 	{
//		  		object @ref;
//		  		tag(@ref) = T_NUMBER;
//		  		nvalue(@ref) = index;
//		 	 	return (lua_hashdefine(avalue(@object), @ref));
//		 	}
			return null;
		}
	
		/*
		** Get a global object. Return the object handle or NULL on error.
		*/
		public static Object lua_getglobal(string name)
		{
//		 	int n = lua_findsymbol(name);
//			if (n < 0)
//		 	{
//			 	return null;
//		 	}
//		 	return s_object(n);
			return null;
		}
	
		/*
		** Pop and return an object
		*/
		public static Object lua_pop()
		{
//		 	if (top <= @base)
//		 	{
//			 	return null;
//		 	}
//		 	top--;
//		 	return top;
			return null;
		}
	
		/*
		** Push a nil object
		*/
		public static int lua_pushnil()
		{
//		 	if ((top - stack) >= MAXSTACK - 1)
//		 	{
//		  		lua_error("stack overflow");
//		  		return 1;
//		 	}
//		 	tag(top) = T_NIL;
		 	return 0;
		}
	
		/*
		** Push an object (tag=number) to stack. Return 0 on success or 1 on error.
		*/
		public static int lua_pushnumber(double n)
		{
//		 	if ((top - stack) >= MAXSTACK - 1)
//		 	{
//		  		lua_error("stack overflow");
//		  		return 1;
//		 	}
//		 	tag(top) = T_NUMBER;
//		 	nvalue(top++) = n;
		 	return 0;
		}
	
		/*
		** Push an object (tag=string) to stack. Return 0 on success or 1 on error.
		*/
		public static int lua_pushstring(CharPtr s)
		{
//		 	if ((top - stack) >= MAXSTACK - 1)
//		 	{
//		  		lua_error("stack overflow");
//		  		return 1;
//		 	}
//		 	tag(top) = T_STRING;
//		 	svalue(top++) = lua_createstring(lua_strdup(ref s));
		 	return 0;
		}
	
		/*
		** Push an object (tag=cfunction) to stack. Return 0 on success or 1 on error.
		*/
		public static int lua_pushcfunction(lua_CFunction fn)
		{
//		 	if ((top - stack) >= MAXSTACK - 1)
//		 	{
//		  		lua_error("stack overflow");
//		  		return 1;
//		 	}
//		 	tag(top) = T_CFUNCTION;
//		 	fvalue(top++) = fn;
		 	return 0;
		}
	
		/*
		** Push an object (tag=userdata) to stack. Return 0 on success or 1 on error.
		*/
		public static int lua_pushuserdata(object u)
		{
//		 	if ((top - stack) >= MAXSTACK - 1)
//		 	{
//		  		lua_error("stack overflow");
//		  		return 1;
//		 	}
//		 	tag(top) = T_USERDATA;
//		 	uvalue(top++) = u;
		 	return 0;
		}
	
		/*
		** Push an object to stack.
		*/
		public static int lua_pushobject(object o)
		{
//		 	if ((top - stack) >= MAXSTACK - 1)
//		 	{
//		  		lua_error("stack overflow");
//		  		return 1;
//			}
//		 	top++= o;
		 	return 0;
		}
	
		/*
		** Store top of the stack at a global variable array field. 
		** Return 1 on error, 0 on success.
		*/
		public static int lua_storeglobal(string name)
		{
//		 	int n = lua_findsymbol(name);
//		 	if (n < 0)
//		 	{
//			 	return 1;
//		 	}
//		 	if (tag(top - 1) == T_MARK)
//		 	{
//			 	return 1;
//		 	}
//		 	s_object(n) = *(--top);
		 	return 0;
		}
	
		/*
		** Store top of the stack at an array field. Return 1 on error, 0 on success.
		*/
		public static int lua_storefield(lua_Object @object, string field)
		{
//		 	if (tag(@object) != T_ARRAY)
//		 	{
//		  		return 1;
//		 	}
//		 	else
//		 	{
//		  		object @ref;
//		  		object h;
//		  		tag(@ref) = T_STRING;
//		  		svalue(@ref) = lua_createstring(lua_strdup(ref field));
//		  		h = lua_hashdefine(avalue(@object), @ref);
//		  		if (h == null)
//		  		{
//			  		return 1;
//		  		}
//		  		if (tag(top - 1) == T_MARK)
//		  		{
//			  		return 1;
//		  		}
//		  		h = *(--top);
//		 	}
		 	return 0;
		}
	
	
		/*
		** Store top of the stack at an array index. Return 1 on error, 0 on success.
		*/
		public static int lua_storeindexed(lua_Object @object, float index)
		{
//		 	if (tag(@object) != T_ARRAY)
//		 	{
//		  		return 1;
//		 	}
//		 	else
//		 	{
//		  		object @ref;
//		  		object h;
//		  		tag(@ref) = T_NUMBER;
//		  		nvalue(@ref) = index;
//		  		h = lua_hashdefine(avalue(@object), @ref);
//		  		if (h == null)
//		  		{
//			  		return 1;
//		  		}
//		  		if (tag(top - 1) == T_MARK)
//		  		{
//			  		return 1;
//		  		}
//		  		h = *(--top);
//		 	}
		 	return 0;
		}
	
	
		/*
		** Given an object handle, return if it is nil.
		*/
		public static int lua_isnil(Object @object)
		{
//		 	return (@object != null && tag(@object) == T_NIL);
			return 0;
		}
	
		/*
		** Given an object handle, return if it is a number one.
		*/
		public static int lua_isnumber(Object @object)
		{
//		 	return (@object != null && tag(@object) == T_NUMBER);
			return 0;
		}
	
		/*
		** Given an object handle, return if it is a string one.
		*/
		public static int lua_isstring(Object @object)
		{
//		 	return (@object != null && tag(@object) == T_STRING);
			return 0;
		}
	
		/*
		** Given an object handle, return if it is an array one.
		*/
		public static int lua_istable(Object @object)
		{
//		 	return (@object != null && tag(@object) == T_ARRAY);
			return 0;
		}
	
		/*
		** Given an object handle, return if it is a cfunction one.
		*/
		public static int lua_iscfunction(Object @object)
		{
//		 	return (@object != null && tag(@object) == T_CFUNCTION);
			return 0;
		}
	
		/*
		** Given an object handle, return if it is an user data one.
		*/
		public static int lua_isuserdata(Object @object)
		{
//		 	return (@object != null && tag(@object) == T_USERDATA);
			return 0;
		}
	
		/*
		** Internal function: return an object type. 
		*/
		public static void lua_type()
		{
//		 	object o = lua_getparam(1);
//		 	lua_pushstring(lua_constant[tag(o)]);
		}
	
		/*
		** Internal function: convert an object to a number
		*/
		public static void lua_obj2number()
		{
//		 	object o = lua_getparam(1);
//		 	lua_pushobject(lua_convtonumber(o));
		}
	
		/*
		** Internal function: print object values
		*/
		public static void lua_print()
		{
//		 	int i = 1;
//		 	object obj;
//		 	while ((obj = lua_getparam(i++)) != null)
//		 	{
//		  		if (lua_isnumber(obj) != 0)
//		  		{
//			  		Console.Write("{0:g}\n",lua_getnumber(obj));
//		  		}
//		  		else if (lua_isstring(obj))
//		  		{
//			  		Console.Write("{0}\n",lua_getstring(obj));
//		  		}
//		  		else if (lua_iscfunction(obj))
//		  		{
//					//C++ TO C# CONVERTER TODO TASK: The following line has a C format specifier which cannot be directly translated to C#:
//					//ORIGINAL LINE: printf("cfunction: %p\n",lua_getcfunction(obj));
//			  		Console.Write("cfunction: %p\n",lua_getcfunction(obj));
//		  		}
//		  		else if (lua_isuserdata(obj))
//		  		{
//					//C++ TO C# CONVERTER TODO TASK: The following line has a C format specifier which cannot be directly translated to C#:
//					//ORIGINAL LINE: printf("userdata: %p\n",lua_getuserdata(obj));
//			  		Console.Write("userdata: %p\n",lua_getuserdata(obj));
//		  		}
//		  		else if (lua_istable(obj))
//		  		{
//					//C++ TO C# CONVERTER TODO TASK: The following line has a C format specifier which cannot be directly translated to C#:
//					//ORIGINAL LINE: printf("table: %p\n",obj);
//			  		Console.Write("table: %p\n",obj);
//		  		}
//		  		else if (lua_isnil(obj))
//		  		{
//			  		Console.Write("nil\n");
//		  		}
//		  		else
//		  		{
//			  		Console.Write("invalid value to print\n");
//		  		}
//		 	}
		}
	}
}
