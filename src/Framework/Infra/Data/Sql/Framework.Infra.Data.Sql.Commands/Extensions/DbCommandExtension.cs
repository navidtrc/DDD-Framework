﻿using System.Data;
using System.Data.Common;
using Utilities.Extensions;

namespace Framework.Infra.Data.Sql.Commands.Extensions;

public static class DbCommandExtension
{
    public static void ApplyCorrectYeKe(this DbCommand command)
    {
        command.CommandText = command.CommandText.CleanString();

        foreach (DbParameter parameter in command.Parameters)
        {
            switch (parameter.DbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.Xml:
                    parameter.Value = parameter.Value is DBNull ? parameter.Value : parameter.Value.CleanString();
                    break;
            }
        }
    }
}