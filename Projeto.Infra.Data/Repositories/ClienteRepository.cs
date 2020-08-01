using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        //atributo
        private DataContext dataContext;

        //construtor para injeção de dependência
        public ClienteRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Cliente GetByEmail(string email)
        {
            return dataContext.Cliente.FirstOrDefault(c => c.Email.Equals(email));
        }

        public Cliente GetByCpf(string cpf)
        {
            return dataContext.Cliente.FirstOrDefault(c => c.Cpf.Equals(cpf));
        }

        public int CountDependentes(int idCliente)
        {
            return dataContext.Dependente.Count(d => d.ClienteId == idCliente);
        }
    }
}
