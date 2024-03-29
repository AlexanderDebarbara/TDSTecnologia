﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TDSTecnologia.Site.Core.Dominio.Extensoes;

namespace System
{
    public static class ExtensionMethods
    {
        public static string Descricao(this Enum value)
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            EnumDescricao[] attrs = fieldInfo.
                GetCustomAttributes(typeof(EnumDescricao), false) as EnumDescricao[];
            if (attrs.Length > 0)
            {
                stringValue = attrs[0].Value;
            }
            return stringValue;
        }
    }
}