using System;
using System.Collections.Generic;
using System.Text;

namespace CSFundamentals.Leetcode
{
    public class Problem269AlienDictionary
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/alien-dictionary/
         * For more solutions: https://leetcode.com/problems/alien-dictionary/solution/
         * Resources: https://en.wikipedia.org/wiki/Topological_sorting#Kahn's_algorithm
         */

        public string AlienOrder(string[] words)
        {
            // Create data structure and try to add all unique letters
            var adjacentList = new Dictionary<char, List<char>>();
            var counts = new Dictionary<char, int>();

            foreach (var word in words)
            {
                foreach (var character in word)
                {
                    counts.TryAdd(character, 0);
                    adjacentList.TryAdd(character, new List<char>());
                }
            }

            // Find all edges
            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];

                if (word1.Length > word2.Length && word1.StartsWith(word2)) // Check that the word2 is not a prefix of word1
                {
                    return "";
                }

                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        adjacentList[word1[j]].Add(word2[j]);
                        counts[word2[j]] += 1;
                        break;
                    }
                }
            }

            // BFS of the characters
            var sb = new StringBuilder();
            var queue = new Queue<char>();
            foreach (var character in counts)
            {
                if (character.Value == 0)
                {
                    queue.Enqueue(character.Key);
                }
            }

            while (queue.Count > 0)
            {
                var character = queue.Dequeue();
                sb.Append(character);

                foreach (var nextCharacter in adjacentList[character])
                {
                    counts[nextCharacter] -= 1;

                    if (counts[nextCharacter] == 0)
                    {
                        queue.Enqueue(nextCharacter);
                    }
                }
            }

            if (sb.Length < counts.Count)
            {
                return "";
            }

            return sb.ToString();
        }
    }
}
