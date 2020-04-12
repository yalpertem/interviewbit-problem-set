using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level4.StacksAndQueues
{
    /// <summary>
    /// Simplify Directory Path
    /// https://www.interviewbit.com/problems/simplify-directory-path/
    /// </summary>
    public class SimplifyDirectoryPath
    {
        /*
        Given a string A representing an absolute path for a file (Unix-style).
        Return the string A after simplifying the absolute path.

        Note:
        Absolute path always begin with ’/’ ( root directory ).
        Path will not have whitespace characters.

        Input Format
        The only argument given is string A.
        Output Format
        Return a string denoting the simplified absolue path for a file (Unix-style).

        Examples

        Input 1:
            A = "/home/"
        Output 1:
            "/home"

        Input 2:
            A = "/a/./b/../../c/"
        Output 2:
            "/c"
        */

        public string Solve(string str)
        {
            var splittedPath = str.Split('/');
            var stack = new Stack<string>();
            for (var i = 0; i < splittedPath.Length; i++)
            {
                var part = splittedPath[i];
                if (part == "" || part == ".")
                {
                    continue;
                }
                else if (part == "..")
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(part);
                }
            }

            if (stack.Count == 0)
            {
                return "/";
            }

            var reverseStack = new Stack<string>();
            while (stack.Count > 0)
            {
                reverseStack.Push(stack.Pop());
            }

            var sb = new StringBuilder("/");
            while (reverseStack.Count > 0)
            {
                sb.Append("/");
                sb.Append(reverseStack.Pop());
            }
            return sb.ToString();
        }
    }
}
