using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Core
{
    public class ContatoRepository:IDisposable
    {
        private readonly AgendaDataContext _ctx = new AgendaDataContext();

        public void Add(Contato contato) 
        {
            _ctx.Contatos.Add(contato);
            _ctx.SaveChanges();
        }

        public void Edit(Contato contato)
        {
            _ctx.Entry(contato).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }

        public IEnumerable<Contato> ObterTodos()
        {
            return _ctx.Contatos.ToList();
        }


        public void Dispose()
        {
            _ctx.Dispose();
        }

        public void Del(Contato contato)
        {
            //_ctx.Contatos.Remove(contato);
            _ctx.Entry(contato).State = System.Data.Entity.EntityState.Deleted;
            _ctx.SaveChanges();
        }

        public IEnumerable<Contato> Buscar(string nome, string email, string tel)
        {
            IQueryable<Contato> contatos = _ctx.Contatos;

            if (nome.Length > 0)
                contatos = contatos.Where(c=> c.Nome.Contains(nome));

            if (email.Length > 0)
                contatos = contatos.Where(c => c.Email.Contains(email));

            if (tel.Length > 0)
                contatos = contatos.Where(c => c.Telefone.Contains(tel));


            return contatos.ToList();
        }
    }
}
