namespace SAT242516014.Filtering
{
    public class SortableAttribute(bool value) : Attribute
    {
        public bool Value { get; set; } = value;
    }
}
