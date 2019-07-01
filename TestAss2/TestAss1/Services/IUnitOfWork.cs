using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Data;

namespace TestAss1.Services
{
    public interface IUnitOfWork
    {
        void Complete(); 
    }

    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
