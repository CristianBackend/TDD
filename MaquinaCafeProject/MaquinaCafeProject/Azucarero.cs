using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafeProject
{
    public class Azucarero
    {
        private int cantidadDeAzucar;

        public void SetCantidadDeAzucar(int cantidad)
        {
            cantidadDeAzucar = cantidad;
        }

        public int GetCantidadDeAzucar()
        {
            return cantidadDeAzucar;
        }

        public bool HasAzucar(int cantidad)
        {
            return cantidadDeAzucar >= cantidad;
        }

        public void GiveAzucar(int cantidad)
        {
            if (HasAzucar(cantidad))
            {
                cantidadDeAzucar -= cantidad;
            }
        }

    }
}
