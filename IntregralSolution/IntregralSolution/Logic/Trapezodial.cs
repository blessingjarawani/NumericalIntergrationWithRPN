using IntregralSolution.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IntregralSolution.Infrastructure.Shared.Util;

namespace IntregralSolution.Logic
{
    class Trapezodial
    {
        ExpressionParser expresionParser = new ExpressionParser();
        double GetFunctionValue(double value, string expression)
        {
            var param = expresionParser.Parameters.Where(x => x.Key == Parameters.X);
            if (param.Count() == 0)
            {
                expresionParser.Parameters.Add(Util.Parameters.X, value);
            }
            expresionParser.Parameters.ToList().ForEach(y => expresionParser.Parameters[y.Key] = value);
            double answer = expresionParser.Calculate(expression);
            return answer;
        }


        public double TrapezoidalIntergral(float lower, float upper, string expression)
        {
            double iterator = 201;
            double mid = (upper - lower) / iterator;
            double value = GetFunctionValue(lower, expression) + GetFunctionValue(upper, expression);
            for (int counter = 1; counter < iterator; counter++)
            {
                value += 2 * GetFunctionValue(lower + counter * mid, expression);
            }
            return (mid / 2) * value;
        }
    }
}
