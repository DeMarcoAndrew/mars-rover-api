public static class MarsAPIConstants
{
    private const string Feed = "feed=raw_images";
    private const string FeedType = "feedtype=json";
    private const string Category = "category=";
    private const string Mission = "mission=";
    public readonly static string CuriosityRoverPath = $"/rss/api/{SetFeedAndCategory("msl")}";
    public readonly static string PerseveranceRoverPath = $"/rss/api/{SetFeedAndCategory("mars2020")}";
    public readonly static string InSightLanderPath = $"/insight/api/?{SetFeedAndMission("insight")}";
    private static string SetFeedAndCategory(string category) => $"?{Feed}&{FeedType}&{Category}{category}";
    private static string SetFeedAndMission(string mission) => $"?{Feed}&{FeedType}&{Mission}{mission}";
}