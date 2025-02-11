using System.Diagnostics.CodeAnalysis;
using System.Net;
using Utilities.Resources;

namespace Framework.Domain.Exceptions;

public abstract class DomainException : AggregateException
{
    public string[] Parameters { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public DomainException(string message, params string[] parameters) : base(message)
    {
        StatusCode = HttpStatusCode.UnprocessableEntity;
        Parameters = parameters;
    }
    public DomainException(HttpStatusCode statusCode, string message, params string[] parameters) : this(message, parameters)
    {
        StatusCode = statusCode;
    }
    public override string ToString()
    {
        if (Parameters?.Length < 1)
        {
            return Message;
        }

        string result = Message;

        for (long i = 0; i < Parameters.Length; i++)
        {
            string placeHolder = $"{{{i}}}";
            result = result.Replace(placeHolder, Parameters[i]);
        }

        return result;
    }
}

public class RequiredException : DomainException
{
    public RequiredException(string property) : base(property.IsRequiredMessage())
    { }

    [DoesNotReturn]
    public static void Throw(string property)
    {
        throw new RequiredException(property);
    }
}
public class NotEmptyException : DomainException
{
    public NotEmptyException(string property) : base(property.NotEmptyMessage())
    { }

    [DoesNotReturn]
    public static void Throw(string property)
    {
        throw new NotEmptyException(property);
    }
}

public class NotNullException : DomainException
{
    public NotNullException(string property) : base(property.NotNullMessage())
    { }

    [DoesNotReturn]
    public static void Throw(string property)
    {
        throw new NotNullException(property);
    }
}

public class StringMaxLengthException : DomainException
{
    public StringMaxLengthException(string property, long maxLength) : base(property.StringMaxLengthMessage(maxLength))
    { }

    [DoesNotReturn]
    public static void Throw(string property, long maxLength)
    {
        throw new StringMaxLengthException(property, maxLength);
    }
}

public class StringMinLengthException : DomainException
{
    public StringMinLengthException(string property, long minLength) : base(property.StringMinLengthMessage(minLength))
    { }

    [DoesNotReturn]
    public static void Throw(string property, long minLength)
    {
        throw new StringMinLengthException(property, minLength);
    }
}

public class StringLengthBetweenException : DomainException
{
    public StringLengthBetweenException(string property, long minLength, long maxLength) : base(property.StringLengthBetweenMessage(minLength, maxLength))
    { }

    [DoesNotReturn]
    public static void Throw(string property, long minLength, long maxLength)
    {
        throw new StringLengthBetweenException(property, minLength, maxLength);
    }
}

public class MaxValueException : DomainException
{
    public MaxValueException(string property, long maxValue) : base(property.MaxValueMessage(maxValue))
    { }

    [DoesNotReturn]
    public static void Throw(string property, long maxValue)
    {
        throw new MaxValueException(property, maxValue);
    }
}

public class MinValueException : DomainException
{
    public MinValueException(string property, long minValue) : base(property.MinValueMessage(minValue))
    { }

    [DoesNotReturn]
    public static void Throw(string property, long minValue)
    {
        throw new MinValueException(property, minValue);
    }
}

public class ValueBetweenException : DomainException
{
    public ValueBetweenException(string property, long minValue, long maxValue) : base(property.ValueBetweenMessage(minValue, maxValue))
    { }

    [DoesNotReturn]
    public static void Throw(string property, long minValue, long maxValue)
    {
        throw new ValueBetweenException(property, minValue, maxValue);
    }
}

public class NotEqualException : DomainException
{
    public NotEqualException(string property, object value) : base(property.NotEqualMessage(value))
    { }

    [DoesNotReturn]
    public static void Throw(string property, object value)
    {
        throw new NotEqualException(property, value);
    }
}

public class EqualException : DomainException
{
    public EqualException(string property, object value) : base(property.EqualMessage(value))
    { }

    [DoesNotReturn]
    public static void Throw(string property, object value)
    {
        throw new EqualException(property, value);
    }
}

public class GreaterThanException : DomainException
{
    public GreaterThanException(string property, object value) : base(property.GreaterThanMessage(value))
    { }

    [DoesNotReturn]
    public static void Throw(string property, object value)
    {
        throw new GreaterThanException(property, value);
    }
}

public class LessThanException : DomainException
{
    public LessThanException(string property, object value) : base(property.LessThanMessage(value))
    { }

    [DoesNotReturn]
    public static void Throw(string property, object value)
    {
        throw new LessThanException(property, value);
    }
}

public class NotValidException : DomainException
{
    public NotValidException(string property) : base(property.NotValidMessage())
    { }

    [DoesNotReturn]
    public static void Throw(string property)
    {
        throw new NotValidException(property);
    }
}

public class MustBeException : DomainException
{
    public MustBeException(string property, object value) : base(property.MustBeMessage(value))
    { }

    [DoesNotReturn]
    public static void Throw(string property, object value)
    {
        throw new MustBeException(property, value);
    }
}

public class MustNotBeException : DomainException
{
    public MustNotBeException(string property, object value) : base(property.MustNotBeMessage(value))
    { }

    [DoesNotReturn]
    public static void Throw(string property, object value)
    {
        throw new MustNotBeException(property, value);
    }
}

public class MustHaveException : DomainException
{
    public MustHaveException(string property, object value) : base(property.MustHaveMessage(value))
    { }

    [DoesNotReturn]
    public static void Throw(string property, object value)
    {
        throw new MustHaveException(property, value);
    }
}

public class MustHaveNotException : DomainException
{
    public MustHaveNotException(string property, object value) : base(property.MustHaveNotMessage(value))
    { }

    [DoesNotReturn]
    public static void Throw(string property, object value)
    {
        throw new MustHaveNotException(property, value);
    }
}

public class FormatIncorrectException : DomainException
{
    public FormatIncorrectException(string property) : base(property.FormatIncorrectMessage())
    { }

    [DoesNotReturn]
    public static void Throw(string property)
    {
        throw new FormatIncorrectException(property);
    }
}
public class MustBeUniqueException : DomainException
{
    public MustBeUniqueException(string property) : base(property.MustBeUniqueMessage())
    { }

    [DoesNotReturn]
    public static void Throw(string property)
    {
        throw new MustBeUniqueException(property);
    }
}

public class NotExistException : DomainException
{
    public NotExistException(string property) : base(property.NotExistMessage())
    { }

    [DoesNotReturn]
    public static void Throw(string property)
    {
        throw new NotExistException(property);
    }
}