using Microsoft.Extensions.Configuration;
using Model;

namespace Tests.Helpers
{
    public class TestConfiguration
    {
        private static IConfigurationRoot GetConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();
        }
        public static AppSettings AppSetting
        {
            get
            {
                var configuration = new AppSettings();
                GetConfigurationRoot().Bind("AppSettings", configuration);
                return configuration;
            }
        }

        public static void ShowConfig(ITestOutputHelper output, IConfiguration config = null)
        {
            config ??= GetConfigurationRoot();
            foreach (var pair in config.GetChildren())
            {
                output.WriteLine($"{pair.Path} - {pair.Value}");
                ShowConfig(output, pair);
            }
        }
    }
}
