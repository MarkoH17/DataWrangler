namespace DataWrangler.FormControls
{
    internal class TextValueItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}