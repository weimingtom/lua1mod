/*
** lua.c
** Linguagem para Usuarios de Aplicacao
** TeCGraf - PUC-Rio
** 28 Apr 93
*/

#include <stdio.h>

#include "lua.h"
#include "lualib.h"

#define TEST_LUA 1


void test (void)
{
  lua_pushobject(lua_getparam(1));
  lua_call ("c", 1);
}


static void callfunc (void)
{
 lua_Object obj = lua_getparam (1);
 if (lua_isstring(obj)) lua_call(lua_getstring(obj),0);
}

static void execstr (void)
{
 lua_Object obj = lua_getparam (1);
 if (lua_isstring(obj)) lua_dostring(lua_getstring(obj));
}

int main (int argc, char *argv[])
{
 int i;
#if !TEST_LUA
 if (argc < 2)
 {
  puts ("usage: lua filename [functionnames]");
  return;
 }
#else
 //char *argv_[] = {"lua.exe", "print.lua"}; //ok
 //char *argv_[] = {"lua.exe", "array.lua"}; //ok
 //char *argv_[] = {"lua.exe", "globals.lua"}; //ok
 //char *argv_[] = {"lua.exe", "save.lua"}; //ok
 //char *argv_[] = {"lua.exe", "sort.lua", "main"}; //ok
 //char *argv_[] = {"lua.exe", "test.lua", "retorno_multiplo"}; //ok
 char *argv_[] = {"lua.exe", "type.lua"}; //ok
 argc = sizeof(argv_) / sizeof(char *);
 argv = argv_;
#endif
 lua_register ("callfunc", callfunc);
 lua_register ("execstr", execstr);
 lua_register ("test", test);
 iolib_open ();
 strlib_open ();
 mathlib_open ();
 lua_dofile (argv[1]);
 for (i=2; i<argc; i++)
 {
  lua_call (argv[i],0);
 }
 return 0;
}


