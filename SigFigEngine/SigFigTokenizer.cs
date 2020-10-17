using System;
using System.Collections.Generic;
using System.Text;
using MathEngine;

namespace MathEngine.SigFig
{
	public class SigFigTokenizer : Tokenizer, ITokenizer
	{
		public SigFigTokenizer(string expression, char escapeChar = 'a')
			:base()
		{

            EscapeChar = escapeChar;
            NumbersParsed = new List<string>();
            Initialize(expression);
        }

        public char EscapeChar { get; }

        public List<string> NumbersParsed { get; protected set; }


		public override void NextToken()
		{
            if (ParseSpecialChar())
                return;

            if (ParseNumber())
                return;
        }

        protected override bool ParseNumber()
        {
            if (char.IsDigit(currentChar) || currentChar == '.' || currentChar == EscapeChar)
            {
                bool hasDecimalPoint = false;
                bool isEscaped = currentChar == EscapeChar;

                if (isEscaped)
                {
                    //chars[currentIndex] = ' ';
                    NextChar();
                }


                string num = "";

                while (char.IsDigit(currentChar) || (!hasDecimalPoint && currentChar == '.'))
                {
                    num += currentChar;
                    hasDecimalPoint = currentChar == '.';
                    NextChar();
                }

                CurrentNumber = double.Parse(num);

                if (!isEscaped)
                    NumbersParsed.Add(num);

                CurrentToken = Token.Number;
                return true;
            }

            return true;
        }
	}
}
