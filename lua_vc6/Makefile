CC = gcc

OBJS= hash.o inout.o lex_yy.o opcode.o table.o y_tab.o lua.o iolib.o mathlib.o strlib.o

CFLAGS= -O2 -I.

T= lua

all:	$T

$T:	$(OBJS)
	$(CC) -o $@ $(OBJS) -lm

A=--------------------------------------------------------------------------
test:	$T
	@echo "$A"
	./$T sort.lua main
	@echo "$A"
	# | column
	./$T globals.lua | sort 
	@echo "$A"
	./$T array.lua
	@echo "$A"
	./$T save.lua
	@echo "$A"
	./$T test.lua retorno_multiplo norma

clean:
	rm -f $T $(OBJS) core core.* *.exe

diff:
	diff . fixed | grep -v ^Only
