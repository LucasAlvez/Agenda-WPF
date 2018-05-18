using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Core
{
    public class AgendaDataContext:DbContext
    {
        public AgendaDataContext():base("AgendaConn")
        {
            Database.SetInitializer(new DbInitializer());
        }


        public DbSet<Contato> Contatos { get; set; }
    }
}
