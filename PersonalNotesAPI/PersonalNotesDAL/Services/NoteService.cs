using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PersonalNotesDAL.Data;
using PersonalNotesDAL.Entities;
using PersonalNotesDAL.Models;
using PersonalNotesDAL.Models.Note;
using PersonalNotesDAL.Repositories.Interface;
using PersonalNotesDAL.Services.Interface;
using PersonalNotesDAL.Uow.Interface;

namespace PersonalNotesDAL.Services
{
    public class NoteService : INoteService
    {
        private IGenericRepository<NoteEntity, int, NoteDBContext> _noteRepository;
        private IMapper _mapper;
        private IUowBase<NoteDBContext> _uow;

        public NoteService(
            IGenericRepository<NoteEntity, int, NoteDBContext> notesRepo,
            IUowBase<NoteDBContext> uow,
            IMapper mapper
            )
        {
            this._noteRepository = notesRepo;
            this._uow = uow;
            this._mapper = mapper;
        }

        public IEnumerable<IndexModel> GetNoteList()
        {
            var storedData = _noteRepository.GetAll();
            var result = _mapper.Map<IEnumerable<NoteEntity>, IEnumerable<IndexModel>>(storedData);
            return result;
        }

        public IEnumerable<FullModel> GetNoteListFullModel()
        {
            var storedData = _noteRepository.GetAll();
            var result = _mapper.Map<IEnumerable<NoteEntity>, IEnumerable<FullModel>>(storedData);
            return result;
        }

        public void AddNote(CreateModel note)
        {
            var entity = _mapper.Map<CreateModel, NoteEntity>(note);
            _noteRepository.Add(entity);
            _uow.SaveChanges();
        }

        public EditModel GetNoteForEdit(int id)
        {
            var storedData = _noteRepository.GetSingle(id);
            var result = _mapper.Map<NoteEntity, EditModel>(storedData);
            return result;
        }

        public void EditNote(EditModel data)
        {
            var storedData = _noteRepository.GetSingle(data.Id);
            storedData.Title = data.Title;
            storedData.Description = data.Description;
            storedData.Timestamp = data.Timestamp;
            _noteRepository.Edit(storedData);
            _uow.SaveChanges();
        }

        public bool CheckExisting(int id)
        {
            var result = _noteRepository.CheckExistingById(id);
            return result;
        }

        public void DeleteNote(int id)
        {
            var storedData = _noteRepository.GetSingle(id);
            storedData.Deleted = true;
            _noteRepository.Edit(storedData);
            _uow.SaveChanges();
        }
    }
}
