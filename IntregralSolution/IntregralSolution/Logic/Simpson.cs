using IntregralSolution.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IntregralSolution.Infrastructure.Shared.Util;

namespace IntregralSolution.Logic
{
    public class Simpson
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


        public double SimpsonIntergral(float lower, float upper, string expression)
        {
            double iterator = 201;
            double interval_size = (upper - lower)
                                  / iterator;
            var sum = GetFunctionValue(lower,expression) + GetFunctionValue(upper,expression);

           for (int i = 1; i < iterator; i++)
            {
                if (i % 3 == 0)
                    sum = sum + 2 * GetFunctionValue(lower + i * interval_size,expression);
                else
                    sum = sum + 3 * GetFunctionValue(lower + i * interval_size,expression);
            }
            return (3 * interval_size / 8) * sum;
        }
    }
    
}
