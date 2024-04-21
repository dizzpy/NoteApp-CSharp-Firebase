using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class AddNoteWindow : Form
    {
        private FirestoreDb db;
        private NoteItem noteToEdit;

        // Event handler delegate for note updated event
        public delegate void NoteUpdatedEventHandler(object sender, NoteItem note);

        // Event raised when a note is updated
        public event NoteUpdatedEventHandler NoteUpdated;

        public AddNoteWindow(NoteItem note = null)
        {
            InitializeComponent();
            InitializeFirestore();

            if (note != null)
            {
                noteToEdit = note;
                NoteTitleText.Text = note.Title;
                NoteText.Text = note.Note;
                SaveNoteButton.Text = "Save Changes";
            }
        }

        private void InitializeFirestore()
        {
            string projectId = "testnoteappdb";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\User\\Desktop\\Studee\\NoteApp\\NoteApp\\NoteCredFile.json");
            db = FirestoreDb.Create(projectId);
        }

        private string GenerateNoteID()
        {
            string timestamp = System.DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            string randomNumber = new Random().Next(1000, 9999).ToString();
            string NoteID = "Note" + timestamp + randomNumber;
            return NoteID;
        }

        private async void SaveNoteButton_Click(object sender, EventArgs e)
        {
            if (noteToEdit != null)
            {
                noteToEdit.Title = NoteTitleText.Text;
                noteToEdit.Note = NoteText.Text;

                DocumentReference noteDocument = db.Collection("Notes").Document(noteToEdit.NoteID);
                await noteDocument.SetAsync(noteToEdit, SetOptions.MergeAll);

                // Raise an event to notify the parent form to refresh the UI
                OnNoteUpdated(noteToEdit);
            }
            else
            {
                NoteItem note = new NoteItem
                {
                    NoteID = GenerateNoteID(),
                    Title = NoteTitleText.Text,
                    Note = NoteText.Text,
                };

                var noteData = new Dictionary<string, object>
                {
                    { "NoteID", note.NoteID },
                    { "Title", note.Title },
                    { "Note", note.Note },
                };

                try
                {
                    DocumentReference noteDocument = db.Collection("Notes").Document(note.NoteID);
                    await noteDocument.SetAsync(noteData);

                    MessageBox.Show("Note Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding note: " + ex.Message);
                }
            }

            this.Close();
        }

        // Method to raise the note updated event
        protected virtual void OnNoteUpdated(NoteItem note)
        {
            NoteUpdated?.Invoke(this, note);
        }
    }
}
