namespace NoteApp
{
    public class NoteItem
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public string NoteID { get; internal set; }

        public override string ToString()
        {
            return $"Title: {Title}, Note: {Note}";
        }
    }
}
