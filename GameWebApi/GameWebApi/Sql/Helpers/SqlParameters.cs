﻿namespace GameWebApi.Sql.Helpers
{
    using System;
    using System.Data;
    using Microsoft.Data.SqlClient;

    public static class SqlParameters
    {
        public static SqlParameter ToSqlParameter(this int value, string parameterName)
        {
            return new SqlParameter(parameterName, SqlDbType.Int) {Value = value};
        }

        public static SqlParameter ToSqlParameter(this bool value, string parameterName)
        {
            return new SqlParameter(parameterName, SqlDbType.Bit) { Value = value };
        }

        public static SqlParameter ToSqlParameter(this string value, string parameterName, bool isVarChar = false)
        {

            var sqlType = isVarChar ? SqlDbType.VarChar : SqlDbType.NVarChar;
            object tmpValue = value;
            if (value == null)
                tmpValue = DBNull.Value;

            return new SqlParameter(parameterName, sqlType) { Value = tmpValue };
        }

        public static SqlParameter ToSqlParameter(this byte value, string parameterName)
        {
            return new SqlParameter(parameterName, SqlDbType.TinyInt) { Value = value };
        }

        public static SqlParameter ToSqlParameter(this DateTime value, string parameterName)
        {
            return new SqlParameter(parameterName, SqlDbType.Date) { Value = value };
        }
    }
}
