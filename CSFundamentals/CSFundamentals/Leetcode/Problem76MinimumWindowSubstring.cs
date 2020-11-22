using System.Collections.Generic;

namespace CSFundamentals.Leetcode
{
    public class Problem76MinimumWindowSubstring
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/minimum-window-substring/
         * For more solutions: https://leetcode.com/problems/minimum-window-substring/solution/
         * 
         * This can provide some help: https://www.geeksforgeeks.org/window-sliding-technique/
         *                             https://medium.com/outco/how-to-solve-sliding-window-problems-28d67601a66
         */

        public string MinWindow(string s, string t)
        {
            if (s.Length == 0 || t.Length == 0)
            {
                return "";
            }

            var dictionaryT = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {
                if (!dictionaryT.ContainsKey(t[i]))
                {
                    dictionaryT.Add(t[i], 0);
                }
                dictionaryT[t[i]]++;
            }

            var required = dictionaryT.Count;
            var filteredS = new List<KeyValuePair<int, char>>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dictionaryT.ContainsKey(s[i]))
                {
                    filteredS.Add(new KeyValuePair<int, char>(i, s[i]));
                }
            }

            var left = 0;
            var right = 0;
            var formed = 0;
            var answers = new int[] { -1, 0, 0 };
            var windowCount = new Dictionary<char, int>();

            while (right < filteredS.Count)
            {
                var character = filteredS[right].Value;

                if (!windowCount.ContainsKey(character))
                {
                    windowCount.Add(character, 0);
                }

                windowCount[character]++;

                if (dictionaryT.ContainsKey(character) &&
                    windowCount[character] == dictionaryT[character])
                {
                    formed++;
                }

                while (left <= right && formed == required)
                {
                    character = filteredS[left].Value;

                    var end = filteredS[right].Key;
                    var start = filteredS[left].Key;

                    if (answers[0] == -1 || (end - start + 1) < answers[0])
                    {
                        answers[0] = end - start + 1;
                        answers[1] = start;
                        answers[2] = end;
                    }

                    windowCount[character] = windowCount[character] - 1;

                    if (dictionaryT.ContainsKey(character) && windowCount[character] < dictionaryT[character])
                    {
                        formed--;
                    }

                    left++;
                }

                right++;
            }

            return answers[0] == -1 ? "" : s.Substring(answers[1], answers[2] - answers[1] + 1);
        }
    }
}
