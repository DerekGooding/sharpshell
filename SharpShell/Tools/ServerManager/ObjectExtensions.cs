﻿using System.ComponentModel;
using System.Linq;

namespace ServerManager
{
    public static class ObjectExtensions
    {
        public static string GetDescription(this object @this)
        {
            var attributes = @this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (!attributes.Any())
                return null;
            return attributes.OfType<DescriptionAttribute>().First().Description;
        }
    }
}