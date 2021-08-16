/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PalindromeCollector.cs
 *  Description  :  Utility for collect palindrome.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/16/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.Algorithm
{
    /// <summary>
    /// Utility for collect palindrome.
    /// </summary>
    public sealed class PalindromeCollector
    {
        /// <summary>
        /// Get lenght of longest palindrome.
        /// </summary>
        /// <param name="str">Source string.</param>
        /// <returns>Lenght of longest palindrome.</returns>
        public static int GetLongestPalindrome(string str)
        {
            /*
             * Designed By Mogoson.
             * 
             * xxx12321yy
             *  yy12321xxx
            */

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            var len = 1;
            var cs = str.ToCharArray();
            for (int i = 0; i < cs.Length; i++)
            {
                for (int j = cs.Length - 1; j > 0; j--)
                {
                    if (cs[i] == cs[j])
                    {
                        var ct = 1;
                        var ni = i + 1;
                        var nj = j - 1;
                        while (ni < cs.Length && nj >= 0)
                        {
                            if (cs[ni] == cs[nj])
                            {
                                ct++;
                                ni++;
                                nj--;
                            }
                            else
                            {
                                break;
                            }
                        }

                        var ci = 0;
                        var hct = ct / 2;
                        while (ci < hct)
                        {
                            if (cs[i + ci] == cs[ni - 1 - ci])
                            {
                                ci++;
                            }
                            else
                            {
                                ct = 0;
                                break;
                            }
                        }

                        if (len < ct)
                        {
                            len = ct;
                        }
                    }
                }
            }
            return len;
        }

        /// <summary>
        /// Get lenght of longest palindrome.
        /// </summary>
        /// <param name="str">Source string.</param>
        /// <returns>Lenght of longest palindrome.</returns>
        public static int GetLongestPalindrome0(string str)
        {
            /*
             * Designed By Mogoson.
             * 
             *     axis
             * xxx[12321]yy
            */

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            if (str.Length == 1)
            {
                return 1;
            }

            if (str.Length == 2)
            {
                if (str[0] == str[1])
                {
                    return 2;
                }
                return 1;
            }

            var len = 1;
            var cs = str.ToCharArray();
            for (int i = 1; i < cs.Length - 1;)
            {
                var v = i;
                while (v + 1 < cs.Length - 1)
                {
                    if (cs[v] == cs[v + 1])
                    {
                        v++;
                    }
                    else
                    {
                        break;
                    }
                }
                var c = v - i + 1;
                var m = c / 2;
                var r = c % 2;

                var axis = i + (r == 0 ? m - 1 : m);
                var lf = -(r == 0 ? m : m + 1);
                var rf = m + 1;

                var rg = axis + lf;
                var rr = cs.Length - (axis + rf);
                if (rg < rr)
                {
                    rg = rr;
                }

                var ofs = 0;
                while (ofs < rg)
                {
                    var le = axis + lf - ofs;
                    var ri = axis + rf + ofs;
                    if (le < 0 || ri > cs.Length - 1)
                    {
                        break;
                    }
                    if (cs[le] != cs[ri])
                    {
                        break;
                    }
                    c += 2;
                    ofs++;
                }

                if (len < c)
                {
                    len = c;
                }
                i = v + 1;
            }
            return len;
        }

        /// <summary>
        /// Get the longest palindrome.
        /// </summary>
        /// <param name="str">Source string.</param>
        /// <returns>The longest palindrome.</returns>
        public static string GetTheLongestPalindrome(string str)
        {
            /*
             * Designed By Mogoson.
             * 
             * xxx12321yy
             *  yy12321xxx
            */

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            var pldm = string.Empty;
            var cs = str.ToCharArray();
            for (int i = 0; i < cs.Length; i++)
            {
                for (int j = cs.Length - 1; j > 0; j--)
                {
                    if (cs[i] == cs[j])
                    {
                        var ct = 1;
                        var ni = i + 1;
                        var nj = j - 1;
                        while (ni < cs.Length && nj >= 0)
                        {
                            if (cs[ni] == cs[nj])
                            {
                                ct++;
                                ni++;
                                nj--;
                            }
                            else
                            {
                                break;
                            }
                        }

                        var ci = 0;
                        var hct = ct / 2;
                        var temp = string.Empty;
                        while (ci < ct)
                        {
                            temp += cs[i + ci];
                            if (ci <= hct)
                            {
                                if (cs[i + ci] != cs[ni - 1 - ci])
                                {
                                    ct = 0;
                                    temp = string.Empty;
                                    break;
                                }
                            }
                            ci++;
                        }

                        if (pldm.Length < temp.Length)
                        {
                            pldm = temp;
                        }
                    }
                }
            }
            return pldm;
        }

        /// <summary>
        /// Collect palindromes string.
        /// </summary>
        /// <param name="str">Source string.</param>
        /// <param name="min">Min length of sub palindrome string.</param>
        /// <returns>Palindromes string.</returns>
        public static ICollection<string> CollectPalindromes(string str, int min = 3)
        {
            /*
             * Designed By Mogoson.
             * 
             * xxx12321yy
             *  yy12321xxx
            */

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            var pldms = new List<string>();
            var cs = str.ToCharArray();
            for (int i = 0; i < cs.Length; i++)
            {
                for (int j = cs.Length - 1; j > 0; j--)
                {
                    if (cs[i] == cs[j])
                    {
                        var ct = 1;
                        var ni = i + 1;
                        var nj = j - 1;
                        while (ni < cs.Length && nj >= 0)
                        {
                            if (cs[ni] == cs[nj])
                            {
                                ct++;
                                ni++;
                                nj--;
                            }
                            else
                            {
                                break;
                            }
                        }

                        var ci = 0;
                        var hct = ct / 2;
                        var temp = string.Empty;
                        while (ci < ct)
                        {
                            temp += cs[i + ci];
                            if (ci <= hct)
                            {
                                if (cs[i + ci] != cs[ni - 1 - ci])
                                {
                                    ct = 0;
                                    temp = string.Empty;
                                    break;
                                }
                            }
                            ci++;
                        }

                        if (string.IsNullOrEmpty(temp) || temp.Length < min)
                        {
                            continue;
                        }
                        pldms.Add(temp);
                    }
                }
            }
            return pldms;
        }
    }
}