using WebApplication1.Models.ValueTypes;

namespace WebApplication1.Models
{
    /// <summary>
    /// Dummy Class for testing De-/Serialization
    /// </summary>
    public class CustomOrder
    {
        /// <summary>
        /// Custom ValueType
        /// </summary>
        public OrderNumber Order { get; set; }

        /// <summary>
        /// Another value
        /// </summary>
        public string ComputerName { get; set; }
    }
}