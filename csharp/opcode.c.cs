﻿/*
** opcode.c
** TecCGraf - PUC-Rio
** 26 Apr 93
*/
using System;

namespace KopiLua
{
	using lua_Object = KopiLua.Lua.Object_;	
	using Word = System.UInt16;
	
	public partial class Lua
	{
		//#define tonumber(o) ((tag(o) != T_NUMBER) && (lua_tonumber(o) != 0))
		private static bool tonumber(Object_ o) { return (tag(o) != Type.T_NUMBER) && (lua_tonumber(o) != 0); }
		//#define tostring(o) ((tag(o) != T_STRING) && (lua_tostring(o) != 0))
		private static bool tostring(Object_ o) { return (tag(o) != Type.T_STRING) && (lua_tostring(o) != 0); }
		
		//#ifndef MAXSTACK
		//#define MAXSTACK 256
		//#endif		
		private const int MAXSTACK = 256;
		private static Object_[] _initstack()
		{
			Object_[] stack = new Object_[MAXSTACK];
			for (int i = 0; i < stack.Length; ++i)
			{
				stack[i] = new Object_();
			}
			stack[0].tag = Type.T_MARK;
			return stack;
		}
		private static Object_[] stack = _initstack();
		
		private class ObjectRef 
		{
			private Object_[] obj;
			private int index;
			public ObjectRef(Object_[] _obj, int _index)
			{
				this.obj = _obj;
				this.index = _index;
			}
			
			public Object_ inc() 
			{
				index++;
				return obj[index - 1];
			}

			public Object_ dec() 
			{
				index--;
				return obj[index + 1];
			}
			
			public Object_ get()
			{
				return obj[index];
			}

			public Object_ get(int offset)
			{
				return obj[index + offset];
			}

			public ObjectRef getRef(int offset)
			{
				return new ObjectRef(obj, index + offset);
			}
			
			public void set(int offset, Object_ o)
			{
				obj[index + offset].set(o);
			}
			
			public void add(int offset) 
			{
				index += offset;
			}
			
			public bool notEqualsTo(Object_ o)
			{
				return obj[index] != o;
			}
			
			public bool isLessThan(Object_ o)
			{
				int idx = -1;
				bool found = false;
				for (int i = 0; i < obj.Length; ++i)
				{
					if (o == obj[i])
					{
						idx = i;
						found = true;
						break;
					}
				}
				if (found == false)
				{
					throw new Exception("objs not same");
				}
				return this.index < idx;				
			}
			
			public void setRef(Object_ o)
			{
				bool found = false;
				for (int i = 0; i < obj.Length; ++i)
				{
					if (o == obj[i])
					{
						this.index = i;
						found = true;
						break;
					}
				}
				if (found == false)
				{
					throw new Exception("objs not same");
				}
			}
			
			public int minus(ObjectRef oref)
			{
				if (this.obj == oref.obj)
				{
					return this.index - oref.index;
				}
				throw new Exception("objs not same");
			}

			public int minus(Object_[] oarr)
			{
				if (this.obj == oarr)
				{
					return this.index - 0;
				}
				throw new Exception("objs not same");
			}
		}
		private static ObjectRef top = new ObjectRef(stack, 1), @base = new ObjectRef(stack, 1);
		
		/*
		** Concatenate two given string, creating a mark space at the beginning.
		** Return the new string pointer.
		*/
		internal static CharPtr lua_strconc(CharPtr l, CharPtr r)
		{
			CharPtr s = (CharPtr)calloc (strlen(l)+strlen(r)+2, sizeOf("char"));
		 	if (s == null)
		 	{
		  		lua_error ("not enough memory");
		  		return null;
		 	}
		 	s[0] = '\0'; s.inc(); // create mark space
		 	return strcat(strcpy(s,l),r);
		}
	
