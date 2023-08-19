using System;

namespace Airport_Ticket_Booking
{
    public partial class Manager
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class FlightFieldConstraintAttribute : Attribute
        {
            public string DataType { get; set; }
            public bool IsRequired { get; set; }
            public string AllowedRange { get; set; }

            public FlightFieldConstraintAttribute(string dataType, bool isRequired, string allowedRange = null)
            {
                DataType = dataType;
                IsRequired = isRequired;
                AllowedRange = allowedRange;
            }
        }
    }
}
