using System.Runtime.CompilerServices;
using Model;
using Tests.Helpers;

namespace Tests
{
    public class BaseTest : XunitContextBase, IDisposable
    {
        protected readonly AppSettings AppSettings;
        private readonly ITestOutputHelper _output;
        public BaseTest(ITestOutputHelper output) : base(output)
        {
            var correlationId = Guid.NewGuid().ToString();

            CustomTestContext.Init(correlationId, TestConfiguration.AppSetting);
            AppSettings = TestConfiguration.AppSetting;
            _output = output;

            _output.WriteLine("Base Test");
            _output.WriteLine(TestConfiguration.AppSetting.HotelApiBaseUrl);
            _output.WriteLine(TestConfiguration.AppSetting.ChannelId);
            _output.WriteLine(TestConfiguration.AppSetting.AccountId);
            _output.WriteLine(TestConfiguration.AppSetting.LocationBaseUrl);
            _output.WriteLine(correlationId);
        }

        public override void Dispose()
        {
            var theExceptionThrownByTest = XunitContext.Context.TestException;
            if (theExceptionThrownByTest != null)
            {
                _output.WriteLine($"Exception: {theExceptionThrownByTest}");
            }
            _output.WriteLine($"CorrelationId: {CustomTestContext.Context.CorrelationId}");
            base.Dispose();
        }
    }

    public static class GlobalSetup
    {
        [ModuleInitializer]
        public static void Setup() =>
            XunitContext.EnableExceptionCapture();
    }
}