		/*
		** Duplicate a string,  creating a mark space at the beginning.
		** Return the new string pointer.
		*/
		public static CharPtr lua_strdup(CharPtr l)
		{
			CharPtr s = (CharPtr)calloc (strlen(l)+2, sizeOf("char"));
		 	if (s == null)
		 	{
		  		lua_error ("not enough memory");
		  		return null;
		 	}
		 	s[0] = '\0'; s.inc(); // create mark space
		 	return strcpy(s,l);
		}
	
		/*
		** Convert, if possible, to a number tag.
		** Return 0 in success or not 0 on error.
		*/ 
		internal static int lua_tonumber(Object_ obj)
		{
		 	CharPtr ptr = null;
		 	if (tag(obj) != Type.T_STRING)
		 	{
		  		lua_reportbug ("unexpected type at conversion to number");
		  		return 1;
		 	}
		 	nvalue(obj, (float)strtod(svalue(obj), ref ptr));
		 	if (ptr[0] != '\0')
		 	{
		  		lua_reportbug ("string to number convertion failed");
		  		return 2;
		 	}
		 	tag(obj, Type.T_NUMBER);
		 	return 0;
		}
	
		private static Object_ lua_convtonumber_cvt = new Object_();
		/*
		** Test if is possible to convert an object to a number one.
		** If possible, return the converted object, otherwise return nil object.
		*/ 
		private static Object_ lua_convtonumber(Object_ obj)
		{
			// static object cvt;
	
		 	if (tag(obj) == Type.T_NUMBER)
		 	{
		  		lua_convtonumber_cvt = obj;
		  		return lua_convtonumber_cvt;
		 	}
	
		 	tag(lua_convtonumber_cvt, Type.T_NIL);
		 	if (tag(obj) == Type.T_STRING)
		 	{
		  		CharPtr ptr = null;
		  		nvalue(lua_convtonumber_cvt, (float)strtod(svalue(obj), ref ptr));
		  		if (ptr[0] == '\0')
		  		{
		  			tag(lua_convtonumber_cvt, Type.T_NUMBER);
		  		}
		 	}
		 	return lua_convtonumber_cvt;
		}
	
		private static CharPtr lua_tostring_s = new CharPtr(new char[256]);
		/*
		** Convert, if possible, to a string tag
		** Return 0 in success or not 0 on error.
		*/ 
		private static int lua_tostring(Object_ obj)
		{
			// static sbyte s[256];
		 	if (tag(obj) != Type.T_NUMBER)
		 	{
		  		lua_reportbug ("unexpected type at conversion to string");
		  		return 1;
		 	}
		 	if ((int) nvalue(obj) == nvalue(obj))
		  		sprintf (lua_tostring_s, "%d", (int) nvalue(obj));
		 	else
		 		sprintf (lua_tostring_s, "%g", nvalue(obj));
		 	svalue(obj, lua_createstring(lua_strdup(lua_tostring_s)));
		 	if (svalue(obj) == null)
		  		return 1;
		 	tag(obj, Type.T_STRING);
		 	return 0;
		}
	
	
		/*
		** Execute the given opcode. Return 0 in success or 1 on error.
		*/
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
			  		tag(top.inc(), Type.T_NIL);
			   		break;
	
		   		case OpCode.PUSH0:
			   		tag(top.get(), Type.T_NUMBER);
			   		nvalue(top.inc(), 0);
			   		break;
		   
			   	case OpCode.PUSH1:
			   		tag(top.get(), Type.T_NUMBER);
			   		nvalue(top.inc(), 1);
			   		break;
		   
			   	case OpCode.PUSH2:
			   		tag(top.get(), Type.T_NUMBER);
			   		nvalue(top.inc(), 2);
			   		break;
	
		   		case OpCode.PUSHBYTE:
			   		tag(top.get(), Type.T_NUMBER);
			   		nvalue(top.inc(), pc[0]); pc.inc();
			   		break;
	
		   		case OpCode.PUSHWORD:
			   		tag(top.get(), Type.T_NUMBER);
			   		nvalue(top.inc(), (Word)(pc[0] | pc[1] << 8));
					pc += 2;
		   			break;
	
