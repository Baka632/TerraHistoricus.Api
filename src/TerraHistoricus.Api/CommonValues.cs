namespace TerraHistoricus.Api;

/// <summary>
/// 存储库中常用值的类
/// </summary>
internal static class CommonValues
{
    /// <summary>
    /// 泰拉记事社 API 的基 Uri
    /// </summary>
    public static readonly string ApiBaseUri = "https://terra-historicus.hypergryph.com/api/";

    /// <summary>
    /// 默认 <see cref="JsonSerializer"/> 设置
    /// </summary>
    public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}
