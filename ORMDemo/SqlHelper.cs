/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMDemo
*文件名： SqlHelper
*创建人： Lxsh
*创建时间：2019/5/30 12:40:09
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/30 12:40:09
*修改人：Lxsh
*描述：
************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ORMDemo
{
    public class SqlHelper
    {
        string strConn = "连接字符串";
        public T Find<T>(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    Type type = typeof(T);
                    var props = type.GetProperties();
                    string columnString = string.Join(",", props.Select(m => $"[{m.GetMappingName()}]"));
                    string sql = $"SELECT {columnString} FROM [{type.GetMappingName()}] WHERE Id={id}";//表名映射
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        T t = (T)Activator.CreateInstance(type);
                        foreach (var prop in props)
                        {
                            //prop.SetValue(t, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                            prop.SetValue(t, reader[prop.GetMappingName()] is DBNull ? null : reader[prop.GetMappingName()]);
                        }
                        return t;

                    }
                    else
                    {
                        return default(T);
                    }

                }
            }
            catch (Exception)
            {

                return default(T);
            }
        }
    }
}