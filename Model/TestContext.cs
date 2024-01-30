namespace Model
{
    public static class TestContext
    {
        public static AppSettings AppSettings { get { return CustomTestContext.Context.AppSettings; } }
        public static string CurrentCorrelationId { get { return CustomTestContext.Context.CorrelationId; } }
    }



    public class CustomTestContext : IDisposable
    {
        static AsyncLocal<CustomTestContext> local;
        private CustomTestContext(string correlationId, AppSettings appSettings)
        {
            CorrelationId = correlationId;
            AppSettings = appSettings;
        }
        public static void Init(string correlationId, AppSettings appSettings)
        {
            local = new AsyncLocal<CustomTestContext>
            {
                Value = new CustomTestContext(correlationId, appSettings)
            };
        }

        public void Dispose()
        {
            local = null;
        }

        public static CustomTestContext Context
        {
            get
            {
                var context = local.Value;
                return context;
            }
        }
        public string CorrelationId { get; }
        public AppSettings AppSettings { get; }
    }
}
