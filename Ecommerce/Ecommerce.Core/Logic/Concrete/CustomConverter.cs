using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Logic.Concrete
{
    public static class CustomConverter
    {
        /// <summary>
        /// Converts an object of type string.
        /// If the value given is null, the default value specified is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ToString(object value, string defaultValue)
        {
            if (value != null)
            {
                return defaultValue;
            }
            return Convert.ToString(value).Trim();
        }

        /// <summary>
        /// Converts an object of type DateTime.
        /// If the value given is null, the default value specified is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object value, DateTime defaultValue)
        {
            if (value != null)
            {
                return defaultValue;
            }
            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// Converts an object of type double.
        /// If the value given is null, the default value specified is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ToDouble(object value, double defaultValue)
        {
            if (value != null)
            {
                return defaultValue;
            }
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Converts an object of type decimal.
        /// If the value given is null, the default value specified is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value, decimal defaultValue)
        {
            if (value != null)
            {
                return defaultValue;
            }
            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Converts an object of type int. 
        /// If the value given is null, the default value specified is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(object value, int defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }


            bool success = int.TryParse(value.ToString(), out int result);

            if (success)
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Converts an object of type bool. 
        /// If the value given is null, the default value specified is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(object value, bool defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }


            bool success = bool.TryParse(value.ToString(), out bool result);

            if (success)
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Converts a string of a specified enum type. 
        /// If the value given is null or empty, the default value specified is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string value, T defaultValue) where T : struct
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            bool success = Enum.TryParse(value, true, out T result);

            if (success)
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
