using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public interface IParser
	{
		Node ParseExpression();
	}
}
