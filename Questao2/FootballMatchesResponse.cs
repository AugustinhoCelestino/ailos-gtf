namespace Questao2
{
    public class FootballMatchesResponse
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<Matches> Data { get; set; } = new List<Matches>();
    }

    public class Matches
    {
        public string Competition { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Round { get; set; } = string.Empty;
        public string Team1 { get; set; } = string.Empty;
        public string Team2 { get; set; } = string.Empty;
        public string Team1goals { get; set; } = string.Empty;
        public string Team2goals { get; set; } = string.Empty;
    }

}
