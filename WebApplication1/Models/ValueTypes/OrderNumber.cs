using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.ValueProviders.Providers;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WebApplication1.Models.ValueTypes
{
    /// <summary>
    /// Custom Value Type Implementation
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public struct OrderNumber : IEquatable<OrderNumber>
    {
        /// <summary>
        /// Actual value
        /// </summary>
        private string Value { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">OrderNumber value</param>
        public OrderNumber(string value)
        {
            value = value?.ToUpper();
            Value = null;


            if (!IsValid(value))
                throw new ArgumentException($"'{value}' is not a valid OrderNumber");

            Value = value;
        }

        /// <summary>
        /// Implicit operator
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator OrderNumber(string value) => new OrderNumber(value);

        /// <summary>
        /// Implicit operator to convert <see cref="OrderNumber"/> into <see cref="string"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator string(OrderNumber value) => value.Value;

        /// <summary>
        /// Operator override
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool operator ==(OrderNumber orderNumber, string value)
            => orderNumber.Value == value;

        /// <summary>
        /// Operator override
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool operator !=(OrderNumber orderNumber, string value)
            => orderNumber.Value != value;



        /// <summary>
        /// Validate the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsValid(string value)
        {
            Regex regEx = new Regex(@"^\w{1,5}$", RegexOptions.IgnoreCase);
            return regEx.IsMatch(value);
        }

        /// <summary>
        /// Object equals implementation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is OrderNumber number &&
                   number.Equals(number);
        }

        /// <summary>
        /// GetHashCode Implementation
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }

        /// <summary>
        /// Interface implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(OrderNumber other)
        {
            return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// ToString Method override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value;
        }
    }
}