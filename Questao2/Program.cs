using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace Questao2
{
    public class Program
    {
        public static void Main()
        {
            string teamName = "Paris Saint-Germain";
            int year = 2013;
            int totalGoals = GetTotalScoredGoals(teamName, year);

            Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

            teamName = "Chelsea";
            year = 2014;
            totalGoals = GetTotalScoredGoals(teamName, year);

            Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            // Output expected:
            // Team Paris Saint - Germain scored 109 goals in 2013
            // Team Chelsea scored 92 goals in 2014
        }

        public static int GetTotalScoredGoals(string team, int year)
        {
            int totalScoredGoals = 0;
            totalScoredGoals += GetTotalScoredGoalsTeams(team, year, "1");
            totalScoredGoals += GetTotalScoredGoalsTeams(team, year, "2");
            return totalScoredGoals;
        }

        public static int GetTotalScoredGoalsTeams(string team, int year, string side)
        {
            int totalScoredGoals = 0;
            int page = 1;
            int totalpages = 1;

            UriBuilder urlBuilder = new("https://jsonmock.hackerrank.com/api/football_matches");

            do
            {
                var urlQuery = HttpUtility.ParseQueryString(urlBuilder.Query);
                urlQuery["year"] = year.ToString();
                urlQuery[$"team{side}"] = team.ToString();
                urlQuery["page"] = page.ToString();

                urlBuilder.Query = urlQuery.ToString();

                HttpRequestMessage httpRequest = new(HttpMethod.Get, urlBuilder.ToString());
                HttpClient httpClient = new();
                HttpResponseMessage response = httpClient.SendAsync(httpRequest).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    FootballMatchesResponse? footballMatchesResponse = JsonConvert.DeserializeObject<FootballMatchesResponse>(response.Content.ReadAsStringAsync().Result);
                    if (footballMatchesResponse == null)
                        break;

                    totalpages = footballMatchesResponse.Total_pages;

                    if (side == "1")
                        totalScoredGoals += footballMatchesResponse.Data.Sum(s => int.Parse(s.Team1goals));
                    else
                        totalScoredGoals += footballMatchesResponse.Data.Sum(s => int.Parse(s.Team2goals));
                }
                page++;

            } while (page <= totalpages);

            return totalScoredGoals;
        }

    }
}