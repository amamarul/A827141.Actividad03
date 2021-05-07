using System.Collections.Generic;

namespace A827141.Actividad03.Model
{
    public class LibroDiario
    {
        private List<AsientoContable> _asientos = new List<AsientoContable> {};
        private int _ultimoNumeroAsiento = 0;
        private string _nombreArchivoSalida = "Diario.txt";

        public LibroDiario() {}

        public int ProximoNumeroAsiento
        {
            get => this._ultimoNumeroAsiento + 1;
        }

        public List<AsientoContable> Asientos
        {
            get => this._asientos;
        }

        public void agregarAsientoContable(AsientoContable asiento)
        {
            // TODO: validar consistencia
            this._asientos.Add(asiento);
        }

        public string generarLibroDiario()
        {
            string reporte = "Asiento|Fecha|CodigoCuenta|Debe|Haber\n";
            foreach (AsientoContable asiento in this._asientos)
            {
                foreach (LineaAsientoContable linea in asiento.Lineas)
                {
                    reporte += string.Format(
                        "{0}|{1}|{2}|{3}|{4} \n",
                        asiento.NroAsiento,
                        asiento.Fecha,
                        linea.Cuenta.Codigo,
                        linea.Columna == TipoMovimiento.Debe ? linea.Importe : "  ",
                        linea.Columna == TipoMovimiento.Haber ? linea.Importe : "  "
                    );
                }
                reporte += "-------------------";
            }

            return reporte;
        }

        public string guardarAsiento()
        {
            this.generarLibroDiario();
            this._ultimoNumeroAsiento++;
            //TODO: guardar archivo
            return "NroAsiento|Fecha|CodigoCuenta|Debe|Haber";
        }

        public string exportar()
        {
            this.generarLibroDiario();
            //TODO: guardar archivo
            return this._nombreArchivoSalida + "NroAsiento|Fecha|CodigoCuenta|Debe|Haber";
        }
    }
}