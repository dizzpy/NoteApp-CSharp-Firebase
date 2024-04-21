using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class AddNoteWindow : Form
    {
        private FirestoreDb db;
        public event EventHandler<NoteItem> AddTaskClicked;

        public AddNoteWindow()
        {
            InitializeComponent();
            InitializeFirestore();
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
            // Create a NoteItem object from the form's input fields
            NoteItem note = new NoteItem
            {
                NoteID = GenerateNoteID(),
                Title = NoteTitleText.Text,
                Note = NoteText.Text,
            };

            // Raise the AddTaskClicked event and pass the note data
            AddTaskClicked?.Invoke(this, note);

            // Create a dictionary to store the note data
            var noteData = new Dictionary<string, object>
            {
                { "noteID", note.NoteID },
                { "Title", note.Title },
                { "note", note.Note },
            };

            try
            {
                string noteID = GenerateNoteID();

                DocumentReference noteDocument = db.Collection("Notes").Document(note.NoteID);
                await noteDocument.SetAsync(noteData);

                MessageBox.Show("Note Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding note: " + ex.Message);
            }

            // Close the form after adding the note
            this.Close();
        }
    }
}
