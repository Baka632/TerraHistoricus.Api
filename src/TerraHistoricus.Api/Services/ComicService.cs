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
}
