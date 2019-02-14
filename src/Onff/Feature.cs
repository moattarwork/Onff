namespace Onff
{
    public class Feature
    {
        public Feature(string name, bool isEnabled)
        {
            Name = name;
            IsEnabled = isEnabled;
        }

        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}