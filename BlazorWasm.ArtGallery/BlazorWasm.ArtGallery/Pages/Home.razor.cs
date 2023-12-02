using Microsoft.JSInterop;

namespace BlazorWasm.ArtGallery.Pages
{
    public partial class Home
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadJavaScript();
                StateHasChanged();
            }
        }

        private async Task LoadJavaScript()
        {
            await Task.Delay(500);
            await JsRuntime.InvokeVoidAsync("loadJs", "theme/js/scripts.js");
        }
    }
}
