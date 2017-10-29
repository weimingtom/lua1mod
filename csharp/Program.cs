/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2017-10-17
 * Time: 21:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

namespace lua1mod
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}

namespace KopiLua
{
	public partial class Lua
	{
		public class BytePtr
		{
			public byte[] chars;
			public int index;
			
			public byte this[int offset]
			{
				get { return chars[index + offset]; }
				set { chars[index + offset] = value; }
			}
			public byte this[uint offset]
			{
				get { return chars[index + offset]; }
				set { chars[index + offset] = value; }
			}
			public byte this[long offset]
			{
				get { return chars[index + (int)offset]; }
				set { chars[index + (int)offset] = value; }
			}

//			public static implicit operator CharPtr(string str) { return new CharPtr(str); }
			public static implicit operator BytePtr(byte[] chars) { return new BytePtr(chars); }

			public BytePtr()
			{
				this.chars = null;
				this.index = 0;
			}

//			public CharPtr(string str)
//			{
//				this.chars = (str + '\0').ToCharArray();
//				this.index = 0;
//			}

			public BytePtr(BytePtr ptr)
			{
				this.chars = ptr.chars;
				this.index = ptr.index;
			}

			public BytePtr(BytePtr ptr, int index)
			{
				this.chars = ptr.chars;
				this.index = index;
			}

			public BytePtr(byte[] chars)
			{
				this.chars = chars;
				this.index = 0;
			}

			public BytePtr(byte[] chars, int index)
			{
				this.chars = chars;
				this.index = index;
			}

			public BytePtr(IntPtr ptr)
			{
				this.chars = new byte[0];
				this.index = 0;
			}

			public static BytePtr operator +(BytePtr ptr, int offset) {return new BytePtr(ptr.chars, ptr.index+offset);}
			public static BytePtr operator -(BytePtr ptr, int offset) {return new BytePtr(ptr.chars, ptr.index-offset);}
			public static BytePtr operator +(BytePtr ptr, uint offset) { return new BytePtr(ptr.chars, ptr.index + (int)offset); }
			public static BytePtr operator -(BytePtr ptr, uint offset) { return new BytePtr(ptr.chars, ptr.index - (int)offset); }

			public void inc() { this.index++; }
			public void dec() { this.index--; }
			public BytePtr next() { return new BytePtr(this.chars, this.index + 1); }
			public BytePtr prev() { return new BytePtr(this.chars, this.index - 1); }
			public BytePtr add(int ofs) { return new BytePtr(this.chars, this.index + ofs); }
			public BytePtr sub(int ofs) { return new BytePtr(this.chars, this.index - ofs); }
			
			public static bool operator ==(BytePtr ptr, byte ch) { return ptr[0] == ch; }
			public static bool operator ==(byte ch, BytePtr ptr) { return ptr[0] == ch; }
			public static bool operator !=(BytePtr ptr, byte ch) { return ptr[0] != ch; }
			public static bool operator !=(byte ch, BytePtr ptr) { return ptr[0] != ch; }

//			public static CharPtr operator +(BytePtr ptr1, BytePtr ptr2)
//			{
//				string result = "";
//				for (int i = 0; ptr1[i] != '\0'; i++)
//					result += ptr1[i];
//				for (int i = 0; ptr2[i] != '\0'; i++)
//					result += ptr2[i];
//				return new CharPtr(result);
//			}
			public static int operator -(BytePtr ptr1, BytePtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index - ptr2.index; }
			public static bool operator <(BytePtr ptr1, BytePtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index < ptr2.index; }
			public static bool operator <=(BytePtr ptr1, BytePtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index <= ptr2.index; }
			public static bool operator >(BytePtr ptr1, BytePtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index > ptr2.index; }
			public static bool operator >=(BytePtr ptr1, BytePtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index >= ptr2.index; }
			public static bool operator ==(BytePtr ptr1, BytePtr ptr2) {
				object o1 = ptr1 as BytePtr;
				object o2 = ptr2 as BytePtr;
				if ((o1 == null) && (o2 == null)) return true;
				if (o1 == null) return false;
				if (o2 == null) return false;
				return (ptr1.chars == ptr2.chars) && (ptr1.index == ptr2.index); }
			public static bool operator !=(BytePtr ptr1, BytePtr ptr2) {return !(ptr1 == ptr2); }

			public override bool Equals(object o)
			{
				return this == (o as BytePtr);
			}

			public override int GetHashCode()
			{
				return 0;
			}
//			public override string ToString()
//			{
//				string result = "";
//				for (int i = index; (i<chars.Length) && (chars[i] != '\0'); i++)
//					result += chars[i];
//				return result;
//			}
		}
		
