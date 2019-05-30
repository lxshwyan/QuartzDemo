/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMDemo
*文件名： BaseAttribute
*创建人： Lxsh
*创建时间：2019/5/30 12:31:51
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/30 12:31:51
*修改人：Lxsh
*描述：
************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMDemo
{
   
   public class BaseAttribute:Attribute
    {
        private string _Name = "";
        public BaseAttribute(string name)
        {
            this._Name = name;
        }

        public virtual string GetName()
        {
            return this._Name;
        }
    }
}