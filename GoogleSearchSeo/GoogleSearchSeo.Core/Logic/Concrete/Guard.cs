using System;

namespace GoogleSearchSeo.Core.Logic.Concrete
{
    public static class Guard
    {
        /// <summary>
        /// Throws an argument null exception if the value passed in is name with
        /// a custom message.
        /// </summary>
        /// <param name="variableValue">The value to be tested for null</param>
        /// <param name="variableName">The name of the variable being tested</param>
        public static void ThrowIfNull(object variableValue, string variableName)
        {
            if (variableValue == null)
            {
                throw new ArgumentNullException(
                    string.Format("The value of {0} cannot be null", variableName));
            }
        }

        /// <summary>
        /// Throws an argument null exception or an argument exception if the value passed in
        /// is null or empty respectively. 
        /// </summary>
        /// <param name="variableValue">The value to be tested for null or empty string</param>
        /// <param name="variableName">The name of the variable being tested</param>
        public static void ThrowIfEmpty(string variableValue, string variableName)
        {
            ThrowIfNull(variableValue, variableName);
            if (variableValue == string.Empty)
            {
                throw new ArgumentException(
                    string.Format("The value of {0} cannot be empty string", variableName));
            }
        }
    }
}
