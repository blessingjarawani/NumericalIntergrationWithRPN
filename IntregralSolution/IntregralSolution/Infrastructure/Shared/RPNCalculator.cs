using IntregralSolution.Infrastructure.Shared.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace IntregralSolution.Infrastructure.Shared
{
    public static class RPNCalculator
    {
        static Operators myoperators = new Operators();
        public static string InfixToPostfix(string infix)
        {
           
            string output = "";
            Stack<string> Operators = new Stack<string>();
           
            string pattern = @"(?<=[-+*/(),^<>=&])(?=.)|(?<=.)(?=[-+*/(),^<>=&])";
           
            Regex regExPattern = new Regex(pattern);

           var array = regExPattern.Split(infix).Where(s => !String.IsNullOrEmpty(s.Trim())).ToList();

            foreach (var item in array)
            {
                if (double.TryParse(item, out double op))
                {
                    output += item + " ";
                }
                else if (item == "(")
                {
                    Operators.Push(item);
                }
                else if (item == ")")
                {
                    while (Operators.Peek() != "(")
                    {
                        output += Operators.Pop() + " ";
                    }

                    Operators.Pop();
                }
                else
                {
                    while (Operators?.Count() > 0 && (Precedence(Operators.Peek()) > Precedence(item) || Precedence(Operators.Peek()) == Precedence(item) && Associativity(item) == "left"))
                    {
                        output += Operators.Pop() + " ";
                    }

                    Operators.Push(item);
                }
            }
            while (Operators?.Count() > 0)
            {
                output += Operators.Pop() + " ";
            }
            output = output.TrimEnd(' ');
            return output;
        }
        public static double PostfixEvaluator(string expression)
        {
           
            Stack<double> OperandStack = new Stack<double>();
            foreach (var item in expression.Split(' '))
            {
                if (double.TryParse(item, out double operand))
                {
                    OperandStack.Push(operand);
                }
                else
                {
                    double op2 = OperandStack.Pop();
                    double op1 = OperandStack.Pop();
                    double output = Evaluate(op1, op2, item);
                    OperandStack.Push(output);
                }
            }
            return OperandStack.Pop();

        }
        public static double Evaluate(double op1, double op2, string oper)
        {
            switch (oper)
            {
                case "+":
                    return op1 + op2;
                case "-":
                    return op1 - op2;
                case "*":
                    return op1 * op2;
                case "/":
                    return op1 / op2;
                case "^":
                    return Math.Pow(op1, op2);
                default:
                    return 0;
            }


        }
        public static string Associativity(string op)
        {
            if (op == "^")
            {
                return "right";
            }
            else
            {
                return "left";
            }
        }
        public static int Precedence(string op)
        {
            int result = myoperators.GetOperatorPrecedence().TryGetValue(op, out int value) ? myoperators.GetOperatorPrecedence()[op] : -1;
            return result;
        }


    }
}


