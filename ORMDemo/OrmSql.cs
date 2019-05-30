/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMDemo
*文件名： OrmSql
*创建人： Lxsh
*创建时间：2019/5/30 10:50:44
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/30 10:50:44
*修改人：Lxsh
*描述：
************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMDemo
{
    public class OrmSql
    {    
        public string GetAllSelectSQL<T>() where T :BaseModel
        {
           Type type = typeof(T);
           var props = type.GetProperties();   
           string columnString = string.Join(",", props.Select(m => $"[{m.GetMappingName()}]"));
           string SelectSQL = $"select  {columnString} from {type.GetMappingName()}"; 
           return SelectSQL;
        }
        public string GetSelectSQLByID<T>(T t)  where T :BaseModel
        {
            Type type = typeof(T);
            var props = type.GetProperties();
            string columnString = string.Join(",", props.Select(m => $"[{m.GetMappingName()}]"));
            string SelectSQL = $"select  {columnString}  from {type.GetMappingName()} where id= '{t.Id}'";
            return SelectSQL;
        }

    }
}