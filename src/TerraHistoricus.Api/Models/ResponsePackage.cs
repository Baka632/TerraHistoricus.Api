using System.Diagnostics;

namespace TerraHistoricus.Api.Models;

/// <summary>
/// 为服务器响应提供通用模型
/// </summary>
/// <typeparam name="T">响应中数据的类型</typeparam>
/// <param name="Code">响应代码</param>
/// <param name="Message">响应消息</param>
/// <param name="Data">响应中的实际数据</param>
public record struct ResponsePackage<T>(int Code, [property: JsonPropertyName("msg")] string Message, T? Data)
{
    /// <summary>
    /// 确定操作是否成功
    /// </summary>
    /// <returns>若操作成功，则返回 <see langword="true"/>，否则返回 <see langword="false"/></returns>
    [DebuggerStepThrough]
    public readonly bool IsSuccess()
    {
        return Code == 0;
    }
}
