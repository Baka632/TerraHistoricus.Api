namespace TerraHistoricus.Api.Models.Info;

/// <summary>
/// 提供推荐漫画信息的结构
/// </summary>
/// <param name="ComicCid">漫画的 CID</param>
/// <param name="EpisodeCid">漫画最新篇章的 CID</param>
/// <param name="Title">漫画的标题</param>
/// <param name="Subtitle">漫画的副标题</param>
/// <param name="Introduction">漫画引言</param>
/// <param name="DesktopCoverUri">为桌面环境而设计的漫画封面的 Uri</param>
/// <param name="MobileCoverUri">为移动设备而设计的漫画封面的 Uri</param>
/// <param name="Theme">颜色主题的字符串</param>
/// <param name="UpdateTimestamp">漫画更新时间的时间戳</param>
/// <param name="Authors">漫画作者列表</param>
/// <param name="Keywords">漫画的关键词</param>
public record struct RecommendComicInfo(
    string ComicCid,
    string EpisodeCid,
    string Title,
    string Subtitle,
    string Introduction,
    [property: JsonPropertyName("pcBg")] string DesktopCoverUri,
    [property: JsonPropertyName("h5Bg")] string MobileCoverUri,
    string Theme,
    [property: JsonPropertyName("updateTime")] long UpdateTimestamp,
    IEnumerable<string> Authors,
    IEnumerable<string> Keywords);
