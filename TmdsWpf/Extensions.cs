using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmds
{
    public static class Extensions
    {

        public static T ParseValue<T>(this string s) where T : IConvertible
        {

            var thisType = default(T);
            var typeCode = thisType.GetTypeCode();
            if (typeCode == TypeCode.Double)
            {
                double d = double.Parse(s);
                return (T)Convert.ChangeType(d, typeCode);
            }
            else if (typeCode == TypeCode.Int32)
            {
                int i = int.Parse(s);
                return (T)Convert.ChangeType(i, typeCode);
            }
            else if (typeCode == TypeCode.Single)
            {
                float f = float.Parse(s);
                return (T)Convert.ChangeType(f, typeCode);
            }
            else if (typeCode == TypeCode.Boolean)
            {
                bool b = bool.Parse(s);
                return (T)Convert.ChangeType(b, typeCode);
            }
            else if (typeCode == TypeCode.DateTime)
            {
                DateTime d = DateTime.Parse(s);
                return (T)Convert.ChangeType(d, typeCode);
            }

            return thisType;
        }

    }
}