		   		case OpCode.PUSHFLOAT:
		   			tag(top.get(), Type.T_NUMBER);
		   			nvalue(top.inc(), bytesToFloat(pc[0], pc[1], pc[2], pc[3]));
					pc += 4;
		   			break;
		   
			   	case OpCode.PUSHSTRING:
			   		{
		   				int w = (Word)(pc[0] | pc[1] << 8);
						pc += 2;
						tag(top.get(), Type.T_STRING);
						svalue(top.inc(), lua_constant[w]);
			   		}
			   		break;
		
			   	case OpCode.PUSHLOCAL0:
			   		top.inc().set(@base.get(0));
				   	break;
			   
			   	case OpCode.PUSHLOCAL1:
				   	top.inc().set(@base.get(1));
				   	break;
			   
				case OpCode.PUSHLOCAL2:
					top.inc().set(@base.get(2));
				   	break;
			   
				case OpCode.PUSHLOCAL3:
					top.inc().set(@base.get(3));
				   	break;
			   
				case OpCode.PUSHLOCAL4:
					top.inc().set(@base.get(4));
				  	break;
			   
				case OpCode.PUSHLOCAL5:
					top.inc().set(@base.get(5));
				   	break;
			   
				case OpCode.PUSHLOCAL6:
					top.inc().set(@base.get(6));
				   	break;
			   
				case OpCode.PUSHLOCAL7:
					top.inc().set(@base.get(7));
				   	break;
			   
				case OpCode.PUSHLOCAL8:
					top.inc().set(@base.get(8));
				   	break;
			   
				case OpCode.PUSHLOCAL9:
					top.inc().set(@base.get(9));
				   	break;
		
			   	case OpCode.PUSHLOCAL:
				   	top.inc().set(@base.get(pc[0])); pc.inc();
				   	break;
		
			   case OpCode.PUSHGLOBAL:
				   	top.inc().set(s_object((Word)(pc[0] | pc[1] << 8)));
				   	pc += 2;
			   		break;
		
			   case OpCode.PUSHINDEXED:
			   		top.dec();
			   		if (tag(top.get(-1)) != Type.T_ARRAY)
					{
				 		lua_reportbug ("indexed expression not a table");
				 		return 1;
					}
					{
			   			Object_ h = lua_hashdefine (avalue(top.get(- 1)), top.get());
				 		if (h == null) return 1;
				 		top.set(-1, h);
					}
			   		break;
		
			   	case OpCode.PUSHMARK:
			   		tag(top.inc(), Type.T_MARK);
				   	break;
		
			   	case OpCode.PUSHOBJECT:
				   	top.set(0, top.get(-3));
				   	top.inc();
				   	break;
		
			   	case OpCode.STORELOCAL0:
				   	top.dec(); @base.get(0).set(top.get());
				   	break;
			   
				case OpCode.STORELOCAL1:
				   	top.dec(); @base.get(1).set(top.get());
				   	break;
			   
				case OpCode.STORELOCAL2:
					top.dec(); @base.get(2).set(top.get());
				  	break;
			   
				case OpCode.STORELOCAL3:
					top.dec(); @base.get(3).set(top.get());
				   	break;
			   
				case OpCode.STORELOCAL4:
					top.dec(); @base.get(4).set(top.get());
				  	break;
			   
				case OpCode.STORELOCAL5:
					top.dec(); @base.get(5).set(top.get());
				   	break;
			   
				case OpCode.STORELOCAL6:
					top.dec(); @base.get(6).set(top.get());
				   	break;
			   
				case OpCode.STORELOCAL7:
					top.dec(); @base.get(7).set(top.get());
				  	break;
			   
				case OpCode.STORELOCAL8:
					top.dec(); @base.get(8).set(top.get());
				   	break;
			   
				case OpCode.STORELOCAL9:
					top.dec(); @base.get(9).set(top.get());
				   	break;
		
			   	case OpCode.STORELOCAL:
				   	top.dec(); @base.get(pc[0]).set(top.get()); pc.inc();
				   	break;
		
