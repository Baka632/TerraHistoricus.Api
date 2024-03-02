namespace TerraHistoricus.Api.Models.Info;

/// <summary>
/// 提供最新篇章更新信息的结构
/// </summary>
/// <param name="ComicCid">篇章所属漫画的 CID</param>
/// <param name="EpisodeCid">篇章的 CID</param>
/// <param name="ComicTitle">漫画的标题</param>
/// <param name="ComicSubtitle">漫画的副标题</param>
/// <param name="EpisodeShortTitle">篇章的短标题</param>
/// <param name="EpisodeType">篇章类型</param>
/// <param name="CoverUri">篇章封面图的 Uri</param>
/// <param name="UpdateTimestamp">篇章更新时间的时间戳</param>
public record struct EpisodeUpdateInfo(
    string ComicCid,
    string EpisodeCid,
    [property: JsonPropertyName("title")] string ComicTitle,
    [property: JsonPropertyName("subtitle")] string ComicSubtitle,
    string EpisodeShortTitle,
    int EpisodeType,
    [property: JsonPropertyName("coverUrl")] string CoverUri,
    [property: JsonPropertyName("updateTime")] long UpdateTimestamp);
