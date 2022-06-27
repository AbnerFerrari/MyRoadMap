using Microsoft.AspNetCore.Components;

namespace MyRoadMap.WebServer.Pages.RoadMaps
{
    public partial class Page
    {
        [Parameter]
        public long Id { get; set; }
    }
}
