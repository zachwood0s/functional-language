grammar Z;

program: 'hello' part;

part : INT | dec;
dec : INT '.' INT;

INT : DIGIT+;
fragment DIGIT : [0-9];

WS : [ \t\r\n] -> skip;
