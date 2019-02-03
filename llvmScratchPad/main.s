	.text
	.def	 @feat.00;
	.scl	3;
	.type	0;
	.endef
	.globl	@feat.00
.set @feat.00, 1
	.file	"main.ll"
	.def	 _main;
	.scl	2;
	.type	32;
	.endef
	.globl	_main                   # -- Begin function main
	.p2align	4, 0x90
_main:                                  # @main
# %bb.0:
	pushl	$20
	pushl	$10
	calll	_addInt
	addl	$8, %esp
	pushl	%eax
	calll	_printInt
	addl	$4, %esp
	movl	$1, %eax
	retl
                                        # -- End function
	.section	.rdata,"dr"
L_formatString:                         # @formatString
	.ascii	"%d"


