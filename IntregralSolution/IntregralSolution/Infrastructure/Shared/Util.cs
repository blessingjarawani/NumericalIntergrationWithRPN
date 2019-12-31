using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IntregralSolution.Infrastructure.Shared
{
    public static class Util
    {
        public  enum Parameters
        {
            X,
        }
        public class ExpressionParser
        {
            private Dictionary<Parameters, double> _Parameters = new Dictionary<Parameters, double>();
            public Dictionary<Parameters, double> Parameters
            {
                get { return _Parameters; }
                set { _Parameters = value; }
            }

          
            public double Calculate(string Formula)
            {
                try
                {
                    string[] arr = Formula.Split("^/+-*()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (KeyValuePair<Parameters, double> de in _Parameters)
                    {
                        foreach (string s in arr)
                        {
                            if (s != de.Key.ToString() && s.EndsWith(de.Key.ToString()))
                            {
                                Formula = Formula.Replace(s, (Convert.ToDouble(s.Replace(de.Key.ToString(), "")) * de.Value).ToString());
                            }
                        }
                        Formula = Formula.Replace(de.Key.ToString(), de.Value.ToString());
                    }

                    var postFix = RPNCalculator.InfixToPostfix(Formula);
                    double outputpostfix = RPNCalculator.PostfixEvaluator(postFix);
                    return outputpostfix;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Occured While Calculating.", ex.GetBaseException());
                }
            }
        }
        }
}
