/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMDemo
*文件名： TableAttribute
*创建人： Lxsh
*创建时间：2019/5/30 10:44:35
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/30 10:44:35
*修改人：Lxsh
*描述：
************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMDemo
{
    [AttributeUsage(AttributeTargets.Class )]
   public  class TableAttribute  :BaseAttribute
    {
     
        public TableAttribute(string tableName):base(tableName)
        {
           
        }
      

    }
}