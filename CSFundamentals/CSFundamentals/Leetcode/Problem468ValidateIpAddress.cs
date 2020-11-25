using System.Globalization;

namespace CSFundamentals.Leetcode
{
    public class Problem468ValidateIpAddress
    {
        /*
         * Leetcode problem: https://leetcode.com/problems/validate-ip-address/
         * For more solutions: https://leetcode.com/problems/validate-ip-address/solution/
         * 
         * Possible returns: "IPv4" "IPv6" "Neither"
         */

        public string ValidIPAddress(string IP)
        {
            if (!string.IsNullOrWhiteSpace(IP))
            {
                if (IP.Contains('.'))
                {
                    var ipv4 = IP.Split('.');

                    if (ipv4.Length == 4)
                    {
                        for (int i = 0; i < ipv4.Length; i++)
                        {
                            bool ipv4ParseSuccess = int.TryParse(ipv4[i], out var intIp);

                            if (!ipv4ParseSuccess ||
                                ipv4[i].Length < 1 ||
                                (ipv4[i].StartsWith("0") && ipv4[i].Length > 1) ||
                                intIp < 0 ||
                                intIp > 255)
                            {
                                return "Neither";
                            }
                        }

                        return "IPv4";
                    }
                }
                else if (IP.Contains(':'))
                {
                    var ipv6 = IP.Split(':');

                    if (ipv6.Length == 8)
                    {
                        for (int i = 0; i < ipv6.Length; i++)
                        {
                            bool ipv6ParseSuccess = IsIv6HexValue(ipv6[i]);

                            if (!ipv6ParseSuccess)
                            {
                                return "Neither";
                            }
                        }

                        return "IPv6";
                    }
                }
            }

            return "Neither";
        }

        private bool IsIv6HexValue(string ipv6Value)
        {
            if (ipv6Value.Length < 1 || ipv6Value.Length > 4)
            {
                return false;
            }

            for (int i = 0; i < ipv6Value.Length; i++)
            {
                if (!((ipv6Value[i] >= '0' && ipv6Value[i] <= '9') ||
                    (ipv6Value[i] >= 'A' && ipv6Value[i] <= 'F') ||
                    (ipv6Value[i] >= 'a' && ipv6Value[i] <= 'f')))
                {
                    return false;
                }
            }

            return true;
        }

        // This works but it will have problems with compilers that do not use the latest c#
        public string ValidIPAddress2(string IP)
        {
            if (!string.IsNullOrWhiteSpace(IP))
            {
                if (IP.Contains('.'))
                {
                    var ipv4 = IP.Split('.');

                    if (ipv4.Length == 4)
                    {
                        for (int i = 0; i < ipv4.Length; i++)
                        {
                            bool ipv4ParseSuccess = int.TryParse(ipv4[i],
                                NumberStyles.Integer,
                                CultureInfo.InvariantCulture,
                                out var intIp);

                            switch (ipv4[i])
                            {
                                case string when !ipv4ParseSuccess:
                                case string when ipv4[i].Length < 1:
                                case string when ipv4[i].StartsWith("0") && ipv4[i].Length > 1:
                                case string when intIp < 0:
                                case string when intIp > 255:
                                    return "Neither";
                                default:
                                    break;
                            }
                        }

                        return "IPv4";
                    }
                }
                else if (IP.Contains(':'))
                {
                    var ipv6 = IP.Split(':');

                    if (ipv6.Length == 8)
                    {
                        for (int i = 0; i < ipv6.Length; i++)
                        {
                            bool ipv6ParseSuccess = int.TryParse(ipv6[i],
                                NumberStyles.AllowHexSpecifier,
                                CultureInfo.InvariantCulture,
                                out var intIp);

                            if (!ipv6ParseSuccess)
                            {
                                return "Neither";
                            }
                        }

                        return "IPv6";
                    }
                }
            }

            return "Neither";
        }
    }
}
