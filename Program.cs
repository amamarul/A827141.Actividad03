using System;
using A827141.Actividad03.Helper;
using A827141.Actividad03.Model;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
namespace A827141.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            PlanCuentas planCuentas = new PlanCuentas();

            planCuentas.agregarMovimientos();
            planCuentas.generarMayor();
        }
    }
}
