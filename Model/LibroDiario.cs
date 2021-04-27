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
            return "NroAsiento|Fecha|CodigoCuenta|Debe|Haber";
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