using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using appointmentControl.Backend.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace appointmentControl.Backend.Extender
{
    public static class MessageExtender
    {
        public static T DeSerializeObject<T>(this Message xMessage)
        {
            return JsonConvert.DeserializeObject<T>(xMessage.MessageInfo, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
        }

        public static T DeSerializeObject<T>(this String jsonParameter)
        {
            return JsonConvert.DeserializeObject<T>(jsonParameter, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
        }

        public static string SerializeObject<T>(this T inputObject)
        {
            var returnValue = new Message();
            CultureInfo culture = new CultureInfo("es-ES");
            var culture2 = CultureInfo.CurrentCulture;

            return JsonConvert.SerializeObject(inputObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
        }
        public static object DeSerializeObject(string value)
        {
            return JsonConvert.DeserializeObject(value);
        }

        /// <summary>
        /// Este metodo construye un DataTable apartir  de un IEnumerable
        /// </summary>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            var table = new DataTable();

            int i = 0;
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                table.Columns.Add(new DataColumn(prop.Name, prop.PropertyType));
                ++i;
            }

            foreach (var item in source)
            {
                var values = new object[i];
                i = 0;
                foreach (var prop in props)
                    values[i++] = prop.GetValue(item);
                table.Rows.Add(values);
            }

            return table;
        }
    }
}
