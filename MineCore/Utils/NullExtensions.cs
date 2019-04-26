﻿using System;

namespace MineCore.Utils
{
    public static class NullExtensions
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static void ThrownOnArgNull(this object value, string fieldName)
        {
            if (value.IsNull())
                throw new ArgumentNullException();
        }
    }
}