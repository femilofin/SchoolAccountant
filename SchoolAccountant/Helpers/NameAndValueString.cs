namespace SchoolAccountant.Helpers
{
    internal class NameAndValueString
    {

        public NameAndValueString(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Value { get; set; }
        public string Name { get; set; }
    }
}


