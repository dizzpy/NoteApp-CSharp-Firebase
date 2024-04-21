using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class NoteItem
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public string TaskID { get; internal set; }

        public override string ToString()
        {
            return $"Title: {Title}, Note: {Note}";
        }
    }
}
