parser grammar ZParser;

options {tokenVocab = ZLexer;}

program : importList? module? (typeDeclaration|definition)* EOF;

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

// Modules

importList
  : list += importItem 
    (importListSeparator? list += importItem)*
    importListSeparator?
  ;

importListSeparator
  : COMMA
  ;

importItem
  : IMPORT importName (AS UPPERCASE_ID)?
  ;

importName
  : UPPERCASE_ID (DOT UPPERCASE_ID)*;

module
  : EXPORT LBRACKET exportList RBRACKET AS UPPERCASE_ID
  ;

exportList
  : list += exportItem 
    (exportListSeparator? list += exportItem)*
    exportListSeparator?
  ;

exportListSeparator
  : COMMA
  ;

exportItem
  : UPPERCASE_ID | LOWERCASE_ID
  ;

// Traits

trait
  : TRAIT identifierType LBRACKET traitList RBRACKET
  ;

traitList
  : list += functionTypeDeclaration
    (traitListSeparator? list += functionTypeDeclaration)*
    traitListSeparator?
  ;

traitListSeparator
  : COMMA
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
  | largeIdentifier                                     #largeIdentifierExpr
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

largeIdentifier
  : UPPERCASE_ID (DOT UPPERCASE_ID)* (DOT LOWERCASE_ID)?
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
