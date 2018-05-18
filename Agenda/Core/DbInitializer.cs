using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Agenda.Core
{
    public class DbInitializer:CreateDatabaseIfNotExists<AgendaDataContext>
    {

        protected override void Seed(AgendaDataContext context)
        {
            context.Contatos.AddRange(new List<Contato>() { 
            
                new Contato(){Nome="Fabiano",Email="fabiano.nalin@gmail.com", Telefone="9999-9901"},
                new Contato(){Nome="Priscila",Email="priscila@gmail.com", Telefone="9999-9902"},
                new Contato(){Nome="Raphael",Email="raphael@gmail.com", Telefone="9999-9903"},
            
            
            });
            context.SaveChanges();
        }

    }
}
