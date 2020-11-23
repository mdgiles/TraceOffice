using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TraceForms
{
	public static class Extensions
	{
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }

        public static object GetPropertyValue(this object record, string propertyName)
        {
            if (record == null) {
                return null;
            }
            else {
                return record.GetType().GetProperty(propertyName)
                   .GetValue(record, null);
            }
        }

        public static void SetPropertyValue(this object record, string propertyName, object value)
        {
            record.GetType().GetProperty(propertyName)
               .SetValue(record, value);
        }

        public static IEnumerable<t> DistinctBy<t>(this IEnumerable<t> list, Func<t, object> propertySelector)
		{
			return list.GroupBy(propertySelector).Select(x => x.First());
		}

        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj == null)
            {
                return true;
            }
            else
            {
                return string.IsNullOrEmpty(obj.ToString());
            }
        }

        public static bool IsNotNullOrEmpty(this object obj)
        {
            return !obj.IsNullOrEmpty();
        }

        public static string ToStringEmptyIfNull(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString();
            }
        }

        public static string ToStringNullIfNull(this object obj)
        {
            if (obj == null) {
                return null;
            }
            else {
                return obj.ToString();
            }
        }

        public static object ToStringNullIfEmpty(this object obj)
        {
            if (obj != null) {
                if (string.IsNullOrEmpty(obj.ToString())) {
                    return null;
                }
            }
            return obj;
        }

        public static int ToIntZeroIfNull(this object obj)
        {
            string val = obj.ToStringEmptyIfNull();
            if (int.TryParse(val, out int result)) {
                return result;
            }
            else {
                return 0;
            }
        }

        public static Dictionary<string, string> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance)
        {
            //modified to not include properties with null or empty values in the dictionary, and to convert everything to a string
            return source.GetType().GetProperties(bindingAttr).Where(p => !p.GetValue(source, null).IsNullOrEmpty()).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null).ToString()
            );

        }

        public static int IndexOf(this OrderedDictionary dictionary, string key)
        {
            for (int i = 0; i < dictionary.Count; ++i)
            {
                if (((DictionaryEntry)dictionary[i]).Key.ToString() == key) return i;
            }
            return -1;
        }
    }
}
