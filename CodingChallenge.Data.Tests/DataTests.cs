using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Interfaces;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        /// <summary>
        /// Utilizado para verificar que el texto sea igual a lo que retorne la funcion Imprimir
        /// </summary>
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica<Cuadrado>.Imprimir(new List<Cuadrado>()));
        }

        /// <summary>
        /// Utilizado para verificar que el texto sea igual a lo que retorne la funcion Imprimir pero configurando el idioma Ingles
        /// </summary>
        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            ResourceManager rm = new ResourceManager("CodingChallenge.Data.Resources.Idioma",
                                           typeof(Resources.Idioma).Assembly);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica<Cuadrado>.Imprimir(new List<Cuadrado>()));
        }

        /// <summary>
        /// Utilizado para verificar el resultado de la variable resumen, debiendo resultar igual al informe completo de la figura geometrica (Cuadrado)
        /// </summary>
        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5m) };

            var resumen = FormaGeometrica<IFormaGeometrica>.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 Figuras Perimetro 20 Area 25", resumen);
        }

        /// <summary>
        /// Utilizado para verificar el resultado de la variable resumen, debiendo resultar igual al informe completo de varias figuras geometricas iguales (Cuadrado)
        /// </summary>
        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            ResourceManager rm = new ResourceManager("CodingChallenge.Data.Resources.Idioma",
                                           typeof(Resources.Idioma).Assembly);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

            var cuadrados = new List<Cuadrado>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica<Cuadrado>.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            ResourceManager rm = new ResourceManager("CodingChallenge.Data.Resources.Idioma",
                                      typeof(Resources.Idioma).Assembly);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Triangulo(TipoTriangulo.Equilatero,4),
                new Cuadrado(2),
                new Triangulo(TipoTriangulo.Equilatero,9),
                new Circulo(2.75m),
                new Triangulo(TipoTriangulo.Equilatero,4.2m)
            };

            var resumen = FormaGeometrica<IFormaGeometrica>.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 Shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Triangulo(TipoTriangulo.Equilatero, 4),
                new Cuadrado(2),
                new Triangulo(TipoTriangulo.Equilatero, 9),
                new Circulo(2.75m),
                new Triangulo(TipoTriangulo.Equilatero, 4.2m)
            };

            var resumen = FormaGeometrica<IFormaGeometrica>.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 Figuras Perimetro 97,66 Area 91,65",
                resumen);
        }
        /// <summary>
        /// Utilizado para agregar una entidad (en este caso Cuadrado) a una lista, con la finalidad de verificar la sobrecarga del operador +
        /// </summary>
        [TestCase]
        public void AgregarCuadradoAlCarrito()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(3.5m),
            };
            var nuevoCuadrado = new Cuadrado(5m);

            var carrito = new Carrito(formas);
            bool seAgregoAlCarrito = carrito + nuevoCuadrado;

            Assert.IsTrue(seAgregoAlCarrito,"Se agrego a la lista");
        }
        /// <summary>
        /// Caso contrario al anterior, utilizamos esta funcion para probar que no se puede agregar cualquier tipo a la lista con la sobrecarga del operador +
        /// </summary>
        [TestCase]
        public void AgregarObjectoNoPermitido()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Triangulo(TipoTriangulo.Equilatero,4)
            };

            var carrito = new Carrito(formas);
            
            var funcion = new Funcion();
            bool seAgregoAlCarrito = carrito + funcion;

            Assert.IsFalse(seAgregoAlCarrito, "Deberia ser objeto permitido");
        }

        /// <summary>
        /// En este caso verificamos que el valor sea igual al calculado
        /// </summary>
        [TestCase]
        public void PerimetroTrapecio()
        {
            var trapecio = new Trapecio(5m, 3m, 3m, 4m);

            Assert.That(15m, Is.EqualTo(trapecio.CalcularPerimetro()));
        }

        /// <summary>
        /// Utilizado para verificar si el calculo del Area del Rectangulo es el esperado que se pasa por parametros
        /// </summary>
        /// <param name="ladoA">Lado A de un rectangulo</param>
        /// <param name="ladoB">Lado B de un rectangulo</param>
        /// <param name="esperado">Resultado esperado</param>
        [Test]
        [TestCase(10, 5, 50)]
        [TestCase(10, 4, 40)]
        [TestCase(8, 6, 48)]
        public void AreaRectangulo(decimal ladoA, decimal ladoB, decimal esperado)
        {
            Rectangulo rectangulo = new Rectangulo(ladoA,ladoB);
            decimal result = rectangulo.CalcularArea();
            Assert.AreEqual(esperado, result);
        }
        /// <summary>
        /// Valída si el string pasado por parametros es igual a resultado del método ObtenerNombre
        /// </summary>
        /// <param name="valorEsperado"></param>
        [TestCase("Forma Geométrica Rectangulo")]
        public void NombreDeFiguras(string valorEsperado)
        {
            Rectangulo rectangulo = new Rectangulo(4,5);
            var result = rectangulo.ObtenerNombre();
            Assert.AreEqual(valorEsperado, result);
        }
    }
}
