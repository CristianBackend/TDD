
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
            // Inicializaci�n de los componentes de la m�quina de caf�
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
            // Act
            var vaso = maquinaCafe.GetTipoVaso("peque�o");

            // Assert
            Assert.AreEqual(3, vaso.GetContenido());
        }

        [TestMethod]
        public void SeleccionarVasoMediano_DeberiaDevolver5OzDeCafe()
        {
            // Act
            var vaso = maquinaCafe.GetTipoVaso("mediano");

            // Assert
            Assert.AreEqual(5, vaso.GetContenido());
        }

        [TestMethod]
        public void SeleccionarVasoGrande_DeberiaDevolver7OzDeCafe()
        {
            // Act
            var vaso = maquinaCafe.GetTipoVaso("grande");

            // Assert
            Assert.AreEqual(7, vaso.GetContenido());
        }

        [TestMethod]
        
        public void PrepararCafe_ConAzucarValida_DeberiaReducirCantidadDeAzucar()
        {
            // Arrange
            int cantidadAzucarInicial = maquinaCafe.azucar.GetCantidadDeAzucar();
            int cantidadAzucarDeseada = 2;

            // Act
            maquinaCafe.GetVasoDeCafe("mediano", 1, cantidadAzucarDeseada);

            // Assert
            int cantidadAzucarEsperada = cantidadAzucarInicial - cantidadAzucarDeseada;
            Assert.AreEqual(cantidadAzucarEsperada, maquinaCafe.azucar.GetCantidadDeAzucar(),
                $"Error: Se esperaba que la cantidad de az�car fuera {cantidadAzucarEsperada}, pero fue {maquinaCafe.azucar.GetCantidadDeAzucar()}.");
        }


        [TestMethod]
        public void SinVasos_DeberiaMostrarMensajeError()
        {
            // Arrange
            maquinaCafe.GetTipoVaso("peque�o").SetCantidadVasos(0);

            // Act
            var mensaje = maquinaCafe.GetVasoDeCafe("peque�o", 1, 1);

            // Assert
            Assert.AreEqual("Error: No hay vasos disponibles.", mensaje);
        }

        [TestMethod]
        public void SinAzucar_DeberiaMostrarMensajeError()
        {
            // Arrange
            maquinaCafe.azucar.SetCantidadDeAzucar(0);

            // Act
            var mensaje = maquinaCafe.GetVasoDeCafe("peque�o", 1, 1);

            // Assert
            Assert.AreEqual("Error: No hay az�car disponible.", mensaje);
        }

        [TestMethod]
        public void SinCafe_DeberiaMostrarMensajeError()
        {
            // Arrange
            maquinaCafe.cafe.SetCantidadDeCafe(0);

            // Act
            var mensaje = maquinaCafe.GetVasoDeCafe("peque�o", 1, 1);

            // Assert
            Assert.AreEqual("Error: No hay caf� disponible.", mensaje);
        }
    }
}
