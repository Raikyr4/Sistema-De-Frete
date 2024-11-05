﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objeto
{
    public class PessoaJuridica : Cliente
    {
        public string RazaoSocial { get; set; }

        public string InscricaoEstadual { get; set; }

        public string CNPJ { get; set; }

        public bool EhRepresentante { get; set; }
    }
}