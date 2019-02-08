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
        public DateTime? PrimeiroVencimento { get; set; }
        public bool? StatusAprovacao { get; set; }

        public Double ValorFinalComJuros { get {
                if (Tipo == 5)
                    return Math.Round((Valor + Valor * ((Parcelas / 12) * TiposCredito.Taxas[Tipo-1])),2, MidpointRounding.AwayFromZero);

                

                return Math.Round((Valor + Valor * ((Parcelas) * TiposCredito.Taxas[Tipo-1])),2, MidpointRounding.AwayFromZero);
            } }

        public Credito()
        {
            this.Valor = 0.0f;
            this.StatusAprovacao = null;
            this.Tipo = 0;
            this.Parcelas = 0;
            this.PrimeiroVencimento = null;
        }

        public void Parametrizar()
        {

            while(this.Valor == 0)
            {
                Console.Write("\nValor do Credito: R$ ");
                string InputValorConsole = Console.ReadLine();
                InputValorConsole = InputValorConsole.Replace('.', ',');
                bool ValorValido = Double.TryParse(InputValorConsole, out Double _Valor);
                this.Valor = (ValorValido) ? _Valor : 0;

                if (!ValorValido)
                    Console.WriteLine("!!! Por Favor, insira um numero valido !!!");
            }

            Console.WriteLine("\n--- Tipos de Credito ---");
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

            while (this.Parcelas == 0)
            {
                Console.Write("Quantidade de Parcelas: ");
                string InputValorConsole = Console.ReadLine();
                bool ValorValido = int.TryParse(InputValorConsole, out int _Valor);
                this.Parcelas = (ValorValido) ? _Valor : 0;

                if (!ValorValido)
                    Console.WriteLine("!!! Por Favor, insira uma quantidade de parcelas válida !!!");
            }

            while (this.PrimeiroVencimento == null)
            {
                Console.Write("Data do primeiro vencimento (ex 28/5/2019): ");
                string InputValorConsole = Console.ReadLine();



                bool ValorValido = DateTime.TryParse(InputValorConsole, out DateTime _Valor);

                this.PrimeiroVencimento = (ValorValido) ? _Valor : this.PrimeiroVencimento;

                if (!ValorValido)
                    Console.WriteLine("!!! Por Favor, insira uma quantidade de parcelas válida !!!");
            }

        }
        public bool Validar()
        {
            bool Valid = true;

            Valid = (this.Valor < 1000000.00) ? Valid : false;
            Valid = (this.Parcelas >= 5 && this.Parcelas <= 72) ? Valid : false;

            if (this.Tipo == 3)
                Valid = (this.Valor >= 15000.00) ? Valid : false;

            Valid = (this.PrimeiroVencimento >= DateTime.Now.AddDays(5) && this.PrimeiroVencimento <= DateTime.Now.AddDays(40)) ? Valid : false;

            this.StatusAprovacao = Valid;

            return Valid;
        }
        public void Resultado()
        {
            string status = (bool)this.StatusAprovacao ? "APROVADO" : "REPROVADO";
            Console.WriteLine("+-----------------------------------");
            Console.WriteLine("+--- Resultado Crédito");
            Console.WriteLine("+-----------------------------------");
            Console.WriteLine("+- Status: {0} ",status);
            Console.WriteLine("+- Valor Total: {0}", ValorFinalComJuros.ToString("c2"));
            Console.WriteLine("+- Valor Juros: {0}", (ValorFinalComJuros-Valor).ToString("c2"));
            Console.WriteLine("+-----------------------------------\n");

        }
    }
}
