parser grammar ZParser;

options {tokenVocab = ZLexer;}

program : (typeDeclaration|definition)* EOF;

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
  | op = MINUS expression                               #unaryExpr
  | expression op = (TIMES | DIVIDE | MOD) expression   #opExpr
  | expression op = (PLUS | MINUS) expression           #opExpr
  | expression DOUBLE_COLON identifierType              #typeCastExpr
  | expression op = (LT | LTE | GT | GTE | EQ | NEQ) expression               #opExpr
  | expression op = LOGICAL_AND expression              #opExpr
  | expression op = LOGICAL_OR expression               #opExpr
  | ifExpression                                        #ifExpr
  | letExpression                                       #letExpr
  | literalChar                                         #literalCharExpr
  | literalInt                                          #literalIntExpr
  | literalFloat                                        #literalFloatExpr
  | identifier                                          #identExpr
  | LPAREN expression RPAREN                            #parenExpr
  ;

ifExpression
  : IF expression THEN expression ELSE expression
  ;

functionCall 
  : LPAREN usageParameterList? RPAREN
  ;

usageParameterList 
  : list += expression (COMMA list += expression)*
  ;


// Let expression

letExpression
  : LET letList IN expression
  ;

letList
  : list += letItem 
    (assignmentListSeparator? list += letItem)* 
    assignmentListSeparator?
  ;

letItem 
  : assignment | typeDeclaration
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

literalChar
  : CHARACTER_CONSTANT
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
