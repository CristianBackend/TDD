
using MaquinaCafeProject;

namespace MaquinaCafeTests1
{
    [TestClass]
    public class MaquinaCafeTests
    {
        private MaquinaCafe maquinaCafe;

        [TestInitialize]
        public void Setup()
        {
            
            var cafetera = new Cafetera();
            cafetera.SetCantidadDeCafe(100);

            var vasosPequenos = new Vaso();
            vasosPequenos.SetCantidadVasos(10);
            vasosPequenos.SetContenido(3);

            var vasosMedianos = new Vaso();
            vasosMedianos.SetCantidadVasos(10);
            vasosMedianos.SetContenido(5);

            var vasosGrandes = new Vaso();
            vasosGrandes.SetCantidadVasos(10);
            vasosGrandes.SetContenido(7);

            var azucarero = new Azucarero();
            azucarero.SetCantidadDeAzucar(20);

            maquinaCafe = new MaquinaCafe(cafetera, vasosPequenos, vasosMedianos, vasosGrandes, azucarero);
        }

        [TestMethod]
        public void SeleccionarVasoPequeno_DeberiaDevolver3OzDeCafe()
        {
           
            var vaso = maquinaCafe.GetTipoVaso("pequeño");

            
            Assert.AreEqual(3, vaso.GetContenido());
        }

        [TestMethod]
        public void SeleccionarVasoMediano_DeberiaDevolver5OzDeCafe()
        {
            
            var vaso = maquinaCafe.GetTipoVaso("mediano");

           
            Assert.AreEqual(5, vaso.GetContenido());
        }

        [TestMethod]
        public void SeleccionarVasoGrande_DeberiaDevolver7OzDeCafe()
        {
            
            var vaso = maquinaCafe.GetTipoVaso("grande");

          
            Assert.AreEqual(7, vaso.GetContenido());
        }

        [TestMethod]
        
        public void PrepararCafe_ConAzucarValida_DeberiaReducirCantidadDeAzucar()
        {
            
            int cantidadAzucarInicial = maquinaCafe.azucar.GetCantidadDeAzucar();
            int cantidadAzucarDeseada = 2;

            
            maquinaCafe.GetVasoDeCafe("mediano", 1, cantidadAzucarDeseada);

            
            int cantidadAzucarEsperada = cantidadAzucarInicial - cantidadAzucarDeseada;
            Assert.AreEqual(cantidadAzucarEsperada, maquinaCafe.azucar.GetCantidadDeAzucar(),
                $"Error: Se esperaba que la cantidad de azúcar fuera {cantidadAzucarEsperada}, pero fue {maquinaCafe.azucar.GetCantidadDeAzucar()}.");
        }


        [TestMethod]
        public void SinVasos_DeberiaMostrarMensajeError()
        {
           
            maquinaCafe.GetTipoVaso("pequeño").SetCantidadVasos(0);

           
            var mensaje = maquinaCafe.GetVasoDeCafe("pequeño", 1, 1);

            
            Assert.AreEqual("Error: No hay vasos disponibles.", mensaje);
        }

        [TestMethod]
        public void SinAzucar_DeberiaMostrarMensajeError()
        {
            
            maquinaCafe.azucar.SetCantidadDeAzucar(0);

            
            var mensaje = maquinaCafe.GetVasoDeCafe("pequeño", 1, 1);

            
            Assert.AreEqual("Error: No hay azúcar disponible.", mensaje);
        }

        [TestMethod]
        public void SinCafe_DeberiaMostrarMensajeError()
        {
            
            maquinaCafe.cafe.SetCantidadDeCafe(0);

          
            var mensaje = maquinaCafe.GetVasoDeCafe("pequeño", 1, 1);

            
            Assert.AreEqual("Error: No hay café disponible.", mensaje);
        }
    }
}
