using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Framework.Core.Domain.Toolkits.ValueObjects;

namespace Framework.Infra.Data.Sql.Commands.ValueConversions;

public class LegalNationalIdConversion()
    : ValueConverter<NationalId, string>(c => c.Value, c => NationalId.FromString(c));