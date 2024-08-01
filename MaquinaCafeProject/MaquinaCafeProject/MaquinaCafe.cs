using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafeProject
{
    public class MaquinaCafe
    {
        public Cafetera cafe;
        private Vaso vasosPequenos;
        private Vaso vasosMedianos;
        private Vaso vasosGrandes;
        public Azucarero azucar;

        public MaquinaCafe(Cafetera cafe, Vaso pequeños, Vaso medianos, Vaso grandes, Azucarero azucar)
        {
            this.cafe = cafe;
            this.vasosPequenos = pequeños;
            this.vasosMedianos = medianos;
            this.vasosGrandes = grandes;
            this.azucar = azucar;
        }

        public Vaso GetTipoVaso(string tipoDeVaso)
        {
            return tipoDeVaso.ToLower() switch
            {
                "pequeño" => vasosPequenos,
                "mediano" => vasosMedianos,
                "grande" => vasosGrandes,
                _ => null
            };
        }

        public string GetVasoDeCafe(string tipoDeVaso, int cantidadDeVasos, int cantidadDeAzucar)
        {
            var vaso = GetTipoVaso(tipoDeVaso);

            if (vaso == null || !vaso.HasVasos(cantidadDeVasos))
            {
                return "Error: No hay vasos disponibles.";
            }
            if (!azucar.HasAzucar(cantidadDeAzucar))
            {
                return "Error: No hay azúcar disponible.";
            }
            if (!cafe.HasCafe(vaso.GetContenido()))
            {
                return "Error: No hay café disponible.";
            }

            vaso.GiveVasos(cantidadDeVasos);
            azucar.GiveAzucar(cantidadDeAzucar); // Verifica que este método esté reduciendo correctamente el azúcar
            cafe.GiveCafe(vaso.GetContenido());

            return "Café preparado con éxito.";
        }
    }
}
