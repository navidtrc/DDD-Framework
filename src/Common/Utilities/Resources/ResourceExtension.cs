using System.Resources;

namespace Utilities.Resources;

public static class ResourceExtension
{
    private static string VALIDATION_ERROR_NOT_EMPTY = nameof(VALIDATION_ERROR_NOT_EMPTY);
    private static string VALIDATION_ERROR_NOT_NULL = nameof(VALIDATION_ERROR_NOT_NULL);
    private static string VALIDATION_ERROR_IS_REQUIRED = nameof(VALIDATION_ERROR_IS_REQUIRED);
    private static string VALIDATION_ERROR_IS_DUPLICATED = nameof(VALIDATION_ERROR_IS_DUPLICATED);
    private static string VALIDATION_ERROR_NOT_FOUND = nameof(VALIDATION_ERROR_NOT_FOUND);
    private static string VALIDATION_ERROR_MUST_BE_UNIQUE = nameof(VALIDATION_ERROR_MUST_BE_UNIQUE);
    private static string VALIDATION_ERROR_NOT_EXIST = nameof(VALIDATION_ERROR_NOT_EXIST);
    private static string VALIDATION_ERROR_STRING_MAX_LENGTH = nameof(VALIDATION_ERROR_STRING_MAX_LENGTH);
    private static string VALIDATION_ERROR_STRING_MIN_LENGTH = nameof(VALIDATION_ERROR_STRING_MIN_LENGTH);
    private static string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = nameof(VALIDATION_ERROR_STRING_LENGTH_BETWEEN);
    private static string VALIDATION_ERROR_MAX_VALUE = nameof(VALIDATION_ERROR_MAX_VALUE);
    private static string VALIDATION_ERROR_MIN_VALUE = nameof(VALIDATION_ERROR_MIN_VALUE);
    private static string VALIDATION_ERROR_VALUE_BETWEEN = nameof(VALIDATION_ERROR_VALUE_BETWEEN);
    private static string VALIDATION_ERROR_NOT_EQUAL = nameof(VALIDATION_ERROR_NOT_EQUAL);
    private static string VALIDATION_ERROR_EQUAL = nameof(VALIDATION_ERROR_EQUAL);
    private static string VALIDATION_ERROR_GREATER_THAN = nameof(VALIDATION_ERROR_GREATER_THAN);
    private static string VALIDATION_ERROR_LESS_THAN = nameof(VALIDATION_ERROR_LESS_THAN);
    private static string VALIDATION_ERROR_NOT_VALID = nameof(VALIDATION_ERROR_NOT_VALID);
    private static string VALIDATION_ERROR_MUST_BE = nameof(VALIDATION_ERROR_MUST_BE);
    private static string VALIDATION_ERROR_MUST_NOT_BE = nameof(VALIDATION_ERROR_MUST_NOT_BE);
    private static string VALIDATION_ERROR_MUST_HAVE = nameof(VALIDATION_ERROR_MUST_HAVE);
    private static string VALIDATION_ERROR_MUST_HAVE_NOT = nameof(VALIDATION_ERROR_MUST_HAVE_NOT);
    private static string VALIDATION_ERROR_FORMAT_INCORRECT = nameof(VALIDATION_ERROR_FORMAT_INCORRECT);

    public static string ToMessageText(this string property, ResourceManager? resourceManager = null)
    {
        try
        {

            if (resourceManager is null) resourceManager = ValidationErrorMessagesResource.ResourceManager;
            string? resourceValue = resourceManager.GetString(property);
            return resourceValue ?? property;
        }
        catch (Exception)
        {
            return property;
        }
    }

    public static string NotEmptyMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_NOT_EMPTY)) =>
    string.Format(resourceKey.ToMessageText(), property.ToMessageText());

    public static string NotNullMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_NOT_NULL)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText());

    public static string IsRequiredMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_IS_REQUIRED)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText());

    public static string IsDuplicatedMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_IS_DUPLICATED)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText());

    public static string NotFoundMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_NOT_FOUND)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText());

    public static string MustBeUniqueMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_MUST_BE_UNIQUE)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText());

    public static string NotExistMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_NOT_EXIST)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText());

    public static string StringMaxLengthMessage(this string property, long maxLength, string resourceKey = nameof(VALIDATION_ERROR_STRING_MAX_LENGTH)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), maxLength);

    public static string StringMinLengthMessage(this string property, long minLength, string resourceKey = nameof(VALIDATION_ERROR_STRING_MIN_LENGTH)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), minLength);

    public static string StringLengthBetweenMessage(this string property, long minLength, long maxLength, string resourceKey = nameof(VALIDATION_ERROR_STRING_LENGTH_BETWEEN)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), minLength, maxLength);

    public static string MaxValueMessage(this string property, long maxValue, string resourceKey = nameof(VALIDATION_ERROR_MAX_VALUE)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), maxValue);

    public static string MinValueMessage(this string property, long minValue, string resourceKey = nameof(VALIDATION_ERROR_MIN_VALUE)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), minValue);

    public static string ValueBetweenMessage(this string property, long minValue, long maxValue, string resourceKey = nameof(VALIDATION_ERROR_VALUE_BETWEEN)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), minValue, maxValue);

    public static string NotEqualMessage(this string property, object value, string resourceKey = nameof(VALIDATION_ERROR_NOT_EQUAL)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), value);

    public static string EqualMessage(this string property, object value, string resourceKey = nameof(VALIDATION_ERROR_EQUAL)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), value);

    public static string GreaterThanMessage(this string property, object value, string resourceKey = nameof(VALIDATION_ERROR_GREATER_THAN)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), value);

    public static string LessThanMessage(this string property, object value, string resourceKey = nameof(VALIDATION_ERROR_LESS_THAN)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), value);

    public static string NotValidMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_NOT_VALID)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText());

    public static string MustBeMessage(this string property, object value, string resourceKey = nameof(VALIDATION_ERROR_MUST_BE)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), value);

    public static string MustNotBeMessage(this string property, object value, string resourceKey = nameof(VALIDATION_ERROR_MUST_NOT_BE)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), value);

    public static string MustHaveMessage(this string property, object value, string resourceKey = nameof(VALIDATION_ERROR_MUST_HAVE)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), value);

    public static string MustHaveNotMessage(this string property, object value, string resourceKey = nameof(VALIDATION_ERROR_MUST_HAVE_NOT)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText(), value);

    public static string FormatIncorrectMessage(this string property, string resourceKey = nameof(VALIDATION_ERROR_FORMAT_INCORRECT)) =>
        string.Format(resourceKey.ToMessageText(), property.ToMessageText());
}
