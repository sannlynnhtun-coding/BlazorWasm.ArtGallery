using BlazorWasm.ArtGallery.Models;
using Microsoft.JSInterop;

namespace BlazorWasm.ArtGallery.Pages
{
    public partial class Home
    {
        private List<ArtAndArtistModel>? _artList = null;
        private ArtAndArtistProfileModel? _artListAndProfile = null;
        private EnumFormType _formType = EnumFormType.List;
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                _artList = _service.ShowArtLst();
                //await LoadJavaScript();
                StateHasChanged();
            }
        }
        private async Task LoadJavaScript()
        {
            await Task.Delay(500);
            await JsRuntime.InvokeVoidAsync("loadJs", "theme/js/scripts.js");
        }

        private async Task FormType(int artistId)
        {
            _artList = null;
            _formType = EnumFormType.Detail;
            _artListAndProfile = _service.ShowArtLstByArtist(artistId);
            StateHasChanged();
            await LoadJavaScript();
            await JsRuntime.InvokeVoidAsync("gridLayout");
        }

        private async Task Back()
        {
            _artListAndProfile = null;
            _formType = EnumFormType.List;
            _artList = _service.ShowArtLst();
            StateHasChanged();
            await LoadJavaScript();
            await JsRuntime.InvokeVoidAsync("gridLayout");
        }
    }
}
