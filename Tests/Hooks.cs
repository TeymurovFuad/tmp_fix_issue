using API.Controllers.Github.Users;
using API.RefitConfig;
using Refit;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Sinks.File;
using BoDi;
using Microsoft.Extensions.Logging;
using API.Configs;

namespace Tests
{
    #region config_1 start
    [Binding]
    public sealed class Hooks
    {
        private string baseUrl = "https://api.github.com";
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun(Order = 1)]
        public static void APIBeforeTestRun()
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()
                  .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}").CreateLogger();

        }

        [BeforeScenario(Order = 1)]
        public void InitializeBeforeScenario()
        {
            var settings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer()
            };
            var gitHubApi = RefitConfig.Instance.InitializeRefitGitClient(baseUrl);
            _scenarioContext.ScenarioContainer.RegisterInstanceAs<IUsersApi>(gitHubApi);
        }

    }
    #endregion


    #region config_2 start
    //[Binding]
    //public class Hooks
    //{
    //    private readonly IObjectContainer _container;
    //    public Hooks(IObjectContainer container)
    //    {
    //        _container = container;
    //    }

    //    [BeforeScenario]
    //    public void CreateLogger()
    //    {
    //        var logger = LoggerDriver.GetLogger<IUsersApi>();
    //        _container.RegisterInstanceAs(logger);
    //    }
    //}

    //public static class LoggerDriver
    //{
    //    public static ILogger<T> GetLogger<T>() where T : class
    //    {
    //        ILogger<T> logger = new LoggerFactory().CreateLogger<T>();
    //        return logger;
    //    }
    //}
    #endregion
}
