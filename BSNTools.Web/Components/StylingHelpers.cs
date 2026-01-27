namespace BSNTools.Web.Components
{
    public class StylingHelpers
    {
        public static string ParseBoundingString(string boundingString)
        {
            // Implementation to parse bounding string like "0;0;0;0;px" into CSS style values

            var parts = boundingString.Split(";").ToList();

            var unit = parts.Last();

            parts.Remove(unit);

            return parts.Select(i => i + unit).Aggregate((a, b) => a + " " + b);
        }
    }
}
