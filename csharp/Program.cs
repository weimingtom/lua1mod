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
			else if (type.Equals("Node"))
			{
				return new Node();
			}
			return null;
		}
		
		public static object calloc(uint n, string type) //FIXME:some places are replaced with new, not with this method
		{
			if (type.Equals("Node"))
		    {
				Node[] result = new Node[n];
				for (int i = 0; i < n; ++i)
				{
					result[i] = new Node();
				}
				return result;
		    }
			return null;
		}
		
		public static void free(object obj)
		{
			
		}

		public static int memcmp(object ptr1, object ptr2, string type) 
		{
			return 0; //FIXME:
		}
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
		
		public static FILE fopen(CharPtr filename, CharPtr mode)
		{
			return null;
		}
		
		public static void fclose(FILE fp)
		{
			
		}
		
		public static FILE stdin = null;
		public static FILE stdout = null;
		public static FILE stderr = null;
		
		public static int isspace(int c)
		{
			return 0;
		}
		public static int isdigit(int c)
		{
			return 0;
		}
	
		
		public static double strtod(string str, string str2)
		{
			return 0;
		}
		
		public static char tolower(char c)
		{
			return '_';
		}
		
		public static char toupper(char c)
		{
			return '_';
		}

		public static int fprintf(FILE fp, string format, params object[] args)
		{
			return 0;
		}
		
		public static void system(CharPtr str)
		{
			
		}
		
		public static int remove(CharPtr filename)
		{
			return 0;
		}
		
		public const int BUFSIZ = 8192; //FIXME:???
		
		public static double sin(double x)
		{
			return Math.Sin(x);
		}
		
		public static double cos(double x)
		{
			return Math.Cos(x);
		}
		
		public static double tan(double x)
		{
			return Math.Tan(x);
		}
		
		public static double asin(double x)
		{
			return Math.Asin(x);
		}
		
		
		public static double acos(double x)
		{
			return Math.Acos(x);
		}
		
		public static double atan(double x)
		{
			return Math.Atan(x);
		}
		
		public static double ceil(double x) 
		{
			return Math.Ceiling(x);
		}
		
		public static double floor(double x)
		{
			return Math.Floor(x);
		}
		
		public static double sqrt(double x) 
		{
			return Math.Sqrt(x);
		}
		
		public static double pow(double x, double y)
		{
			return Math.Pow(x, y);
		}
		
		public static CharPtr strstr(CharPtr str1, CharPtr str2)
		{
			return null;
		}
		
		public static uint strlen(CharPtr str)
		{
			return 0;
		}
		
		public static CharPtr strdup(CharPtr s)
		{
			return null;
		}
		
		public static double strtod(CharPtr nptr, ref CharPtr endptr) 
		{
			return 0;
		}
		
		public static void sprintf(CharPtr ptr, CharPtr format, params object[] args)
		{
			
		}
		
		public static void sscanf(CharPtr ptr, CharPtr format, ref long arg)
		{
				
		}
		public static void sscanf(CharPtr ptr, CharPtr format, ref float arg)
		{
				
		}
		public static int fscanf(FILE fp, CharPtr format, CharPtr str)
		{
			return 0;
		}		
		public static int fscanf(FILE fp, CharPtr format, ref long str)
		{
			return 0;
		}
		public static int fscanf(FILE fp, CharPtr format, ref float str)
		{
			return 0;
		}
		
		
		
		public static CharPtr strchr(CharPtr str, char ch)
		{
			return null;
		}
		
		public static CharPtr strcpy(CharPtr dest, CharPtr src)
		{
			return null;
		}
		
		public static int puts(CharPtr str)
		{
			return 0;
		}
	}
}