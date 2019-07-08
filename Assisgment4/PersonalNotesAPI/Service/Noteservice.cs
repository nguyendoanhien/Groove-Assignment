using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using PersonalNotesAPI.Entity;
using PersonalNotesAPI.Models.Notes;
using PersonalNotesAPI.Repositories.Interface;
using PersonalNotesAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Service
{
    public class Noteservice : INotesService
    {
        private INotesRepositories _notesRepositories;
         private IMapper _mapper;
        public Noteservice( INotesRepositories notesRepositories, IMapper mapper)
        {
            _notesRepositories = notesRepositories;
            _mapper = mapper;
        }
        public void AddNote(CreateModel note)
        {
            var entity = _mapper.Map<CreateModel, NotesEntity>(note);
            _notesRepositories.Add(entity);
           
        }

        public bool CheckExisting(int id)
        {
            var result = _notesRepositories.CheckExistingById(id);
            return result;
        }

        public void DeleteNote(int id)
        {
            var storedData = _notesRepositories.GetSingle(id);
            storedData.Deleted = true;
            _notesRepositories.Edit(storedData);
          
           
        }
        

        public void EditNote(EditModel data)
        {
            var storedData = _notesRepositories.GetSingle(data.Id);
            storedData.Title = data.Title;
            storedData.Description = data.Description;
            storedData.NotebookId = data.NotebookId;
            //var result = _mapper.Map<NotesEntity, EditModel>(storedData);

            _notesRepositories.Edit(storedData);
            
        }

        public EditModel GetNoteForEdit(int id)
        {
            var storedData = _notesRepositories.GetSingle(id);

            var result = _mapper.Map<NotesEntity, EditModel>(storedData);
            return result;
        }

        public IEnumerable<Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal.IndexModel> GetNoteList()
        {
            var storedData = _notesRepositories.GetAll();
            var result = _mapper.Map<IEnumerable<NotesEntity>, IEnumerable<Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal.IndexModel>>(storedData);
            return result;
        }

        public IEnumerable<FullModel> GetNoteListFullModel()
        {
            var storedData = _notesRepositories.GetAll();
            var result = _mapper.Map<IEnumerable<NotesEntity>, IEnumerable<FullModel>>(storedData);
            return result;
        }
    }
}
