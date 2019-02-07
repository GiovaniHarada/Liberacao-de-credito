using System;
using System.Collections.Generic;
using System.Text;

namespace LiberacaoCredito.Models
{
    class Credito
    {
        public Double Valor { get; set; }
        public int Tipo { get; set; }
        public int Parcelas { get; set; }
        public DateTime PrimeiroVencimento { get; set; }
        public bool? StatusAprovacao { get; set; }

        public Credito()
        {
            this.Valor = 0.0f;
            this.StatusAprovacao = null;
            this.Tipo = 0;
            this.Parcelas = 0;
            this.PrimeiroVencimento = DateTime.Now;
        }

        public void Parametrizar()
        {

            while(this.Valor == 0)
            {
                Console.Write("Valor do Credito: R$ ");
                string InputValorConsole = Console.ReadLine();
                bool ValorValido = Double.TryParse(InputValorConsole, out Double _Valor);
                this.Valor = (ValorValido) ? _Valor : 0;

                if (!ValorValido)
                    Console.WriteLine("!!! Por Favor, insira um numero valido !!!");
            }

            Console.WriteLine("--- Tipos de Credito ---");
            Console.WriteLine("- 1) Credito Direto");
            Console.WriteLine("- 2) Credito Consignado");
            Console.WriteLine("- 3) Credito Pessoa Juridica");
            Console.WriteLine("- 4) Credito Pessoa Fisica");
            Console.WriteLine("- 5) Credito Imobiliario\n");


            while (this.Tipo == 0)
            {
                Console.Write("\nEscolha a Modalidade do Credito: ");
                string InputConsole = Console.ReadLine();
                bool ValorValido = int.TryParse(InputConsole, out int _Valor);
                this.Tipo = (ValorValido) ? _Valor : 0;
                this.Tipo = (_Valor >= 1 && _Valor <= 5) ? _Valor : 0;

                if (!ValorValido)
                    Console.WriteLine("!!! Por Favor, insira uma operacao valida !!!");
            }

        }
    }
}
