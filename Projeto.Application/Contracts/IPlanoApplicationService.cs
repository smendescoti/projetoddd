using Projeto.Application.Models;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IPlanoApplicationService
    {
        void Insert(PlanoCadastroModel model);
        void Update(PlanoEdicaoModel model);
        void Delete(int id);
        List<Plano> GetAll();
        Plano GetById(int id);
    }
}
