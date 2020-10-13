namespace Drysdale.String.Manipulation
{
    #region Enumeration.Charactor-Distinction...
    /// <summary>
    /// Enumeration.Charactor-Distinction
    /// </summary>
    public enum CharactorDistinction
    {
        /// <summary>
        /// "Same as 'D' and 'd'" Capital-Letter And Small-Letter Are-Treated As-One Charactor
        /// </summary>
        CapitalAndSmallAreOne,
        /// <summary>
        /// "Same as 'D' and 'd'" Capital-Leter And Small-Letter Are-Treated As-Two-Different Charactors
        /// </summary>
        CapitalAndSmallAreTwo
    }
    #endregion

    #region Enumeration.Charactor-Type...
    /// <summary>
    /// Enumeration.Charactor-Type
    /// </summary>
    public enum CharactorType
    {
        /// <summary>
        /// PositiveInteger
        /// </summary>
        PositiveInteger,
        /// <summary>
        /// AlphabetLetter
        /// </summary>
        AlphabetLetter
    }
    #endregion

    #region Enumeration.Charactor-Case...
    /// <summary>
    /// Enumeration.Charactor-Case
    /// </summary>
    public enum CharactorCase
    {
        /// <summary>
        /// Upper-Case-Letter
        /// </summary>
        Upper,
        /// <summary>
        /// Lower-Case-Letter
        /// </summary>
        Lower
    }
    #endregion
}
