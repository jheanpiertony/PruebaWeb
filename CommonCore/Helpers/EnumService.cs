using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommonCore.Helpers
{
    public class EnumService
    {
        public List<SelectListItem> ToListSelectListItem<T>()
        {

            var t = typeof(T);
            if (!t.IsEnum) { throw new ApplicationException("Tipo debe ser enum"); }

            var members = t.GetFields(BindingFlags.Public | BindingFlags.Static);
            var result = new List<SelectListItem>();

            foreach (var member in members)
            {
                var attributeDescription = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                var descripcion = member.Name;

                if (attributeDescription.Any())
                {
                    descripcion = ((System.ComponentModel.DescriptionAttribute)attributeDescription[0]).Description;
                }

                var valor = ((int)Enum.Parse(t, member.Name));
                result.Add(new SelectListItem()
                {
                    Text = descripcion,
                    Value = valor.ToString()
                });
            }
            return result;
        }

        public List<SelectListItem> ToListSelectListItemEdit<T>( int itemSelected)
        {

            var t = typeof(T);
            if (!t.IsEnum) { throw new ApplicationException("Tipo debe ser enum"); }

            var members = t.GetFields(BindingFlags.Public | BindingFlags.Static);
            var result = new List<SelectListItem>();

            foreach (var member in members)
            {
                var attributeDescription = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                var descripcion = member.Name;

                if (attributeDescription.Any())
                {
                    descripcion = ((System.ComponentModel.DescriptionAttribute)attributeDescription[0]).Description;
                }

                var valor = ((int)Enum.Parse(t, member.Name));
                var selected = false;

                if (valor == itemSelected)
                {
                    selected = true;
                }

                result.Add(new SelectListItem()
                {
                    Text = descripcion,
                    Value = valor.ToString(),
                    Selected = selected
                });
            }
            return result;
        }

        public List<EnumEditar> ToListSelectListItemEditar<T>(int itemSelected)
        {
            var t = typeof(T);
            if (!t.IsEnum) { throw new ApplicationException("Tipo debe ser enum"); }

            var members = t.GetFields(BindingFlags.Public | BindingFlags.Static);
            var result = new List<EnumEditar>();

            foreach (var member in members)
            {
                var attributeDescription = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                var descripcion = member.Name;

                if (attributeDescription.Any())
                {
                    descripcion = ((System.ComponentModel.DescriptionAttribute)attributeDescription[0]).Description;
                }

                var valor = ((int)Enum.Parse(t, member.Name));
                var selected = false;

                if (valor == itemSelected)
                {
                    selected = true;
                }

                result.Add(new EnumEditar()
                {
                    Text = descripcion,
                    Value = valor,
                    Selected = selected
                });
            }
            return result;
        }

    }

    public class EnumEditar
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }
}