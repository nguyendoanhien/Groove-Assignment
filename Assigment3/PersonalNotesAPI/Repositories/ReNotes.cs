using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.Controllers;
using PersonalNotesAPI.Data;
using PersonalNotesAPI.Entity;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Models.Notes;
using PersonalNotesAPI.Repositories.Interface;
using PersonalNotesAPI.Service;
using PersonalNotesAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Repositories
{
    public class ReNotes: INotesRepositories
    {
        private readonly IUserResolverService _UserResolverService;

        private readonly Datacontext _datacontext;
        public ReNotes(Datacontext datacontext, IUserResolverService UserResolverService)
        {
            _datacontext = datacontext;
            _UserResolverService = UserResolverService;


        }

        public void Add(BaseEntity entity)
        {
            _datacontext.Add(entity);
            _datacontext.SaveChanges();
        }

        public bool CheckExistingById(BaseEntity id)
        {
            var result = _datacontext.Notes.Any(x => x.Id.Equals(id));
            return result;
        }

        public bool CheckExistingById(int id)
        {
            var result = _datacontext.Notes.Any(x => x.Id.Equals(id));
            return result;
        }

        public void Delete(BaseEntity entityId)
        {
            var storedEntity = _datacontext.Notes.FirstOrDefault(x =>
                 x.Id.Equals(entityId) && (x.Deleted == null || !x.Deleted.Value) &&
                 x.CreatedBy == _UserResolverService.CurrentUserName());
            if (storedEntity == null) return;
            storedEntity.Deleted = true;
            _datacontext.Attach(storedEntity).State = EntityState.Modified;
        }

        public void Edit(BaseEntity entity)
        {
            var storedEntity =_datacontext.Attach(entity);
            storedEntity.State = EntityState.Modified;
            _datacontext.SaveChanges();
        }

        public IEnumerable<NotesEntity> GetAll()
        {
            return _datacontext.Notes;
            //return _datacontext.Notes.Where(x => (x.Deleted == null || !x.Deleted.Value) &&
            //                                       x.CreatedBy == _UserResolverService.CurrentUserName());
        }

        public NotesEntity GetSingle(int entityId)
        {
            return _datacontext.Notes.FirstOrDefault(x =>
                  x.Id.Equals(entityId) && (x.Deleted == null || !x.Deleted.Value) &&
                  x.CreatedBy == _UserResolverService.CurrentUserName());
        }
    }
    }
