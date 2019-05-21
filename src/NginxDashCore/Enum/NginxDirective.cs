using System.ComponentModel;

namespace NginxDashCore.Enum
{
    public enum NginxDirective
    {
        [Description("proxy_pass")]
        PROXY_PASS,
        [Description("proxy_set_header")]
        PROXY_SET_HEADER,
        [Description("proxy_http_version")]
        PROXY_HTTP_VERSION,
        [Description("proxy_read_timeout")]
        PROXY_READ_TIMEOUT
    }
}