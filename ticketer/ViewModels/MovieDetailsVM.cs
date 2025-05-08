namespace ticketer.ViewModels
{
    public class MovieDetailsVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }

        public string ProducerName { get; set; }
        public List<string> ActorNames { get; set; }

        public List<ShowtimeInfo> Showtimes { get; set; }

        public class ShowtimeInfo
        {
            public string CinemaName { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan Time { get; set; }
        }
    }

}
