public static class MarsAPIConstants
{
    private const string Feed = "feed=raw_images";
    private const string FeedType = "feedtype=json";
    private const string Category = "category=";
    private const string version = "v1.2";
    public const  string CuriosityRoverPath = $"/api/v1/raw_image_items/?condition_1=msl%3Amission";
    public readonly static string PerseveranceRoverPath = $"/rss/api/{SetFeedAndCategory("mars2020")}";
    public const string InSightLanderPath = $"/api/v1/raw_image_items/?condition_1=insight%3Amission";
    public readonly static string IngenuityHelicopterPath = $"/rss/api/{SetFeedAndCategory("ingenuity")}";
    public const string LatestCuriosityRoverSolsPath = $"/api/v1/raw_image_items/msl/latest/";
    public const string LatestInSightLanderPath = $"/api/v1/raw_image_items/insight/latest/";
    public readonly static string LatestPerseveranceRoverSolsPath = $"/rss/api/?{SetFeedAndCategory("mars2020")}&ver=1.2&latest=true";
    public readonly static string LatestIngenuityRoverSolsPath = $"/rss/api/?{SetFeedAndCategory("ingenuity")}&ver=1.2&latest=true";
    private static string SetFeedAndCategory(string category) => $"?{Feed}&{FeedType}&{Category}{category}";
}