		public class CharPtr
		{
			public char[] chars;
			public int index;
			
			public char this[int offset]
			{
				get { return chars[index + offset]; }
				set { chars[index + offset] = value; }
			}
			public char this[uint offset]
			{
				get { return chars[index + offset]; }
				set { chars[index + offset] = value; }
			}
			public char this[long offset]
			{
				get { return chars[index + (int)offset]; }
				set { chars[index + (int)offset] = value; }
			}

			public static implicit operator CharPtr(string str) { return new CharPtr(str); }
			public static implicit operator CharPtr(char[] chars) { return new CharPtr(chars); }

			public CharPtr()
			{
				this.chars = null;
				this.index = 0;
			}

			public CharPtr(string str)
			{
				this.chars = (str + '\0').ToCharArray();
				this.index = 0;
			}

			public CharPtr(CharPtr ptr)
			{
				this.chars = ptr.chars;
				this.index = ptr.index;
			}

			public CharPtr(CharPtr ptr, int index)
			{
				this.chars = ptr.chars;
				this.index = index;
			}

			public CharPtr(char[] chars)
			{
				this.chars = chars;
				this.index = 0;
			}

			public CharPtr(char[] chars, int index)
			{
				this.chars = chars;
				this.index = index;
			}

			public CharPtr(IntPtr ptr)
			{
				this.chars = new char[0];
				this.index = 0;
			}

			public static CharPtr operator +(CharPtr ptr, int offset) {return new CharPtr(ptr.chars, ptr.index+offset);}
			public static CharPtr operator -(CharPtr ptr, int offset) {return new CharPtr(ptr.chars, ptr.index-offset);}
			public static CharPtr operator +(CharPtr ptr, uint offset) { return new CharPtr(ptr.chars, ptr.index + (int)offset); }
			public static CharPtr operator -(CharPtr ptr, uint offset) { return new CharPtr(ptr.chars, ptr.index - (int)offset); }

			public void inc() { this.index++; }
			public void dec() { this.index--; }
			public CharPtr next() { return new CharPtr(this.chars, this.index + 1); }
			public CharPtr prev() { return new CharPtr(this.chars, this.index - 1); }
			public CharPtr add(int ofs) { return new CharPtr(this.chars, this.index + ofs); }
			public CharPtr sub(int ofs) { return new CharPtr(this.chars, this.index - ofs); }
			
			public static bool operator ==(CharPtr ptr, char ch) { return ptr[0] == ch; }
			public static bool operator ==(char ch, CharPtr ptr) { return ptr[0] == ch; }
			public static bool operator !=(CharPtr ptr, char ch) { return ptr[0] != ch; }
			public static bool operator !=(char ch, CharPtr ptr) { return ptr[0] != ch; }

			public static CharPtr operator +(CharPtr ptr1, CharPtr ptr2)
			{
				string result = "";
				for (int i = 0; ptr1[i] != '\0'; i++)
					result += ptr1[i];
				for (int i = 0; ptr2[i] != '\0'; i++)
					result += ptr2[i];
				return new CharPtr(result);
			}
			public static int operator -(CharPtr ptr1, CharPtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index - ptr2.index; }
			public static bool operator <(CharPtr ptr1, CharPtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index < ptr2.index; }
			public static bool operator <=(CharPtr ptr1, CharPtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index <= ptr2.index; }
			public static bool operator >(CharPtr ptr1, CharPtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index > ptr2.index; }
			public static bool operator >=(CharPtr ptr1, CharPtr ptr2) {
				Debug.Assert(ptr1.chars == ptr2.chars); return ptr1.index >= ptr2.index; }
			public static bool operator ==(CharPtr ptr1, CharPtr ptr2) {
				object o1 = ptr1 as CharPtr;
				object o2 = ptr2 as CharPtr;
				if ((o1 == null) && (o2 == null)) return true;
				if (o1 == null) return false;
				if (o2 == null) return false;
				return (ptr1.chars == ptr2.chars) && (ptr1.index == ptr2.index); }
			public static bool operator !=(CharPtr ptr1, CharPtr ptr2) {return !(ptr1 == ptr2); }

			public override bool Equals(object o)
			{
				return this == (o as CharPtr);
			}

			public override int GetHashCode()
			{
				return 0;
			}
			public override string ToString()
			{
				string result = "";
				for (int i = index; (i<chars.Length) && (chars[i] != '\0'); i++)
					result += chars[i];
				return result;
			}
		}		
		
