using System.Net;

namespace BSNTools.Web.Common.Helpers.Extensions
{
    public static class IPAddressExtensions
    {
        public static string ToBinaryString(this IPAddress ipAddress)
        {
            return string.Join(".", ipAddress.GetAddressBytes().Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        }
    }
}
