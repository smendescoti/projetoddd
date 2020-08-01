using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class DependenteRepository : BaseRepository<Dependente>, IDependenteRepository
    {
        //atributo
        private DataContext dataContext;

        //construtor para injeção de dependência
        public DependenteRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
