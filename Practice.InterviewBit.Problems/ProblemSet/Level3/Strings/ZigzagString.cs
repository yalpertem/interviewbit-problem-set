using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level3.Strings
{
    /// <summary>
    /// Zigzag String
    /// https://www.interviewbit.com/problems/zigzag-string/
    /// </summary>
    public class ZigzagString
    {
        /*
        The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
        P.......A........H.......N
        ..A..P....L....S....I...I....G
        ....Y.........I........R
        And then read line by line: PAHNAPLSIIGYIR
        Write the code that will take a string and make this conversion given a number of rows:

        string convert(string text, int nRows);
        convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR"
        
        Example 2 :
        ABCD, 2 can be written as

        A....C
        ...B....D
        and hence the answer would be ACBD.
        */

        public string Solve(string str, int lines)
        {
            if (lines <= 1)
            {
                return str;
            }

            var maxAddition = 2 * lines - 2;
            var curAddition = maxAddition;
            var result = "";

            for (var i = 0; i < lines; i++)
            {
                if (i < str.Length)
                {
                    result += str[i];
                }
                var start = i;
                while (start <= str.Length)
                {
                    var pos1 = start + curAddition;
                    if (pos1 < str.Length && curAddition != 0)
                    {
                        result += str[pos1];
                    }

                    var pos2 = pos1 + maxAddition - curAddition;
                    if (pos2 < str.Length && maxAddition != curAddition)
                    {
                        result += str[pos2];
                    }
                    start += maxAddition;
                }
                curAddition -= 2;
            }

            return result;
        }
    }
}
