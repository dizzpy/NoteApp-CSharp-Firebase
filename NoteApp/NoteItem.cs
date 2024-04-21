using Google.Cloud.Firestore;

namespace NoteApp
{
    [FirestoreData]
    public class NoteItem
    {
        [FirestoreProperty]
        public string Title { get; set; }

        [FirestoreProperty]
        public string Note { get; set; }

        [FirestoreProperty]
        public string NoteID { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Note: {Note}";
        }
    }
}
