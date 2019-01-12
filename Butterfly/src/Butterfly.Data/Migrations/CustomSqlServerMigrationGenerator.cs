using Butterfly.Models.Cores;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Data.Migrations
{
    internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        /// <summary>
        /// The generate.
        /// </summary>
        /// <param name="addColumnOperation">
        /// The add column operation.
        /// </param>
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreatedUtcColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        /// <summary>
        /// The generate.
        /// </summary>
        /// <param name="createTableOperation">
        /// The create table operation.
        /// </param>
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetCreatedUtcColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        /// <summary>
        /// The set created utc column.
        /// </summary>
        /// <param name="columns">
        /// The columns.
        /// </param>
        private static void SetCreatedUtcColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns) SetCreatedUtcColumn(columnModel);
        }

        /// <summary>
        /// The set created utc column.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        private static void SetCreatedUtcColumn(PropertyModel column)
        {
            const string NameOfColumnWithDate = nameof(EntityBase.Created);

            // w trakcie tworzenia migracji nadaje domyślną wartość równą aktualnej dacie serwera SQL dla pól kolumn nazwanych CreationDate
            if (column.Name == NameOfColumnWithDate) column.DefaultValueSql = "SYSUTCDATETIME()";
        }
    }
}
