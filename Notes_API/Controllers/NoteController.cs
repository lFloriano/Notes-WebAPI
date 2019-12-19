using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Notes_API.Models;

namespace Notes_API.Controllers
{
    public class NoteController : ApiController
    {
        static readonly NoteRepository repository = new NoteRepository();

        public List<Note> GetAllNotes()
        {
            return repository.GetAll();
        }

        public Note GetNoteById(int id)
        {
            Note note = repository.Get(id);

            if (note == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return note;
        }

        public HttpResponseMessage PostNote(Note note)
        {
            //TODO: rever este metodo
            note.Id = repository.Add(note);
            var response = Request.CreateResponse<int>(HttpStatusCode.Created, note.Id);

            string uri = Url.Link("DefaultApi", new { id = note.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutNote(Note note)
        {
            if (!repository.Update(note))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteNote(int id)
        {
            Note note = repository.Get(id);

            if (note == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Delete(id);
        }
    }
}
