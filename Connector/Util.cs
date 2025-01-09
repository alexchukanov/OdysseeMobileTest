using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector
{
    public static class Util
    {
        public static T ConvertInvariant<T>(this object obj, T defaultValue = default(T))
        {
            if (obj == null)
            {
                return defaultValue;
            }
            JValue jValue = obj as JValue;
            if (jValue != null && jValue.Value == null)
            {
                return defaultValue;
            }
            T result;
            try
            {
                result = (T)Convert.ChangeType(jValue == null ? obj : jValue.Value, typeof(T), CultureInfo.InvariantCulture);
                if (typeof(T) == typeof(decimal))
                {
                    return (T)(object)((decimal)(object)result).Normalize();
                }
            }
            catch
            {
                // fallback to float conversion, i.e. 1E-1 for a decimal conversion will fail
                string stringValue = (jValue == null ? obj.ToStringInvariant() : jValue.Value.ToStringInvariant());
                decimal decimalValue = decimal.Parse(stringValue, System.Globalization.NumberStyles.Float);
                return (T)Convert.ChangeType(decimalValue, typeof(T), CultureInfo.InvariantCulture);
            }
            return result;
        }

        public static decimal ClampDecimal(decimal minValue, decimal maxValue, decimal? stepSize, decimal value)
        {
            if (minValue < 0) throw new ArgumentOutOfRangeException(nameof(minValue));
            if (maxValue < 0) throw new ArgumentOutOfRangeException(nameof(maxValue));
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue));

            if (stepSize.HasValue)
            {
                if (stepSize < 0) throw new ArgumentOutOfRangeException(nameof(stepSize));

                value = Math.Min(maxValue, value);
                value = Math.Max(minValue, value);
                decimal mod = value % stepSize.Value;
                value -= mod;
            }

            return value.Normalize();
        }

        /// <summary>
        /// Convert an object to string using invariant culture
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>String</returns>
        public static string ToStringInvariant(this object obj)
        {
            return Convert.ToString(obj, CultureInfo.InvariantCulture) ?? string.Empty;
        }

        /// <summary>
        /// Convert an object to string uppercase using invariant culture
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>String</returns>
        public static string ToStringUpperInvariant(this object obj)
        {
            return ToStringInvariant(obj).ToUpperInvariant();
        }

        /// <summary>
        /// Convert an object to string lowercase using invariant culture
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>String</returns>
        public static string ToStringLowerInvariant(this object obj)
        {
            return ToStringInvariant(obj).ToLowerInvariant();
        }


        public static decimal Normalize(this decimal value)
        {
            return value / 1.000000000000000000000000000000000m;
        }

    }

    public class OdysseeAuthenticator : IAuthenticator
    {
        #region Fields/Constants

        private readonly string _domain;
        private readonly string _user;
        private readonly string _password;

        #endregion

        #region Constructors

        public OdysseeAuthenticator(string domain, string user, string password)
        {
            _domain = domain;
            _user = user;
            _password = password;
        }


        public String Authorization
        {
            get
            {

                string arg = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}@{2}", _user, _password, _domain)));
                string value = string.Format("Basic {0}", arg);
                return value;
            }
        }
        #endregion

        #region Implementations

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (!request.Parameters.Any((Parameter p) => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
            {
                request.AddParameter("Authorization", Authorization, ParameterType.HttpHeader);
            }
        }
        #endregion
    }
}
