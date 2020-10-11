using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public class UnaryNode : Node
	{

		public UnaryNode(Node rhs, Func<double, double> op)
		{
			this.rhs = rhs;
			this.op = op;
		}

		Node rhs;
		Func<double, double> op;

		public override double Eval()
		{
			return op(rhs.Eval());
		}
	}
}
