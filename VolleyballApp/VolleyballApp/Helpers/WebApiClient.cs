using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ViewModels;
using Xamarin.Forms;

namespace VolleyballApp.Helpers
{
    public class WebApiClient
    {
        public static string ApiUrl { get; } = Application.Current.Properties.ContainsKey("ApiUrl") ? Application.Current.Properties["ApiUrl"] as string : string.Empty;
        private static string _jwtToken = Application.Current.Properties.ContainsKey("JwtToken") ? Application.Current.Properties["JwtToken"] as string : string.Empty;

        public WebApiClient()
        {

        }

        public static bool Validate()
        {
            if (!Uri.TryCreate(ApiUrl + "api/account/validate", UriKind.Absolute, out Uri uri))
            {
                return false;
            }


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _jwtToken);

                HttpResponseMessage response = httpClient.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Login(LoginViewModel model)
        {
            HttpResponseMessage response = null;

            using (var httpClient = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                response = httpClient.PostAsync(new Uri(ApiUrl + "api/account/login"), stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Application.Current.Properties["JwtToken"] = response.Content.ReadAsStringAsync().Result;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void Register(RegisterViewModel model)
        {
            HttpResponseMessage response = null;

            using (var httpClient = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                response = httpClient.PostAsync(new Uri(ApiUrl + "api/account/register"), stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Application.Current.Properties["JwtToken"] = response.Content.ReadAsStringAsync().Result;
                }
            }
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
            List<Team> teams = new List<Team>();
            using (var httpClient = new HttpClient())
            {
                response = httpClient.GetAsync(new Uri(ApiUrl + $"api/teams")).Result;

                if (response.IsSuccessStatusCode)
                {
                    teams.AddRange(JsonConvert.DeserializeObject<List<Team>>(response.Content.ReadAsStringAsync().Result));
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
