using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace BSNTools.Web.Components
{
    public partial class Window : ComponentBase
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool FullScreen { get; set; } = false;

        [Parameter]
        public int Width { get; set; } = 400;

        [Parameter] 
        public int Height { get; set; } = 300;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public RenderFragment MenuBar { get; set; }

        public Window()
        {

        }
    }
}
