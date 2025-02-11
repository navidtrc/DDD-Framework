using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Utilities.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// برای دریافت توضیحات یک ویژگی از enum اگر [Description] داشته باشد از این متد استفاده می‌شود.
    /// </summary>
    /// <param name="enumValue">مقداری که قرار است توضحیات آن دریافت شود</param>
    /// <returns>متن داخل [Description] در صورتی که وجود داشته باشد و در غیراین صورت عنوان enums ارسال شده</returns>
    public static string GetEnumDescription(this Enum enumValue)
    {
        var memberInfo = enumValue.GetType().GetField(enumValue.ToString());
        var attributes = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes != null ? ((DescriptionAttribute)attributes.FirstOrDefault()).Description : enumValue.ToString();
    }
    public static DisplayAttribute? GetDisplayAttribute(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DisplayAttribute>();
    }
}