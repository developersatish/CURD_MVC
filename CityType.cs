using System.ComponentModel;

namespace OnlyMvc.Infrastructure
{
    public enum CityType
    {
        [Description("Select City")]
        Select = 0,

        [Description("New Delhi")]
        NewDelhi = 1,

        [Description("Mumbai")]
        Mumbai = 2,

        [Description("Banglore")]
        Bangalore = 3,

        [Description("Buxar")]
        Buxar = 4,

        [Description("Jabalpur")]
        Jabalpur = 5
    }
}