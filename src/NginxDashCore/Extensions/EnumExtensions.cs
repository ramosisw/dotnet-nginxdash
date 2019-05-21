using System.ComponentModel;
using NginxDashCore.Enum;

namespace NginxDashCore.Extensions
{
    public static class EnumExtensions
    {
        private static string GetDescription<T>(this T modifier)
        {
            var attr = modifier.GetType()
                    .GetField(modifier.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attr.Length > 0)
            {
                var Description = attr[0] as DescriptionAttribute;
                return Description.Description;
            }
            return "";
        }

        public static string GetModifier(this LocationModifier modifier)
        {
            return modifier.GetDescription();
        }

        public static string GetDirective(this NginxDirective modifier)
        {
            return modifier.GetDescription();
        }
    }
}