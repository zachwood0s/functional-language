	.text
	.def	 @feat.00;
	.scl	3;
	.type	0;
	.endef
	.globl	@feat.00
.set @feat.00, 0
	.file	"test.c"
	.def	 addInt;
	.scl	2;
	.type	32;
	.endef
	.globl	addInt                  # -- Begin function addInt
	.p2align	4, 0x90
addInt:                                 # @addInt
.seh_proc addInt
# %bb.0:
	pushq	%rax
	.seh_stackalloc 8
	.seh_endprologue
	movl	%edx, 4(%rsp)
	movl	%ecx, (%rsp)
	movl	(%rsp), %eax
	addl	4(%rsp), %eax
	popq	%rcx
	retq
	.seh_handlerdata
	.text
	.seh_endproc
                                        # -- End function
	.def	 printInt;
	.scl	2;
	.type	32;
	.endef
	.globl	printInt                # -- Begin function printInt
	.p2align	4, 0x90
printInt:                               # @printInt
.seh_proc printInt
# %bb.0:
	subq	$40, %rsp
	.seh_stackalloc 40
	.seh_endprologue
	movl	%ecx, 36(%rsp)
	movl	36(%rsp), %edx
	leaq	"??_C@_02DPKJAMEF@?$CFd?$AA@"(%rip), %rcx
	callq	printf
	nop
	addq	$40, %rsp
	retq
	.seh_handlerdata
	.text
	.seh_endproc
                                        # -- End function
	.section	.rdata,"dr",discard,"??_C@_02DPKJAMEF@?$CFd?$AA@"
	.globl	"??_C@_02DPKJAMEF@?$CFd?$AA@" # @"??_C@_02DPKJAMEF@?$CFd?$AA@"
"??_C@_02DPKJAMEF@?$CFd?$AA@":
	.asciz	"%d"


