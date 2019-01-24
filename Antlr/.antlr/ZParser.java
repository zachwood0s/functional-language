// Generated from z:\Documents\Projects\C#\FunctionalLang\Antlr\ZParser.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ZParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		IF=1, THEN=2, ELSE=3, LET=4, IN=5, WS=6, LOWERCASE_ID=7, UPPERCASE_ID=8, 
		INT=9, CHARACTER_CONSTANT=10, PLUS=11, MINUS=12, DIVIDE=13, TIMES=14, 
		MOD=15, LOGICAL_AND=16, LOGICAL_OR=17, GTE=18, GT=19, LTE=20, LT=21, EQ=22, 
		NEQ=23, ASSIGN=24, SINGLE_ARROW=25, DOUBLE_COLON=26, COLON=27, COMMA=28, 
		LPAREN=29, RPAREN=30, DOT=31, SEMI_COLON=32, BLOCK_COMMENT=33, LINE_COMMENT=34;
	public static final int
		RULE_program = 0, RULE_definition = 1, RULE_globalDefinition = 2, RULE_functionDefinition = 3, 
		RULE_typeList = 4, RULE_functionBody = 5, RULE_parameterList = 6, RULE_expression = 7, 
		RULE_ifExpression = 8, RULE_functionCall = 9, RULE_usageParameterList = 10, 
		RULE_letExpression = 11, RULE_letList = 12, RULE_letItem = 13, RULE_assignmentListSeparator = 14, 
		RULE_assignment = 15, RULE_literalInt = 16, RULE_literalFloat = 17, RULE_literalChar = 18, 
		RULE_identifier = 19, RULE_typeDeclaration = 20, RULE_functionTypeDeclaration = 21, 
		RULE_variableTypeDeclaration = 22, RULE_type = 23, RULE_emptyType = 24, 
		RULE_identifierType = 25, RULE_functionType = 26, RULE_nestedFunctionType = 27;
	public static final String[] ruleNames = {
		"program", "definition", "globalDefinition", "functionDefinition", "typeList", 
		"functionBody", "parameterList", "expression", "ifExpression", "functionCall", 
		"usageParameterList", "letExpression", "letList", "letItem", "assignmentListSeparator", 
		"assignment", "literalInt", "literalFloat", "literalChar", "identifier", 
		"typeDeclaration", "functionTypeDeclaration", "variableTypeDeclaration", 
		"type", "emptyType", "identifierType", "functionType", "nestedFunctionType"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'if'", "'then'", "'else'", "'let'", "'in'", null, null, null, null, 
		null, "'+'", "'-'", "'/'", "'*'", "'%'", "'&&'", "'||'", "'>='", "'>'", 
		"'<='", "'<'", "'=='", "'!='", "'='", "'->'", "'::'", "':'", "','", "'('", 
		"')'", "'.'", "';'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "IF", "THEN", "ELSE", "LET", "IN", "WS", "LOWERCASE_ID", "UPPERCASE_ID", 
		"INT", "CHARACTER_CONSTANT", "PLUS", "MINUS", "DIVIDE", "TIMES", "MOD", 
		"LOGICAL_AND", "LOGICAL_OR", "GTE", "GT", "LTE", "LT", "EQ", "NEQ", "ASSIGN", 
		"SINGLE_ARROW", "DOUBLE_COLON", "COLON", "COMMA", "LPAREN", "RPAREN", 
		"DOT", "SEMI_COLON", "BLOCK_COMMENT", "LINE_COMMENT"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "ZParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public ZParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(ZParser.EOF, 0); }
		public List<TypeDeclarationContext> typeDeclaration() {
			return getRuleContexts(TypeDeclarationContext.class);
		}
		public TypeDeclarationContext typeDeclaration(int i) {
			return getRuleContext(TypeDeclarationContext.class,i);
		}
		public List<DefinitionContext> definition() {
			return getRuleContexts(DefinitionContext.class);
		}
		public DefinitionContext definition(int i) {
			return getRuleContext(DefinitionContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(60);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==LOWERCASE_ID) {
				{
				setState(58);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
				case 1:
					{
					setState(56);
					typeDeclaration();
					}
					break;
				case 2:
					{
					setState(57);
					definition();
					}
					break;
				}
				}
				setState(62);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(63);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DefinitionContext extends ParserRuleContext {
		public FunctionDefinitionContext functionDefinition() {
			return getRuleContext(FunctionDefinitionContext.class,0);
		}
		public GlobalDefinitionContext globalDefinition() {
			return getRuleContext(GlobalDefinitionContext.class,0);
		}
		public DefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_definition; }
	}

	public final DefinitionContext definition() throws RecognitionException {
		DefinitionContext _localctx = new DefinitionContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_definition);
		try {
			setState(67);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(65);
				functionDefinition();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(66);
				globalDefinition();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class GlobalDefinitionContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(ZParser.ASSIGN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public GlobalDefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_globalDefinition; }
	}

	public final GlobalDefinitionContext globalDefinition() throws RecognitionException {
		GlobalDefinitionContext _localctx = new GlobalDefinitionContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_globalDefinition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(69);
			identifier();
			setState(70);
			match(ASSIGN);
			setState(71);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionDefinitionContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode LPAREN() { return getToken(ZParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(ZParser.RPAREN, 0); }
		public TerminalNode ASSIGN() { return getToken(ZParser.ASSIGN, 0); }
		public FunctionBodyContext functionBody() {
			return getRuleContext(FunctionBodyContext.class,0);
		}
		public ParameterListContext parameterList() {
			return getRuleContext(ParameterListContext.class,0);
		}
		public FunctionDefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionDefinition; }
	}

	public final FunctionDefinitionContext functionDefinition() throws RecognitionException {
		FunctionDefinitionContext _localctx = new FunctionDefinitionContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_functionDefinition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(73);
			identifier();
			setState(74);
			match(LPAREN);
			setState(76);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LOWERCASE_ID) {
				{
				setState(75);
				parameterList();
				}
			}

			setState(78);
			match(RPAREN);
			setState(79);
			match(ASSIGN);
			setState(80);
			functionBody();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeListContext extends ParserRuleContext {
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZParser.COMMA, i);
		}
		public TypeListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typeList; }
	}

	public final TypeListContext typeList() throws RecognitionException {
		TypeListContext _localctx = new TypeListContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_typeList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(82);
			type();
			setState(87);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(83);
				match(COMMA);
				setState(84);
				type();
				}
				}
				setState(89);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionBodyContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public FunctionBodyContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionBody; }
	}

	public final FunctionBodyContext functionBody() throws RecognitionException {
		FunctionBodyContext _localctx = new FunctionBodyContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_functionBody);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(90);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterListContext extends ParserRuleContext {
		public List<IdentifierContext> identifier() {
			return getRuleContexts(IdentifierContext.class);
		}
		public IdentifierContext identifier(int i) {
			return getRuleContext(IdentifierContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZParser.COMMA, i);
		}
		public ParameterListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterList; }
	}

	public final ParameterListContext parameterList() throws RecognitionException {
		ParameterListContext _localctx = new ParameterListContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_parameterList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(92);
			identifier();
			setState(97);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(93);
				match(COMMA);
				setState(94);
				identifier();
				}
				}
				setState(99);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class IdentExprContext extends ExpressionContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public IdentExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class UnaryExprContext extends ExpressionContext {
		public Token op;
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode MINUS() { return getToken(ZParser.MINUS, 0); }
		public UnaryExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class OpExprContext extends ExpressionContext {
		public Token op;
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode TIMES() { return getToken(ZParser.TIMES, 0); }
		public TerminalNode DIVIDE() { return getToken(ZParser.DIVIDE, 0); }
		public TerminalNode MOD() { return getToken(ZParser.MOD, 0); }
		public TerminalNode PLUS() { return getToken(ZParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(ZParser.MINUS, 0); }
		public TerminalNode LT() { return getToken(ZParser.LT, 0); }
		public TerminalNode LTE() { return getToken(ZParser.LTE, 0); }
		public TerminalNode GT() { return getToken(ZParser.GT, 0); }
		public TerminalNode GTE() { return getToken(ZParser.GTE, 0); }
		public TerminalNode EQ() { return getToken(ZParser.EQ, 0); }
		public TerminalNode NEQ() { return getToken(ZParser.NEQ, 0); }
		public TerminalNode LOGICAL_AND() { return getToken(ZParser.LOGICAL_AND, 0); }
		public TerminalNode LOGICAL_OR() { return getToken(ZParser.LOGICAL_OR, 0); }
		public OpExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class LiteralCharExprContext extends ExpressionContext {
		public LiteralCharContext literalChar() {
			return getRuleContext(LiteralCharContext.class,0);
		}
		public LiteralCharExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class FunctionCallExprContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public FunctionCallExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class IfExprContext extends ExpressionContext {
		public IfExpressionContext ifExpression() {
			return getRuleContext(IfExpressionContext.class,0);
		}
		public IfExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class LiteralFloatExprContext extends ExpressionContext {
		public LiteralFloatContext literalFloat() {
			return getRuleContext(LiteralFloatContext.class,0);
		}
		public LiteralFloatExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class TypeCastExprContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode DOUBLE_COLON() { return getToken(ZParser.DOUBLE_COLON, 0); }
		public IdentifierTypeContext identifierType() {
			return getRuleContext(IdentifierTypeContext.class,0);
		}
		public TypeCastExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class LiteralIntExprContext extends ExpressionContext {
		public LiteralIntContext literalInt() {
			return getRuleContext(LiteralIntContext.class,0);
		}
		public LiteralIntExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class LetExprContext extends ExpressionContext {
		public LetExpressionContext letExpression() {
			return getRuleContext(LetExpressionContext.class,0);
		}
		public LetExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}
	public static class ParenExprContext extends ExpressionContext {
		public TerminalNode LPAREN() { return getToken(ZParser.LPAREN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode RPAREN() { return getToken(ZParser.RPAREN, 0); }
		public ParenExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 14;
		enterRecursionRule(_localctx, 14, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				{
				_localctx = new UnaryExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(101);
				((UnaryExprContext)_localctx).op = match(MINUS);
				setState(102);
				expression(14);
				}
				break;
			case 2:
				{
				_localctx = new IfExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(103);
				ifExpression();
				}
				break;
			case 3:
				{
				_localctx = new LetExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(104);
				letExpression();
				}
				break;
			case 4:
				{
				_localctx = new LiteralCharExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(105);
				literalChar();
				}
				break;
			case 5:
				{
				_localctx = new LiteralIntExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(106);
				literalInt();
				}
				break;
			case 6:
				{
				_localctx = new LiteralFloatExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(107);
				literalFloat();
				}
				break;
			case 7:
				{
				_localctx = new IdentExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(108);
				identifier();
				}
				break;
			case 8:
				{
				_localctx = new ParenExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(109);
				match(LPAREN);
				setState(110);
				expression(0);
				setState(111);
				match(RPAREN);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(137);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(135);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
					case 1:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(115);
						if (!(precpred(_ctx, 13))) throw new FailedPredicateException(this, "precpred(_ctx, 13)");
						setState(116);
						((OpExprContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << DIVIDE) | (1L << TIMES) | (1L << MOD))) != 0)) ) {
							((OpExprContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(117);
						expression(14);
						}
						break;
					case 2:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(118);
						if (!(precpred(_ctx, 12))) throw new FailedPredicateException(this, "precpred(_ctx, 12)");
						setState(119);
						((OpExprContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
							((OpExprContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(120);
						expression(13);
						}
						break;
					case 3:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(121);
						if (!(precpred(_ctx, 10))) throw new FailedPredicateException(this, "precpred(_ctx, 10)");
						setState(122);
						((OpExprContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << GTE) | (1L << GT) | (1L << LTE) | (1L << LT) | (1L << EQ) | (1L << NEQ))) != 0)) ) {
							((OpExprContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(123);
						expression(11);
						}
						break;
					case 4:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(124);
						if (!(precpred(_ctx, 9))) throw new FailedPredicateException(this, "precpred(_ctx, 9)");
						setState(125);
						((OpExprContext)_localctx).op = match(LOGICAL_AND);
						setState(126);
						expression(10);
						}
						break;
					case 5:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(127);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(128);
						((OpExprContext)_localctx).op = match(LOGICAL_OR);
						setState(129);
						expression(9);
						}
						break;
					case 6:
						{
						_localctx = new FunctionCallExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(130);
						if (!(precpred(_ctx, 15))) throw new FailedPredicateException(this, "precpred(_ctx, 15)");
						setState(131);
						functionCall();
						}
						break;
					case 7:
						{
						_localctx = new TypeCastExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(132);
						if (!(precpred(_ctx, 11))) throw new FailedPredicateException(this, "precpred(_ctx, 11)");
						setState(133);
						match(DOUBLE_COLON);
						setState(134);
						identifierType();
						}
						break;
					}
					} 
				}
				setState(139);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class IfExpressionContext extends ParserRuleContext {
		public TerminalNode IF() { return getToken(ZParser.IF, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode THEN() { return getToken(ZParser.THEN, 0); }
		public TerminalNode ELSE() { return getToken(ZParser.ELSE, 0); }
		public IfExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifExpression; }
	}

	public final IfExpressionContext ifExpression() throws RecognitionException {
		IfExpressionContext _localctx = new IfExpressionContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_ifExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(140);
			match(IF);
			setState(141);
			expression(0);
			setState(142);
			match(THEN);
			setState(143);
			expression(0);
			setState(144);
			match(ELSE);
			setState(145);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionCallContext extends ParserRuleContext {
		public TerminalNode LPAREN() { return getToken(ZParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(ZParser.RPAREN, 0); }
		public UsageParameterListContext usageParameterList() {
			return getRuleContext(UsageParameterListContext.class,0);
		}
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_functionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(147);
			match(LPAREN);
			setState(149);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << IF) | (1L << LET) | (1L << LOWERCASE_ID) | (1L << INT) | (1L << CHARACTER_CONSTANT) | (1L << MINUS) | (1L << LPAREN))) != 0)) {
				{
				setState(148);
				usageParameterList();
				}
			}

			setState(151);
			match(RPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class UsageParameterListContext extends ParserRuleContext {
		public ExpressionContext expression;
		public List<ExpressionContext> list = new ArrayList<ExpressionContext>();
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(ZParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(ZParser.COMMA, i);
		}
		public UsageParameterListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_usageParameterList; }
	}

	public final UsageParameterListContext usageParameterList() throws RecognitionException {
		UsageParameterListContext _localctx = new UsageParameterListContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_usageParameterList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(153);
			((UsageParameterListContext)_localctx).expression = expression(0);
			((UsageParameterListContext)_localctx).list.add(((UsageParameterListContext)_localctx).expression);
			setState(158);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(154);
				match(COMMA);
				setState(155);
				((UsageParameterListContext)_localctx).expression = expression(0);
				((UsageParameterListContext)_localctx).list.add(((UsageParameterListContext)_localctx).expression);
				}
				}
				setState(160);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LetExpressionContext extends ParserRuleContext {
		public TerminalNode LET() { return getToken(ZParser.LET, 0); }
		public LetListContext letList() {
			return getRuleContext(LetListContext.class,0);
		}
		public TerminalNode IN() { return getToken(ZParser.IN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public LetExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_letExpression; }
	}

	public final LetExpressionContext letExpression() throws RecognitionException {
		LetExpressionContext _localctx = new LetExpressionContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_letExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(161);
			match(LET);
			setState(162);
			letList();
			setState(163);
			match(IN);
			setState(164);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LetListContext extends ParserRuleContext {
		public LetItemContext letItem;
		public List<LetItemContext> list = new ArrayList<LetItemContext>();
		public List<LetItemContext> letItem() {
			return getRuleContexts(LetItemContext.class);
		}
		public LetItemContext letItem(int i) {
			return getRuleContext(LetItemContext.class,i);
		}
		public List<AssignmentListSeparatorContext> assignmentListSeparator() {
			return getRuleContexts(AssignmentListSeparatorContext.class);
		}
		public AssignmentListSeparatorContext assignmentListSeparator(int i) {
			return getRuleContext(AssignmentListSeparatorContext.class,i);
		}
		public LetListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_letList; }
	}

	public final LetListContext letList() throws RecognitionException {
		LetListContext _localctx = new LetListContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_letList);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			((LetListContext)_localctx).letItem = letItem();
			((LetListContext)_localctx).list.add(((LetListContext)_localctx).letItem);
			setState(173);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(168);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==SEMI_COLON) {
						{
						setState(167);
						assignmentListSeparator();
						}
					}

					setState(170);
					((LetListContext)_localctx).letItem = letItem();
					((LetListContext)_localctx).list.add(((LetListContext)_localctx).letItem);
					}
					} 
				}
				setState(175);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			}
			setState(177);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SEMI_COLON) {
				{
				setState(176);
				assignmentListSeparator();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LetItemContext extends ParserRuleContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public TypeDeclarationContext typeDeclaration() {
			return getRuleContext(TypeDeclarationContext.class,0);
		}
		public LetItemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_letItem; }
	}

	public final LetItemContext letItem() throws RecognitionException {
		LetItemContext _localctx = new LetItemContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_letItem);
		try {
			setState(181);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(179);
				assignment();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(180);
				typeDeclaration();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentListSeparatorContext extends ParserRuleContext {
		public TerminalNode SEMI_COLON() { return getToken(ZParser.SEMI_COLON, 0); }
		public AssignmentListSeparatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignmentListSeparator; }
	}

	public final AssignmentListSeparatorContext assignmentListSeparator() throws RecognitionException {
		AssignmentListSeparatorContext _localctx = new AssignmentListSeparatorContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_assignmentListSeparator);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(183);
			match(SEMI_COLON);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(ZParser.ASSIGN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(185);
			identifier();
			setState(186);
			match(ASSIGN);
			setState(187);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LiteralIntContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(ZParser.INT, 0); }
		public LiteralIntContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literalInt; }
	}

	public final LiteralIntContext literalInt() throws RecognitionException {
		LiteralIntContext _localctx = new LiteralIntContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_literalInt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(189);
			match(INT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LiteralFloatContext extends ParserRuleContext {
		public List<TerminalNode> INT() { return getTokens(ZParser.INT); }
		public TerminalNode INT(int i) {
			return getToken(ZParser.INT, i);
		}
		public TerminalNode DOT() { return getToken(ZParser.DOT, 0); }
		public LiteralFloatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literalFloat; }
	}

	public final LiteralFloatContext literalFloat() throws RecognitionException {
		LiteralFloatContext _localctx = new LiteralFloatContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_literalFloat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(191);
			match(INT);
			setState(192);
			match(DOT);
			setState(193);
			match(INT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LiteralCharContext extends ParserRuleContext {
		public TerminalNode CHARACTER_CONSTANT() { return getToken(ZParser.CHARACTER_CONSTANT, 0); }
		public LiteralCharContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literalChar; }
	}

	public final LiteralCharContext literalChar() throws RecognitionException {
		LiteralCharContext _localctx = new LiteralCharContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_literalChar);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			match(CHARACTER_CONSTANT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdentifierContext extends ParserRuleContext {
		public TerminalNode LOWERCASE_ID() { return getToken(ZParser.LOWERCASE_ID, 0); }
		public IdentifierContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_identifier; }
	}

	public final IdentifierContext identifier() throws RecognitionException {
		IdentifierContext _localctx = new IdentifierContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_identifier);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(197);
			match(LOWERCASE_ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeDeclarationContext extends ParserRuleContext {
		public FunctionTypeDeclarationContext functionTypeDeclaration() {
			return getRuleContext(FunctionTypeDeclarationContext.class,0);
		}
		public VariableTypeDeclarationContext variableTypeDeclaration() {
			return getRuleContext(VariableTypeDeclarationContext.class,0);
		}
		public TypeDeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typeDeclaration; }
	}

	public final TypeDeclarationContext typeDeclaration() throws RecognitionException {
		TypeDeclarationContext _localctx = new TypeDeclarationContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_typeDeclaration);
		try {
			setState(201);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(199);
				functionTypeDeclaration();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(200);
				variableTypeDeclaration();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionTypeDeclarationContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode COLON() { return getToken(ZParser.COLON, 0); }
		public FunctionTypeContext functionType() {
			return getRuleContext(FunctionTypeContext.class,0);
		}
		public FunctionTypeDeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionTypeDeclaration; }
	}

	public final FunctionTypeDeclarationContext functionTypeDeclaration() throws RecognitionException {
		FunctionTypeDeclarationContext _localctx = new FunctionTypeDeclarationContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_functionTypeDeclaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(203);
			identifier();
			setState(204);
			match(COLON);
			setState(205);
			functionType();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariableTypeDeclarationContext extends ParserRuleContext {
		public IdentifierContext identifier() {
			return getRuleContext(IdentifierContext.class,0);
		}
		public TerminalNode COLON() { return getToken(ZParser.COLON, 0); }
		public IdentifierTypeContext identifierType() {
			return getRuleContext(IdentifierTypeContext.class,0);
		}
		public VariableTypeDeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variableTypeDeclaration; }
	}

	public final VariableTypeDeclarationContext variableTypeDeclaration() throws RecognitionException {
		VariableTypeDeclarationContext _localctx = new VariableTypeDeclarationContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_variableTypeDeclaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(207);
			identifier();
			setState(208);
			match(COLON);
			setState(209);
			identifierType();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeContext extends ParserRuleContext {
		public IdentifierTypeContext identifierType() {
			return getRuleContext(IdentifierTypeContext.class,0);
		}
		public NestedFunctionTypeContext nestedFunctionType() {
			return getRuleContext(NestedFunctionTypeContext.class,0);
		}
		public EmptyTypeContext emptyType() {
			return getRuleContext(EmptyTypeContext.class,0);
		}
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_type);
		try {
			setState(214);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(211);
				identifierType();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(212);
				nestedFunctionType();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(213);
				emptyType();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class EmptyTypeContext extends ParserRuleContext {
		public TerminalNode LPAREN() { return getToken(ZParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(ZParser.RPAREN, 0); }
		public EmptyTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_emptyType; }
	}

	public final EmptyTypeContext emptyType() throws RecognitionException {
		EmptyTypeContext _localctx = new EmptyTypeContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_emptyType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(216);
			match(LPAREN);
			setState(217);
			match(RPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdentifierTypeContext extends ParserRuleContext {
		public TerminalNode UPPERCASE_ID() { return getToken(ZParser.UPPERCASE_ID, 0); }
		public IdentifierTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_identifierType; }
	}

	public final IdentifierTypeContext identifierType() throws RecognitionException {
		IdentifierTypeContext _localctx = new IdentifierTypeContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_identifierType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(219);
			match(UPPERCASE_ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionTypeContext extends ParserRuleContext {
		public TypeListContext typeList() {
			return getRuleContext(TypeListContext.class,0);
		}
		public TerminalNode SINGLE_ARROW() { return getToken(ZParser.SINGLE_ARROW, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public FunctionTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionType; }
	}

	public final FunctionTypeContext functionType() throws RecognitionException {
		FunctionTypeContext _localctx = new FunctionTypeContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_functionType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(221);
			typeList();
			setState(222);
			match(SINGLE_ARROW);
			setState(223);
			type();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NestedFunctionTypeContext extends ParserRuleContext {
		public TerminalNode LPAREN() { return getToken(ZParser.LPAREN, 0); }
		public FunctionTypeContext functionType() {
			return getRuleContext(FunctionTypeContext.class,0);
		}
		public TerminalNode RPAREN() { return getToken(ZParser.RPAREN, 0); }
		public NestedFunctionTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_nestedFunctionType; }
	}

	public final NestedFunctionTypeContext nestedFunctionType() throws RecognitionException {
		NestedFunctionTypeContext _localctx = new NestedFunctionTypeContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_nestedFunctionType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(225);
			match(LPAREN);
			setState(226);
			functionType();
			setState(227);
			match(RPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 7:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 13);
		case 1:
			return precpred(_ctx, 12);
		case 2:
			return precpred(_ctx, 10);
		case 3:
			return precpred(_ctx, 9);
		case 4:
			return precpred(_ctx, 8);
		case 5:
			return precpred(_ctx, 15);
		case 6:
			return precpred(_ctx, 11);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3$\u00e8\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\3\2\3\2\7\2=\n\2\f\2\16\2@\13"+
		"\2\3\2\3\2\3\3\3\3\5\3F\n\3\3\4\3\4\3\4\3\4\3\5\3\5\3\5\5\5O\n\5\3\5\3"+
		"\5\3\5\3\5\3\6\3\6\3\6\7\6X\n\6\f\6\16\6[\13\6\3\7\3\7\3\b\3\b\3\b\7\b"+
		"b\n\b\f\b\16\be\13\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3"+
		"\t\5\tt\n\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3"+
		"\t\3\t\3\t\3\t\3\t\3\t\7\t\u008a\n\t\f\t\16\t\u008d\13\t\3\n\3\n\3\n\3"+
		"\n\3\n\3\n\3\n\3\13\3\13\5\13\u0098\n\13\3\13\3\13\3\f\3\f\3\f\7\f\u009f"+
		"\n\f\f\f\16\f\u00a2\13\f\3\r\3\r\3\r\3\r\3\r\3\16\3\16\5\16\u00ab\n\16"+
		"\3\16\7\16\u00ae\n\16\f\16\16\16\u00b1\13\16\3\16\5\16\u00b4\n\16\3\17"+
		"\3\17\5\17\u00b8\n\17\3\20\3\20\3\21\3\21\3\21\3\21\3\22\3\22\3\23\3\23"+
		"\3\23\3\23\3\24\3\24\3\25\3\25\3\26\3\26\5\26\u00cc\n\26\3\27\3\27\3\27"+
		"\3\27\3\30\3\30\3\30\3\30\3\31\3\31\3\31\5\31\u00d9\n\31\3\32\3\32\3\32"+
		"\3\33\3\33\3\34\3\34\3\34\3\34\3\35\3\35\3\35\3\35\3\35\2\3\20\36\2\4"+
		"\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668\2\5\3\2\17\21"+
		"\3\2\r\16\3\2\24\31\2\u00e8\2>\3\2\2\2\4E\3\2\2\2\6G\3\2\2\2\bK\3\2\2"+
		"\2\nT\3\2\2\2\f\\\3\2\2\2\16^\3\2\2\2\20s\3\2\2\2\22\u008e\3\2\2\2\24"+
		"\u0095\3\2\2\2\26\u009b\3\2\2\2\30\u00a3\3\2\2\2\32\u00a8\3\2\2\2\34\u00b7"+
		"\3\2\2\2\36\u00b9\3\2\2\2 \u00bb\3\2\2\2\"\u00bf\3\2\2\2$\u00c1\3\2\2"+
		"\2&\u00c5\3\2\2\2(\u00c7\3\2\2\2*\u00cb\3\2\2\2,\u00cd\3\2\2\2.\u00d1"+
		"\3\2\2\2\60\u00d8\3\2\2\2\62\u00da\3\2\2\2\64\u00dd\3\2\2\2\66\u00df\3"+
		"\2\2\28\u00e3\3\2\2\2:=\5*\26\2;=\5\4\3\2<:\3\2\2\2<;\3\2\2\2=@\3\2\2"+
		"\2><\3\2\2\2>?\3\2\2\2?A\3\2\2\2@>\3\2\2\2AB\7\2\2\3B\3\3\2\2\2CF\5\b"+
		"\5\2DF\5\6\4\2EC\3\2\2\2ED\3\2\2\2F\5\3\2\2\2GH\5(\25\2HI\7\32\2\2IJ\5"+
		"\20\t\2J\7\3\2\2\2KL\5(\25\2LN\7\37\2\2MO\5\16\b\2NM\3\2\2\2NO\3\2\2\2"+
		"OP\3\2\2\2PQ\7 \2\2QR\7\32\2\2RS\5\f\7\2S\t\3\2\2\2TY\5\60\31\2UV\7\36"+
		"\2\2VX\5\60\31\2WU\3\2\2\2X[\3\2\2\2YW\3\2\2\2YZ\3\2\2\2Z\13\3\2\2\2["+
		"Y\3\2\2\2\\]\5\20\t\2]\r\3\2\2\2^c\5(\25\2_`\7\36\2\2`b\5(\25\2a_\3\2"+
		"\2\2be\3\2\2\2ca\3\2\2\2cd\3\2\2\2d\17\3\2\2\2ec\3\2\2\2fg\b\t\1\2gh\7"+
		"\16\2\2ht\5\20\t\20it\5\22\n\2jt\5\30\r\2kt\5&\24\2lt\5\"\22\2mt\5$\23"+
		"\2nt\5(\25\2op\7\37\2\2pq\5\20\t\2qr\7 \2\2rt\3\2\2\2sf\3\2\2\2si\3\2"+
		"\2\2sj\3\2\2\2sk\3\2\2\2sl\3\2\2\2sm\3\2\2\2sn\3\2\2\2so\3\2\2\2t\u008b"+
		"\3\2\2\2uv\f\17\2\2vw\t\2\2\2w\u008a\5\20\t\20xy\f\16\2\2yz\t\3\2\2z\u008a"+
		"\5\20\t\17{|\f\f\2\2|}\t\4\2\2}\u008a\5\20\t\r~\177\f\13\2\2\177\u0080"+
		"\7\22\2\2\u0080\u008a\5\20\t\f\u0081\u0082\f\n\2\2\u0082\u0083\7\23\2"+
		"\2\u0083\u008a\5\20\t\13\u0084\u0085\f\21\2\2\u0085\u008a\5\24\13\2\u0086"+
		"\u0087\f\r\2\2\u0087\u0088\7\34\2\2\u0088\u008a\5\64\33\2\u0089u\3\2\2"+
		"\2\u0089x\3\2\2\2\u0089{\3\2\2\2\u0089~\3\2\2\2\u0089\u0081\3\2\2\2\u0089"+
		"\u0084\3\2\2\2\u0089\u0086\3\2\2\2\u008a\u008d\3\2\2\2\u008b\u0089\3\2"+
		"\2\2\u008b\u008c\3\2\2\2\u008c\21\3\2\2\2\u008d\u008b\3\2\2\2\u008e\u008f"+
		"\7\3\2\2\u008f\u0090\5\20\t\2\u0090\u0091\7\4\2\2\u0091\u0092\5\20\t\2"+
		"\u0092\u0093\7\5\2\2\u0093\u0094\5\20\t\2\u0094\23\3\2\2\2\u0095\u0097"+
		"\7\37\2\2\u0096\u0098\5\26\f\2\u0097\u0096\3\2\2\2\u0097\u0098\3\2\2\2"+
		"\u0098\u0099\3\2\2\2\u0099\u009a\7 \2\2\u009a\25\3\2\2\2\u009b\u00a0\5"+
		"\20\t\2\u009c\u009d\7\36\2\2\u009d\u009f\5\20\t\2\u009e\u009c\3\2\2\2"+
		"\u009f\u00a2\3\2\2\2\u00a0\u009e\3\2\2\2\u00a0\u00a1\3\2\2\2\u00a1\27"+
		"\3\2\2\2\u00a2\u00a0\3\2\2\2\u00a3\u00a4\7\6\2\2\u00a4\u00a5\5\32\16\2"+
		"\u00a5\u00a6\7\7\2\2\u00a6\u00a7\5\20\t\2\u00a7\31\3\2\2\2\u00a8\u00af"+
		"\5\34\17\2\u00a9\u00ab\5\36\20\2\u00aa\u00a9\3\2\2\2\u00aa\u00ab\3\2\2"+
		"\2\u00ab\u00ac\3\2\2\2\u00ac\u00ae\5\34\17\2\u00ad\u00aa\3\2\2\2\u00ae"+
		"\u00b1\3\2\2\2\u00af\u00ad\3\2\2\2\u00af\u00b0\3\2\2\2\u00b0\u00b3\3\2"+
		"\2\2\u00b1\u00af\3\2\2\2\u00b2\u00b4\5\36\20\2\u00b3\u00b2\3\2\2\2\u00b3"+
		"\u00b4\3\2\2\2\u00b4\33\3\2\2\2\u00b5\u00b8\5 \21\2\u00b6\u00b8\5*\26"+
		"\2\u00b7\u00b5\3\2\2\2\u00b7\u00b6\3\2\2\2\u00b8\35\3\2\2\2\u00b9\u00ba"+
		"\7\"\2\2\u00ba\37\3\2\2\2\u00bb\u00bc\5(\25\2\u00bc\u00bd\7\32\2\2\u00bd"+
		"\u00be\5\20\t\2\u00be!\3\2\2\2\u00bf\u00c0\7\13\2\2\u00c0#\3\2\2\2\u00c1"+
		"\u00c2\7\13\2\2\u00c2\u00c3\7!\2\2\u00c3\u00c4\7\13\2\2\u00c4%\3\2\2\2"+
		"\u00c5\u00c6\7\f\2\2\u00c6\'\3\2\2\2\u00c7\u00c8\7\t\2\2\u00c8)\3\2\2"+
		"\2\u00c9\u00cc\5,\27\2\u00ca\u00cc\5.\30\2\u00cb\u00c9\3\2\2\2\u00cb\u00ca"+
		"\3\2\2\2\u00cc+\3\2\2\2\u00cd\u00ce\5(\25\2\u00ce\u00cf\7\35\2\2\u00cf"+
		"\u00d0\5\66\34\2\u00d0-\3\2\2\2\u00d1\u00d2\5(\25\2\u00d2\u00d3\7\35\2"+
		"\2\u00d3\u00d4\5\64\33\2\u00d4/\3\2\2\2\u00d5\u00d9\5\64\33\2\u00d6\u00d9"+
		"\58\35\2\u00d7\u00d9\5\62\32\2\u00d8\u00d5\3\2\2\2\u00d8\u00d6\3\2\2\2"+
		"\u00d8\u00d7\3\2\2\2\u00d9\61\3\2\2\2\u00da\u00db\7\37\2\2\u00db\u00dc"+
		"\7 \2\2\u00dc\63\3\2\2\2\u00dd\u00de\7\n\2\2\u00de\65\3\2\2\2\u00df\u00e0"+
		"\5\n\6\2\u00e0\u00e1\7\33\2\2\u00e1\u00e2\5\60\31\2\u00e2\67\3\2\2\2\u00e3"+
		"\u00e4\7\37\2\2\u00e4\u00e5\5\66\34\2\u00e5\u00e6\7 \2\2\u00e69\3\2\2"+
		"\2\23<>ENYcs\u0089\u008b\u0097\u00a0\u00aa\u00af\u00b3\u00b7\u00cb\u00d8";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}