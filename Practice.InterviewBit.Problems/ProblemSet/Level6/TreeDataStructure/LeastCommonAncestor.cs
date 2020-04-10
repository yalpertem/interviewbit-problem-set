using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level6.TreeDataStructure
{
    //Least Common Ancestor
    class LeastCommonAncestor
    {
        /// <summary>
        /// Stores the paths iteratively for num1 and num2, by 'l' and 'r' (left & right)
        /// </summary>
        private List<List<char>> _paths;
        
        /// <summary>
        /// Stores whether num 0 or 1 are found.
        /// </summary>
        private List<bool> _isFound;

        public int Solve(TreeNode head, int num1, int num2)
        {
            if (head == null)
            {
                return -1;
            }

            InitializeLists();
            
            var iterate = head;
            FindPath(iterate, num1, 0);
            FindPath(iterate, num2, 1);

            // one num does not exist
            if (!_isFound[0] || !_isFound[1])
            {
                return -1;
            }

            // follow the path until it splits
            for (var i = 0; i < _paths[0].Count && i < _paths[1].Count; i++)
            {
                if (_paths[0][i] == _paths[1][i])
                {
                    if (_paths[0][i] == 'r')
                    {
                        iterate = iterate.right;
                    }
                    else
                    {
                        iterate = iterate.left;
                    }
                }
                else
                {
                    break;
                }
            }
            return iterate.val;
        }

        private void FindPath(TreeNode head, int num, int order)
        {
            if (_isFound[order])
            {
                return;
            }

            if (head.val == num)
            {
                _isFound[order] = true;
                return;
            }

            if (head.right != null)
            {
                _paths[order].Add('r');
                FindPath(head.right, num, order);
                if (_isFound[order])
                {
                    return;
                }
                else
                {
                    _paths[order].RemoveAt(_paths[order].Count - 1);
                }
            }

            if (head.left != null)
            {
                _paths[order].Add('l');
                FindPath(head.left, num, order);
                if (_isFound[order])
                {
                    return;
                }
                else
                {
                    _paths[order].RemoveAt(_paths[order].Count - 1);
                }
            }
        }

        private void InitializeLists()
        {
            _paths = new List<List<char>>
            {
                new List<char>(),
                new List<char>()
            };
            _isFound = new List<bool>
            {
                false,
                false
            };
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
    }
}
