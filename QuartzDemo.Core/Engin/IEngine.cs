/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：QuartzDemo.Core
*文件名： IEngine
*创建人： Lxsh
*创建时间：2019/5/11 12:10:58
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/11 12:10:58
*修改人：Lxsh
*描述：
************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzDemo.Core
{
    public interface IEngine
    {
        /// <summary>
        /// 构建一个实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;
        /// <summary>
        /// 构建类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);
    }
}