using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level4.StacksAndQueues
{
    /// <summary>
    /// Evaluate Expression
    /// https://www.interviewbit.com/problems/evaluate-expression/
    /// </summary>
    public class EvaluateExpression
    {
        /*
        Evaluate the value of an arithmetic expression in Reverse Polish Notation.
        Valid operators are +, -, *, /. Each operand may be an integer or another expression.

        Input Format
        The only argument given is character array A.
        Output Format
        Return the value of arithmetic expression formed using reverse Polish Notation.
        
        For Example

        Input 1:
            A =   ["2", "1", "+", "3", "*"]
        Output 1:
            9
        Explaination 1:
            starting from backside:
            *: ( )*( )
            3: ()*(3)
            +: ( () + () )*(3)
            1: ( () + (1) )*(3)
            2: ( (2) + (1) )*(3)
            ((2)+(1))*(3) = 9
    
        Input 2:
            A = ["4", "13", "5", "/", "+"]
        Output 2:
            6
        Explaination 2:
            +: ()+()
            /: ()+(() / ())
            5: ()+(() / (5))
            1: ()+((13) / (5))
            4: (4)+((13) / (5))
            (4)+((13) / (5)) = 6
        */

        public int Solve(List<string> A)
        {
            var stack = new Stack<string>();

            for (var i = A.Count - 1; i >= 0; i--)
            {
                stack.Push(A[i]);
                EvalStackIfNecessary(stack);
            }
            var result = stack.Pop();
            return int.Parse(result);
        }

        private void EvalStackIfNecessary(Stack<string> stack)
        {
            while (true)
            {
                var stackTop = stack.Peek();
                if (stackTop == null || IsOperation(stackTop))
                {
                    break;
                }

                var stackTopNum = int.Parse(stack.Pop());
                var stackSecondTop = stack.Peek();
                if (stackSecondTop == null || IsOperation(stackSecondTop))
                {
                    stack.Push(stackTop);
                    break;
                }
                else
                {
                    var stackSecondTopNum = int.Parse(stack.Pop());
                    var stackOp = stack.Pop();
                    var currentResult = EvalSingle(stackTopNum,
                        stackSecondTopNum, stackOp);
                    stack.Push(currentResult.ToString());
                }
            }

        }

        private bool IsOperation(string s)
        {
            return s == "+" || s == "-" || s == "*" || s == "/";
        }

        private int EvalSingle(int num1, int num2, string operation)
        {
            return operation switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "/" => num1 / num2,
                "*" => num1 * num2,
                _ => 0,
            };
        }
    }
}
