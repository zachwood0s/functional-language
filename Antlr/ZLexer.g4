lexer grammar ZLexer;

IF : 'if';
THEN : 'then';
ELSE: 'else';
LET: 'let';
IN: 'in';

WS : [ \t\r\n]+ -> skip;
LOWERCASE_ID : LOWER_CHAR ID_CHAR*;
UPPERCASE_ID : UPPER_CHAR ID_CHAR*;

fragment UPPER_CHAR   : [A-Z];
fragment LOWER_CHAR   : [a-z];
fragment ID_CHAR      : UPPER_CHAR | LOWER_CHAR | [_];

INT : DIGIT+;

fragment DIGIT : [0-9];

PLUS: '+';
MINUS: '-';
DIVIDE: '/';
TIMES: '*';
MOD: '%';

LOGICAL_AND : '&&';
LOGICAL_OR : '||';

GTE: '>=';
GT: '>';
LTE: '<=';
LT: '<';
EQ: '==';
NEQ: '!=';

ASSIGN: '=';

SINGLE_ARROW: '->';
DOUBLE_COLON: '::';
COLON: ':';
COMMA: ',';
LPAREN: '(';
RPAREN: ')';
DOT: '.';
SEMI_COLON: ';';