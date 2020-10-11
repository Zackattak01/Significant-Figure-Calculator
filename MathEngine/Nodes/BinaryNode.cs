using System;
using System.Collections.Generic;
using System.Text;

namespace MathEngine
{
	public class BinaryNode : Node
	{


		public BinaryNode(Node lhs, Node rhs, Func<double, double, double> op)
		{
			this.lhs = lhs;
			this.rhs = rhs;
			this.op = op;
		}

		Node lhs;
		Node rhs;
		Func<double, double, double> op;

		public override double Eval()
		{
			return op(lhs.Eval(), rhs.Eval());
		}
	}
}
