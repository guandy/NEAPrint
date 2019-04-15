using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEAPrintDemo
{
    public class CommonResult
    {
        /// <summary>
        /// 1-success other-falid
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// true-成功 false-失败
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Message { get; set; }

        public object Data { get; set; }

        public int Total { get; set; }
    }
}
