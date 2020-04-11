using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level6.HeapsAndMaps
{
    /// <summary>
    /// N max pair combinations
    /// https://www.interviewbit.com/problems/n-max-pair-combinations/
    /// </summary>
    public class NmaxPairCombinations
    {
        /*
        Given two arrays A & B of size N each.
        Find the maximum N elements from the sum combinations (Ai + Bj) formed from elements in array A and B.
        For example if A = [1,2], B = [3,4], then possible pair sums can be 1+3 = 4 , 1+4=5 , 2+3=5 , 2+4=6
        and maximum 2 elements are 6, 5

        Example:
        N = 4
        a[]={1,4,2,3}
        b[]={2,5,1,6}

        Maximum 4 elements of combinations sum are
        10   (4+6), 
        9    (3+6),
        9    (4+5),
        8    (2+6)
        */

        public List<int> Solve(List<int> list1, List<int> list2)
        {
            var result = new List<int>();
            list1.Sort();
            list2.Sort();
            var count = list1.Count;
            var used = new HashSet<Candidate>(new CandidateIndexComparer());
            var queue = new PriorityQueue<Candidate>();

            var candidate = new Candidate(count - 1, count - 1, list1[count - 1] + list2[count - 1]);
            queue.Enqueue(candidate);
            used.Add(candidate);
            var neededCount = count;

            while (neededCount > 0)
            {
                var newSum = queue.Dequeue();
                result.Add(newSum.Sum);

                if (newSum.IndexI > 0)
                {
                    var candidate1 = new Candidate(newSum.IndexI - 1, newSum.IndexJ,
                        list1[newSum.IndexI - 1] + list2[newSum.IndexJ]);
                    if (!used.Contains(candidate1))
                    {
                        queue.Enqueue(candidate1);
                        used.Add(candidate1);
                    }
                }

                if (newSum.IndexJ > 0)
                {
                    var candidate2 = new Candidate(newSum.IndexI, newSum.IndexJ - 1,
                        list1[newSum.IndexI] + list2[newSum.IndexJ - 1]);
                    if (!used.Contains(candidate2))
                    {
                        queue.Enqueue(candidate2);
                        used.Add(candidate2);
                    }
                }

                neededCount--;
            }

            return result;
        }

        private class Candidate : IComparable<Candidate>
        {
            public int IndexI;
            public int IndexJ;
            public int Sum;
            public Candidate() { }
            public Candidate(int i, int j, int sum)
            {
                IndexI = i;
                IndexJ = j;
                Sum = sum;
            }
            public int CompareTo(Candidate other)
            {
                if (Sum == other.Sum)
                {
                    if (IndexI != other.IndexI)
                    {
                        return IndexI.CompareTo(other.IndexI);
                    }
                    else
                    {
                        return IndexJ.CompareTo(other.IndexJ);
                    }
                }
                return other.Sum.CompareTo(Sum);
            }
        }

        private class CandidateIndexComparer : IEqualityComparer<Candidate>
        {
            public bool Equals(Candidate x, Candidate y)
            {
                return x.IndexI == y.IndexI && x.IndexJ == y.IndexJ;
            }

            public int GetHashCode(Candidate x)
            {
                return x.IndexI.GetHashCode() + x.IndexJ.GetHashCode();
            }
        }

        // Taken from: https://visualstudiomagazine.com/Articles/2012/11/01/Priority-Queues-with-C.aspx?Page=2
        private class PriorityQueue<T> where T : IComparable<T>
        {
            private readonly List<T> data;

            public PriorityQueue()
            {
                this.data = new List<T>();
            }

            public void Enqueue(T item)
            {
                data.Add(item);
                int ci = data.Count - 1; // child index; start at end
                while (ci > 0)
                {
                    int pi = (ci - 1) / 2; // parent index
                    if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
                    T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                    ci = pi;
                }
            }

            public T Dequeue()
            {
                // assumes pq is not empty; up to calling code
                int li = data.Count - 1; // last index (before removal)
                T frontItem = data[0];   // fetch the front
                data[0] = data[li];
                data.RemoveAt(li);

                --li; // last index (after removal)
                int pi = 0; // parent index. start at front of pq
                while (true)
                {
                    int ci = pi * 2 + 1; // left child index of parent
                    if (ci > li) break;  // no children so done
                    int rc = ci + 1;     // right child
                    if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                        ci = rc;
                    if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
                    T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
                    pi = ci;
                }
                return frontItem;
            }

            public T Peek()
            {
                T frontItem = data[0];
                return frontItem;
            }

            public int Count()
            {
                return data.Count;
            }

            public override string ToString()
            {
                string s = "";
                for (int i = 0; i < data.Count; ++i)
                    s += data[i].ToString() + " ";
                s += "count = " + data.Count;
                return s;
            }

            public bool IsConsistent()
            {
                // is the heap property true for all data?
                if (data.Count == 0) return true;
                int li = data.Count - 1; // last index
                for (int pi = 0; pi < data.Count; ++pi) // each parent index
                {
                    int lci = 2 * pi + 1; // left child index
                    int rci = 2 * pi + 2; // right child index

                    if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
                    if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; // check the right child too.
                }
                return true; // passed all checks
            } // IsConsistent
        } // PriorityQueue
    }
}
