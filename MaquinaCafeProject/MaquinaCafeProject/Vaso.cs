using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafeProject
{
    public class Vaso
    {
        private int cantidadVasos;
        private int contenido;

        public void SetCantidadVasos(int cantidad)
        {
            cantidadVasos = cantidad;
        }

        public int GetCantidadVasos()
        {
            return cantidadVasos;
        }

        public void SetContenido(int contenido)
        {
            this.contenido = contenido;
        }

        public int GetContenido()
        {
            return contenido;
        }

        public bool HasVasos(int cantidad)
        {
            return cantidadVasos >= cantidad;
        }

        public void GiveVasos(int cantidad)
        {
            if (HasVasos(cantidad))
            {
                cantidadVasos -= cantidad;
            }
        }
    }
}
