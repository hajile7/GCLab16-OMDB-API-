namespace GCLab16_OMDB_API_.Models
{
    public partial class MovieModel
    {
        public string Title { get; set; }
        public long Year { get; set; }
        public string Rated { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public Uri Poster { get; set; }
    }

    public partial class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}
