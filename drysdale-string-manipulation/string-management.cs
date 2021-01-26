using Drysdale.Number.Manipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Drysdale.String.Manipulation
{
    #region Class.String-Manipulator...
    /// <summary>
    /// Class.String-Manipulator
    /// </summary>
    public class StringManip
    {
        static readonly string _us = "_";
        #region Static-Method.Removes WhithSpaces-And-Vowels(ou) NotFoundIn(DrysdaleChivhanga)...
        /// <summary>
        /// Static-Method.Removes WhithSpaces-And-Vowels(ou) NotFoundIn(DrysdaleChivhanga)
        /// </summary>
        /// <param name="incVal">The Incoming-String-Value</param>
        /// <returns>The String-Without-' WhithSpaces-And-Vowels(ou) **NotFoundIn(DrysdaleChivhanga)'</returns>
        public static string CastrateVowels(string incVal)
        {
            string nakedstring = string.Concat(incVal.Where(c => !char.IsWhiteSpace(c))).ToLower();
            nakedstring = new Regex("[^a-z]").Replace(nakedstring, "");
            return Regex.Replace(nakedstring, "[ou]", "", RegexOptions.IgnoreCase);
        }
        #endregion

        #region Static-Method.Get-Distinct-Chars-Without-Spaces...
        /// <summary>
        /// Static-Method.Get-Distinct-Chars-Without-Spaces Version-01
        /// </summary>
        /// <param name="incVal">The Incoming-String-Value</param>
        /// <param name="incDis">The Incoming-Charactor.Distinction-Value</param>
        /// <returns>The Non-Spaced-String-With-Distinct-Charactors</returns>
        /// <remarks>
        /// Enumeration.Description<br/>
        /// ---------------------------<br/>
        /// ---------------------------<br/>
        /// <br/><br/>
        /// CharactorDistinction.CapitalAndSmallAreOne <br/>
        /// ---------------------------------------------------------------------------------<br/>
        /// Capital-letters and their respective small letters are treated as same charactors.<br/>
        /// For example Capital 'D' and small 'd' are treated as single 'd' charactor<br/><br/>
        ///  CharactorDistinction.CapitalAndSmallAreTwo <br/>
        /// --------------------------------------------------------------------------------------<br/>
        /// Capital-letters and their respective small letters are treated as different charactors.<br/>
        /// For example Capital 'D' and small 'd' are treated as different 'd' charactors
        /// </remarks>
        public static string GetDistinctWithoutSpaces(string incVal, CharactorDistinction incDis)
        {

            string stringWithZeroSpaces = string.Concat(incVal.Where(c => !char.IsWhiteSpace(c)));
            return incDis switch
            {
                CharactorDistinction.CapitalAndSmallAreTwo => new string(stringWithZeroSpaces.Distinct().ToArray()),
                _ => new string(stringWithZeroSpaces.ToLower().Distinct().ToArray()),
            };
        }
        #endregion

        #region  Static-Method.Reverse-The-Incoming-String...
        /// <summary>
        /// Static-Method.Reverse-The-Incoming-String
        /// </summary>
        /// <param name="incVal">The Incoming-Sting-Value</param>
        /// <returns>The Reversed-String-Value</returns>
        public static string Reverse(string incVal)
        {
            char[] cArray = incVal.ToCharArray();
            string reverse = string.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }

            return reverse;
        }
        #endregion

        #region Static-Method.Generate-14-Charactors...
        /// <summary>
        /// Static-Method.Generate-14-Charactors
        /// </summary>
        /// <param name="incVal">The Incoming-String-Value</param>
        /// <returns>The 14-Charactors</returns>
        public static string FourteenCharactors(string incVal)
        {
            int len = incVal.Length;
            string outgoing = len switch
            {
                1 => $"0000000000000{incVal}",
                2 => $"000000000000{incVal}",
                3 => $"00000000000{incVal}",
                4 => $"0000000000{incVal}",
                5 => $"000000000{incVal}",
                6 => $"00000000{incVal}",
                7 => $"0000000{incVal}",
                8 => $"000000{incVal}",
                9 => $"00000{incVal}",
                10 => $"0000{incVal}",
                11 => $"000{incVal}",
                12 => $"00{incVal}",
                13 => $"0{incVal}",
                _ => incVal.Substring(0, 14),
            };
            return outgoing;
        }
        #endregion

        #region Static-Method.Generate-CustomGuid...
        /// <summary>
        /// Static-Method.Generate-CustomGuid
        /// </summary>
        /// <param name="incVal">The Incoming-String-Value</param>
        /// <returns>The Geneated-Custom-Guid</returns>
        public static string GenerateGUID(string incVal)
        {
            string castrated = CastrateVowels(incVal);
            string reversed = Reverse(CastrateVowels(castrated));
            string eightLetterd = FourteenCharactors(reversed);

            string[] fullGuid = Guid.NewGuid().ToString().ToLower().Split('-');
            string twoChivDates = GetCharactors(2, Fzd_Def_String.GetPrimeSurnameDateChars);
            string twoAlphabets = GetCharactors(2, Fzd_Def_String.GetAlbhabetChars);
            string fourAlphabets = GetCharactors(4, Fzd_Def_String.GetAlbhabetChars);
            string threeChivPrime = GetCharactors(3, Fzd_Def_String.GetPrimeSurnameDateChars);
            string shuffeldDrys = GetShuffledString(Fzd_Def_String.GetFirstNameChars);

            StringBuilder uniqId = new StringBuilder();
            uniqId.Append($"{fullGuid[4]}#{eightLetterd}#{_us}{shuffeldDrys[0]}{_us}{twoChivDates[1]}{_us}{shuffeldDrys[1]}{_us}");
            uniqId.Append($"{twoAlphabets}{_us}{shuffeldDrys[2]}{_us}{threeChivPrime}{_us}{shuffeldDrys[3]}{_us}");
            uniqId.Append($"{fullGuid[3]}{_us}{shuffeldDrys[4]}{_us}{fullGuid[1]}{_us}{shuffeldDrys[5]}{_us}");
            uniqId.Append($"{fourAlphabets}{_us}{shuffeldDrys[6]}{_us}{fullGuid[2]}{_us}{shuffeldDrys[7]}{_us}{fullGuid[0]}");

            return uniqId.ToString().ToLower();
        }
        #endregion

        #region Static-Method.GetRandomCharactors...
        /// <summary>
        /// Static-Method.GetRandomCharactors
        /// </summary>
        /// <param name="sizeOfString">The Incoming-Required-Size-Of-String-Value</param>
        /// <param name="incVal">The String-To-Choose-From-Value</param>
        /// <returns>The Randomly-Chosen-Charactors</returns>
        /// <remarks>If Length of </remarks>
        public static string GetCharactors(int sizeOfString, string incVal)
        {
            string distinctValue = GetDistinctWithoutSpaces(incVal, CharactorDistinction.CapitalAndSmallAreTwo);
            int distinctLength = distinctValue.Length;
            string response="";
            if (distinctLength > sizeOfString)
            {
                int i = 0;
                while (i < sizeOfString)
                {
                    char thisChar = GetCharactor(incVal);
                    if (response.Contains(thisChar))
                        continue;
                    response.Append(thisChar);
                    i++;
                }
            }
            else
            {
                if (distinctLength == sizeOfString)
                    response = distinctValue;
                else
                {
                    int remainingChars = sizeOfString - distinctLength;
                    foreach (char item in distinctValue)
                    {
                        response.Append(item);
                    }
                    int i = 0;
                    while (i<remainingChars)
                    {
                        char thisChar = GetGetRandomLetter(CharactorCase.Lower);
                        if (response.Contains(thisChar))
                            continue;
                        response.Append(thisChar);
                        i++;
                    }
                }
            }
            return response;
        }


        #endregion

        #region Static-Method.Get-Random Alphabet-Letter...
        /// <summary>
        /// Static-Method.Get-Random Alphabet-Letter
        /// </summary>
        /// <param name="incVal">The Incoming-Desired-Case-For-Charactor-Value</param>
        /// <returns>The Generated-Random Alphabet-Letter</returns>
        /// <remarks>
        /// Enumeration.Description<br/>
        /// ---------------------------<br/>
        /// ---------------------------<br/>
        /// <br/><br/>
        /// CharactorCase.Lower<br/>
        /// ---------------------------------------------------------------<br/>
        /// Returns a lower-case aplhabet letter from 'a-z' inclusive<br/>
        /// ---------------------------------------------------------------<br/>
        ///  CharactorCase.Upper.<br/>
        /// ---------------------------------------------------------------<br/>
        /// Returns a lower-case aplhabet letter from 'A-Z' inclusive<br/>
        /// ---------------------------------------------------------------<br/>
        /// </remarks>
        public static char GetGetRandomLetter(CharactorCase incVal) => incVal switch
        {

            CharactorCase.Upper => Convert.ToChar(NumberManip.GetNumber(65, 91)),
            _ => Convert.ToChar(NumberManip.GetNumber(97, 123)),
        };
        #endregion

        #region Static-Method.GetRandomCharactor...
        /// <summary>
        /// Static-Method.GetRandomCharactor
        /// </summary>
        public static char GetCharactor(string charactors) => charactors[NumberManip.GetNumber(0, charactors.Length)];
        #endregion

        #region Static-Method.ShuffleGivenString
        /// <summary>
        /// Static-Method.ShuffleGivenString
        /// </summary>
        /// <param name="list"/>
        public static string GetShuffledString(string list)
        {
            Random rand = new Random();
            int index;
            List<char> chars = new List<char>(list);
            StringBuilder sb = new StringBuilder();
            while (chars.Count > 0)
            {
                index = rand.Next(chars.Count);
                sb.Append(chars[index]);
                chars.RemoveAt(index);
            }
            return sb.ToString();
        }
        #endregion

        #region Static-Method.BothMatch...
        /// <summary>
        /// Static-Method.BothMatch
        /// </summary>
        /// <param name="first">The First (String-Expected-Target-Value)</param>
        /// <param name="second">The Second (String-Expected-Target-Value)</param>
        /// <returns>True If Match Otherwise False</returns>
        public static bool BothMatch(object first, object second)
            => string.Equals(a: Convert.ToString(first), b: Convert.ToString(second), comparisonType: StringComparison.OrdinalIgnoreCase);
        #endregion

        #region Static-Method.Check-If-String Contained...
        /// <summary>
        /// Static-Method.Check-If-String Contained
        /// </summary>
        /// <param name="valueInQuestion"></param>
        /// <param name="targetList"></param>
        /// <returns>True If Available And Vice Versa</returns>
        public static bool CheckIfContained(string valueInQuestion, List<string> targetList)
            => targetList.Any(x => string.Equals(x, valueInQuestion, StringComparison.OrdinalIgnoreCase));
        #endregion

        #region Static-Method.CombineTwoStringsIntoOne...
        /// <summary>
        /// Static-Method.CombineTwoStringsIntoOne
        /// </summary>
        /// <param name="first"/>
        /// <param name="second"/>

        public static string CombineTwo(string first, string second) => $"{first}-{second}";
        #endregion

        #region Static-Method.CastrateString...
        /// <summary>
        /// Static-Method.CastrateString
        /// </summary>
        /// <param name="incVal"/>
        /// <param name="limit"/>
        /// <param name="desired"/>
        public static string CastrateString(string incVal, int limit, int desired)
        {
            string nakedstring = string.Concat(incVal.Where(c => !char.IsWhiteSpace(c)));
            return nakedstring.Length > limit ? nakedstring.Substring(0, desired) : FourteenCharactors(nakedstring);
        }
        #endregion

        #region Static-Method.Get-Initialised-Name(Drysdale Famba Zvako Dhura Chivhanga)...
        /// <summary>
        /// Static-Method.Get-Initialised-Name(Drysdale Famba Zvako Dhura Chivhanga)
        /// </summary>
        /// <param name="first"/>
        /// <param name="middle"/>
        /// <param name="last"/>
        /// <returns>D. F. Chivhanga</returns>
        public static string GetInitialisedName(string first, string middle, string last)
        {
            string fname = string.IsNullOrEmpty(first.Trim()) ? "" : $"{first.Substring(0, 1).ToUpper()}. ";
            string mname = string.IsNullOrEmpty(middle.Trim()) ? "" : $"{middle.Substring(0, 1).ToUpper()}. ";
            string lname = string.IsNullOrEmpty(last.Trim()) ? "" : $"{last}";
            return $"{fname}{mname}{lname}";
        }
        #endregion

        #region Static-Method.Get-Initialised-Name(Drysdale Chivhanga)...
        /// <summary>
        /// Static-Method.Get-Initialised-Name(Drysdale  Chivhanga)
        /// </summary>
        /// <param name="first">The Firstname</param>
        /// <param name="last">The Lastname/Surname</param>
        /// <returns>D.  Chivhanga</returns>
        public static string GetInitialisedName(string first, string last)
        {
            string fname = string.IsNullOrEmpty(first) ? "" : $"{first.Substring(0, 1).ToUpper()}. ";
            string lname = string.IsNullOrEmpty(last) ? "" : $"{last}";
            return $"{fname}{lname}";
        }
        #endregion

        #region Static-Method.Get-Comma-Separated-Name(Drysdale Chivhanga)...
        /// <summary>
        /// Static-Method.Get-Comma-Separated-Name(Drysdale  Chivhanga)
        /// </summary>
        /// <param name="first">The Firstname</param>
        /// <param name="last">The Lastname/Surname</param>
        /// <returns>Chivhanga, Drysdale</returns>
        public static string GetCommaSeparatedName(string first, string last)
            => $"{last}, {first}";
        #endregion

        #region Static-Method.Remove-Dashes(Drysdale-Chivhanga/null)...
        /// <summary>
        /// Static-Method.Remove-Dashes(Drysdale-Chivhanga/null)
        /// </summary>
        /// <param name="incomingVal"></param>
        /// <returns>Drysdale Chivhanga /(Not Yet Available=[Nya])</returns>
        public static string RemoveDashes(string incomingVal) => string.IsNullOrEmpty(incomingVal) ? "Nya" : incomingVal.Replace('-', ' ');
        #endregion

        #region Static-Method.Get-Two-Strings-From-Char.Splitter...
        /// <summary>
        /// Static-Method.Get-Two-Strings-From-Char.Splitter
        /// </summary>
        /// <param name="iVal">The Incoming-String-Value</param>
        /// <param name="spliter">The Incoming-Splitting-Charactor</param>
        /// <param name="fVal">The First Out-Going-String-Value</param>
        /// <param name="sVal">The Second Out-Going-String-Value</param>
        public static void GetSplitedTwo(string iVal, char spliter, out string fVal, out string sVal)
        {
            string[] splittedValue = iVal.Split(spliter);
            fVal = splittedValue[0];
            sVal = splittedValue[1];
        }
        #endregion

        #region GetRandom08AlphaNumerals...
        /// <summary>
        /// GetRandom08AlphaNumerals
        /// </summary>
        /// <remarks>
        /// Can Be Used To Get A Random 8 Letter Password
        /// </remarks>
        public static string GetRandom08AlphaNumerals
        {
            get
            {
                string drysChiv = $"{Fzd_Def_String.GetFirstNameChars}{Fzd_Def_String.GetSurnameChars}";
                string threeLetaz = GetCharactors(3, drysChiv);
                int fiveDigits = NumberManip.GetNumber(10000, 99999);
                string fullDummyPassword = $"{fiveDigits}{GetCapitalLetters(threeLetaz)}";
                return GetShuffledString(fullDummyPassword);
            }
        }
        #endregion

        #region GetCapitalLetters...
        /// <summary>
        /// GetCapitalLetters
        /// </summary>
        /// <param name="smallLetters"></param>
        /// <returns></returns>
        public static string GetCapitalLetters(string smallLetters)
        {
            int numLetters = smallLetters.Length;
            int lettersToBeCaps = NumberManip.GetNumber(1, numLetters);
            string targetedSubstring = smallLetters.Substring(0, lettersToBeCaps);
            string nonTargeted = smallLetters.Substring(lettersToBeCaps);

            return $"{nonTargeted}{targetedSubstring.ToUpper()}";
        }
        #endregion
    }
    #endregion
}
