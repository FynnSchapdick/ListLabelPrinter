using System.Data;
using System.Reflection;
using combit.Reporting.DataProviders;

namespace ListLabelPrinter.Infrastructure.Extensions;

public static class ObjectExtensions
{
    public static AdoDataProvider AsAdoNetDataSet(this object data, string tableName)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }
        
        if (string.IsNullOrEmpty(tableName))
        {
            throw new ArgumentNullException(nameof(tableName));
        }

        var ds = new DataSet();
        var dt = new DataTable(data.GetType().Name);
        ds.Tables.Add(dt);

        var properties = data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        var columns = new DataColumn[properties.Length];

        for (int i = 0; i < properties.Length; i++)
        {
            var prop = properties[i];
            var column = new DataColumn(prop.Name, prop.PropertyType);
            columns[i] = column;
        }

        dt.Columns.AddRange(columns);

        var row = dt.NewRow();
        for (int i = 0; i < properties.Length; i++)
        {
            var prop = properties[i];
            row[i] = prop.GetValue(data);
        }

        dt.Rows.Add(row);

        return new AdoDataProvider(ds);
    }
}