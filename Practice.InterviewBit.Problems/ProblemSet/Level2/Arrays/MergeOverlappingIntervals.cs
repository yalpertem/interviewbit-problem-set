using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.InterviewBit.Problems.ProblemSet.Level2.Arrays
{
    /// <summary>
    /// Merge Overlapping Intervals
    /// https://www.interviewbit.com/problems/merge-overlapping-intervals/
    /// </summary>
    public class MergeOverlappingIntervals
    {
        /*
        Given a collection of intervals, merge all overlapping intervals.

        For example:
        Given [1,3],[2,6],[8,10],[15,18],
        return [1,6],[8,10],[15,18].

        Make sure the returned intervals are sorted.

        (Only Java solutions are accepted)

        public ArrayList<Interval> merge(ArrayList<Interval> intervals) {
            ArrayList<Interval> merged = new ArrayList<Interval>();
            int curStartIndex = 0, curEndIndex = 0;
            intervals.sort((s1, s2) -> s1.start - s2.start); 
        
            for (int i = 0; i < intervals.size() - 1; i++){
                if (intervals.get(i + 1).start <= intervals.get(curEndIndex).end) {
                    if (intervals.get(i + 1).end > intervals.get(curEndIndex).end) {
                        // overlapping
                        curEndIndex = i + 1;
                    }
                } else {
                    int newStart = intervals.get(curStartIndex).start;
                    int newEnd = intervals.get(curEndIndex).end;
                    merged.add(new Interval(newStart, newEnd));
                    curStartIndex = i + 1;
                    curEndIndex = curStartIndex;
                }
            }
        
            //add the last interval
            int newStart = intervals.get(curStartIndex).start;
            int newEnd = intervals.get(curEndIndex).end;
            merged.add(new Interval(newStart, newEnd));
        
            return merged;
        }

        */
    }
}
