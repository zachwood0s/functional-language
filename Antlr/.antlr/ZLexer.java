// Generated from z:\Documents\Projects\C#\FunctionalLang\Antlr/ZLexer.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ZLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		IF=1, THEN=2, ELSE=3, LET=4, IN=5, WS=6, LOWERCASE_ID=7, UPPERCASE_ID=8, 
		INT=9, PLUS=10, MINUS=11, DIVIDE=12, TIMES=13, MOD=14, LOGICAL_AND=15, 
		LOGICAL_OR=16, GTE=17, GT=18, LTE=19, LT=20, EQ=21, NEQ=22, ASSIGN=23, 
		SINGLE_ARROW=24, DOUBLE_COLON=25, COLON=26, COMMA=27, LPAREN=28, RPAREN=29, 
		DOT=30, SEMI_COLON=31;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"IF", "THEN", "ELSE", "LET", "IN", "WS", "LOWERCASE_ID", "UPPERCASE_ID", 
		"UPPER_CHAR", "LOWER_CHAR", "ID_CHAR", "INT", "DIGIT", "PLUS", "MINUS", 
		"DIVIDE", "TIMES", "MOD", "LOGICAL_AND", "LOGICAL_OR", "GTE", "GT", "LTE", 
		"LT", "EQ", "NEQ", "ASSIGN", "SINGLE_ARROW", "DOUBLE_COLON", "COLON", 
		"COMMA", "LPAREN", "RPAREN", "DOT", "SEMI_COLON"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'if'", "'then'", "'else'", "'let'", "'in'", null, null, null, null, 
		"'+'", "'-'", "'/'", "'*'", "'%'", "'&&'", "'||'", "'>='", "'>'", "'<='", 
		"'<'", "'=='", "'!='", "'='", "'->'", "'::'", "':'", "','", "'('", "')'", 
		"'.'", "';'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "IF", "THEN", "ELSE", "LET", "IN", "WS", "LOWERCASE_ID", "UPPERCASE_ID", 
		"INT", "PLUS", "MINUS", "DIVIDE", "TIMES", "MOD", "LOGICAL_AND", "LOGICAL_OR", 
		"GTE", "GT", "LTE", "LT", "EQ", "NEQ", "ASSIGN", "SINGLE_ARROW", "DOUBLE_COLON", 
		"COLON", "COMMA", "LPAREN", "RPAREN", "DOT", "SEMI_COLON"
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


	public ZLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "ZLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2!\u00b6\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\3\2\3\2\3\2\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3"+
		"\4\3\4\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\7\6\7_\n\7\r\7\16\7`\3\7\3\7\3\b"+
		"\3\b\7\bg\n\b\f\b\16\bj\13\b\3\t\3\t\7\tn\n\t\f\t\16\tq\13\t\3\n\3\n\3"+
		"\13\3\13\3\f\3\f\3\f\5\fz\n\f\3\r\6\r}\n\r\r\r\16\r~\3\16\3\16\3\17\3"+
		"\17\3\20\3\20\3\21\3\21\3\22\3\22\3\23\3\23\3\24\3\24\3\24\3\25\3\25\3"+
		"\25\3\26\3\26\3\26\3\27\3\27\3\30\3\30\3\30\3\31\3\31\3\32\3\32\3\32\3"+
		"\33\3\33\3\33\3\34\3\34\3\35\3\35\3\35\3\36\3\36\3\36\3\37\3\37\3 \3 "+
		"\3!\3!\3\"\3\"\3#\3#\3$\3$\2\2%\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23"+
		"\2\25\2\27\2\31\13\33\2\35\f\37\r!\16#\17%\20\'\21)\22+\23-\24/\25\61"+
		"\26\63\27\65\30\67\319\32;\33=\34?\35A\36C\37E G!\3\2\7\5\2\13\f\17\17"+
		"\"\"\3\2C\\\3\2c|\3\2aa\3\2\62;\2\u00b7\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3"+
		"\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2"+
		"\2\31\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2"+
		"\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2"+
		"\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2"+
		"\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\3I\3\2\2\2"+
		"\5L\3\2\2\2\7Q\3\2\2\2\tV\3\2\2\2\13Z\3\2\2\2\r^\3\2\2\2\17d\3\2\2\2\21"+
		"k\3\2\2\2\23r\3\2\2\2\25t\3\2\2\2\27y\3\2\2\2\31|\3\2\2\2\33\u0080\3\2"+
		"\2\2\35\u0082\3\2\2\2\37\u0084\3\2\2\2!\u0086\3\2\2\2#\u0088\3\2\2\2%"+
		"\u008a\3\2\2\2\'\u008c\3\2\2\2)\u008f\3\2\2\2+\u0092\3\2\2\2-\u0095\3"+
		"\2\2\2/\u0097\3\2\2\2\61\u009a\3\2\2\2\63\u009c\3\2\2\2\65\u009f\3\2\2"+
		"\2\67\u00a2\3\2\2\29\u00a4\3\2\2\2;\u00a7\3\2\2\2=\u00aa\3\2\2\2?\u00ac"+
		"\3\2\2\2A\u00ae\3\2\2\2C\u00b0\3\2\2\2E\u00b2\3\2\2\2G\u00b4\3\2\2\2I"+
		"J\7k\2\2JK\7h\2\2K\4\3\2\2\2LM\7v\2\2MN\7j\2\2NO\7g\2\2OP\7p\2\2P\6\3"+
		"\2\2\2QR\7g\2\2RS\7n\2\2ST\7u\2\2TU\7g\2\2U\b\3\2\2\2VW\7n\2\2WX\7g\2"+
		"\2XY\7v\2\2Y\n\3\2\2\2Z[\7k\2\2[\\\7p\2\2\\\f\3\2\2\2]_\t\2\2\2^]\3\2"+
		"\2\2_`\3\2\2\2`^\3\2\2\2`a\3\2\2\2ab\3\2\2\2bc\b\7\2\2c\16\3\2\2\2dh\5"+
		"\25\13\2eg\5\27\f\2fe\3\2\2\2gj\3\2\2\2hf\3\2\2\2hi\3\2\2\2i\20\3\2\2"+
		"\2jh\3\2\2\2ko\5\23\n\2ln\5\27\f\2ml\3\2\2\2nq\3\2\2\2om\3\2\2\2op\3\2"+
		"\2\2p\22\3\2\2\2qo\3\2\2\2rs\t\3\2\2s\24\3\2\2\2tu\t\4\2\2u\26\3\2\2\2"+
		"vz\5\23\n\2wz\5\25\13\2xz\t\5\2\2yv\3\2\2\2yw\3\2\2\2yx\3\2\2\2z\30\3"+
		"\2\2\2{}\5\33\16\2|{\3\2\2\2}~\3\2\2\2~|\3\2\2\2~\177\3\2\2\2\177\32\3"+
		"\2\2\2\u0080\u0081\t\6\2\2\u0081\34\3\2\2\2\u0082\u0083\7-\2\2\u0083\36"+
		"\3\2\2\2\u0084\u0085\7/\2\2\u0085 \3\2\2\2\u0086\u0087\7\61\2\2\u0087"+
		"\"\3\2\2\2\u0088\u0089\7,\2\2\u0089$\3\2\2\2\u008a\u008b\7\'\2\2\u008b"+
		"&\3\2\2\2\u008c\u008d\7(\2\2\u008d\u008e\7(\2\2\u008e(\3\2\2\2\u008f\u0090"+
		"\7~\2\2\u0090\u0091\7~\2\2\u0091*\3\2\2\2\u0092\u0093\7@\2\2\u0093\u0094"+
		"\7?\2\2\u0094,\3\2\2\2\u0095\u0096\7@\2\2\u0096.\3\2\2\2\u0097\u0098\7"+
		">\2\2\u0098\u0099\7?\2\2\u0099\60\3\2\2\2\u009a\u009b\7>\2\2\u009b\62"+
		"\3\2\2\2\u009c\u009d\7?\2\2\u009d\u009e\7?\2\2\u009e\64\3\2\2\2\u009f"+
		"\u00a0\7#\2\2\u00a0\u00a1\7?\2\2\u00a1\66\3\2\2\2\u00a2\u00a3\7?\2\2\u00a3"+
		"8\3\2\2\2\u00a4\u00a5\7/\2\2\u00a5\u00a6\7@\2\2\u00a6:\3\2\2\2\u00a7\u00a8"+
		"\7<\2\2\u00a8\u00a9\7<\2\2\u00a9<\3\2\2\2\u00aa\u00ab\7<\2\2\u00ab>\3"+
		"\2\2\2\u00ac\u00ad\7.\2\2\u00ad@\3\2\2\2\u00ae\u00af\7*\2\2\u00afB\3\2"+
		"\2\2\u00b0\u00b1\7+\2\2\u00b1D\3\2\2\2\u00b2\u00b3\7\60\2\2\u00b3F\3\2"+
		"\2\2\u00b4\u00b5\7=\2\2\u00b5H\3\2\2\2\b\2`hoy~\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}