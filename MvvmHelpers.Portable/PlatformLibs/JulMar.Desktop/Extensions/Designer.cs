﻿using System.ComponentModel;
using System.Windows;

namespace JulMar.Extensions
{
    /// <summary>
    /// Properties used to control the design surface details
    /// </summary>
    public static class Designer
    {
        /// <summary>
        /// Returns true/false whether the code is currently being executed by a designer surface
        /// (Blend or Visual Studio).
        /// </summary>
        public static bool InDesignMode
        {
            get
            {
                return ((bool) (DesignerProperties
                                   .IsInDesignModeProperty
                                   .GetMetadata(typeof (DependencyObject)).DefaultValue));
            }
        }
    }
}
