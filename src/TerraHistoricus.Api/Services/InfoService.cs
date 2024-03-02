using TerraHistoricus.Api.Models.Info;

namespace TerraHistoricus.Api.Services;

/// <summary>
/// 泰拉记事社信息服务
/// </summary>
public static class InfoService
{
    /// <summary>
    /// 获取推荐漫画的信息
    /// </summary>
    /// <returns>包含推荐漫画信息的 <see cref="RecommendComicInfo"/></returns>
    /// <exception cref="InvalidOperationException">出现未知错误</exception>
    /// <exception cref="HttpRequestException">由于网络问题，操作失败</exception>
    public static async Task<RecommendComicInfo> GetRecommendComicAsync()
    {
        Stream jsonStream = await HttpClientProvider.HttpClient.GetStreamAsync("recommend");
        ResponsePackage<RecommendComicInfo> result = await JsonSerializer.DeserializeAsync<ResponsePackage<RecommendComicInfo>>(jsonStream, CommonValues.DefaultJsonSerializerOptions);

        if (result.IsSuccess())
        {
            return result.Data;
        }
        else
        {
            throw new InvalidOperationException($"出现错误\n错误代码：{result.Code}\n错误信息：{result.Message}");
        }
    }

    /// <summary>
    /// 获取最近更新篇章的信息
    /// </summary>
    /// <returns>包含最近更新篇章信息的 <see cref="IEnumerable{T}"/></returns>
    /// <exception cref="InvalidOperationException">出现未知错误</exception>
    /// <exception cref="HttpRequestException">由于网络问题，操作失败</exception>
    public static async Task<IEnumerable<EpisodeUpdateInfo>> GetRecentUpdateEpisodeAsync()
    {
        Stream jsonStream = await HttpClientProvider.HttpClient.GetStreamAsync("recentUpdate");
        ResponsePackage<IEnumerable<EpisodeUpdateInfo>> result = await JsonSerializer.DeserializeAsync<ResponsePackage<IEnumerable<EpisodeUpdateInfo>>>(jsonStream, CommonValues.DefaultJsonSerializerOptions);

        if (result.IsSuccess())
        {
            return result.Data!;
        }
        else
        {
            throw new InvalidOperationException($"出现错误\n错误代码：{result.Code}\n错误信息：{result.Message}");
        }
    }
}
