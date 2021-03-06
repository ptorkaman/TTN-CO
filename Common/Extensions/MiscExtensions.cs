using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.OleDb;
using System.Web.Mvc;

namespace TTN
{
	/// <remarks>codehint: sm-add</remarks>
	public static class MiscExtensions
    {
		public static void Dump(this Exception exc) {
			try {
				exc.StackTrace.Dump();
				exc.Message.Dump();
			}
			catch (Exception) {
			}
		}
		public static string ToElapsedMinutes(this Stopwatch watch) 
        {
			return "{0:0.0}".FormatWith(TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).TotalMinutes);
		}
		public static string ToElapsedSeconds(this Stopwatch watch) 
        {
			return "{0:0.0}".FormatWith(TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).TotalSeconds);
		}

		public static bool HasColumn(this DataView dv, string columnName) 
        {
			dv.RowFilter = "ColumnName='" + columnName + "'";
			return dv.Count > 0;
		}
		public static string GetDataType(this DataTable dt, string columnName) 
        {
			dt.DefaultView.RowFilter = "ColumnName='" + columnName + "'";
			return dt.Rows[0]["DataType"].ToString();
		}

		public static int CountExecute(this OleDbConnection conn, string sqlCount) 
        {
			using (OleDbCommand cmd = new OleDbCommand(sqlCount, conn)) 
            {
				return (int)cmd.ExecuteScalar();
			}
		}

		public static object SafeConvert(this TypeConverter converter, string value) 
        {
			try 
            {
				if (converter != null && value.HasValue() && converter.CanConvertFrom(typeof(string))) 
                {
					return converter.ConvertFromString(value);
				}
			}
			catch (Exception exc) 
            {
				exc.Dump();
			}
			return null;
		}
		public static bool IsEqual(this TypeConverter converter, string value, object compareWith) 
        {
			object convertedObject = converter.SafeConvert(value);

			if (convertedObject != null && compareWith != null)
				return convertedObject.Equals(compareWith);

			return false;
		}

		public static void SelectValue(this List<SelectListItem> lst, string value, string defaultValue = null) 
        {
			if (lst != null) {
				var itm = lst.FirstOrDefault(i => i.Value.IsCaseInsensitiveEqual(value));

				if (itm == null && defaultValue != null)
					itm = lst.FirstOrDefault(i => i.Value.IsCaseInsensitiveEqual(defaultValue));

				if (itm != null)
					itm.Selected = true;
			}
		}

        public static bool IsNullOrDefault<T>(this T? value) where T : struct
        {
            return default(T).Equals(value.GetValueOrDefault());
        }
    }	// class
}
