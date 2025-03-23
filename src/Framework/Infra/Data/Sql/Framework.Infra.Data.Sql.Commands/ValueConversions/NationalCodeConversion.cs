using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Framework.Core.Domain.Toolkits.ValueObjects;

namespace Framework.Infra.Data.Sql.Commands.ValueConversions;

public class NationalCodeConversion()
    : ValueConverter<LegalNationalCode, string>(c => c.Value, c => LegalNationalCode.FromString(c));