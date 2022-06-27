using Microsoft.AspNetCore.Components;
using MyRoadMap.Domain.Model.Entities;

namespace MyRoadMap.WebServer.Pages.RoadMaps
{
    public partial class List
    {
        [Inject]
        public ApiClient ApiClient { get; set; }

        public List<RoadMap> RoadMaps { get; set; } = new List<RoadMap>();

        protected override async Task OnInitializedAsync()
        {
            RoadMaps = await ApiClient.Get<List<RoadMap>>("api/RoadMaps");
            await base.OnInitializedAsync();
        }
    }
}
