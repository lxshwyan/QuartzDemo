/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：QuartzDemo.Core
*文件名： EnginContext
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
using System.Runtime.CompilerServices;
using System.Runtime;
using System.Text;

namespace QuartzDemo.Core
{
    public class EnginContext
    {
        private static IEngine _engine;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]    //多线程同时只能访问一次 
        public static IEngine Initialize(IEngine engine)
        {
            if (_engine == null)
                _engine = engine;
            return _engine;
        }

        /// <summary>
        /// 当前引擎
        /// </summary>
        public static IEngine Current
        {
            get
            {
                return _engine;
            }
        }
    }
}
