using TerraHistoricus.Api.Models.Episode;
using TerraHistoricus.Api.Models.Pages;

namespace TerraHistoricus.Api.Services;

/// <summary>
/// 泰拉记事社篇章与页面服务
/// </summary>
public static class EpisodeAndPageService
{
    /// <summary>
    /// 获取篇章的详细信息
    /// </summary>
    /// <param name="comicCid">漫画的 CID</param>
    /// <param name="episodeCid">篇章的 CID</param>
    /// <returns>包含篇章详细信息的 <see cref="EpisodeDetail"/></returns>
    /// <exception cref="ArgumentException">参数错误</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="comicCid"/> 或 <paramref name="episodeCid"/> 为 null 或空白</exception>
    /// <exception cref="HttpRequestException">由于网络问题，操作失败</exception>
    public async static Task<EpisodeDetail> GetEpisodeDetailAsync(string comicCid, string episodeCid)
    {
        if (string.IsNullOrWhiteSpace(comicCid))
        {
            throw new ArgumentOutOfRangeException(nameof(comicCid), $"“{nameof(comicCid)}”不能为 null 或空白。");
        }

        if (string.IsNullOrWhiteSpace(episodeCid))
        {
            throw new ArgumentOutOfRangeException(nameof(episodeCid), $"“{nameof(episodeCid)}”不能为 null 或空白。");
        }

        Stream jsonStream = await HttpClientProvider.HttpClient.GetStreamAsync($"comic/{comicCid}/episode/{episodeCid}/");
        ResponsePackage<EpisodeDetail> result = await JsonSerializer.DeserializeAsync<ResponsePackage<EpisodeDetail>>(jsonStream, CommonValues.DefaultJsonSerializerOptions);

        if (result.IsSuccess())
        {
            return result.Data;
        }
        else
        {
            throw new ArgumentException($"传入参数错误\n错误代码：{result.Code}\n错误信息：{result.Message}");
        }
    }

    /// <summary>
    /// 获取页面的详细信息
    /// </summary>
    /// <param name="comicCid">漫画的 CID</param>
    /// <param name="episodeCid">篇章的 CID</param>
    /// <param name="pageNumber">页面的页码</param>
    /// <returns>包含页面详细信息的 <see cref="PageDetail"/></returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageNumber"/> 小于 1</exception>
    /// <exception cref="ArgumentException">参数错误</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="comicCid"/> 或 <paramref name="episodeCid"/> 为 null 或空白</exception>
    /// <exception cref="HttpRequestException">由于网络问题，操作失败</exception>
    public async static Task<PageDetail> GetPageDetailAsync(string comicCid, string episodeCid, int pageNumber)
    {
        if (string.IsNullOrWhiteSpace(comicCid))
        {
            throw new ArgumentOutOfRangeException(nameof(comicCid), $"“{nameof(comicCid)}”不能为 null 或空白。");
        }

        if (string.IsNullOrWhiteSpace(episodeCid))
        {
            throw new ArgumentOutOfRangeException(nameof(episodeCid), $"“{nameof(episodeCid)}”不能为 null 或空白。");
        }

        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "页面的页码应当大于 1。");
        }

        Stream jsonStream = await HttpClientProvider.HttpClient.GetStreamAsync($"comic/{comicCid}/episode/{episodeCid}/page?pageNum={pageNumber}");
        ResponsePackage<PageDetail> result = await JsonSerializer.DeserializeAsync<ResponsePackage<PageDetail>>(jsonStream, CommonValues.DefaultJsonSerializerOptions);

        if (result.IsSuccess())
        {
            return result.Data;
        }
        else
        {
            throw new ArgumentException($"传入参数错误\n错误代码：{result.Code}\n错误信息：{result.Message}");
        }
    }
}
