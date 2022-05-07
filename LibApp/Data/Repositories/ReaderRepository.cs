using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Abstract;
using Entities;
using DateBase;

namespace Data.Repositories
{
    public class ReaderRepository : iReaderRepository
    {
        private readonly MysqlDBContext _context;
        public ReaderRepository(MysqlDBContext context)
        {
            _context = context;
        }
        public void AddReader(ReaderEntity reader)
        {
            _context.Readers.Add(reader);
            _context.SaveChanges();
        }
        public List<ReaderEntity> GetReader()
        {
            return _context.Readers.ToList();
        }
        public void DeleteReader(int id)
        {
            _context.Readers.Remove(_context.Readers.Find(id));
            _context.SaveChanges();
        }

        public void UpdateReader(ReaderEntity reader)
        {
            _context.ChangeTracker.Clear();
            _context.Readers.Update(reader);
            _context.SaveChanges();
        }
    }
}
