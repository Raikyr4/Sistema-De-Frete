﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Objeto
{
    public class Estado
    {
        public int Codigo { get; set; }    

        public string Nome { get; set; }

        public string Uf { get; set; }

        public float ICMSLocal { get; set; }
        
        public float ICMSExterno { get; set; }
    }
}
