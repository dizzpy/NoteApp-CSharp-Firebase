using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "");
            db = FirestoreDb.Create(projectId);
        }

        private string GenerateNoteID()
        {
            string timestamp = System.DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            string randomNumber = new Random().Next(1000, 9999).ToString();
            string NoteID ="Note" + timestamp + randomNumber;
            return NoteID;
        }

        private async void SaveNoteButton_Click(object sender, EventArgs e)
        {
            // Create a TaskItem object from the form's input fields
            NoteItem note = new NoteItem
            {
                TaskID = GenerateNoteID(),
                Title = NoteTitleText.Text,
                Note = NoteText.Text,
            };

            // Raise the AddTaskClicked event and pass the task data
            AddTaskClicked?.Invoke(this, note);

            // Create a dictionary to store the task data
            var noteData = new Dictionary<string, object>
            {
                { "noteID", note.TaskID },
                { "Title", note.Title },
                { "note", note.Note },
            };

            try
            {
                string taskID = GenerateNoteID();

                DocumentReference taskDocument = db.Collection("UserEmailAddrass").Document(note.TaskID);
                await taskDocument.SetAsync(noteData);

                MessageBox.Show("Task Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task: " + ex.Message);
            }

            // Close the form after adding the task
            this.Close();
        }
    }
}
