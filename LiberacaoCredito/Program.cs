﻿using System;
using LiberacaoCredito.Models;
using Newtonsoft.Json;

namespace LiberacaoCredito
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ContinuaExec = true;
            while (ContinuaExec)
            {
                Credito NovoCredito = new Credito();
                NovoCredito.Parametrizar();
                NovoCredito.Validar();

                Console.WriteLine();
                NovoCredito.Resultado();


            }
        }
    }
}
