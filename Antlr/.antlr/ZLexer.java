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
		INT=9, CHARACTER_CONSTANT=10, PLUS=11, MINUS=12, DIVIDE=13, TIMES=14, 
		MOD=15, LOGICAL_AND=16, LOGICAL_OR=17, GTE=18, GT=19, LTE=20, LT=21, EQ=22, 
		NEQ=23, ASSIGN=24, SINGLE_ARROW=25, DOUBLE_COLON=26, COLON=27, COMMA=28, 
		LPAREN=29, RPAREN=30, DOT=31, SEMI_COLON=32, BLOCK_COMMENT=33, LINE_COMMENT=34;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"IF", "THEN", "ELSE", "LET", "IN", "WS", "LOWERCASE_ID", "UPPERCASE_ID", 
		"UPPER_CHAR", "LOWER_CHAR", "ID_CHAR", "INT", "DIGIT", "CHARACTER_CONSTANT", 
		"CHAR", "ESCAPE_SEQUENCE", "SIMPLE_ESCAPE", "PLUS", "MINUS", "DIVIDE", 
		"TIMES", "MOD", "LOGICAL_AND", "LOGICAL_OR", "GTE", "GT", "LTE", "LT", 
		"EQ", "NEQ", "ASSIGN", "SINGLE_ARROW", "DOUBLE_COLON", "COLON", "COMMA", 
		"LPAREN", "RPAREN", "DOT", "SEMI_COLON", "BLOCK_COMMENT", "LINE_COMMENT"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2$\u00e9\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\3\2\3\2"+
		"\3\2\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\6\3\6\3"+
		"\6\3\7\6\7k\n\7\r\7\16\7l\3\7\3\7\3\b\3\b\7\bs\n\b\f\b\16\bv\13\b\3\t"+
		"\3\t\7\tz\n\t\f\t\16\t}\13\t\3\n\3\n\3\13\3\13\3\f\3\f\3\f\3\f\5\f\u0087"+
		"\n\f\3\r\6\r\u008a\n\r\r\r\16\r\u008b\3\16\3\16\3\17\3\17\3\17\3\17\3"+
		"\20\3\20\5\20\u0096\n\20\3\21\3\21\3\22\3\22\3\22\3\23\3\23\3\24\3\24"+
		"\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\30\3\31\3\31\3\31\3\32\3\32"+
		"\3\32\3\33\3\33\3\34\3\34\3\34\3\35\3\35\3\36\3\36\3\36\3\37\3\37\3\37"+
		"\3 \3 \3!\3!\3!\3\"\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3)\3"+
		")\3)\3)\7)\u00d5\n)\f)\16)\u00d8\13)\3)\3)\3)\3)\3)\3*\3*\3*\3*\7*\u00e3"+
		"\n*\f*\16*\u00e6\13*\3*\3*\3\u00d6\2+\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21"+
		"\n\23\2\25\2\27\2\31\13\33\2\35\f\37\2!\2#\2%\r\'\16)\17+\20-\21/\22\61"+
		"\23\63\24\65\25\67\269\27;\30=\31?\32A\33C\34E\35G\36I\37K M!O\"Q#S$\3"+
		"\2\n\5\2\13\f\17\17\"\"\3\2C\\\3\2c|\3\2aa\3\2\62;\6\2\f\f\17\17))^^\f"+
		"\2$$))AA^^cdhhppttvvxx\4\2\f\f\17\17\2\u00eb\2\3\3\2\2\2\2\5\3\2\2\2\2"+
		"\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2"+
		"\2\2\2\31\3\2\2\2\2\35\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3"+
		"\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2"+
		"\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C"+
		"\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2"+
		"\2\2\2Q\3\2\2\2\2S\3\2\2\2\3U\3\2\2\2\5X\3\2\2\2\7]\3\2\2\2\tb\3\2\2\2"+
		"\13f\3\2\2\2\rj\3\2\2\2\17p\3\2\2\2\21w\3\2\2\2\23~\3\2\2\2\25\u0080\3"+
		"\2\2\2\27\u0086\3\2\2\2\31\u0089\3\2\2\2\33\u008d\3\2\2\2\35\u008f\3\2"+
		"\2\2\37\u0095\3\2\2\2!\u0097\3\2\2\2#\u0099\3\2\2\2%\u009c\3\2\2\2\'\u009e"+
		"\3\2\2\2)\u00a0\3\2\2\2+\u00a2\3\2\2\2-\u00a4\3\2\2\2/\u00a6\3\2\2\2\61"+
		"\u00a9\3\2\2\2\63\u00ac\3\2\2\2\65\u00af\3\2\2\2\67\u00b1\3\2\2\29\u00b4"+
		"\3\2\2\2;\u00b6\3\2\2\2=\u00b9\3\2\2\2?\u00bc\3\2\2\2A\u00be\3\2\2\2C"+
		"\u00c1\3\2\2\2E\u00c4\3\2\2\2G\u00c6\3\2\2\2I\u00c8\3\2\2\2K\u00ca\3\2"+
		"\2\2M\u00cc\3\2\2\2O\u00ce\3\2\2\2Q\u00d0\3\2\2\2S\u00de\3\2\2\2UV\7k"+
		"\2\2VW\7h\2\2W\4\3\2\2\2XY\7v\2\2YZ\7j\2\2Z[\7g\2\2[\\\7p\2\2\\\6\3\2"+
		"\2\2]^\7g\2\2^_\7n\2\2_`\7u\2\2`a\7g\2\2a\b\3\2\2\2bc\7n\2\2cd\7g\2\2"+
		"de\7v\2\2e\n\3\2\2\2fg\7k\2\2gh\7p\2\2h\f\3\2\2\2ik\t\2\2\2ji\3\2\2\2"+
		"kl\3\2\2\2lj\3\2\2\2lm\3\2\2\2mn\3\2\2\2no\b\7\2\2o\16\3\2\2\2pt\5\25"+
		"\13\2qs\5\27\f\2rq\3\2\2\2sv\3\2\2\2tr\3\2\2\2tu\3\2\2\2u\20\3\2\2\2v"+
		"t\3\2\2\2w{\5\23\n\2xz\5\27\f\2yx\3\2\2\2z}\3\2\2\2{y\3\2\2\2{|\3\2\2"+
		"\2|\22\3\2\2\2}{\3\2\2\2~\177\t\3\2\2\177\24\3\2\2\2\u0080\u0081\t\4\2"+
		"\2\u0081\26\3\2\2\2\u0082\u0087\5\23\n\2\u0083\u0087\5\25\13\2\u0084\u0087"+
		"\5\31\r\2\u0085\u0087\t\5\2\2\u0086\u0082\3\2\2\2\u0086\u0083\3\2\2\2"+
		"\u0086\u0084\3\2\2\2\u0086\u0085\3\2\2\2\u0087\30\3\2\2\2\u0088\u008a"+
		"\5\33\16\2\u0089\u0088\3\2\2\2\u008a\u008b\3\2\2\2\u008b\u0089\3\2\2\2"+
		"\u008b\u008c\3\2\2\2\u008c\32\3\2\2\2\u008d\u008e\t\6\2\2\u008e\34\3\2"+
		"\2\2\u008f\u0090\7)\2\2\u0090\u0091\5\37\20\2\u0091\u0092\7)\2\2\u0092"+
		"\36\3\2\2\2\u0093\u0096\n\7\2\2\u0094\u0096\5!\21\2\u0095\u0093\3\2\2"+
		"\2\u0095\u0094\3\2\2\2\u0096 \3\2\2\2\u0097\u0098\5#\22\2\u0098\"\3\2"+
		"\2\2\u0099\u009a\7^\2\2\u009a\u009b\t\b\2\2\u009b$\3\2\2\2\u009c\u009d"+
		"\7-\2\2\u009d&\3\2\2\2\u009e\u009f\7/\2\2\u009f(\3\2\2\2\u00a0\u00a1\7"+
		"\61\2\2\u00a1*\3\2\2\2\u00a2\u00a3\7,\2\2\u00a3,\3\2\2\2\u00a4\u00a5\7"+
		"\'\2\2\u00a5.\3\2\2\2\u00a6\u00a7\7(\2\2\u00a7\u00a8\7(\2\2\u00a8\60\3"+
		"\2\2\2\u00a9\u00aa\7~\2\2\u00aa\u00ab\7~\2\2\u00ab\62\3\2\2\2\u00ac\u00ad"+
		"\7@\2\2\u00ad\u00ae\7?\2\2\u00ae\64\3\2\2\2\u00af\u00b0\7@\2\2\u00b0\66"+
		"\3\2\2\2\u00b1\u00b2\7>\2\2\u00b2\u00b3\7?\2\2\u00b38\3\2\2\2\u00b4\u00b5"+
		"\7>\2\2\u00b5:\3\2\2\2\u00b6\u00b7\7?\2\2\u00b7\u00b8\7?\2\2\u00b8<\3"+
		"\2\2\2\u00b9\u00ba\7#\2\2\u00ba\u00bb\7?\2\2\u00bb>\3\2\2\2\u00bc\u00bd"+
		"\7?\2\2\u00bd@\3\2\2\2\u00be\u00bf\7/\2\2\u00bf\u00c0\7@\2\2\u00c0B\3"+
		"\2\2\2\u00c1\u00c2\7<\2\2\u00c2\u00c3\7<\2\2\u00c3D\3\2\2\2\u00c4\u00c5"+
		"\7<\2\2\u00c5F\3\2\2\2\u00c6\u00c7\7.\2\2\u00c7H\3\2\2\2\u00c8\u00c9\7"+
		"*\2\2\u00c9J\3\2\2\2\u00ca\u00cb\7+\2\2\u00cbL\3\2\2\2\u00cc\u00cd\7\60"+
		"\2\2\u00cdN\3\2\2\2\u00ce\u00cf\7=\2\2\u00cfP\3\2\2\2\u00d0\u00d1\7\61"+
		"\2\2\u00d1\u00d2\7,\2\2\u00d2\u00d6\3\2\2\2\u00d3\u00d5\13\2\2\2\u00d4"+
		"\u00d3\3\2\2\2\u00d5\u00d8\3\2\2\2\u00d6\u00d7\3\2\2\2\u00d6\u00d4\3\2"+
		"\2\2\u00d7\u00d9\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d9\u00da\7,\2\2\u00da"+
		"\u00db\7\61\2\2\u00db\u00dc\3\2\2\2\u00dc\u00dd\b)\2\2\u00ddR\3\2\2\2"+
		"\u00de\u00df\7\61\2\2\u00df\u00e0\7\61\2\2\u00e0\u00e4\3\2\2\2\u00e1\u00e3"+
		"\n\t\2\2\u00e2\u00e1\3\2\2\2\u00e3\u00e6\3\2\2\2\u00e4\u00e2\3\2\2\2\u00e4"+
		"\u00e5\3\2\2\2\u00e5\u00e7\3\2\2\2\u00e6\u00e4\3\2\2\2\u00e7\u00e8\b*"+
		"\2\2\u00e8T\3\2\2\2\13\2lt{\u0086\u008b\u0095\u00d6\u00e4\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}