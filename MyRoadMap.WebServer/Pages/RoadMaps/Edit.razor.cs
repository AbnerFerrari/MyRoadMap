using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyRoadMap.Domain.Model.Entities;

namespace MyRoadMap.WebServer.Pages.RoadMaps
{
    public partial class Edit
    {
        [Inject]
        public ApiClient ApiClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public long Id { get; set; }

        public RoadMap Model { get; set; }

        public Edit()
        {
            Model = new RoadMap();
        }

        protected override async Task OnInitializedAsync()
        {
            Model = await ApiClient.Get<RoadMap>($"api/RoadMaps/{Id}");
            await base.OnInitializedAsync();
        }

        public async Task OnSubmit(EditContext editContext)
        {
            try
            {
                if (editContext.Validate())
                {
                    _ = await ApiClient.Put<RoadMap>($"api/RoadMaps/{Model.Id}", editContext.Model as RoadMap);
                    NavigationManager.NavigateTo("RoadMaps");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
