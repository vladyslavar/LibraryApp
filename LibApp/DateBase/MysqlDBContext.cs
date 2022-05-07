using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;


namespace DateBase
{
    public class MysqlDBContext: DbContext
    {
        public MysqlDBContext(DbContextOptions<MysqlDBContext> options) : base(options)
        {
           
        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<ReaderEntity> Readers { get; set; }
    }
}

