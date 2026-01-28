using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Pages
{
    public partial class IP
    {
        [SupplyParameterFromQuery(Name = "ip")]
        public string IPAddress { get; set; } = string.Empty;

        [SupplyParameterFromQuery(Name = "cidr")]
        public string CIDR { get; set; } = string.Empty;

        [SupplyParameterFromQuery(Name = "subnet")]
        public string SubnetCIDR { get; set; } = string.Empty;

        public IP()
        {

        }

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(IPAddress))
            {
                ipNetwork = IPNetwork2.Parse(IPAddress, true);

                if (!string.IsNullOrEmpty(CIDR))
                {
                    subnets = ipNetwork.Subnet(byte.Parse(CIDR));

                } 
            }
        }
    }
}