			   	case OpCode.STOREGLOBAL:
				   	top.dec(); s_object((Word)(pc[0] | pc[1] << 8), top.get());
					pc += 2;
			   		break;
		
			   	case OpCode.STOREINDEXED0:
			   		if (tag(top.get(-3)) != Type.T_ARRAY)
			   		{
				 		lua_reportbug ("indexed expression not a table");
				 		return 1;
					}
					{
			   			Object_ h = lua_hashdefine(avalue(top.get(-3)), top.get(-2));
				 		if (h == null)
				 		{
					 		return 1;
				 		}
				 		h.set(top.get(-1));
					}
			   		top.add(-3);
			   		break;
		
			   	case OpCode.STOREINDEXED:
			   		{
			   			int n = pc[0]; pc.inc();
			   			if (tag(top.get(-3-n)) != Type.T_ARRAY)
						{
				 			lua_reportbug ("indexed expression not a table");
				 			return 1;
						}
						{
			   				Object_ h = lua_hashdefine (avalue(top.get(-3-n)), top.get(-2-n));
				 			if (h == null)
				 			{
					 			return 1;
				 			}
				 			h.set(top.get(-1));
						}
						top.dec();
			   		}
			   		break;
		
			   	case OpCode.STOREFIELD:
			   		if (tag(top.get(-3)) != Type.T_ARRAY)
					{
				 		lua_error ("internal error - table expected");
				 		return 1;
					}
			   		(lua_hashdefine (avalue(top.get(-3)), top.get(-2))).set(top.get(-1));
					top.add(-2);
			   		break;
		
			   	case OpCode.ADJUST:
			   		{
			   			Object_ newtop = @base.get(pc[0]); pc.inc();
			   			if (top.notEqualsTo(newtop))
						{
			   				while (top.isLessThan(newtop))
				 			{
				 				tag(top.inc(), Type.T_NIL);
				 			}
				 			top.setRef(newtop);
						}
			   		}
			   		break;
		
			   	case OpCode.CREATEARRAY:
			   		if (tag(top.get(-1)) == Type.T_NIL)
			   			nvalue(top.get(-1), 101);
					else
					{
						if (tonumber(top.get(-1))) return 1;
						if (nvalue(top.get(-1)) <= 0) nvalue(top.get(-1), 101);
				 	}
					avalue(top.get(-1), (Hash)lua_createarray(lua_hashcreate((uint)nvalue(top.get(-1)))));
					if (avalue(top.get(-1)) == null)
				 		return 1;
					tag(top.get(-1), Type.T_ARRAY);
			   		break;
		
			   	case OpCode.EQOP:
			   		{
			   			Object_ l = top.get(-2);
			   			Object_ r = top.get(-1);
			   			top.dec();
						if (tag(l) != tag(r))
							tag(top.get(-1), Type.T_NIL);
						else
						{
				 			switch (tag(l))
				 			{
				  			case Type.T_NIL:
				 				tag(top.get(-1), Type.T_NUMBER);
					  			break;
				  
					  		case Type.T_NUMBER:
					  			tag(top.get(-1), (nvalue(l) == nvalue(r)) ? Type.T_NUMBER : Type.T_NIL);
					  			break;
				  
					  		case Type.T_ARRAY:
					  			tag(top.get(-1), (avalue(l) == avalue(r)) ? Type.T_NUMBER : Type.T_NIL);
					  			break;
				  
					  		case Type.T_FUNCTION:
					  			tag(top.get(-1), (bvalue(l) == bvalue(r)) ? Type.T_NUMBER : Type.T_NIL);
					  			break;
				  
					  		case Type.T_CFUNCTION:
					  			tag(top.get(-1), (fvalue(l) == fvalue(r)) ? Type.T_NUMBER : Type.T_NIL);
					  			break;
				  
					  		case Type.T_USERDATA:
					  			tag(top.get(-1), (uvalue(l) == uvalue(r)) ? Type.T_NUMBER : Type.T_NIL);
					  			break;
				  
					  		case Type.T_STRING:
					  			tag(top.get(-1), (strcmp (svalue(l), svalue(r)) == 0) ? Type.T_NUMBER : Type.T_NIL);
					  			break;
				  
					  		case Type.T_MARK:
					  			return 1;
				 			}
						}
						nvalue(top.get(-1), 1);
			   		}
			   		break;
		
