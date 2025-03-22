using System.Data;

namespace Framework.Core.Domain.Toolkits;

public static class GlobalConstants
{
    public static readonly (decimal MinValue, decimal MaxValue, SqlDbType Type, int Precision, int Scale) PRICE = (0, 1_000_000_000_000, SqlDbType.Decimal, 18, 2);
    public static readonly (int MinLength, int MaxLength, SqlDbType Type) ADDRESS = (2, 250, SqlDbType.NVarChar);
}
