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
		IF=1, THEN=2, ELSE=3, LET=4, IN=5, EXPORT=6, IMPORT=7, AS=8, TRAIT=9, 
		WITH=10, WS=11, LOWERCASE_ID=12, UPPERCASE_ID=13, INT=14, CHARACTER_CONSTANT=15, 
		PLUS=16, MINUS=17, DIVIDE=18, TIMES=19, MOD=20, LOGICAL_AND=21, LOGICAL_OR=22, 
		GTE=23, GT=24, LTE=25, LT=26, EQ=27, NEQ=28, ASSIGN=29, SINGLE_ARROW=30, 
		DOUBLE_COLON=31, COLON=32, COMMA=33, LPAREN=34, RPAREN=35, LBRACKET=36, 
		RBRACKET=37, DOT=38, SEMI_COLON=39, BLOCK_COMMENT=40, LINE_COMMENT=41;
	public static final int
		RULE_program = 0, RULE_definition = 1, RULE_globalDefinition = 2, RULE_functionDefinition = 3, 
		RULE_typeList = 4, RULE_functionBody = 5, RULE_parameterList = 6, RULE_importList = 7, 
		RULE_importListSeparator = 8, RULE_importItem = 9, RULE_importName = 10, 
		RULE_module = 11, RULE_exportList = 12, RULE_exportListSeparator = 13, 
		RULE_exportItem = 14, RULE_trait = 15, RULE_traitList = 16, RULE_traitListSeparator = 17, 
		RULE_expression = 18, RULE_ifExpression = 19, RULE_functionCall = 20, 
		RULE_usageParameterList = 21, RULE_largeIdentifier = 22, RULE_letExpression = 23, 
		RULE_letList = 24, RULE_letItem = 25, RULE_assignmentListSeparator = 26, 
		RULE_assignment = 27, RULE_literalInt = 28, RULE_literalFloat = 29, RULE_literalChar = 30, 
		RULE_identifier = 31, RULE_typeDeclaration = 32, RULE_functionTypeDeclaration = 33, 
		RULE_variableTypeDeclaration = 34, RULE_type = 35, RULE_emptyType = 36, 
		RULE_identifierType = 37, RULE_functionType = 38, RULE_nestedFunctionType = 39;
	public static final String[] ruleNames = {
		"program", "definition", "globalDefinition", "functionDefinition", "typeList", 
		"functionBody", "parameterList", "importList", "importListSeparator", 
		"importItem", "importName", "module", "exportList", "exportListSeparator", 
		"exportItem", "trait", "traitList", "traitListSeparator", "expression", 
		"ifExpression", "functionCall", "usageParameterList", "largeIdentifier", 
		"letExpression", "letList", "letItem", "assignmentListSeparator", "assignment", 
		"literalInt", "literalFloat", "literalChar", "identifier", "typeDeclaration", 
		"functionTypeDeclaration", "variableTypeDeclaration", "type", "emptyType", 
		"identifierType", "functionType", "nestedFunctionType"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'if'", "'then'", "'else'", "'let'", "'in'", "'export'", "'import'", 
		"'as'", "'trait'", "'with'", null, null, null, null, null, "'+'", "'-'", 
		"'/'", "'*'", "'%'", "'&&'", "'||'", "'>='", "'>'", "'<='", "'<'", "'=='", 
		"'!='", "'='", "'->'", "'::'", "':'", "','", "'('", "')'", "'{'", "'}'", 
		"'.'", "';'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "IF", "THEN", "ELSE", "LET", "IN", "EXPORT", "IMPORT", "AS", "TRAIT", 
		"WITH", "WS", "LOWERCASE_ID", "UPPERCASE_ID", "INT", "CHARACTER_CONSTANT", 
		"PLUS", "MINUS", "DIVIDE", "TIMES", "MOD", "LOGICAL_AND", "LOGICAL_OR", 
		"GTE", "GT", "LTE", "LT", "EQ", "NEQ", "ASSIGN", "SINGLE_ARROW", "DOUBLE_COLON", 
		"COLON", "COMMA", "LPAREN", "RPAREN", "LBRACKET", "RBRACKET", "DOT", "SEMI_COLON", 
		"BLOCK_COMMENT", "LINE_COMMENT"
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
		public ImportListContext importList() {
			return getRuleContext(ImportListContext.class,0);
		}
		public ModuleContext module() {
			return getRuleContext(ModuleContext.class,0);
		}
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
			setState(81);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==IMPORT) {
				{
				setState(80);
				importList();
				}
			}

			setState(84);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==EXPORT) {
				{
				setState(83);
				module();
				}
			}

			setState(90);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==LOWERCASE_ID) {
				{
				setState(88);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
				case 1:
					{
					setState(86);
					typeDeclaration();
					}
					break;
				case 2:
					{
					setState(87);
					definition();
					}
					break;
				}
				}
				setState(92);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(93);
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
			setState(97);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(95);
				functionDefinition();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(96);
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
			setState(99);
			identifier();
			setState(100);
			match(ASSIGN);
			setState(101);
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
			setState(103);
			identifier();
			setState(104);
			match(LPAREN);
			setState(106);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LOWERCASE_ID) {
				{
				setState(105);
				parameterList();
				}
			}

			setState(108);
			match(RPAREN);
			setState(109);
			match(ASSIGN);
			setState(110);
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
			setState(112);
			type();
			setState(117);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(113);
				match(COMMA);
				setState(114);
				type();
				}
				}
				setState(119);
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
			setState(120);
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
			setState(122);
			identifier();
			setState(127);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(123);
				match(COMMA);
				setState(124);
				identifier();
				}
				}
				setState(129);
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

	public static class ImportListContext extends ParserRuleContext {
		public ImportItemContext importItem;
		public List<ImportItemContext> list = new ArrayList<ImportItemContext>();
		public List<ImportItemContext> importItem() {
			return getRuleContexts(ImportItemContext.class);
		}
		public ImportItemContext importItem(int i) {
			return getRuleContext(ImportItemContext.class,i);
		}
		public List<ImportListSeparatorContext> importListSeparator() {
			return getRuleContexts(ImportListSeparatorContext.class);
		}
		public ImportListSeparatorContext importListSeparator(int i) {
			return getRuleContext(ImportListSeparatorContext.class,i);
		}
		public ImportListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_importList; }
	}

	public final ImportListContext importList() throws RecognitionException {
		ImportListContext _localctx = new ImportListContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_importList);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			((ImportListContext)_localctx).importItem = importItem();
			((ImportListContext)_localctx).list.add(((ImportListContext)_localctx).importItem);
			setState(137);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(132);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==COMMA) {
						{
						setState(131);
						importListSeparator();
						}
					}

					setState(134);
					((ImportListContext)_localctx).importItem = importItem();
					((ImportListContext)_localctx).list.add(((ImportListContext)_localctx).importItem);
					}
					} 
				}
				setState(139);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
			}
			setState(141);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COMMA) {
				{
				setState(140);
				importListSeparator();
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

	public static class ImportListSeparatorContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(ZParser.COMMA, 0); }
		public ImportListSeparatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_importListSeparator; }
	}

	public final ImportListSeparatorContext importListSeparator() throws RecognitionException {
		ImportListSeparatorContext _localctx = new ImportListSeparatorContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_importListSeparator);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(143);
			match(COMMA);
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

	public static class ImportItemContext extends ParserRuleContext {
		public TerminalNode IMPORT() { return getToken(ZParser.IMPORT, 0); }
		public ImportNameContext importName() {
			return getRuleContext(ImportNameContext.class,0);
		}
		public TerminalNode AS() { return getToken(ZParser.AS, 0); }
		public TerminalNode UPPERCASE_ID() { return getToken(ZParser.UPPERCASE_ID, 0); }
		public ImportItemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_importItem; }
	}

	public final ImportItemContext importItem() throws RecognitionException {
		ImportItemContext _localctx = new ImportItemContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_importItem);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(145);
			match(IMPORT);
			setState(146);
			importName();
			setState(149);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==AS) {
				{
				setState(147);
				match(AS);
				setState(148);
				match(UPPERCASE_ID);
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

	public static class ImportNameContext extends ParserRuleContext {
		public List<TerminalNode> UPPERCASE_ID() { return getTokens(ZParser.UPPERCASE_ID); }
		public TerminalNode UPPERCASE_ID(int i) {
			return getToken(ZParser.UPPERCASE_ID, i);
		}
		public List<TerminalNode> DOT() { return getTokens(ZParser.DOT); }
		public TerminalNode DOT(int i) {
			return getToken(ZParser.DOT, i);
		}
		public ImportNameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_importName; }
	}

	public final ImportNameContext importName() throws RecognitionException {
		ImportNameContext _localctx = new ImportNameContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_importName);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(151);
			match(UPPERCASE_ID);
			setState(156);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==DOT) {
				{
				{
				setState(152);
				match(DOT);
				setState(153);
				match(UPPERCASE_ID);
				}
				}
				setState(158);
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

	public static class ModuleContext extends ParserRuleContext {
		public TerminalNode EXPORT() { return getToken(ZParser.EXPORT, 0); }
		public TerminalNode LBRACKET() { return getToken(ZParser.LBRACKET, 0); }
		public ExportListContext exportList() {
			return getRuleContext(ExportListContext.class,0);
		}
		public TerminalNode RBRACKET() { return getToken(ZParser.RBRACKET, 0); }
		public TerminalNode AS() { return getToken(ZParser.AS, 0); }
		public TerminalNode UPPERCASE_ID() { return getToken(ZParser.UPPERCASE_ID, 0); }
		public ModuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_module; }
	}

	public final ModuleContext module() throws RecognitionException {
		ModuleContext _localctx = new ModuleContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_module);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(159);
			match(EXPORT);
			setState(160);
			match(LBRACKET);
			setState(161);
			exportList();
			setState(162);
			match(RBRACKET);
			setState(163);
			match(AS);
			setState(164);
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

	public static class ExportListContext extends ParserRuleContext {
		public ExportItemContext exportItem;
		public List<ExportItemContext> list = new ArrayList<ExportItemContext>();
		public List<ExportItemContext> exportItem() {
			return getRuleContexts(ExportItemContext.class);
		}
		public ExportItemContext exportItem(int i) {
			return getRuleContext(ExportItemContext.class,i);
		}
		public List<ExportListSeparatorContext> exportListSeparator() {
			return getRuleContexts(ExportListSeparatorContext.class);
		}
		public ExportListSeparatorContext exportListSeparator(int i) {
			return getRuleContext(ExportListSeparatorContext.class,i);
		}
		public ExportListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exportList; }
	}

	public final ExportListContext exportList() throws RecognitionException {
		ExportListContext _localctx = new ExportListContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_exportList);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			((ExportListContext)_localctx).exportItem = exportItem();
			((ExportListContext)_localctx).list.add(((ExportListContext)_localctx).exportItem);
			setState(173);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,14,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(168);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==COMMA) {
						{
						setState(167);
						exportListSeparator();
						}
					}

					setState(170);
					((ExportListContext)_localctx).exportItem = exportItem();
					((ExportListContext)_localctx).list.add(((ExportListContext)_localctx).exportItem);
					}
					} 
				}
				setState(175);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,14,_ctx);
			}
			setState(177);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COMMA) {
				{
				setState(176);
				exportListSeparator();
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

	public static class ExportListSeparatorContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(ZParser.COMMA, 0); }
		public ExportListSeparatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exportListSeparator; }
	}

	public final ExportListSeparatorContext exportListSeparator() throws RecognitionException {
		ExportListSeparatorContext _localctx = new ExportListSeparatorContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_exportListSeparator);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(179);
			match(COMMA);
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

	public static class ExportItemContext extends ParserRuleContext {
		public TerminalNode UPPERCASE_ID() { return getToken(ZParser.UPPERCASE_ID, 0); }
		public TerminalNode LOWERCASE_ID() { return getToken(ZParser.LOWERCASE_ID, 0); }
		public ExportItemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exportItem; }
	}

	public final ExportItemContext exportItem() throws RecognitionException {
		ExportItemContext _localctx = new ExportItemContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_exportItem);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(181);
			_la = _input.LA(1);
			if ( !(_la==LOWERCASE_ID || _la==UPPERCASE_ID) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
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

	public static class TraitContext extends ParserRuleContext {
		public TerminalNode TRAIT() { return getToken(ZParser.TRAIT, 0); }
		public IdentifierTypeContext identifierType() {
			return getRuleContext(IdentifierTypeContext.class,0);
		}
		public TerminalNode LBRACKET() { return getToken(ZParser.LBRACKET, 0); }
		public TraitListContext traitList() {
			return getRuleContext(TraitListContext.class,0);
		}
		public TerminalNode RBRACKET() { return getToken(ZParser.RBRACKET, 0); }
		public TraitContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_trait; }
	}

	public final TraitContext trait() throws RecognitionException {
		TraitContext _localctx = new TraitContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_trait);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(183);
			match(TRAIT);
			setState(184);
			identifierType();
			setState(185);
			match(LBRACKET);
			setState(186);
			traitList();
			setState(187);
			match(RBRACKET);
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

	public static class TraitListContext extends ParserRuleContext {
		public FunctionTypeDeclarationContext functionTypeDeclaration;
		public List<FunctionTypeDeclarationContext> list = new ArrayList<FunctionTypeDeclarationContext>();
		public List<FunctionTypeDeclarationContext> functionTypeDeclaration() {
			return getRuleContexts(FunctionTypeDeclarationContext.class);
		}
		public FunctionTypeDeclarationContext functionTypeDeclaration(int i) {
			return getRuleContext(FunctionTypeDeclarationContext.class,i);
		}
		public List<TraitListSeparatorContext> traitListSeparator() {
			return getRuleContexts(TraitListSeparatorContext.class);
		}
		public TraitListSeparatorContext traitListSeparator(int i) {
			return getRuleContext(TraitListSeparatorContext.class,i);
		}
		public TraitListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_traitList; }
	}

	public final TraitListContext traitList() throws RecognitionException {
		TraitListContext _localctx = new TraitListContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_traitList);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(189);
			((TraitListContext)_localctx).functionTypeDeclaration = functionTypeDeclaration();
			((TraitListContext)_localctx).list.add(((TraitListContext)_localctx).functionTypeDeclaration);
			setState(196);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,17,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(191);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==COMMA) {
						{
						setState(190);
						traitListSeparator();
						}
					}

					setState(193);
					((TraitListContext)_localctx).functionTypeDeclaration = functionTypeDeclaration();
					((TraitListContext)_localctx).list.add(((TraitListContext)_localctx).functionTypeDeclaration);
					}
					} 
				}
				setState(198);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,17,_ctx);
			}
			setState(200);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COMMA) {
				{
				setState(199);
				traitListSeparator();
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

	public static class TraitListSeparatorContext extends ParserRuleContext {
		public TerminalNode COMMA() { return getToken(ZParser.COMMA, 0); }
		public TraitListSeparatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_traitListSeparator; }
	}

	public final TraitListSeparatorContext traitListSeparator() throws RecognitionException {
		TraitListSeparatorContext _localctx = new TraitListSeparatorContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_traitListSeparator);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(202);
			match(COMMA);
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
	public static class LargeIdentifierExprContext extends ExpressionContext {
		public LargeIdentifierContext largeIdentifier() {
			return getRuleContext(LargeIdentifierContext.class,0);
		}
		public LargeIdentifierExprContext(ExpressionContext ctx) { copyFrom(ctx); }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 36;
		enterRecursionRule(_localctx, 36, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(218);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
			case 1:
				{
				_localctx = new UnaryExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(205);
				((UnaryExprContext)_localctx).op = match(MINUS);
				setState(206);
				expression(15);
				}
				break;
			case 2:
				{
				_localctx = new IfExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(207);
				ifExpression();
				}
				break;
			case 3:
				{
				_localctx = new LetExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(208);
				letExpression();
				}
				break;
			case 4:
				{
				_localctx = new LiteralCharExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(209);
				literalChar();
				}
				break;
			case 5:
				{
				_localctx = new LiteralIntExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(210);
				literalInt();
				}
				break;
			case 6:
				{
				_localctx = new LiteralFloatExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(211);
				literalFloat();
				}
				break;
			case 7:
				{
				_localctx = new LargeIdentifierExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(212);
				largeIdentifier();
				}
				break;
			case 8:
				{
				_localctx = new IdentExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(213);
				identifier();
				}
				break;
			case 9:
				{
				_localctx = new ParenExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(214);
				match(LPAREN);
				setState(215);
				expression(0);
				setState(216);
				match(RPAREN);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(242);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(240);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
					case 1:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(220);
						if (!(precpred(_ctx, 14))) throw new FailedPredicateException(this, "precpred(_ctx, 14)");
						setState(221);
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
						setState(222);
						expression(15);
						}
						break;
					case 2:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(223);
						if (!(precpred(_ctx, 13))) throw new FailedPredicateException(this, "precpred(_ctx, 13)");
						setState(224);
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
						setState(225);
						expression(14);
						}
						break;
					case 3:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(226);
						if (!(precpred(_ctx, 11))) throw new FailedPredicateException(this, "precpred(_ctx, 11)");
						setState(227);
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
						setState(228);
						expression(12);
						}
						break;
					case 4:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(229);
						if (!(precpred(_ctx, 10))) throw new FailedPredicateException(this, "precpred(_ctx, 10)");
						setState(230);
						((OpExprContext)_localctx).op = match(LOGICAL_AND);
						setState(231);
						expression(11);
						}
						break;
					case 5:
						{
						_localctx = new OpExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(232);
						if (!(precpred(_ctx, 9))) throw new FailedPredicateException(this, "precpred(_ctx, 9)");
						setState(233);
						((OpExprContext)_localctx).op = match(LOGICAL_OR);
						setState(234);
						expression(10);
						}
						break;
					case 6:
						{
						_localctx = new FunctionCallExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(235);
						if (!(precpred(_ctx, 16))) throw new FailedPredicateException(this, "precpred(_ctx, 16)");
						setState(236);
						functionCall();
						}
						break;
					case 7:
						{
						_localctx = new TypeCastExprContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(237);
						if (!(precpred(_ctx, 12))) throw new FailedPredicateException(this, "precpred(_ctx, 12)");
						setState(238);
						match(DOUBLE_COLON);
						setState(239);
						identifierType();
						}
						break;
					}
					} 
				}
				setState(244);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
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
		enterRule(_localctx, 38, RULE_ifExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(245);
			match(IF);
			setState(246);
			expression(0);
			setState(247);
			match(THEN);
			setState(248);
			expression(0);
			setState(249);
			match(ELSE);
			setState(250);
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
		enterRule(_localctx, 40, RULE_functionCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(252);
			match(LPAREN);
			setState(254);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << IF) | (1L << LET) | (1L << LOWERCASE_ID) | (1L << UPPERCASE_ID) | (1L << INT) | (1L << CHARACTER_CONSTANT) | (1L << MINUS) | (1L << LPAREN))) != 0)) {
				{
				setState(253);
				usageParameterList();
				}
			}

			setState(256);
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
		enterRule(_localctx, 42, RULE_usageParameterList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(258);
			((UsageParameterListContext)_localctx).expression = expression(0);
			((UsageParameterListContext)_localctx).list.add(((UsageParameterListContext)_localctx).expression);
			setState(263);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(259);
				match(COMMA);
				setState(260);
				((UsageParameterListContext)_localctx).expression = expression(0);
				((UsageParameterListContext)_localctx).list.add(((UsageParameterListContext)_localctx).expression);
				}
				}
				setState(265);
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

	public static class LargeIdentifierContext extends ParserRuleContext {
		public List<TerminalNode> UPPERCASE_ID() { return getTokens(ZParser.UPPERCASE_ID); }
		public TerminalNode UPPERCASE_ID(int i) {
			return getToken(ZParser.UPPERCASE_ID, i);
		}
		public List<TerminalNode> DOT() { return getTokens(ZParser.DOT); }
		public TerminalNode DOT(int i) {
			return getToken(ZParser.DOT, i);
		}
		public TerminalNode LOWERCASE_ID() { return getToken(ZParser.LOWERCASE_ID, 0); }
		public LargeIdentifierContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_largeIdentifier; }
	}

	public final LargeIdentifierContext largeIdentifier() throws RecognitionException {
		LargeIdentifierContext _localctx = new LargeIdentifierContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_largeIdentifier);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(266);
			match(UPPERCASE_ID);
			setState(271);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(267);
					match(DOT);
					setState(268);
					match(UPPERCASE_ID);
					}
					} 
				}
				setState(273);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
			}
			setState(276);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
			case 1:
				{
				setState(274);
				match(DOT);
				setState(275);
				match(LOWERCASE_ID);
				}
				break;
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
		enterRule(_localctx, 46, RULE_letExpression);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(278);
			match(LET);
			setState(279);
			letList();
			setState(280);
			match(IN);
			setState(281);
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
		enterRule(_localctx, 48, RULE_letList);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(283);
			((LetListContext)_localctx).letItem = letItem();
			((LetListContext)_localctx).list.add(((LetListContext)_localctx).letItem);
			setState(290);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(285);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==SEMI_COLON) {
						{
						setState(284);
						assignmentListSeparator();
						}
					}

					setState(287);
					((LetListContext)_localctx).letItem = letItem();
					((LetListContext)_localctx).list.add(((LetListContext)_localctx).letItem);
					}
					} 
				}
				setState(292);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			}
			setState(294);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SEMI_COLON) {
				{
				setState(293);
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
		enterRule(_localctx, 50, RULE_letItem);
		try {
			setState(298);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(296);
				assignment();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(297);
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
		enterRule(_localctx, 52, RULE_assignmentListSeparator);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(300);
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
		enterRule(_localctx, 54, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(302);
			identifier();
			setState(303);
			match(ASSIGN);
			setState(304);
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
		enterRule(_localctx, 56, RULE_literalInt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(306);
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
		enterRule(_localctx, 58, RULE_literalFloat);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(308);
			match(INT);
			setState(309);
			match(DOT);
			setState(310);
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
		enterRule(_localctx, 60, RULE_literalChar);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(312);
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
		enterRule(_localctx, 62, RULE_identifier);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(314);
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
		enterRule(_localctx, 64, RULE_typeDeclaration);
		try {
			setState(318);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(316);
				functionTypeDeclaration();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(317);
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
		enterRule(_localctx, 66, RULE_functionTypeDeclaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(320);
			identifier();
			setState(321);
			match(COLON);
			setState(322);
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
		enterRule(_localctx, 68, RULE_variableTypeDeclaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(324);
			identifier();
			setState(325);
			match(COLON);
			setState(326);
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
		enterRule(_localctx, 70, RULE_type);
		try {
			setState(331);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,31,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(328);
				identifierType();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(329);
				nestedFunctionType();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(330);
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
		enterRule(_localctx, 72, RULE_emptyType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(333);
			match(LPAREN);
			setState(334);
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
		enterRule(_localctx, 74, RULE_identifierType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(336);
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
		enterRule(_localctx, 76, RULE_functionType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(338);
			typeList();
			setState(339);
			match(SINGLE_ARROW);
			setState(340);
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
		enterRule(_localctx, 78, RULE_nestedFunctionType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(342);
			match(LPAREN);
			setState(343);
			functionType();
			setState(344);
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
		case 18:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 14);
		case 1:
			return precpred(_ctx, 13);
		case 2:
			return precpred(_ctx, 11);
		case 3:
			return precpred(_ctx, 10);
		case 4:
			return precpred(_ctx, 9);
		case 5:
			return precpred(_ctx, 16);
		case 6:
			return precpred(_ctx, 12);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3+\u015d\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\3\2\5\2T\n\2\3"+
		"\2\5\2W\n\2\3\2\3\2\7\2[\n\2\f\2\16\2^\13\2\3\2\3\2\3\3\3\3\5\3d\n\3\3"+
		"\4\3\4\3\4\3\4\3\5\3\5\3\5\5\5m\n\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\7\6v\n"+
		"\6\f\6\16\6y\13\6\3\7\3\7\3\b\3\b\3\b\7\b\u0080\n\b\f\b\16\b\u0083\13"+
		"\b\3\t\3\t\5\t\u0087\n\t\3\t\7\t\u008a\n\t\f\t\16\t\u008d\13\t\3\t\5\t"+
		"\u0090\n\t\3\n\3\n\3\13\3\13\3\13\3\13\5\13\u0098\n\13\3\f\3\f\3\f\7\f"+
		"\u009d\n\f\f\f\16\f\u00a0\13\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\16\3\16\5"+
		"\16\u00ab\n\16\3\16\7\16\u00ae\n\16\f\16\16\16\u00b1\13\16\3\16\5\16\u00b4"+
		"\n\16\3\17\3\17\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\21\3\22\3\22\5\22"+
		"\u00c2\n\22\3\22\7\22\u00c5\n\22\f\22\16\22\u00c8\13\22\3\22\5\22\u00cb"+
		"\n\22\3\23\3\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\5\24\u00dd\n\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\7\24\u00f3"+
		"\n\24\f\24\16\24\u00f6\13\24\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\26\3"+
		"\26\5\26\u0101\n\26\3\26\3\26\3\27\3\27\3\27\7\27\u0108\n\27\f\27\16\27"+
		"\u010b\13\27\3\30\3\30\3\30\7\30\u0110\n\30\f\30\16\30\u0113\13\30\3\30"+
		"\3\30\5\30\u0117\n\30\3\31\3\31\3\31\3\31\3\31\3\32\3\32\5\32\u0120\n"+
		"\32\3\32\7\32\u0123\n\32\f\32\16\32\u0126\13\32\3\32\5\32\u0129\n\32\3"+
		"\33\3\33\5\33\u012d\n\33\3\34\3\34\3\35\3\35\3\35\3\35\3\36\3\36\3\37"+
		"\3\37\3\37\3\37\3 \3 \3!\3!\3\"\3\"\5\"\u0141\n\"\3#\3#\3#\3#\3$\3$\3"+
		"$\3$\3%\3%\3%\5%\u014e\n%\3&\3&\3&\3\'\3\'\3(\3(\3(\3(\3)\3)\3)\3)\3)"+
		"\2\3&*\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<"+
		">@BDFHJLNP\2\6\3\2\16\17\3\2\24\26\3\2\22\23\3\2\31\36\2\u0161\2S\3\2"+
		"\2\2\4c\3\2\2\2\6e\3\2\2\2\bi\3\2\2\2\nr\3\2\2\2\fz\3\2\2\2\16|\3\2\2"+
		"\2\20\u0084\3\2\2\2\22\u0091\3\2\2\2\24\u0093\3\2\2\2\26\u0099\3\2\2\2"+
		"\30\u00a1\3\2\2\2\32\u00a8\3\2\2\2\34\u00b5\3\2\2\2\36\u00b7\3\2\2\2 "+
		"\u00b9\3\2\2\2\"\u00bf\3\2\2\2$\u00cc\3\2\2\2&\u00dc\3\2\2\2(\u00f7\3"+
		"\2\2\2*\u00fe\3\2\2\2,\u0104\3\2\2\2.\u010c\3\2\2\2\60\u0118\3\2\2\2\62"+
		"\u011d\3\2\2\2\64\u012c\3\2\2\2\66\u012e\3\2\2\28\u0130\3\2\2\2:\u0134"+
		"\3\2\2\2<\u0136\3\2\2\2>\u013a\3\2\2\2@\u013c\3\2\2\2B\u0140\3\2\2\2D"+
		"\u0142\3\2\2\2F\u0146\3\2\2\2H\u014d\3\2\2\2J\u014f\3\2\2\2L\u0152\3\2"+
		"\2\2N\u0154\3\2\2\2P\u0158\3\2\2\2RT\5\20\t\2SR\3\2\2\2ST\3\2\2\2TV\3"+
		"\2\2\2UW\5\30\r\2VU\3\2\2\2VW\3\2\2\2W\\\3\2\2\2X[\5B\"\2Y[\5\4\3\2ZX"+
		"\3\2\2\2ZY\3\2\2\2[^\3\2\2\2\\Z\3\2\2\2\\]\3\2\2\2]_\3\2\2\2^\\\3\2\2"+
		"\2_`\7\2\2\3`\3\3\2\2\2ad\5\b\5\2bd\5\6\4\2ca\3\2\2\2cb\3\2\2\2d\5\3\2"+
		"\2\2ef\5@!\2fg\7\37\2\2gh\5&\24\2h\7\3\2\2\2ij\5@!\2jl\7$\2\2km\5\16\b"+
		"\2lk\3\2\2\2lm\3\2\2\2mn\3\2\2\2no\7%\2\2op\7\37\2\2pq\5\f\7\2q\t\3\2"+
		"\2\2rw\5H%\2st\7#\2\2tv\5H%\2us\3\2\2\2vy\3\2\2\2wu\3\2\2\2wx\3\2\2\2"+
		"x\13\3\2\2\2yw\3\2\2\2z{\5&\24\2{\r\3\2\2\2|\u0081\5@!\2}~\7#\2\2~\u0080"+
		"\5@!\2\177}\3\2\2\2\u0080\u0083\3\2\2\2\u0081\177\3\2\2\2\u0081\u0082"+
		"\3\2\2\2\u0082\17\3\2\2\2\u0083\u0081\3\2\2\2\u0084\u008b\5\24\13\2\u0085"+
		"\u0087\5\22\n\2\u0086\u0085\3\2\2\2\u0086\u0087\3\2\2\2\u0087\u0088\3"+
		"\2\2\2\u0088\u008a\5\24\13\2\u0089\u0086\3\2\2\2\u008a\u008d\3\2\2\2\u008b"+
		"\u0089\3\2\2\2\u008b\u008c\3\2\2\2\u008c\u008f\3\2\2\2\u008d\u008b\3\2"+
		"\2\2\u008e\u0090\5\22\n\2\u008f\u008e\3\2\2\2\u008f\u0090\3\2\2\2\u0090"+
		"\21\3\2\2\2\u0091\u0092\7#\2\2\u0092\23\3\2\2\2\u0093\u0094\7\t\2\2\u0094"+
		"\u0097\5\26\f\2\u0095\u0096\7\n\2\2\u0096\u0098\7\17\2\2\u0097\u0095\3"+
		"\2\2\2\u0097\u0098\3\2\2\2\u0098\25\3\2\2\2\u0099\u009e\7\17\2\2\u009a"+
		"\u009b\7(\2\2\u009b\u009d\7\17\2\2\u009c\u009a\3\2\2\2\u009d\u00a0\3\2"+
		"\2\2\u009e\u009c\3\2\2\2\u009e\u009f\3\2\2\2\u009f\27\3\2\2\2\u00a0\u009e"+
		"\3\2\2\2\u00a1\u00a2\7\b\2\2\u00a2\u00a3\7&\2\2\u00a3\u00a4\5\32\16\2"+
		"\u00a4\u00a5\7\'\2\2\u00a5\u00a6\7\n\2\2\u00a6\u00a7\7\17\2\2\u00a7\31"+
		"\3\2\2\2\u00a8\u00af\5\36\20\2\u00a9\u00ab\5\34\17\2\u00aa\u00a9\3\2\2"+
		"\2\u00aa\u00ab\3\2\2\2\u00ab\u00ac\3\2\2\2\u00ac\u00ae\5\36\20\2\u00ad"+
		"\u00aa\3\2\2\2\u00ae\u00b1\3\2\2\2\u00af\u00ad\3\2\2\2\u00af\u00b0\3\2"+
		"\2\2\u00b0\u00b3\3\2\2\2\u00b1\u00af\3\2\2\2\u00b2\u00b4\5\34\17\2\u00b3"+
		"\u00b2\3\2\2\2\u00b3\u00b4\3\2\2\2\u00b4\33\3\2\2\2\u00b5\u00b6\7#\2\2"+
		"\u00b6\35\3\2\2\2\u00b7\u00b8\t\2\2\2\u00b8\37\3\2\2\2\u00b9\u00ba\7\13"+
		"\2\2\u00ba\u00bb\5L\'\2\u00bb\u00bc\7&\2\2\u00bc\u00bd\5\"\22\2\u00bd"+
		"\u00be\7\'\2\2\u00be!\3\2\2\2\u00bf\u00c6\5D#\2\u00c0\u00c2\5$\23\2\u00c1"+
		"\u00c0\3\2\2\2\u00c1\u00c2\3\2\2\2\u00c2\u00c3\3\2\2\2\u00c3\u00c5\5D"+
		"#\2\u00c4\u00c1\3\2\2\2\u00c5\u00c8\3\2\2\2\u00c6\u00c4\3\2\2\2\u00c6"+
		"\u00c7\3\2\2\2\u00c7\u00ca\3\2\2\2\u00c8\u00c6\3\2\2\2\u00c9\u00cb\5$"+
		"\23\2\u00ca\u00c9\3\2\2\2\u00ca\u00cb\3\2\2\2\u00cb#\3\2\2\2\u00cc\u00cd"+
		"\7#\2\2\u00cd%\3\2\2\2\u00ce\u00cf\b\24\1\2\u00cf\u00d0\7\23\2\2\u00d0"+
		"\u00dd\5&\24\21\u00d1\u00dd\5(\25\2\u00d2\u00dd\5\60\31\2\u00d3\u00dd"+
		"\5> \2\u00d4\u00dd\5:\36\2\u00d5\u00dd\5<\37\2\u00d6\u00dd\5.\30\2\u00d7"+
		"\u00dd\5@!\2\u00d8\u00d9\7$\2\2\u00d9\u00da\5&\24\2\u00da\u00db\7%\2\2"+
		"\u00db\u00dd\3\2\2\2\u00dc\u00ce\3\2\2\2\u00dc\u00d1\3\2\2\2\u00dc\u00d2"+
		"\3\2\2\2\u00dc\u00d3\3\2\2\2\u00dc\u00d4\3\2\2\2\u00dc\u00d5\3\2\2\2\u00dc"+
		"\u00d6\3\2\2\2\u00dc\u00d7\3\2\2\2\u00dc\u00d8\3\2\2\2\u00dd\u00f4\3\2"+
		"\2\2\u00de\u00df\f\20\2\2\u00df\u00e0\t\3\2\2\u00e0\u00f3\5&\24\21\u00e1"+
		"\u00e2\f\17\2\2\u00e2\u00e3\t\4\2\2\u00e3\u00f3\5&\24\20\u00e4\u00e5\f"+
		"\r\2\2\u00e5\u00e6\t\5\2\2\u00e6\u00f3\5&\24\16\u00e7\u00e8\f\f\2\2\u00e8"+
		"\u00e9\7\27\2\2\u00e9\u00f3\5&\24\r\u00ea\u00eb\f\13\2\2\u00eb\u00ec\7"+
		"\30\2\2\u00ec\u00f3\5&\24\f\u00ed\u00ee\f\22\2\2\u00ee\u00f3\5*\26\2\u00ef"+
		"\u00f0\f\16\2\2\u00f0\u00f1\7!\2\2\u00f1\u00f3\5L\'\2\u00f2\u00de\3\2"+
		"\2\2\u00f2\u00e1\3\2\2\2\u00f2\u00e4\3\2\2\2\u00f2\u00e7\3\2\2\2\u00f2"+
		"\u00ea\3\2\2\2\u00f2\u00ed\3\2\2\2\u00f2\u00ef\3\2\2\2\u00f3\u00f6\3\2"+
		"\2\2\u00f4\u00f2\3\2\2\2\u00f4\u00f5\3\2\2\2\u00f5\'\3\2\2\2\u00f6\u00f4"+
		"\3\2\2\2\u00f7\u00f8\7\3\2\2\u00f8\u00f9\5&\24\2\u00f9\u00fa\7\4\2\2\u00fa"+
		"\u00fb\5&\24\2\u00fb\u00fc\7\5\2\2\u00fc\u00fd\5&\24\2\u00fd)\3\2\2\2"+
		"\u00fe\u0100\7$\2\2\u00ff\u0101\5,\27\2\u0100\u00ff\3\2\2\2\u0100\u0101"+
		"\3\2\2\2\u0101\u0102\3\2\2\2\u0102\u0103\7%\2\2\u0103+\3\2\2\2\u0104\u0109"+
		"\5&\24\2\u0105\u0106\7#\2\2\u0106\u0108\5&\24\2\u0107\u0105\3\2\2\2\u0108"+
		"\u010b\3\2\2\2\u0109\u0107\3\2\2\2\u0109\u010a\3\2\2\2\u010a-\3\2\2\2"+
		"\u010b\u0109\3\2\2\2\u010c\u0111\7\17\2\2\u010d\u010e\7(\2\2\u010e\u0110"+
		"\7\17\2\2\u010f\u010d\3\2\2\2\u0110\u0113\3\2\2\2\u0111\u010f\3\2\2\2"+
		"\u0111\u0112\3\2\2\2\u0112\u0116\3\2\2\2\u0113\u0111\3\2\2\2\u0114\u0115"+
		"\7(\2\2\u0115\u0117\7\16\2\2\u0116\u0114\3\2\2\2\u0116\u0117\3\2\2\2\u0117"+
		"/\3\2\2\2\u0118\u0119\7\6\2\2\u0119\u011a\5\62\32\2\u011a\u011b\7\7\2"+
		"\2\u011b\u011c\5&\24\2\u011c\61\3\2\2\2\u011d\u0124\5\64\33\2\u011e\u0120"+
		"\5\66\34\2\u011f\u011e\3\2\2\2\u011f\u0120\3\2\2\2\u0120\u0121\3\2\2\2"+
		"\u0121\u0123\5\64\33\2\u0122\u011f\3\2\2\2\u0123\u0126\3\2\2\2\u0124\u0122"+
		"\3\2\2\2\u0124\u0125\3\2\2\2\u0125\u0128\3\2\2\2\u0126\u0124\3\2\2\2\u0127"+
		"\u0129\5\66\34\2\u0128\u0127\3\2\2\2\u0128\u0129\3\2\2\2\u0129\63\3\2"+
		"\2\2\u012a\u012d\58\35\2\u012b\u012d\5B\"\2\u012c\u012a\3\2\2\2\u012c"+
		"\u012b\3\2\2\2\u012d\65\3\2\2\2\u012e\u012f\7)\2\2\u012f\67\3\2\2\2\u0130"+
		"\u0131\5@!\2\u0131\u0132\7\37\2\2\u0132\u0133\5&\24\2\u01339\3\2\2\2\u0134"+
		"\u0135\7\20\2\2\u0135;\3\2\2\2\u0136\u0137\7\20\2\2\u0137\u0138\7(\2\2"+
		"\u0138\u0139\7\20\2\2\u0139=\3\2\2\2\u013a\u013b\7\21\2\2\u013b?\3\2\2"+
		"\2\u013c\u013d\7\16\2\2\u013dA\3\2\2\2\u013e\u0141\5D#\2\u013f\u0141\5"+
		"F$\2\u0140\u013e\3\2\2\2\u0140\u013f\3\2\2\2\u0141C\3\2\2\2\u0142\u0143"+
		"\5@!\2\u0143\u0144\7\"\2\2\u0144\u0145\5N(\2\u0145E\3\2\2\2\u0146\u0147"+
		"\5@!\2\u0147\u0148\7\"\2\2\u0148\u0149\5L\'\2\u0149G\3\2\2\2\u014a\u014e"+
		"\5L\'\2\u014b\u014e\5P)\2\u014c\u014e\5J&\2\u014d\u014a\3\2\2\2\u014d"+
		"\u014b\3\2\2\2\u014d\u014c\3\2\2\2\u014eI\3\2\2\2\u014f\u0150\7$\2\2\u0150"+
		"\u0151\7%\2\2\u0151K\3\2\2\2\u0152\u0153\7\17\2\2\u0153M\3\2\2\2\u0154"+
		"\u0155\5\n\6\2\u0155\u0156\7 \2\2\u0156\u0157\5H%\2\u0157O\3\2\2\2\u0158"+
		"\u0159\7$\2\2\u0159\u015a\5N(\2\u015a\u015b\7%\2\2\u015bQ\3\2\2\2\"SV"+
		"Z\\clw\u0081\u0086\u008b\u008f\u0097\u009e\u00aa\u00af\u00b3\u00c1\u00c6"+
		"\u00ca\u00dc\u00f2\u00f4\u0100\u0109\u0111\u0116\u011f\u0124\u0128\u012c"+
		"\u0140\u014d";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}