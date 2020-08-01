﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }

        #region Relacionamentos

        public List<Cliente> Clientes { get; set; }

        #endregion
    }
}
