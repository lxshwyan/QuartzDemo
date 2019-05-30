/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMDemo
*文件名： DBAttributeExtend
*创建人： Lxsh
*创建时间：2019/5/30 11:58:34
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/30 11:58:34
*修改人：Lxsh
*描述：
************************************************************************/
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ORMDemo
{
    public static class DBAttributeExtend
    {
        public static string GetMappingName<T>(this T t) where T : BaseModel
        {
            if (t.GetType().IsDefined(typeof(TableAttribute), true))
            {
                TableAttribute attribute = (TableAttribute)t.GetType().GetCustomAttributes(typeof(TableAttribute), true)[0];
                return attribute.GetName();
            }
            else
            {
                return t.GetType().Name;
            }


        }

        public static string GetMappingName(this Type type)
        {
            if (type.IsDefined(typeof(TableAttribute), true))
            {
                TableAttribute attribute = (TableAttribute)type.GetCustomAttribute(typeof(TableAttribute), true);
                return attribute.GetName();
            }
            else
            {
                return type.Name;
            }
        }
        public static string GetMappingName(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(ColumnAttribute), true))
            {
                ColumnAttribute attribute = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute), true);
                return attribute.GetName();
            }
            else
            {
                return prop.Name;
            }
        }
    }
}