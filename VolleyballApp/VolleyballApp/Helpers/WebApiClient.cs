using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace VolleyballApp.Helpers
{
    public class WebApiClient
    {
        public static string ApiUrl { get; } = Application.Current.Properties["apiUrl"] as string;

        public WebApiClient()
        {

        }

        public static Position GetPosition(int positionId)
        {
            HttpResponseMessage response = null;
            Position position = null;
            using (var httpClient = new HttpClient())
            {
                response = httpClient.GetAsync(new Uri(ApiUrl + $"api/positions/{positionId}")).Result;

                if (response.IsSuccessStatusCode)
                {
                    position = JsonConvert.DeserializeObject<Position>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return position;
        }

        public static List<Position> GetPositions()
        {
            HttpResponseMessage response = null;
            List<Position> positions = null;
            using (var httpClient = new HttpClient())
            {
                response = httpClient.GetAsync(new Uri(ApiUrl + $"api/positions/")).Result;

                if (response.IsSuccessStatusCode)
                {
                    positions = JsonConvert.DeserializeObject<List<Position>>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return positions;
        }

        public static List<Player> GetPlayers(int teamId)
        {
            HttpResponseMessage response = null;
            List<Player> players = null;
            using (var httpClient = new HttpClient())
            {
                response = httpClient.GetAsync(new Uri(ApiUrl + $"api/players/{teamId}")).Result;

                if (response.IsSuccessStatusCode)
                {
                    players = JsonConvert.DeserializeObject<List<Player>>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return players;
        }

        public static void AddPlayer(Player player)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsync(new Uri(ApiUrl + $"api/players/"), new StringContent(JsonConvert.SerializeObject(player), Encoding.UTF8, "application/json")).Result;
            }
        }

        public static List<Team> GetTeams()
        {
            HttpResponseMessage response = null;
            List<Team> teams = null;
            using (var httpClient = new HttpClient())
            {
                response = httpClient.GetAsync(new Uri(ApiUrl + $"api/teams")).Result;

                if (response.IsSuccessStatusCode)
                {
                    teams = JsonConvert.DeserializeObject<List<Team>>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return teams;
        }

        public static void AddTeam(Team team)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsync(new Uri(ApiUrl + $"api/teams/"), new StringContent(JsonConvert.SerializeObject(team), Encoding.UTF8, "application/json")).Result;
            }
        }
    }
}
