using System;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class SingleNoteCard : UserControl
    {
        private NoteItem note;
        public event EventHandler<NoteItem> DeleteNote;
        public event EventHandler<NoteItem> EditNote;

        public NoteItem Note
        {
            get { return note; }
            set
            {
                note = value;
                InitializeTask();
            }
        }

        public SingleNoteCard(NoteItem noteItem)
        {
            InitializeComponent();
            Note = noteItem;
            NotePanel.Click += EditNote_Click;
        }

        private void EditNote_Click(object sender, EventArgs e)
        {
            OnEditNote();
        }

        protected virtual void OnEditNote()
        {
            EditNote?.Invoke(this, Note);
        }

        private void InitializeTask()
        {
            NoteTitle.Text = Note.Title;
            NoteDescription.Text = Note.Note;
        }

        private void NoteDeleteButton_Click(object sender, EventArgs e)
        {
            OnDeleteNote();
        }

        protected virtual void OnDeleteNote()
        {
            DeleteNote?.Invoke(this, Note);
        }
    }
}
