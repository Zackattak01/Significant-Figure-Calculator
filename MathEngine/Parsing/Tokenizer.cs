using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace MathEngine
{
    public class Tokenizer : ITokenizer
    {
        public Tokenizer(string expression)
        {
            Initialize(expression);
        }

        //this constructor is here to allow a inheriting class to defer initialization until it has had a chance to init its local vars
        //the inheriting class will be responsible for initing the local vars here however which is why the Initalize method exists to reduce code dupe
        protected Tokenizer()
		{

		}

        public int CurrentToken { get; protected set; }


        public double CurrentNumber { get; protected set; }


        protected int currentIndex = -1;
        protected char[] chars;
        protected char currentChar;

        protected virtual void Initialize(string expression)
		{
            chars = expression.ToCharArray();
            NextChar();
            NextToken();
        }

        protected void NextChar()
        {

            do
            {

                currentIndex++;
                if (currentIndex >= chars.Length)
                {
                    currentChar = '\0';
                }
                else
                {
                    currentChar = chars[currentIndex];
                }

            }
            while (char.IsWhiteSpace(currentChar));

        }

        public virtual void NextToken()
        {

            if (ParseSpecialChar())
                return;

            if (ParseNumber())
                return;


        }

        protected virtual bool ParseSpecialChar()
		{
            switch (currentChar)
            {
                case '\0':
                    CurrentToken = Token.EOE;
                    return true;

                case '+':
                    NextChar();
                    CurrentToken = Token.Add;
                    return true;

                case '-':
                    NextChar();
                    CurrentToken = Token.Subtract;
                    return true;

                case '*':
                    NextChar();
                    CurrentToken = Token.Multiply;
                    return true;

                case '/':
                    NextChar();
                    CurrentToken = Token.Divide;
                    return true;

                case '^':
                    NextChar();
                    CurrentToken = Token.Power;
                    return true;

                case '(':
                    NextChar();
                    CurrentToken = Token.ParenOpen;
                    return true;

                case ')':
                    NextChar();
                    CurrentToken = Token.ParenClose;
                    return true;
                default:
                    return false;

            }
        }

        protected virtual bool ParseNumber()
		{
            if (char.IsDigit(currentChar) || currentChar == '.')
            {
                bool hasDecimalPoint = false;

                string num = "";

                while (char.IsDigit(currentChar) || (!hasDecimalPoint && currentChar == '.'))
                {
                    num += currentChar;
                    hasDecimalPoint = currentChar == '.';
                    NextChar();
                }

                CurrentNumber = double.Parse(num);

                CurrentToken = Token.Number;
                return true ;
            }

            return false;
        }

	}
}
