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
            double iterator = 200;
            double evenSum =0 , oddSum = 0;
            double count = iterator / 2;

            double distance = (upper - lower)
                                  / iterator;
            var sum = GetFunctionValue(lower,expression) + GetFunctionValue(upper,expression);

            for (int i = 1; i <= count; i++)
            {
                oddSum += GetFunctionValue((lower + (2 * i - 1 ) * distance), expression);
               
            }
            oddSum *= 4;
            for (int i = 1; i < count; i++)
            {
                evenSum += GetFunctionValue((lower + (i * 2) * distance), expression);
                
            }
            evenSum *= 2;
            sum += oddSum + evenSum;
            sum *= (distance / 3);
            return  sum;
        }
    }
    
}
