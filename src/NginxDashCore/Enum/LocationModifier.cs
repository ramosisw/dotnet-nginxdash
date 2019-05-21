using System.ComponentModel;

namespace NginxDashCore.Enum
{
    public enum LocationModifier
    {
        [Description("")]
        PREFIX,
        [Description("=")]
        EXACTLY,
        [Description("~")]
        CASE_SENSITIVE,
        [Description("~*")]
        CASE_INSENSITIVE,
        [Description("^~")]
        NON_REGEX
    }
}