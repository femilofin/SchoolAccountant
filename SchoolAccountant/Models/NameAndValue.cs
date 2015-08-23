namespace SchoolAccountant.Models
{
    public class NameAndValue
    {
        public NameAndValue(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public int Value { get; set; }
        public string Name { get; set; }
    }
}