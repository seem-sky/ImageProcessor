﻿// <copyright file="Rational.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessorCore
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Represents a number that can be expressed as a fraction.
    /// </summary>
    /// <remarks>
    /// This is a very simplified implimentation of a rational number designed for use with metadata only.
    /// </remarks>
    public struct Rational : IEquatable<Rational>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rational"/> struct.
        /// </summary>
        ///<param name="value">The <see cref="double"/> to convert to an instance of this type.</param>
        public Rational(double value)
          : this(value, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rational"/> struct.
        /// </summary>
        ///<param name="value">The <see cref="double"/> to convert to an instance of this type.</param>
        ///<param name="bestPrecision">Specifies if the instance should be created with the best precision possible.</param>
        public Rational(double value, bool bestPrecision)
        {
            BigRational rational = new BigRational(Math.Abs(value), bestPrecision);

            Numerator = (uint)rational.Numerator;
            Denominator = (uint)rational.Denominator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rational"/> struct.
        /// </summary>
        /// <param name="value">The integer to create the rational from.</param>
        public Rational(uint value)
          : this(value, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rational"/> struct.
        /// </summary>
        /// <param name="numerator">The number above the line in a vulgar fraction showing how many of the parts indicated by the denominator are taken.</param>
        /// <param name="denominator">The number below the line in a vulgar fraction; a divisor.</param>
        public Rational(uint numerator, uint denominator)
          : this(numerator, denominator, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rational"/> struct.
        /// </summary>
        /// <param name="numerator">The number above the line in a vulgar fraction showing how many of the parts indicated by the denominator are taken.</param>
        /// <param name="denominator">The number below the line in a vulgar fraction; a divisor.</param>
        /// <param name="simplify">Specified if the rational should be simplified.</param>
        public Rational(uint numerator, uint denominator, bool simplify)
        {
            BigRational rational = new BigRational(numerator, denominator, simplify);

            Numerator = (uint)rational.Numerator;
            Denominator = (uint)rational.Denominator;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Rational"/> instances are considered equal.
        /// </summary>
        /// <param name="left">The first <see cref="Rational"/>  to compare.</param>
        /// <param name="right"> The second <see cref="Rational"/>  to compare.</param>
        /// <returns></returns>
        public static bool operator ==(Rational left, Rational right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Rational"/> instances are not considered equal.
        /// </summary>
        /// <param name="left">The first <see cref="Rational"/> to compare.</param>
        /// <param name="right"> The second <see cref="Rational"/> to compare.</param>
        /// <returns></returns>
        public static bool operator !=(Rational left, Rational right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Gets the numerator of a number.
        /// </summary>
        public uint Numerator
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the denominator of a number.
        /// </summary>
        public uint Denominator
        {
            get;
            private set;
        }

        ///<summary>
        /// Determines whether the specified <see cref="object"/> is equal to this <see cref="Rational"/>.
        ///</summary>
        ///<param name="obj">The <see cref="object"/> to compare this <see cref="Rational"/> with.</param>
        public override bool Equals(object obj)
        {
            if (obj is Rational)
                return Equals((Rational)obj);

            return false;
        }

        ///<summary>
        /// Determines whether the specified <see cref="Rational"/> is equal to this <see cref="Rational"/>.
        ///</summary>
        ///<param name="other">The <see cref="Rational"/> to compare this <see cref="Rational"/> with.</param>
        public bool Equals(Rational other)
        {
            BigRational left = new BigRational(Numerator, Denominator);
            BigRational right = new BigRational(other.Numerator, other.Denominator);

            return left.Equals(right);
        }

        ///<summary>
        /// Converts the specified <see cref="double"/> to an instance of this type.
        ///</summary>
        ///<param name="value">The <see cref="double"/> to convert to an instance of this type.</param>
        public static Rational FromDouble(double value)
        {
            return new Rational(value, false);
        }

        ///<summary>
        /// Converts the specified <see cref="double"/> to an instance of this type.
        ///</summary>
        ///<param name="value">The <see cref="double"/> to convert to an instance of this type.</param>
        ///<param name="bestPrecision">Specifies if the instance should be created with the best precision possible.</param>
        public static Rational FromDouble(double value, bool bestPrecision)
        {
            return new Rational(value, bestPrecision);
        }

        ///<summary>
        /// Serves as a hash of this type.
        ///</summary>
        public override int GetHashCode()
        {
            BigRational self = new BigRational(Numerator, Denominator);
            return self.GetHashCode();
        }

        /// <summary>
        /// Converts a rational number to the nearest <see cref="double"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double ToDouble()
        {
            return Numerator / (double)Denominator;
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        public override string ToString()
        {
            return ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using
        /// the specified culture-specific format information.
        /// </summary>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information. 
        /// </param>
        /// <returns></returns>
        public string ToString(IFormatProvider provider)
        {
            BigRational rational = new BigRational(Numerator, Denominator);
            return rational.ToString(provider);
        }
    }
}