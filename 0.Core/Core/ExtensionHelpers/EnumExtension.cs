﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Core.ExtensionHelpers
{
    public static class EnumExtension
    {
        /// <summary>
        /// Code to retrieve the value in the Description attribute on an Enum member via reflection.
        /// Source: http://goo.gl/lzDJ4Z
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                        Attribute.GetCustomAttribute(field,
                            typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static T MapFromString<T>(string value) where T : struct, IConvertible
        {
            if (Enum.TryParse<T>(value, out T myEnum))
            {
                return myEnum;
            }
            else
            {
                throw new Exception($"Couldn't find the type {typeof(T).Name}");
            }
        }
    }
}
