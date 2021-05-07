﻿using System;
using A827141.Actividad03.Helper;
using A827141.Actividad03.Model;

namespace A827141.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            LibroDiario libroDiario = new LibroDiario();
            PlanCuentas planCuentas = new PlanCuentas();

            CustomInput.IngresoAsientosContables(libroDiario, planCuentas);
            
            Console.WriteLine(libroDiario.generarLibroDiario());
        }
    }
}
