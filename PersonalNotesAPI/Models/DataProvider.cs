using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public class DataProvider
    {
        public List<Notebook> NotebooksList;
        public List<Note> NoteList;


        public DataProvider()
        {
            NoteList = new List<Note>()
            {
                new Note()
                {
                    Id = 1,
                    Title = "mo",
                    Description = "haha",
                    Finished = true,
                    NotebookId = 2,
                    CreatedBy = "mo",
                    CreatedOn = DateTime.Parse("6/24/2019"),
                    UpdatedBy = "hoai luong",
                    UpdatedOn = DateTime.Parse("6/24/2019"),
                    Deleted = true,
                    Timestamp = null,
                },

            };
            NotebooksList = new List<Notebook>()
            {
                new Notebook()  {
                    Id = 1,Name="hong mo",ParentId=1,CreatedBy="hahah",CreatedOn=DateTime.Parse("6/24/2019"), UpdatedBy="nguyen",UpdatedOn=DateTime.Parse("6/24/2019"), },

                    new Notebook()  {
                    Id = 2,Name="thu ha",ParentId=1,CreatedBy="hahah",CreatedOn=DateTime.Parse("6/24/2019"), UpdatedBy="nguyen",UpdatedOn=DateTime.Parse("6/24/2019"), },
                        new Notebook()  {
                    Id = 3,Name="thu hue",ParentId=1,CreatedBy="hahah",CreatedOn=DateTime.Parse("6/24/2019"), UpdatedBy="nguyen",UpdatedOn=DateTime.Parse("6/24/2019"), },
                            new Notebook()  {
                    Id = 3,Name="thu nga",ParentId=1,CreatedBy="hahah",CreatedOn=DateTime.Parse("6/24/2019"), UpdatedBy="nguyen",UpdatedOn=DateTime.Parse("6/24/2019"), }
            };

           

        }

     
    }
}
