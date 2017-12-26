/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2017-10-17
 * Time: 21:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System; 
using KopiLua;

namespace lua1mod
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			//Console.WriteLine("atof() = " + KopiLua.Lua.atof("12.34"));
			//Lua.main(2, new Lua.CharPtr[] {"lua.exe", "print.lua"});
			//Lua.main(2, new Lua.CharPtr[] {"lua.exe", "array.lua"}); //ok
			//Lua.main(2, new Lua.CharPtr[] {"lua.exe", "globals.lua"}); //ok
			//Lua.main(2, new Lua.CharPtr[] {"lua.exe", "save.lua"}); //ok
			//Lua.main(3, new Lua.CharPtr[] {"lua.exe", "sort.lua", "main"}); //ok
			Lua.main(2, new Lua.CharPtr[] {"lua.exe", "test.lua", "retorno_multiplo"});
			//Lua.main(2, new Lua.CharPtr[] {"lua.exe", "type.lua"});
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
