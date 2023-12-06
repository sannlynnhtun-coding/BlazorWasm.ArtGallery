using BlazorWasm.ArtGallery.Models;
using Microsoft.JSInterop;

namespace BlazorWasm.ArtGallery.Pages
{
    public partial class Home
    {
        private List<ArtAndArtistModel>? _artList = null;
        private List<ArtAndArtistModel>? _artListByArtist = null;
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

        private void FormType(int artistId)
        {
            _artList = null;
            _formType = EnumFormType.Detail;
            _artListByArtist = _service.ShowArtLstByArtist(artistId);
            StateHasChanged();
        }

        private async Task Back()
        {
            _artListByArtist = null;
            _formType = EnumFormType.List;
            _artList = _service.ShowArtLst();
            StateHasChanged();
            await LoadJavaScript();
            await JsRuntime.InvokeVoidAsync("gridLayout");
        }
    }
}
