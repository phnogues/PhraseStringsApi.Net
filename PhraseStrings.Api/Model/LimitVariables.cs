namespace PhraseStrings.Api.Model
{
    internal static class LimitVariables
    {
        public static object NumberOfAllowedRequestsLock { get; } = new object();

        public static object NumberOfRemainingRequestsLock { get; } = new object();

        public static object DateTimeOfLimitResetingLock { get; } = new object();

        public static int? NumberOfAllowedRequests { get; set; }

        public static int? NumberOfRemainingRequests { get; set; }

        public static DateTimeOffset? DateTimeOfLimitReseting { get; set; }
    }
}
