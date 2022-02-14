using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.

                var low = 0;
                var high = nums.Length - 1;


                while (high - low >= 0)
                {
                    var mid = (high + low) / 2;  // mid value is taken as the average of high and low which is the binary search.

                    if (nums[mid] == target)
                        return mid;              // if target is found, returns the index value which is "mid".
                    else if (nums[mid] < target)
                        low = mid + 1;           // if nums[mid] < target, low value equals mid + 1.
                    else if (nums[mid] > target)
                        high = mid - 1;          // if nums[mid] > target, high value equals mid - 1.

                }
                return low;                      // by making all the necessary changes of low and high values, low value is returned(which is the index).

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                paragraph = paragraph.ToLower();   // converts the string into lower case letters.
                string[] removesymbols = { "!", "?", "''", ",", ";", ".", "'" };  //these are the symbols which are to be removed in the string.
                foreach (string s in removesymbols)
                {
                    paragraph = paragraph.Replace(s, " ");  // replacing the above symbols with " " in the string.
                }

                foreach (string ban in banned)
                {
                    paragraph = paragraph.Replace(ban, string.Empty);  // if the ban word is found in the string, then replacing it with the empty string.
                }
                Dictionary<string, int> dict = new Dictionary<string, int>();
                string[] arr = paragraph.Split(' ', StringSplitOptions.RemoveEmptyEntries);   // removes empty entries in the string.
                foreach (string item in arr)
                {
                    if (!dict.ContainsKey(item))
                    {
                        dict.Add(item, 1);     // if the dictionary doesn't contain item, then it gets added to the dictionary.
                    }
                    else
                    {
                        dict[item]++;    // if item is already in the dictionary, then the value of that key of dictionary is incremented.
                    }
                }
                return dict.OrderBy(a => a.Value).Last().Key;   // returns the value of the last key from the dictionary.


            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                var dict = new Dictionary<int, int>();
                foreach (int i in arr)
                    if (dict.ContainsKey(i))
                        dict[i] += 1;           // if dictionary already contains "i" value, then the value of that key is incremented.
                    else
                        dict.Add(i, 1);         // if dictionary doesn't contain the key, it gets added to the dictionary.

                int max = -1;
                foreach (var item in dict)
                    if (item.Key == item.Value)
                        max = Math.Max(max, item.Key);  

                return max;                     // if key is equal to value of the dictionary, max key from the dictionary is returned.

            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int bulls = 0, cows = 0;
                var dict = new Dictionary<char, int>();
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])
                        bulls++;                        //if secret value equals guess value, bulls value is incremented.
                    else
                    {
                        if (!dict.ContainsKey(secret[i]))
                            dict.Add(secret[i], 0);     //if dictionary doesn't contain the key secret[i], it gets added to the dictionary.
                        dict[secret[i]]++;              //the value of that particular key gets incremented here.
                    }
                }
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] != guess[i])
                    {
                        if (dict.ContainsKey(guess[i]) && dict[guess[i]] > 0)
                        {
                            dict[guess[i]]--;
                            cows++;                 // if the dictionary contains the key guess[i] and greater than 0, value of the key gets decremented and cows value is incremented.
                        }
                    }
                }
                return bulls + "A" + cows + "B";    // returns the final output.

            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                var dict = new Dictionary<char, int>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (!dict.ContainsKey(s[i])) 
                        dict.Add(s[i], i);          // if the dictionary doesn't contain the key s[i] then it gets added to the dictionary.
                    dict[s[i]] = i;                  
                }
                var output = new List<int>();       //creating a list
                int max = 0, cnt = 1;               // initializing the values of max and cnt
                for (int i = 0; i < s.Length; i++, cnt++)
                {
                    max = Math.Max(max, dict[s[i]]);
                    if (i == max)
                    {
                        output.Add(cnt);            //if i value is equal to max, value of cnt is added to the list "output" and cnt is made 0.
                        cnt = 0;
                    }
                }
                return output;                      //returns output.

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int line = 1, sum = 0;          //initializing the values of line and sum.
                foreach (char c in s)
                {
                    sum = sum + widths[c - 'a'];    //sum of every character from the respective width array is calculated.

                    if (sum > 100)
                    {
                        line++;                     //if sum value is greater than 100, line is incremented and the sum is initialized in the below line.
                        sum = widths[c - 'a'];
                    }
                }
                int[] arr = new int[] { line, sum };  // gives array of line number and sum
                return arr.ToList();                    // converts the array into list and outputs it.

            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                if (bulls_string10 == null || bulls_string10 == string.Empty)
                    return true;

                Dictionary<char, char> dict = new Dictionary<char, char>();     //dictionary is created
                Stack<char> stack = new Stack<char>();                          // stack is created.

                dict.Add(')', '(');
                dict.Add('}', '{');
                dict.Add(']', '[');                                             // items are added into the dictionary.

                foreach (var c in bulls_string10)
                    if (c == ')' || c == '}' || c == ']')
                    {
                        if (stack.Count > 0 && stack.Peek() == dict[c])
                            stack.Pop();                                        // if the no. of elements in stack is greater than 0 and the top value is equal to dict[c], then the element is removed from the stack.
                        else
                            return false;
                    }
                    else
                        stack.Push(c);                              //pushing the element into the stack.

                return stack.Count == 0;                            //returns true

            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                int count = 0;
                Dictionary<char, string> alphabets = new Dictionary<char, string>(30);  //dictionary is created.
                HashSet<string> hash = new HashSet<string>();                           //hashset is created.
                string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                char[] alpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                for (int i = 0; i < morse.Length; i++)
                {
                    alphabets.Add(alpha[i], morse[i]);          // adding the arrays alpha and morse to the dictionary.
                }

                foreach (string w in words)
                {
                    string str = "";            //empty string is initialized.
                    foreach (char c in w.ToCharArray())  // character array is created for each value of 'w'.
                    {
                        str += alphabets[c];        // dictionary items are added to the string.

                    }
                    if (!hash.Contains(str))    
                    {
                        hash.Add(str);              // if the hashset doesn't contain the string 'str', it gets added to the hashset and it takes only the unique ones.
                        count++;                    // count is incremented.
                    }
                }
                return count;                       //returns the count value.

            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    
    }
}
