using System;

namespace CSFundamentals.Leetcode
{
    public class Problem157ReadNCharactersGivenRead4
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/read-n-characters-given-read4/
         * For more solutions: https://leetcode.com/problems/read-n-characters-given-read4/solution/
         */

        // We are doing a dummy implementation as we need to call this method to do the reading
        // In Leetcode the have the real implementation of this method for their tests
        public int Read4(char[] buf4)
        {
            return 0;
        }

        public int Read(char[] buf, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            var counter = 0;
            var tempBuf = new char[4];
            var read4Count = Read4(tempBuf);

            while (counter < n && read4Count != 0)
            {
                if ((counter + read4Count) > n)
                {
                    read4Count = n - counter;
                }

                Array.Copy(tempBuf, 0, buf, counter, read4Count);

                counter += read4Count;

                read4Count = Read4(tempBuf);
            }

            return counter;
        }
    }
}
