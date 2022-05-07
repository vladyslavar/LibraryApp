using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Entities;
using Models;

namespace Mappers
{
    public static class ReaderMapper
    {
        public static ReaderEntity ToEntity(this Reader reader)
        {
            return new ReaderEntity()
            {
                Id = reader.ID,
                Name = reader.Name,
                Surname = reader.Surname
            };
        }

        public static Reader ToDomain(this ReaderEntity reader)
        {
            return new Reader()
            {
                ID = reader.Id,
                Name = reader.Name,
                Surname = reader.Surname
            };
        }
        public static Reader ModelToDomain(this ReaderModel reader)
        {
            return new Reader()
            {
                ID = reader.ID,
                Name = reader.Name,
                Surname = reader.Surname
            };
        }
    }
}
