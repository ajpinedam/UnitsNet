﻿// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Rotational speed (sometimes called speed of revolution) is the number of complete rotations, revolutions, cycles, or turns per time unit. Rotational speed is a cyclic frequency, measured in radians per second or in hertz in the SI System by scientists, or in revolutions per minute (rpm or min-1) or revolutions per second in everyday life. The symbol for rotational speed is ω (the Greek lowercase letter "omega").
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct RotationalSpeed : IComparable, IComparable<RotationalSpeed>
    {
        /// <summary>
        ///     Base unit of RotationalSpeed.
        /// </summary>
        private readonly double _revolutionsPerSecond;

        public RotationalSpeed(double revolutionspersecond) : this()
        {
            _revolutionsPerSecond = revolutionspersecond;
        }

        #region Properties

        /// <summary>
        ///     Get RotationalSpeed in RevolutionsPerMinute.
        /// </summary>
        public double RevolutionsPerMinute
        {
            get { return _revolutionsPerSecond*60; }
        }

        /// <summary>
        ///     Get RotationalSpeed in RevolutionsPerSecond.
        /// </summary>
        public double RevolutionsPerSecond
        {
            get { return _revolutionsPerSecond; }
        }

        #endregion

        #region Static 

        public static RotationalSpeed Zero
        {
            get { return new RotationalSpeed(); }
        }

        /// <summary>
        ///     Get RotationalSpeed from RevolutionsPerMinute.
        /// </summary>
        public static RotationalSpeed FromRevolutionsPerMinute(double revolutionsperminute)
        {
            return new RotationalSpeed(revolutionsperminute/60);
        }

        /// <summary>
        ///     Get RotationalSpeed from RevolutionsPerSecond.
        /// </summary>
        public static RotationalSpeed FromRevolutionsPerSecond(double revolutionspersecond)
        {
            return new RotationalSpeed(revolutionspersecond);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RotationalSpeedUnit" /> to <see cref="RotationalSpeed" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>RotationalSpeed unit value.</returns>
        public static RotationalSpeed From(double value, RotationalSpeedUnit fromUnit)
        {
            switch (fromUnit)
            {
                case RotationalSpeedUnit.RevolutionPerMinute:
                    return FromRevolutionsPerMinute(value);
                case RotationalSpeedUnit.RevolutionPerSecond:
                    return FromRevolutionsPerSecond(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(RotationalSpeedUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static RotationalSpeed operator -(RotationalSpeed right)
        {
            return new RotationalSpeed(-right._revolutionsPerSecond);
        }

        public static RotationalSpeed operator +(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left._revolutionsPerSecond + right._revolutionsPerSecond);
        }

        public static RotationalSpeed operator -(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left._revolutionsPerSecond - right._revolutionsPerSecond);
        }

        public static RotationalSpeed operator *(double left, RotationalSpeed right)
        {
            return new RotationalSpeed(left*right._revolutionsPerSecond);
        }

        public static RotationalSpeed operator *(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left._revolutionsPerSecond*(double)right);
        }

        public static RotationalSpeed operator /(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left._revolutionsPerSecond/(double)right);
        }

        public static double operator /(RotationalSpeed left, RotationalSpeed right)
        {
            return Convert.ToDouble(left._revolutionsPerSecond/right._revolutionsPerSecond);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is RotationalSpeed)) throw new ArgumentException("Expected type RotationalSpeed.", "obj");
            return CompareTo((RotationalSpeed) obj);
        }

        public int CompareTo(RotationalSpeed other)
        {
            return _revolutionsPerSecond.CompareTo(other._revolutionsPerSecond);
        }

        public static bool operator <=(RotationalSpeed left, RotationalSpeed right)
        {
            return left._revolutionsPerSecond <= right._revolutionsPerSecond;
        }

        public static bool operator >=(RotationalSpeed left, RotationalSpeed right)
        {
            return left._revolutionsPerSecond >= right._revolutionsPerSecond;
        }

        public static bool operator <(RotationalSpeed left, RotationalSpeed right)
        {
            return left._revolutionsPerSecond < right._revolutionsPerSecond;
        }

        public static bool operator >(RotationalSpeed left, RotationalSpeed right)
        {
            return left._revolutionsPerSecond > right._revolutionsPerSecond;
        }

        public static bool operator ==(RotationalSpeed left, RotationalSpeed right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._revolutionsPerSecond == right._revolutionsPerSecond;
        }

        public static bool operator !=(RotationalSpeed left, RotationalSpeed right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._revolutionsPerSecond != right._revolutionsPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _revolutionsPerSecond.Equals(((RotationalSpeed) obj)._revolutionsPerSecond);
        }

        public override int GetHashCode()
        {
            return _revolutionsPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(RotationalSpeedUnit unit)
        {
            switch (unit)
            {
                case RotationalSpeedUnit.RevolutionPerMinute:
                    return RevolutionsPerMinute;
                case RotationalSpeedUnit.RevolutionPerSecond:
                    return RevolutionsPerSecond;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(RotationalSpeedUnit.RevolutionPerSecond);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
		/// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(RotationalSpeedUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
        {
            return ToString(unit, culture, UnitFormatter.GetFormat(As(unit), significantDigitsAfterRadix));
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(RotationalSpeedUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
