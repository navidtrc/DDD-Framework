using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Framework.Core.Domain.ValueObjects;

namespace Framework.Infra.Data.Sql.Commands.ValueConversions;

public class BusinessIdConversion() :
    ValueConverter<BusinessId, Guid>(c => c.Value, c => BusinessId.FromGuid(c));