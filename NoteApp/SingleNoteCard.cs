using System;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class SingleNoteCard : UserControl
    {
        private NoteItem note;
        public event EventHandler<NoteItem> DeleteNote;

        public SingleNoteCard(NoteItem noteItem)
        {
            InitializeComponent();
            note = noteItem;
            InitializeTask();
            NoteDeleteButton.Click += DeleteItemFromList_Click;
        }

        private void InitializeTask()
        {
            NoteTitle.Text = note.Title;
            NoteDescription.Text = note.Note;
        }

        private void DeleteItemFromList_Click(object sender, EventArgs e)
        {
            OnDeleteTask(note);
        }

        protected virtual void OnDeleteTask(NoteItem taskToDelete)
        {
            DeleteNote?.Invoke(this, taskToDelete);
        }
    }
}
