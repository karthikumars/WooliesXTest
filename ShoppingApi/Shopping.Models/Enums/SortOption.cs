using System.ComponentModel;

namespace Shopping.Models.Enums
{
    /// <summary>
    /// Product Sort Option
    /// </summary>
    public enum SortOption
    {
        [Description("Low to High Price")]
        Low = 0,

        [Description("High to Low Price")]
        High,

        [Description("Name A-Z")]
        Ascending,

        [Description("Name Z-A")]
        Descending,

        [Description("Recommended")]
        Recommended
    }
}