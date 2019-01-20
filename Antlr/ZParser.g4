parser grammar ZParser;

options {tokenVocab = ZLexer;}

program : (typeDeclaration|definition)*;

definition 
  : functionDefinition | globalDefinition
  ;

globalDefinition
  : identifier ASSIGN expression
  ;

// Functions

functionDefinition 
  : identifier LPAREN parameterList? RPAREN ASSIGN functionBody
  ;

typeList 
  : type (COMMA type)*
  ;


functionBody 
  : expression
  ;

parameterList 
  : identifier(COMMA identifier)*
  ;


// Expressions

expression 
  : expression functionCall                             #functionCallExpr
  | unary                                               #unaryExpr
  | expression op = (TIMES | DIVIDE | MOD) expression   #opExpr
  | expression op = (PLUS | MINUS) expression           #opExpr
  | expression op = typeCast                            #typeCastExpr
  | expression op = comparison expression               #opExpr
  | expression op = LOGICAL_AND expression              #opExpr
  | expression op = LOGICAL_OR expression               #opExpr
  | ifExpression                                        #ifExpr
  | letExpression                                       #letExpr
  | literalInt                                          #literalIntExpr
  | literalFloat                                        #literalFloatExpr
  | identifier                                          #identExpr
  | LPAREN expression RPAREN                            #parenExpr
  ;

unary
  : MINUS expression
  ;

typeCast
  : DOUBLE_COLON identifierType
  ;

comparison
  : (LT | LTE | GT | GTE | EQ | NEQ)
  ;

ifExpression
  : IF expression THEN expression ELSE expression
  ;

functionCall 
  : LPAREN usageParameterList? RPAREN
  ;

usageParameterList
  : identifier (COMMA identifier)*
  ;


// Let expression

letExpression
  : LET assignmentList IN expression
  ;

assignmentList
  : (assignment | typeDeclaration) 
    (assignmentListSeparator? (assignment | typeDeclaration))* 
    assignmentListSeparator?
  ;

assignmentListSeparator
  : SEMI_COLON
  ;

assignment
  : identifier ASSIGN expression
  ;

literalInt 
  : INT
  ;

literalFloat 
  : INT DOT INT
  ;

identifier 
  : LOWERCASE_ID
  ;

// TYPES

typeDeclaration
  : functionTypeDeclaration | variableTypeDeclaration
  ;

functionTypeDeclaration 
  : identifier COLON functionType
  ;

variableTypeDeclaration
  : identifier COLON identifierType
  ;

type 
  : identifierType | nestedFunctionType | emptyType
  ;

emptyType
  : LPAREN RPAREN
  ;

identifierType 
  : UPPERCASE_ID
  ;

functionType
  : typeList SINGLE_ARROW type
  ;

nestedFunctionType 
  : LPAREN functionType RPAREN
  ;
