using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
        Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

        You may assume that each input would have exactly one solution, and you may not use the same element twice.

        You can return the answer in any order.
    */
    public class Leet001_TwoSum
    {
        public static void Main(string[] args)
        {
            var inputArr = new int[] {2, 7, 11, 15};
            var target = 17;

            inputArr = TakeIntegerArrayInput();
            target = TakeNumberInput();

            int[] result = [.. TwoSum(inputArr, target).OrderBy(x => x)];
            Console.WriteLine($"Output: [{result[0]},{result[1]}]");
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.TryGetValue(complement, out _))
                {
                    return [i, dict[complement]];
                }

                dict[nums[i]] = i; 
            }

            return new int[2];
        }

        public static int[] TakeIntegerArrayInput()
        {
            Console.WriteLine("Enter input array (Space separated numbers):");
            var inputArr = Console.ReadLine();
            
            return [.. inputArr.Split(' ').Select(int.Parse)]; // Same as inputArr.Split(' ').Select(int.Parse).ToArray()
        }

        public static int TakeNumberInput()
        {
            Console.WriteLine("Enter number:");
            var input = Console.ReadLine();

            //int.TryParse(input, out output); // It never throws an exception.
            return int.Parse(input);
        }
    }   
}