using A827141.Actividad03.Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace A827141.Actividad03.Helper
{
    public class CustomInput
    {
        public static Cuenta IngresoCuentaContable(PlanCuentas planCuentas)
        {
            Cuenta cuenta;

            do
            {
                int codigoCuenta = Input.IngresoNumeroPositivo("Ingrese un código de la cuenta contable válido");
                cuenta = planCuentas.buscarCuenta(codigoCuenta);
            } while (!planCuentas.existeCuenta(cuenta));

            return cuenta;
        }

        public static TipoMovimiento IngresoTipoColumna()
        {
            return Input.IngresoVerdaderoFalso("¿Columna del debe?") ? TipoMovimiento.Debe : TipoMovimiento.Haber;
        }

        public static AsientoContable IngresoLineasAsiento(AsientoContable asientoContable, PlanCuentas planCuentas)
        {
            Console.WriteLine("\tIngrese las lineas del asiento");

            bool salida = false;

            do
            {
                Cuenta cuenta = CustomInput.IngresoCuentaContable(planCuentas);

                TipoMovimiento columa = CustomInput.IngresoTipoColumna();

                int importe = Input.IngresoNumeroPositivo("Ingrese el monto");

                if (asientoContable.Lineas.Count > 0)
                {
                    Console.WriteLine(asientoContable.reporte());
                }

                salida = Input.IngresoVerdaderoFalso("¿Desea finalizar la carga de lineas?");
                
                if (
                    asientoContable.balance() == 0 
                    && salida
                ) {
                    asientoContable.agregarLinea(
                        new LineaAsientoContable(cuenta, importe, columa)
                    );
                }
            } while (salida);

            return asientoContable;
        }

        public static LibroDiario IngresoAsientosContables(
            LibroDiario libroDiario,
            PlanCuentas planCuentas,
            string Mensaje = "Ingrese asiento contable"
        ) {
            Console.WriteLine("\n");
            
            bool salida = false;

            do
            {
                Console.WriteLine("\t" + Mensaje);

                int nroAsiento = libroDiario.ProximoNumeroAsiento;
                string fecha = Input.IngresoTexto("Ingrese la fecha del asiento a cargar. Formato dd/mm/aaaa");

                AsientoContable asientoContable = new AsientoContable(nroAsiento, fecha);

                CustomInput.IngresoLineasAsiento(asientoContable, planCuentas);

                salida = Input.IngresoVerdaderoFalso("¿Desea ingresar otro asiento?");

                if (salida)
                {
                    libroDiario.agregarAsientoContable(asientoContable);
                }
            } while (salida);

            return libroDiario;
        }
    }
}