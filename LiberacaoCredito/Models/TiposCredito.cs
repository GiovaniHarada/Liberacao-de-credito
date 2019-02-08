using System;
using System.Collections.Generic;
using System.Text;

namespace LiberacaoCredito.Models
{
    static class TiposCredito
    {
        public static Double Direto { get { return 0.02f; } }
        public static Double Consignado { get { return 0.01f; } }
        public static Double Juridica { get { return 0.05f; } }
        public static Double Fisica { get { return 0.03f; } }
        public static Double Imobiliario { get { return 0.09f; } }
                      
        public static Double[] Taxas { get { return new Double[] { Direto, Consignado, Juridica, Fisica, Imobiliario }; } }
    }
}
