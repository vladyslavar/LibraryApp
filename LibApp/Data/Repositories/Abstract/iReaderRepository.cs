using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface iReaderRepository
    {
        void AddReader(ReaderEntity reader);
        void UpdateReader(ReaderEntity reader);
        void DeleteReader(int id);
        List<ReaderEntity> GetReader();
    }
}
