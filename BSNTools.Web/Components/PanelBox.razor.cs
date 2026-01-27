using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Components
{
    public partial class PanelBox : ComponentBase
    {
        [Parameter]
        public string Title { get; set; } = "";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public PanelBox()
        {

        }
    }
}
