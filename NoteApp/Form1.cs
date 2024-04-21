using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class Form1 : Form
    {
        private FirestoreDb db;
        private List<NoteItem> notes = new List<NoteItem>();
        private AddNoteWindow addNoteWindow;

        public Form1()
        {
            InitializeComponent();
            InitializeFirestore();
            LoadNotesFromFirestore();
            addNoteWindow = new AddNoteWindow();
            addNoteWindow.NoteUpdated += AddNoteWindow_NoteUpdated;
        }

        private void InitializeFirestore()
        {
            string projectId = "testnoteappdb";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\User\\Desktop\\Studee\\NoteApp\\NoteApp\\NoteCredFile.json");
            db = FirestoreDb.Create(projectId);
        }

        private async void LoadNotesFromFirestore()
        {
            try
            {
                CollectionReference noteCollection = db.Collection("Notes");
                QuerySnapshot querySnapshot = await noteCollection.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    Dictionary<string, object> noteData = documentSnapshot.ToDictionary();

                    if (noteData.ContainsKey("Title") && noteData.ContainsKey("Note"))
                    {
                        NoteItem note = new NoteItem
                        {
                            NoteID = documentSnapshot.Id,
                            Title = noteData["Title"].ToString(),
                            Note = noteData["Note"].ToString(),
                        };

                        notes.Add(note);
                        AddNoteToListView(note);
                    }
                    else
                    {
                        MessageBox.Show("Error: 'Title' or 'note' key is missing in the Firestore document.");
                    }
                }

                MessageBox.Show("Data loaded successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from Firestore: " + ex.Message);
            }
        }

        private void AddNoteToListView(NoteItem note)
        {
            try
            {
                SingleNoteCard item = new SingleNoteCard(note);
                item.DeleteNote += Item_DeleteNote;
                item.EditNote += Item_EditNote;
                flowLayoutPanel1.Controls.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding note to UI: " + ex.Message);
            }
        }

        private void AddNoteWindow_NoteUpdated(object sender, NoteItem note)
        {
            // Find and update the note in the UI
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is SingleNoteCard singleNoteCard && singleNoteCard.Note.NoteID == note.NoteID)
                {
                    singleNoteCard.Note = note; // Update the note in the SingleNoteCard control
                    break;
                }
            }
        }

        private async void Item_EditNote(object sender, NoteItem note)
        {
            using (var addNoteWindow = new AddNoteWindow(note))
            {
                addNoteWindow.ShowDialog();
            }
        }

        private async void Item_DeleteNote(object sender, NoteItem note)
        {
            try
            {
                SingleNoteCard cardToRemove = (SingleNoteCard)sender;
                notes.Remove(note);
                flowLayoutPanel1.Controls.Remove(cardToRemove);

                await db.Collection("Notes").Document(note.NoteID).DeleteAsync();

                MessageBox.Show("Note deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting note: " + ex.Message);
            }
        }

        private void OpenAddNoteWindow_Click(object sender, EventArgs e)
        {
            using (var addNoteWindow = new AddNoteWindow())
            {
                addNoteWindow.ShowDialog();
            }
        }
    }
}
