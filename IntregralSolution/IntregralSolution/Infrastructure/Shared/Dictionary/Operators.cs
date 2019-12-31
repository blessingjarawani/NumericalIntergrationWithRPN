using System;
using System.Collections.Generic;
using System.Text;

namespace IntregralSolution.Infrastructure.Shared.Dictionary
{
    public class Operators
    {
        Dictionary<string, int> operators = new Dictionary<string, int>()
        {
            {"^", 4},
            {"/", 3},
            {"*", 3},
            {"+", 2},
            {"-", 2}

        };
        public Dictionary<string, int> GetOperatorPrecedence()
        {
            return operators;
        }

    }
}