namespace BSNTools.Web.Components
{
    public class Styling
    {
        public string Width {  get; set; } = "100%";

        public string Height { get; set; } = "auto";

        public string Margin { get; set; } = "0;0;0;0;px";

        public string Padding { get; set; } = "0;0;0;0;px";

        public Styling()
        {
        }

        public override string ToString()
        {
            return $"width:{Width};height:{Height};margin:{StylingHelpers.ParseBoundingString(Margin)};padding:{StylingHelpers.ParseBoundingString(Padding)};";
        }
    }
}