		public static string sizeOf(string type) 
		{
			return type;
		}
		
		public static object malloc(string type)
		{
			if (type.Equals("Hash"))
			{
				return new Hash();
			}
			else if (type.Equals("node"))
			{
				return new node();
			}
			return null;
		}
		
		public static object calloc(uint n, string type)
		{
			if (type.Equals("node"))
		    {
				node[] result = new node[n];
				for (int i = 0; i < n; ++i)
				{
					result[i] = new node();
				}
				return result;
		    }
			return null;
		}
		
		public static void lua_error(string str)
		{
			
		}
		
		public static void free(object obj)
		{
			
		}
		
//		public static void lua_markobject(object obj)
//		{
//			
//		}
		
//		public static object lua_getparam(int n)
//		{
//			return null;
//		}
		
//		public static void lua_pushobject(object obj)
//		{
//			
//		}
		
		public static void lua_reportbug(string str)
		{
			
		}
		
//		public static void lua_pushnil()
//		{
//			
//		}
		
		public static int tag(object obj)
		{
			return 0;
		}
		public static void tag(object obj, int t)
		{
			
		}
		
		public static Hash avalue(object obj)
		{
			return null;
		}
		
		public static CharPtr svalue(object obj)
		{
			return null;
		}
		public static int nvalue(object obj)
		{
			return 0;
		}
		
		public const int T_NIL = 0;
		public const int T_NUMBER = 0;
		public const int T_STRING = 0;
		public const int T_ARRAY = 0;
		
		public static int memcmp(CharPtr ptr1, CharPtr ptr2, uint size) { return memcmp(ptr1, ptr2, (int)size); }
		public static int memcmp(CharPtr ptr1, CharPtr ptr2, int size)
		{
			for (int i=0; i<size; i++)
				if (ptr1[i]!=ptr2[i])
				{
					if (ptr1[i]<ptr2[i])
						return -1;
					else
						return 1;
				}
			return 0;
		}
		public static CharPtr objToCharPtr(object obj)
		{
			return null;
		}
		public static int strcmp(CharPtr s1, CharPtr s2)
		{
			if (s1 == s2)
				return 0;
			if (s1 == null)
				return -1;
			if (s2 == null)
				return 1;

			for (int i = 0; ; i++)
			{
				if (s1[i] != s2[i])
				{
					if (s1[i] < s2[i])
						return -1;
					else
						return 1;
				}
				if (s1[i] == '\0')
					return 0;
			}
		}
		
		public class FILE
		{
			
		}
		
		public static int fgetc(FILE fp)
		{
			return 0;
		}
		public static void ungetc(int c, FILE fp)
		{
			
		}
		
		public static int EOF = -1;
		
		public static FILE fopen(string filename, string mode)
		{
			return null;
		}
		public static void fclose(FILE fp)
		{
			
		}
		
//		public static int lua_addfile(ref string fn)
//		{
//			return 0;
//		}
		
//		public delegate int Input();
		public static void lua_setinput(Input input)
		{
			
		}
		
//		public delegate void Unput(int c);
		public static void lua_setunput(Unput unput)
		{
			
		}
		
		public static FILE stdin = null;
		public static FILE stdout = null;
		
		public static void lua_pushnumber(float f)
		{
			
		}
		
//		public static int lua_isstring(object obj)
//		{
//			return 0;
//		}
		
//		public static string lua_getstring(object obj)
//		{
//			return null;
//		}
		
		public static bool isspace(int c)
		{
			return false;
		}
		public static bool isdigit(int c)
		{
			return false;
		}
		
		public static int fscanf(FILE fp, string str, string str2)
		{
			return 0;
		}
		
		public static double strtod(string str, string str2)
		{
			return 0;
		}
		
//		public static void lua_pushnumber(double d)
//		{
//			
//		}
		
		public static char tolower(char c)
		{
			return '_';
		}
		
		public static void lua_pushstring(string str)
		{
			
		}
		
		public static int fprintf(FILE fp, string format, params object[] args)
		{
			return 0;
		}
		
		public static void system(string str)
		{
			
		}
		
//		public static int lua_isnumber(object obj)
//		{
//			return 0;
//		}
		
//		public static double lua_getnumber(object obj)
//		{
//			return 0;
//		}
		
		public static int remove(string filename)
		{
			return 0;
		}
		
//		public static void lua_call(string str, int i)
//		{
//			
//		}
		
//		public static void lua_dostring(string str)
//		{
//			
//		}
		
		public static void lua_dofile(string filename)
		{
			
		}
		
		public static bool lua_parse()
		{
			return true;
		}
	}
}