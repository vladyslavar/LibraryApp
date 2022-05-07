using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Abstract;
using Domain;
using Services.Abstract;
using Mappers;

namespace Services
{
    public class ReaderService : IReaderService
    {
        private readonly iReaderRepository _reader;
        public ReaderService(iReaderRepository reader)
        {
            _reader = reader;
        }
        public void AddReader(Reader reader)
        {
            _reader.AddReader(reader.ToEntity());
        }
        public Reader GetReader(string name, string surname)
        {
            return _reader.GetReader().Where(p => p.Name == name && p.Surname == surname).FirstOrDefault().ToDomain();
        }
        public void DeleteReader(int id)
        {
            _reader.DeleteReader(id);
        }
        public void UpdateReader(Reader reader)
        {
            _reader.UpdateReader(reader.ToEntity());
        }
    }
}
