using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level6.TreeDataStructure
{
    public class OrderOfPeopleHeights
    {
        private int[] segmentTree;

        public List<int> Solve(List<int> A, List<int> B)
        {
            //TODO: couldn't solve yet.
            var sortedHeights = new List<Person>();
            var result = new List<int>();
            for (var i = 0; i < A.Count; i++)
            {
                sortedHeights.Add(new Person(A[i], B[i]));
                result.Add(-1);
            }
            sortedHeights.Sort();

            BuildSegmentTree(sortedHeights.Count);

            for (var i = 0; i < sortedHeights.Count; i++)
            {
            }
            return result;
        }

        private void BuildSegmentTree(int count)
        {
            segmentTree = new int[count * 2];
            // insert leaf nodes in tree 
            for (int i = 0; i < count; i++)
            {
                segmentTree[count + i] = i;
            }

            // build the tree by calculating parents 
            for (int i = count - 1; i > 0; --i)
            {
                segmentTree[i] = segmentTree[i << 1] + segmentTree[i << 1 | 1];
            }

            //print to test
            for (var i = 0; i < segmentTree.Length; i++)
            {
                Console.WriteLine(segmentTree[i]);
            }

        }

        private class Person : IComparable<Person>
        {
            public int Height;
            public int Infronts;

            public Person() { }
            public Person(int height, int infronts)
            {
                Height = height;
                Infronts = infronts;
            }

            public int CompareTo(Person other)
            {
                return Height.CompareTo(other.Height);
            }
        }
    }
}
