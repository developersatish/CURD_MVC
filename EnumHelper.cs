using System;
using System.ComponentModel;
using System.Reflection;

namespace OnlyMvc.Infrastructure
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum en)
        {

            if (en != null)
            {
                Type type = en.GetType();

                MemberInfo[] memInfo = type.GetMember(en.ToString());

                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attrs != null && attrs.Length > 0)
                    {
                        return ((DescriptionAttribute)attrs[0]).Description;
                    }
                }

                return en.ToString();
            }
            return null;
        }
    }
}