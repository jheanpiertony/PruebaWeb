using System;
using System.ComponentModel;

namespace CommonCore.Helpers
{
    public static class ObtenerDescripcionEnum
    {
        public static string ObtenerDescripcion(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length == 0 ? value.ToString() : (attr[0] as DescriptionAttribute).Description;
        }
    }
}
