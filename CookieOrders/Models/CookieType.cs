using System.ComponentModel;

namespace CookieOrders.Models
{
    public enum CookieType
    {
        [Description("Thin Mints")]
        ThinMints,
        [Description("Caramel Delites")]
        CaramelDelites,
        [Description("Peanut Butter Patties")]
        PeanutButterPatties,
        [Description("S'Mores")]
        Smores,
        [Description("Lemonades")]
        Lemonades,
        [Description("Thanks-a-lots")]
        ThanksAlots,
        [Description("Shortbread")]
        Shortbread,
        [Description("Peanut Butter Sandwiches")]
        PeanutButterSandwiches,
        [Description("Gluten-free Trios")]
        GlutenFreeTrios
    }
}
