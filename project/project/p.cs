
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                          =  0, // (EOF)
        SYMBOL_ERROR                        =  1, // (Error)
        SYMBOL_WHITESPACE                   =  2, // Whitespace
        SYMBOL_MINUS                        =  3, // '-'
        SYMBOL_EXCLAMEQ                     =  4, // '!='
        SYMBOL_LPAREN                       =  5, // '('
        SYMBOL_RPAREN                       =  6, // ')'
        SYMBOL_TIMES                        =  7, // '*'
        SYMBOL_COMMA                        =  8, // ','
        SYMBOL_DIV                          =  9, // '/'
        SYMBOL_COLON                        = 10, // ':'
        SYMBOL_PLUS                         = 11, // '+'
        SYMBOL_LT                           = 12, // '<'
        SYMBOL_EQ                           = 13, // '='
        SYMBOL_EQEQ                         = 14, // '=='
        SYMBOL_GT                           = 15, // '>'
        SYMBOL_AND                          = 16, // and
        SYMBOL_BOOLEANLITERAL               = 17, // BooleanLiteral
        SYMBOL_DEF                          = 18, // def
        SYMBOL_ELSE                         = 19, // else
        SYMBOL_FLOATLITERAL                 = 20, // FloatLiteral
        SYMBOL_FOR                          = 21, // for
        SYMBOL_IDENTIFIER                   = 22, // Identifier
        SYMBOL_IF                           = 23, // if
        SYMBOL_IN                           = 24, // in
        SYMBOL_INTEGERLITERAL               = 25, // IntegerLiteral
        SYMBOL_NOT                          = 26, // not
        SYMBOL_OR                           = 27, // or
        SYMBOL_STRINGLITERAL                = 28, // StringLiteral
        SYMBOL_WHILE                        = 29, // while
        SYMBOL_CONDITIONALSTATEMENT         = 30, // <ConditionalStatement>
        SYMBOL_EXPRESSION                   = 31, // <Expression>
        SYMBOL_FUNCTIONDEFINITION           = 32, // <FunctionDefinition>
        SYMBOL_LOOPSTATEMENT                = 33, // <LoopStatement>
        SYMBOL_PARAMETERS                   = 34, // <Parameters>
        SYMBOL_PROGRAM                      = 35, // <Program>
        SYMBOL_STATEMENT                    = 36, // <Statement>
        SYMBOL_STATEMENTS                   = 37, // <Statements>
        SYMBOL_VARIABLEDECLARATIONSTATEMENT = 38  // <VariableDeclarationStatement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                               =  0, // <Program> ::= <Statements>
        RULE_STATEMENTS                                            =  1, // <Statements> ::= <Statement>
        RULE_STATEMENTS2                                           =  2, // <Statements> ::= <Statements> <Statement>
        RULE_STATEMENT                                             =  3, // <Statement> ::= <VariableDeclarationStatement>
        RULE_STATEMENT2                                            =  4, // <Statement> ::= <ConditionalStatement>
        RULE_STATEMENT3                                            =  5, // <Statement> ::= <LoopStatement>
        RULE_STATEMENT4                                            =  6, // <Statement> ::= <FunctionDefinition>
        RULE_STATEMENT5                                            =  7, // <Statement> ::= <Expression>
        RULE_VARIABLEDECLARATIONSTATEMENT_IDENTIFIER_EQ            =  8, // <VariableDeclarationStatement> ::= Identifier '=' <Expression>
        RULE_VARIABLEDECLARATIONSTATEMENT_IDENTIFIER_EQ2           =  9, // <VariableDeclarationStatement> ::= Identifier '=' <Expression> <Expression>
        RULE_CONDITIONALSTATEMENT_IF_COLON                         = 10, // <ConditionalStatement> ::= if <Expression> ':' <Statements>
        RULE_CONDITIONALSTATEMENT_IF_COLON_ELSE_COLON              = 11, // <ConditionalStatement> ::= if <Expression> ':' <Statements> else ':' <Statements>
        RULE_LOOPSTATEMENT_WHILE_COLON                             = 12, // <LoopStatement> ::= while <Expression> ':' <Statements>
        RULE_LOOPSTATEMENT_FOR_IDENTIFIER_IN_COLON                 = 13, // <LoopStatement> ::= for Identifier in <Expression> ':' <Statements>
        RULE_FUNCTIONDEFINITION_DEF_IDENTIFIER_LPAREN_RPAREN_COLON = 14, // <FunctionDefinition> ::= def Identifier '(' <Parameters> ')' ':' <Statements>
        RULE_PARAMETERS_IDENTIFIER                                 = 15, // <Parameters> ::= Identifier
        RULE_PARAMETERS_IDENTIFIER_COMMA                           = 16, // <Parameters> ::= Identifier ',' <Parameters>
        RULE_EXPRESSION_IDENTIFIER                                 = 17, // <Expression> ::= Identifier
        RULE_EXPRESSION_INTEGERLITERAL                             = 18, // <Expression> ::= IntegerLiteral
        RULE_EXPRESSION_FLOATLITERAL                               = 19, // <Expression> ::= FloatLiteral
        RULE_EXPRESSION_STRINGLITERAL                              = 20, // <Expression> ::= StringLiteral
        RULE_EXPRESSION_BOOLEANLITERAL                             = 21, // <Expression> ::= BooleanLiteral
        RULE_EXPRESSION_PLUS                                       = 22, // <Expression> ::= <Expression> '+' <Expression>
        RULE_EXPRESSION_MINUS                                      = 23, // <Expression> ::= <Expression> '-' <Expression>
        RULE_EXPRESSION_TIMES                                      = 24, // <Expression> ::= <Expression> '*' <Expression>
        RULE_EXPRESSION_DIV                                        = 25, // <Expression> ::= <Expression> '/' <Expression>
        RULE_EXPRESSION_LT                                         = 26, // <Expression> ::= <Expression> '<' <Expression>
        RULE_EXPRESSION_GT                                         = 27, // <Expression> ::= <Expression> '>' <Expression>
        RULE_EXPRESSION_EQEQ                                       = 28, // <Expression> ::= <Expression> '==' <Expression>
        RULE_EXPRESSION_EXCLAMEQ                                   = 29, // <Expression> ::= <Expression> '!=' <Expression>
        RULE_EXPRESSION_AND                                        = 30, // <Expression> ::= <Expression> and <Expression>
        RULE_EXPRESSION_OR                                         = 31, // <Expression> ::= <Expression> or <Expression>
        RULE_EXPRESSION_NOT                                        = 32, // <Expression> ::= not <Expression>
        RULE_EXPRESSION_LPAREN_RPAREN                              = 33  // <Expression> ::= '(' <Expression> ')'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;
        public MyParser(string filename, ListBox lst ,ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            this.ls = ls;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //and
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEANLITERAL :
                //BooleanLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEF :
                //def
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOATLITERAL :
                //FloatLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGERLITERAL :
                //IntegerLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOT :
                //not
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //or
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITIONALSTATEMENT :
                //<ConditionalStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONDEFINITION :
                //<FunctionDefinition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOPSTATEMENT :
                //<LoopStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERS :
                //<Parameters>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTS :
                //<Statements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATIONSTATEMENT :
                //<VariableDeclarationStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <Statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS :
                //<Statements> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS2 :
                //<Statements> ::= <Statements> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <VariableDeclarationStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <ConditionalStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <LoopStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <FunctionDefinition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATIONSTATEMENT_IDENTIFIER_EQ :
                //<VariableDeclarationStatement> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATIONSTATEMENT_IDENTIFIER_EQ2 :
                //<VariableDeclarationStatement> ::= Identifier '=' <Expression> <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALSTATEMENT_IF_COLON :
                //<ConditionalStatement> ::= if <Expression> ':' <Statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALSTATEMENT_IF_COLON_ELSE_COLON :
                //<ConditionalStatement> ::= if <Expression> ':' <Statements> else ':' <Statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOPSTATEMENT_WHILE_COLON :
                //<LoopStatement> ::= while <Expression> ':' <Statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOPSTATEMENT_FOR_IDENTIFIER_IN_COLON :
                //<LoopStatement> ::= for Identifier in <Expression> ':' <Statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDEFINITION_DEF_IDENTIFIER_LPAREN_RPAREN_COLON :
                //<FunctionDefinition> ::= def Identifier '(' <Parameters> ')' ':' <Statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_IDENTIFIER :
                //<Parameters> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_IDENTIFIER_COMMA :
                //<Parameters> ::= Identifier ',' <Parameters>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_IDENTIFIER :
                //<Expression> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_INTEGERLITERAL :
                //<Expression> ::= IntegerLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_FLOATLITERAL :
                //<Expression> ::= FloatLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_STRINGLITERAL :
                //<Expression> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_BOOLEANLITERAL :
                //<Expression> ::= BooleanLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUS :
                //<Expression> ::= <Expression> '+' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUS :
                //<Expression> ::= <Expression> '-' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_TIMES :
                //<Expression> ::= <Expression> '*' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_DIV :
                //<Expression> ::= <Expression> '/' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQ :
                //<Expression> ::= <Expression> '==' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EXCLAMEQ :
                //<Expression> ::= <Expression> '!=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_AND :
                //<Expression> ::= <Expression> and <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_OR :
                //<Expression> ::= <Expression> or <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_NOT :
                //<Expression> ::= not <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LPAREN_RPAREN :
                //<Expression> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "' in line " + args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "Expexted Token " + args.ExpectedTokens.ToString();
            lst.Items.Add((string)m2);
            //todo: Report message to UI?
        }
        private void TokenReadEvent(LALRParser pr,TokenReadEventArgs args)
        {
            string info = args.Token.Text + "   \t \t" +(SymbolConstants) args.Token.Symbol.Id;
            ls.Items.Add(info);

        }

    }
}
