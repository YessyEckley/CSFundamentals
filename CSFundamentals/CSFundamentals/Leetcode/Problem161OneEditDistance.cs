namespace CSFundamentals.Leetcode
{
    public class Problem161OneEditDistance
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/one-edit-distance/ 
         * For more solutions: https://leetcode.com/problems/one-edit-distance/solution/
         */

        public bool IsOneEditDistance(string s, string t)
        {
            if (s.Length == 0 && t.Length == 0)
            {
                return false;
            }

            if (s.Length > t.Length)
            {
                return IsOneEditDistance(t, s);
            }

            if (t.Length - s.Length > 1)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                {
                    if (s.Length == t.Length)
                    {
                        return s.Substring(i + 1).Equals(t.Substring(i + 1));
                    }
                    else
                    {
                        return s.Substring(i).Equals(t.Substring(i + 1));
                    }
                }
            }

            return s.Length + 1 == t.Length;
        }
    }
}