			   	case OpCode.LTOP:
			   		{
			   			Object_ l = top.get(-2);
			   			Object_ r = top.get(-1);
			   			top.dec();
						if (tag(l) == Type.T_NUMBER && tag(r) == Type.T_NUMBER)
						{
							tag(top.get(-1), (nvalue(l) < nvalue(r)) ? Type.T_NUMBER : Type.T_NIL);
						}
						else
						{
					 		if (tostring(l) || tostring(r))
					  			return 1;
					 		tag(top.get(-1), (strcmp (svalue(l), svalue(r)) < 0) ? Type.T_NUMBER : Type.T_NIL);
						}
						nvalue(top.get(-1), 1);
			   		}
			   		break;
		
			   	case OpCode.LEOP:
			   		{
			   			Object_ l = top.get(-2);
			   			Object_ r = top.get(-1);
			   			top.dec();
						if (tag(l) == Type.T_NUMBER && tag(r) == Type.T_NUMBER)
						{
							tag(top.get(-1), (nvalue(l) <= nvalue(r)) ? Type.T_NUMBER : Type.T_NIL);
						}
						else
						{
					 		if (tostring(l) || tostring(r))
					  			return 1;
					 		tag(top.get(-1), (strcmp (svalue(l), svalue(r)) <= 0) ? Type.T_NUMBER : Type.T_NIL);
						}
						nvalue(top.get(-1), 1);
				   	}
			   		break;
		
			   case OpCode.ADDOP:
			   		{
			   			Object_ l = top.get(-2);
			   			Object_ r = top.get(-1);
						if (tonumber(r) || tonumber(l))
				 			return 1;
						nvalue(l, nvalue(l) + nvalue(r));
						top.dec();
			   		}
			   		break;
		
			  	case OpCode.SUBOP:
			   		{
			   			Object_ l = top.get(-2);
			   			Object_ r = top.get(-1);
						if (tonumber(r) || tonumber(l))
				 			return 1;
						nvalue(l, nvalue(l) - nvalue(r));
						top.dec();
			   		}
			   		break;
		
			   	case OpCode.MULTOP:
			   		{
			   			Object_ l = top.get(-2);
			   			Object_ r = top.get(-1);
						if (tonumber(r) || tonumber(l))
				 			return 1;
						nvalue(l, nvalue(l) * nvalue(r));
						top.dec();
			   		}
			   		break;
		
			   	case OpCode.DIVOP:
			   		{
			   			Object_ l = top.get(-2);
			   			Object_ r = top.get(-1);
						if (tonumber(r) || tonumber(l))
				 			return 1;
						nvalue(l, nvalue(l) / nvalue(r));
						top.dec();
			   		}
			   		break;
		
			   	case OpCode.CONCOP:
			   		{
			   			Object_ l = top.get(-2);
			   			Object_ r = top.get(-1);
						if (tonumber(r) || tonumber(l))
				 			return 1;
						svalue(l, lua_createstring (lua_strconc(svalue(l),svalue(r))));
						if (svalue(l) == null)
				 			return 1;
						top.dec();
			   		}
			   		break;
		
			   	case OpCode.MINUSOP:
			   		if (tonumber(top.get(-1)))
						return 1;
					nvalue(top.get(-1), - nvalue(top.get(-1)));
			   		break;
		
			   	case OpCode.NOTOP:
			   		tag(top.get(-1), tag(top.get(-1)) == Type.T_NIL ? Type.T_NUMBER : Type.T_NIL);
			   		break;
		
