using System;

namespace Menou.Core.Logic.Concrete
{
    public static class Guard
    {
        /// <summary>
        /// If the value passed in is null, a null exception is thrown with the variable name indicated.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueName"></param>
        public static void IsNotNull(object value, string valueName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(valueName);
            }
        }

        /// <summary>
        /// If the string value passed in is null or empty, an argument exception is thrown with the variable name indicated.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueName"></param>
        public static void IsNotNullOrEmpty(string value, string valueName)
        {
            IsNotNull(value, valueName);
            if (value == string.Empty)
            {
                throw new ArgumentException(valueName);
            }
        }
    }
}
