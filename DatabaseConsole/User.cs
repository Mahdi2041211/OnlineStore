﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    public abstract class User : Database
    {
        /// <summary>
        /// مسار الصورة الشخصية للمستخدم
        /// </summary>
        string SelfiePath { get; set; }
    }
}