			   	case OpCode.ONTJMP:
			   		{
			   			int n = (Word)(pc[0] | pc[1] << 8);
						pc += 2;
						if (tag(top.get(-1)) != Type.T_NIL) pc += n;
					}
			   		break;
		
			   	case OpCode.ONFJMP:
			   		{
						int n = (Word)(pc[0] | pc[1] << 8);
						pc += 2;
						if (tag(top.get(-1)) == Type.T_NIL) pc += n;
					}
			   		break;
		
			   	case OpCode.JMP:
			   		pc += (Word)(pc[0] | pc[1] << 8) + 2;
				   	break;
		
			   	case OpCode.UPJMP:
				   	pc -= (Word)(pc[0] | pc[1] << 8) - 2;
				   	break;
		
			   	case OpCode.IFFJMP:
			   		{
				   		int n = (Word)(pc[0] | pc[1] << 8);
						pc += 2;
						top.dec();
						if (tag(top.get()) == Type.T_NIL) pc += n;
					}
			   		break;
		
			   	case OpCode.IFFUPJMP:
			   		{
			   			int n = (Word)(pc[0] | pc[1] << 8);
						pc += 2;
						top.dec();
						if (tag(top.get()) == Type.T_NIL) pc -= n;
					}
			   		break;
		
			   	case OpCode.POP:
			   		top.dec();
				   	break;
		
			   	case OpCode.CALLFUNC:
			   		{
						BytePtr newpc;
						ObjectRef b_ = top.getRef(-1);
						while (tag(b_.get()) != Type.T_MARK) b_.dec();
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
						else if (tag(b_.get(-1)) == Type.T_CFUNCTION)
						{
				 			int nparam;
				 			lua_debugline = 0; // always reset debug flag
				 			nvalue(b_.get(), @base.minus(stack)); // store base value
				 			@base = b_.getRef(+1);
				 			nparam = top.minus(@base); // number of parameters
				 			(fvalue(b_.get(-1)))(); // call C function
		
				 			/* shift returned values */
							{
				  				int i;
				  				int nretval = top.minus(@base) - nparam;
				  				top = @base.getRef(-2);
				  				@base = new ObjectRef(stack, (int) nvalue(@base.get(-1)));
				  				for (i=0; i<nretval; i++)
				  				{
				  					top.get().set(top.get(nparam + 2));
				   					top.inc();
				  				}
				 			}
						}
						else
						{
				 			lua_reportbug ("call expression not a function");
				 			return 1;
						}
			   		}
			   		break;
		
			   	case OpCode.RETCODE:
			   		{
						int i;
						int shift = pc[0]; pc.inc();
						int nretval = top.minus(@base) - shift;
						top.setRef(@base.get(-2));
						pc = bvalue(@base.get(-2));
						@base = new ObjectRef(stack, (int) nvalue(@base.get(-1))); //FIXME:???new ObjectRef???
						for (i=0; i<nretval; i++)
						{
							top.get().set(top.get(shift + 2));
			 				top.inc();
						}
		   			}
		   			break;
		
			  	case OpCode.HALT:
			   		return 0; // success
		
			   	case OpCode.SETFUNCTION:
		   			{
						int file, func;
						file = (Word)(pc[0] | pc[1] << 8);
						pc += 2;
						func = (Word)(pc[0] | pc[1] << 8);
						pc += 2;
						if (lua_pushfunction (file, func) != 0)
			 				return 1;
					}
		   			break;
		
		   		case OpCode.SETLINE:
		   			lua_debugline = (Word)(pc[0] | pc[1] << 8);
					pc += 2;
		   			break;
	
		   		case OpCode.RESET:
					lua_popfunction ();
		   			break;
	
		   		default:
					lua_error ("internal error - opcode didn't match");
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
		public static int lua_dofile(CharPtr filename)
		{
		 	if (lua_openfile (filename) != 0) return 1;
		 	if (lua_parse () != 0) { lua_closefile (); return 1; }
		 	lua_closefile ();
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
		public static int lua_storeglobal(CharPtr name)
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
