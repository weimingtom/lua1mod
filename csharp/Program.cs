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
			//Lua.main(2, new Lua.CharPtr[] {"lua", "print.lua"});
			//Lua.main(2, new Lua.CharPtr[] {"lua", "array.lua"}); //ok
			//Lua.main(2, new Lua.CharPtr[] {"lua", "globals.lua"}); //ok
			//Lua.main(2, new Lua.CharPtr[] {"lua", "save.lua"}); //ok
			//Lua.main(2, new Lua.CharPtr[] {"lua", "sort.lua"});
			//Lua.main(2, new Lua.CharPtr[] {"lua", "test.lua"}); //ok
			Lua.main(2, new Lua.CharPtr[] {"lua", "type.lua"});
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
