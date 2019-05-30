/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMDemo
*文件名： Donator
*创建人： Lxsh
*创建时间：2019/5/30 10:48:55
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/30 10:48:55
*修改人：Lxsh
*描述：
************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMDemo
{
          
   [Table("Donators")]
   public  class Donator:BaseModel
    {
           public string Name { get; set; }
           public string Amount { get; set; }
           public string DonateDate { get; set; }
    }
}