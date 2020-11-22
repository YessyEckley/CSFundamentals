namespace CSFundamentals.Leetcode
{
    public class Problem158ReadNCharactersGivenRead4II
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/read-n-characters-given-read4-ii-call-multiple-times/
         * For more solutions: There is no solution
         */

        // We are doing a dummy implementation as we need to call this method to do the reading
        // In Leetcode the have the real implementation of this method for their tests
        public int Read4(char[] buf4)
        {
            return 0;
        }

        /**
         * @param buf Destination buffer
         * @param n   Number of characters to read
         * @return    The number of actual characters read
         */

        public int Read(char[] buf, int n)
        {
            if (n == 0)
            {
                return n;
            }
            var counter = 0;

            while (counter < n)
            {
                if (read4NextIndex >= buf4Counter)
                {
                    buf4Counter = Read4(read4Buf);
                    read4NextIndex = 0;

                    if (buf4Counter == 0)
                    {
                        break;
                    }
                }

                buf[counter] = read4Buf[read4NextIndex];
                read4NextIndex++;
                counter++;
            }

            return counter;
        }

        public char[] read4Buf = new char[4];
        public int read4NextIndex = 4;
        public int buf4Counter = 4;
    }
}
