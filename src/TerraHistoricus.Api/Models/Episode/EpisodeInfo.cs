namespace TerraHistoricus.Api.Models.Episode;

/// <summary>
/// 提供篇章基本信息的结构
/// </summary>
/// <param name="Cid">篇章的 CID</param>
/// <param name="Title">篇章的标题</param>
/// <param name="ShortTitle">篇章的短标题</param>
/// <param name="DisplayTimestamp">篇章发布时间的时间戳</param>
/// <param name="Type">篇章类型</param>
public record struct EpisodeInfo(
    string Cid,
    string Title,
    string ShortTitle,
    [property: JsonPropertyName("displayTime")] long DisplayTimestamp,
    int Type);