using TerraHistoricus.Api.Models.Comic;

namespace TerraHistoricus.Api.Services;

/// <summary>
/// 泰拉记事社漫画服务
/// </summary>
public static class ComicService
{
    /// <summary>
    /// 获取全部漫画
    /// </summary>
    /// <returns>包含全部漫画的 <see cref="IEnumerable{T}"/></returns>
    /// <exception cref="InvalidOperationException">出现未知错误</exception>
    /// <exception cref="HttpRequestException">由于网络问题，操作失败</exception>
    public static async Task<IEnumerable<ComicInfo>> GetAllComicAsync()
    {
        Stream jsonStream = await HttpClientProvider.HttpClient.GetStreamAsync("comic");
        ResponsePackage<IEnumerable<ComicInfo>> result = await JsonSerializer.DeserializeAsync<ResponsePackage<IEnumerable<ComicInfo>>>(jsonStream, CommonValues.DefaultJsonSerializerOptions);

        if (result.IsSuccess())
        {
            return result.Data!;
        }
        else
        {
            throw new InvalidOperationException($"出现错误\n错误代码：{result.Code}\n错误信息：{result.Message}");
        }
    }

    /// <summary>
    /// 获取漫画的详细信息
    /// </summary>
    /// <param name="cid">漫画的 CID</param>
    /// <returns>包含漫画详细信息的 <see cref="ComicDetail"/></returns>
    /// <exception cref="ArgumentException">参数错误</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="cid"/> 为 null 或空白</exception>
    /// <exception cref="HttpRequestException">由于网络问题，操作失败</exception>
    public static async Task<ComicDetail> GetComicDetailAsync(string cid)
    {
        if (string.IsNullOrWhiteSpace(cid))
        {
            throw new ArgumentOutOfRangeException(nameof(cid), $"“{nameof(cid)}”不能为 null 或空白。");
        }

        Stream jsonStream = await HttpClientProvider.HttpClient.GetStreamAsync($"comic/{cid}");
        ResponsePackage<ComicDetail> result = await JsonSerializer.DeserializeAsync<ResponsePackage<ComicDetail>>(jsonStream, CommonValues.DefaultJsonSerializerOptions);

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
