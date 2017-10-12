using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace OTI_Booking_Platform.Models
{
    public static class ContextExtensions
    {
        public static string GetTableName<T>(this DbContext context) where T : class
        {
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

            return objectContext.GetTableName<T>();
        }

        public static string GetTableName<T>(this ObjectContext context) where T : class
        {
            string sql = context.CreateObjectSet<T>().ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
        }

        public static IDictionary<String, PropertyInfo> GetTableColumns(this DbContext ctx, Type entityType)
        {
            ObjectContext octx = (ctx as IObjectContextAdapter).ObjectContext;
            EntityType storageEntityType = octx.MetadataWorkspace.GetItems(DataSpace.SSpace)
                .Where(x => x.BuiltInTypeKind == BuiltInTypeKind.EntityType).OfType<EntityType>()
                .Single(x => x.Name == entityType.Name);

            var columnNames = storageEntityType.Properties.ToDictionary(x => x.Name,
                y => y.MetadataProperties.FirstOrDefault(x => x.Name == "PreferredName")?.Value as string ?? y.Name);

            return storageEntityType.Properties.Select((elm, index) =>
                    new { elm.Name, Property = entityType.GetProperty(columnNames[elm.Name]) })
                .ToDictionary(x => x.Name, x => x.Property);
        }
    }
}