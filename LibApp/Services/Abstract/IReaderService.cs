using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.Abstract
{
    public interface IReaderService
    {
        void AddReader(Reader reader);
        void UpdateReader(Reader reader);
        void DeleteReader(int id);
        Reader GetReader(string name, string surname);
    }
}
