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

        public Form1()
        {
            InitializeComponent();
            InitializeFirestore();
            LoadNotesFromFirestore();
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

                    // Check if "Title" and "note" keys exist in noteData dictionary
                    if (noteData.ContainsKey("Title") && noteData.ContainsKey("note"))
                    {
                        NoteItem note = new NoteItem
                        {
                            NoteID = documentSnapshot.Id,
                            Title = noteData["Title"].ToString(),
                            Note = noteData["note"].ToString(),
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
                flowLayoutPanel1.Controls.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding note to UI: " + ex.Message);
            }
        }

        private async void Item_DeleteNote(object sender, NoteItem note)
        {
            try
            {
                // Remove the note from the notes list
                notes.Remove(note);

                // Remove the corresponding SingleNoteCard control from the flowLayoutPanel
                flowLayoutPanel1.Controls.Remove((SingleNoteCard)sender);

                // Delete the note document from Firestore
                await db.Collection("Notes").Document(note.NoteID).DeleteAsync();

                MessageBox.Show("Note deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting note: " + ex.Message);
            }
        }


        private void AddNoteWindow_AddTaskClicked(object sender, NoteItem note)
        {
            // Add the note to the notes list
            notes.Add(note);
            // Display the note on the form
            AddNoteToListView(note);
        }

        private void OpenAddNote_Click(object sender, EventArgs e)
        {
            using (var addNoteWindow = new AddNoteWindow())
            {
                addNoteWindow.AddTaskClicked += AddNoteWindow_AddTaskClicked;
                addNoteWindow.ShowDialog();
            }
        }
    }
}
