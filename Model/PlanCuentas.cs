using System.ComponentModel;
using System;
using System.Collections.Generic;
using A827141.Actividad03.Helper;
using A827141.Actividad03.Model;
using System.Linq;

namespace A827141.Actividad03.Model
{
    public class PlanCuentas
    {
        private List<Cuenta> _cuentas = new List<Cuenta> {};

        public List<Cuenta> Cuentas
        {
            get => this._cuentas;
        }

        public PlanCuentas()
        {
            generarPlan();
        }

        public bool existeCuenta(Cuenta cuenta)
        {
            return this._cuentas.Contains(cuenta);
        }

        public Cuenta buscarCuenta(int numeroCuenta)
        {
            return this._cuentas
                    .FirstOrDefault(
                        cuenta => cuenta.Codigo == numeroCuenta
                    );
        }

        private void generarPlan()
        {
            string planDeCuentas = Document.ReadTextFromFile("plan-de-cuentas.txt");

            string[] lines = planDeCuentas.Split("\n");

            for (var i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split("|");
                this._cuentas.Add(
                    new Cuenta(Int32.Parse(line[0]), line[1], line[2])
                );
            }
        }

        public void agregarMovimientos()
        {
            string movimientosTxt = Document.ReadTextFromFile("Diario.txt");

            string[] lines = movimientosTxt.Split("\n");

            for (var i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split("|");

                Cuenta cuenta = this._cuentas.FirstOrDefault(
                    cuenta => cuenta.Codigo == Int32.Parse(line[2])
                );

                if (cuenta != null)
                {
                    cuenta.agregarMovimiento(
                        new LineaAsientoContable(
                            cuenta, 
                            (string) line[3] != "" ? Int32.Parse(line[3]) : Int32.Parse(line[4]), 
                            (string) line[3] != "" ? TipoMovimiento.Debe : TipoMovimiento.Haber
                        )
                    );
                } else {
                    throw new Exception("la cuenta no existe");
                }
            }
        }

        public void generarMayor()
        {
            Console.WriteLine(
                "Cuenta - " 
                + "Fecha - "
                + "Debe - " 
                + "Haber" 
            );

            foreach (Cuenta cuenta in this._cuentas)
            {
                Console.WriteLine(
                    cuenta.Codigo + " - " 
                    + DateTime.Now.ToString("dd/MM/yyyy") + " - "
                    + cuenta.calcularDebe() + " - " 
                    + cuenta.calcularHaber() 
                );                
            }
        }
    }
}