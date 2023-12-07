namespace BlazorWasm.ArtGallery.Models
{
    public class ArtistModel
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public List<SocialModel> Social { get; set; }
    }
}
