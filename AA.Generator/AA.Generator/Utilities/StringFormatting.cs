﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.Generator.Utilities
{
    internal static class StringFormatting
    {
        public static string AlignByCenter(this string str, int rowWidth)
        {
            var pad = (str.Length + rowWidth) / 2;
            return str.PadLeft(pad);
        }
    }
}
