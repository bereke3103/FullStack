using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteListVM
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
