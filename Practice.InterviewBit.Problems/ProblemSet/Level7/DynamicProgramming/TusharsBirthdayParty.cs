using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level7.DynamicProgramming
{
    /// <summary>
    /// Tushar's Birthday Party
    /// https://www.interviewbit.com/problems/tushars-birthday-party/
    /// </summary>
    public class TusharsBirthdayParty
    {
        /*
        As it is Tushar’s Birthday on March 1st, he decided to throw a party to all his friends at TGI Fridays in Pune.
        Given are the eating capacity of each friend, filling capacity of each dish and cost of each dish. 
        A friend is satisfied if the sum of the filling capacity of dishes he ate is equal to his capacity.
        Find the minimum cost such that all of Tushar’s friends are satisfied (reached their eating capacity).

        NOTE:
        Each dish is supposed to be eaten by only one person. Sharing is not allowed.
        Each friend can take any dish unlimited number of times.
        There always exists a dish with filling capacity 1 so that a solution always exists.

        Input Format
        Friends : List of integers denoting eating capacity of friends separated by space.
        Capacity: List of integers denoting filling capacity of each type of dish.
        Cost :    List of integers denoting cost of each type of dish.
        
        Constraints:
        1 <= Capacity of friend <= 1000
        1 <= No. of friends <= 1000
        1 <= No. of dishes <= 1000

        Example:

        Input:
            2 4 6
            2 1 3
            2 5 3
        Output:
            14
        Explanation: 
            First friend will take 1st and 2nd dish, second friend will take 2nd dish twice.  Thus, total cost = (5+3)+(3*2)= 14
        */

        public int Solve(List<int> people, List<int> dishCapacities, List<int> dishCosts)
        {
            var maxCapacity = 0;
            for (var i = 0; i < people.Count; i++)
            {
                maxCapacity = Math.Max(maxCapacity, people[i]);
            }

            var dp = new int[maxCapacity + 1];
            dp[0] = 0;
            for (var i = 1; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }

            for (var i = 1; i < dp.Length; i++)
            {
                for (var j = 0; j < dishCapacities.Count; j++)
                {
                    var dishCapacity = dishCapacities[j];
                    if (dishCapacity <= i)
                    {
                        var candidate = dishCosts[j] + dp[i - dishCapacity];
                        dp[i] = Math.Min(dp[i], candidate);
                    }
                }
            }

            var totalCost = 0;
            for (var i = 0; i < people.Count; i++)
            {
                totalCost += dp[people[i]];
            }
            return totalCost;
        }
    }
}
