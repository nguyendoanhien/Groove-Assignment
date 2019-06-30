using AutoMapper;
using PersonalNotesAPI.Entities;
using PersonalNotesAPI.Models.Note;
using PersonalNotesAPI.Repositories.Interface;
using PersonalNotesAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Services
{
    public class NoteService : INoteService
    {
        private INoteRepository _noteRepository;
        private IMapper _mapper;

        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public NoteEntity GetNoteById(int id)
        {
            var note = _noteRepository.GetNoteEntityById(id);
            return note;
        }
        public void AddNote(CreateNote note)
        {
            var newNote = _mapper.Map<CreateNote, NoteEntity>(note);
            _noteRepository.AddNote(newNote);
        }

        public void DeleteNote(int id)
        {
            var storedData = _noteRepository.GetNoteEntityById(id);
            storedData.Deleted = true;
            _noteRepository.UpdateNote(storedData);
        }

        public void UpdateNote(EditNote note)
        {
            var storedData = _noteRepository.GetNoteEntityById(note.Id);
            storedData.Title = note.Title;
            storedData.Description = note.Description;
            storedData.Timestamp = note.Timestamp;
            _noteRepository.UpdateNote(storedData);
        }


        public IEnumerable<IndexNote> GetNoteList()
        {
            var storedData = _noteRepository.Notes();
            var result = _mapper.Map<IEnumerable<NoteEntity>, IEnumerable<IndexNote>>(storedData);
            return result;
        }

        public IEnumerable<FullNote> GetNoteListFullModel()
        {
            var storedData = _noteRepository.Notes();
            var result = _mapper.Map<IEnumerable<NoteEntity>, IEnumerable<FullNote>>(storedData);
            return result;
        }

        public EditNote GetNoteForEdit(int id)
        {
            var storedData = _noteRepository.GetNoteEntityById(id);
            var result = _mapper.Map<NoteEntity, EditNote>(storedData);
            return result;
        }
    }
}
