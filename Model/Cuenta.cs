using System.ComponentModel;
using System;
using System.Collections.Generic;
using A827141.Actividad03.Helper;
using A827141.Actividad03.Model;
using System.Linq;
namespace A827141.Actividad03.Model
{
    public class Cuenta
    {
        private int _codigo;
        private string _nombre;
        private string _tipo;
        private List<LineaAsientoContable> _movimientos = new List<LineaAsientoContable>{};

        public Cuenta(int codigo, string nombre, string tipo)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._tipo = tipo;
        }
        
        public int Codigo
        {
            get => this._codigo;
        }

        public string Nombre
        {
            get => this._nombre;
        }

        public string Tipo
        {
            get => this._tipo;
        }

        public List<LineaAsientoContable> Movimientos
        {
            get => this._movimientos;
        }


        public void agregarMovimiento(LineaAsientoContable linea)
        {
            this._movimientos.Add(linea);
        }

        public int calcularDebe()
        {
            int totDebe = 0;
            foreach (LineaAsientoContable movimiento in this._movimientos)
            {
                if (movimiento.Columna == TipoMovimiento.Debe)
                {
                    totDebe += movimiento.Importe;
                }
            }

            return totDebe;
        }

        public int calcularHaber()
        {
            int totHaber = 0;
            foreach (LineaAsientoContable movimiento in this._movimientos)
            {
                if (movimiento.Columna == TipoMovimiento.Haber)
                {
                    totHaber += movimiento.Importe;
                }
            }

            return totHaber;
        }
    }
}