using AssignmentSystem.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture
        public void LCT01_SelectionSortAscending(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }

            foreach (int i in numbers)
            {
                Debug.Log(i);
            }
        }

        public void LCT02_BubbleSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for(int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        //(numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                    }
                }
            }
            foreach (var _n in numbers)
            {
                Debug.Log(_n);
            }
        }

        public void LCT03_InsertionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 1; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }

            foreach(var _n in numbers)
            {
                Debug.Log(_n);
            }
        }

        #endregion

        #region Assignment

        public void AS01_SelectionSortDescending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                if (maxIndex != i)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[maxIndex];
                    numbers[maxIndex] = temp;
                }
            }

            foreach (int _n in numbers)
            {
                Debug.Log(_n);
            }
        }

        public void AS02_BubbleSortDescending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            foreach (int _n in numbers)
            {
                Debug.Log(_n);
            }
        }

        public void AS03_InsertionSortDescending(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] < current)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = current;
            }

            foreach (int _n in numbers)
            {
                Debug.Log(_n);
            }
        }

        public void AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            Array.Sort(numbers);
            Array.Reverse(numbers);
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] != numbers[0])
                {
                    Debug.Log(numbers[i]);
                    return;
                }
            }
        }

        #endregion

        #region Extra

        public void EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            Array.Sort(numbers);

            int longestStreak = 1;
            int currentStreak = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1] + 1)
                {
                    currentStreak++;
                }
                else if (numbers[i] != numbers[i - 1])
                {
                    longestStreak = Math.Max(longestStreak, currentStreak);
                    currentStreak = 1;
                }
            }

            longestStreak = Math.Max(longestStreak, currentStreak);

            Debug.Log($"The longest consecutive sequence is: {longestStreak}");
        }

        #endregion
    }
}