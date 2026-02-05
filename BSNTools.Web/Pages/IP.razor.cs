using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BSNTools.Web.Core.Debugging;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Pages
{
    public partial class IP : ComponentBase
    {
        [SupplyParameterFromQuery(Name = "ip")]
        public string IPAddress { get; set; }

        [SupplyParameterFromQuery(Name = "cidr")]
        public string CIDR { get; set; }

        [SupplyParameterFromQuery(Name = "subnet")]
        public string SubnetCIDR { get; set; } = string.Empty;

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(IPAddress))
            {
                Console.WriteLine(IPAddress);

                ipNetwork = IPNetwork2.Parse(IPAddress, true);

                if (!string.IsNullOrEmpty(CIDR))
                {
                    Console.WriteLine(CIDR);

                    subnets = ipNetwork.Subnet(byte.Parse(CIDR));

                    LogService.Log(subnets.Count.ToString());

                    while (subnets != null && subnets.Count == 0)
                    {
                        await InvokeAsync(async () => await Task.Delay(100));

                    }


                }
            }
        }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (string.IsNullOrEmpty(IPAddress))
            {
                string addr = await InputBox.ShowAsync("Eingabe", "Gebe die IP-Adresse ein:");

                if (!string.IsNullOrEmpty(addr))
                {
                    NavigationManager.NavigateTo(NavigationManager.GetUriWithQueryParameters(new Dictionary<string, object?>
                    {
                        ["ip"] = addr
                    }));
                }
            }

            if (subnets != null)
            {
                LogService.Log(subnets.Count.ToString());
            }
        }
    }
}
