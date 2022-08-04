using API.Controllers.Github.Users;
using API.RefitConfig;
using Common;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Configs
{
    public class RefitConfig
    {
        //internal IUsersApi user;
        //private readonly Constants constants = new Constants();

        //public RefitConfig()
        //{
        //    user = RestService.For<IUsersApi>(constants.GITHUB_BASE_URL);
        //}

        //public UserDetailsModel GetDetails()
        //{
        //    var details = user.GetUserDetails(userName: "fuadTeymurov").GetAwaiter().GetResult();
        //    return details;
        //}

        private static readonly Lazy<RefitConfig> lazy =
      new Lazy<RefitConfig>(() => new RefitConfig());

        public static RefitConfig Instance { get { return lazy.Value; } }

        private RefitConfig()
        {
        }
        public IUsersApi InitializeRefitGitClient(string baseUrl)
        {
            var options = new JsonSerializerOptions();
            var settings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer()
            };
            var _httpClient = new HttpClient(new HttpClientHandler()) { BaseAddress = new Uri(baseUrl) };
            var builder = RequestBuilder.ForType<IUsersApi>(settings);
            return RestService.For(_httpClient, builder);

            //var _httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(baseUrl) };
            //var contract = Refit.RestService.For<IUsersApi>(_httpClient);
            //return contract;
        }

    }
}
