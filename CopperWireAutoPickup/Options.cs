
namespace Fyrefly.CopperWireAutoPickup
{
    public class Options
    {
        public static bool AutogetWire => XRL.UI.Options.GetOption("OptionAutogetWire").EqualsNoCase("Yes");

        public static int AutogetWireMinLength
        {
            get
            {
                if (int.TryParse(XRL.UI.Options.GetOption("OptionMinimumAutoPickupWireLength", "10"), out var result))
                {
                    return result;
                }
                return 10;
            }
        }
    }
}