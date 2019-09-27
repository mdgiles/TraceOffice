using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms
{
	public static class Extensions
	{
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
