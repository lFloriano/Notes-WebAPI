using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes_API.Models
{
    interface INoteRepository
    {
        List<Note> GetAll();
        Note Get(int id);
        int Add(Note note);
        bool Delete(int id);
        bool Update(Note note);
    }
}
