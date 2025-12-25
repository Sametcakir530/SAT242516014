namespace SAT242516014.Filtering
{
    public class EditableAttribute(bool value) : Attribute
    {
        public bool Value { get; set; } = value;
    }
}
