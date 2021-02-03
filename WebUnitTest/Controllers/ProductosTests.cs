using AutoMapper;
using CommonCore;
using CommonCore.Helpers;
using CommonCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Web.Controllers.Tests
{
    [TestClass]
    public class ProductosTests
    {
        private ApplicationDbContext ConstruirDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(@"Data Source = DESARROLLO-33\SQLEXPRESS; Initial Catalog = PruebaWebDB; Integrated Security = True; ").Options;

            var dbContext = new ApplicationDbContext(options);
            ////var dbContext = new ApplicationDbContext();
            return dbContext;
        }

        private ApplicationDbContext ConstruirDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName).Options;
            var dbContext = new ApplicationDbContext(options);
            return dbContext;
        }

        [TestMethod]
        public async Task CreateAsyncTest()
        {
            //Prepración -- Arrange (Arreglar, Organizar, Ordenar)
            Producto producto = new Producto()
            {
            };

            var contexto = new Mock<ApplicationDbContext>();
            var imagenHelper = new Mock<ImagenHelper>();
            var repositorio = new Mock<IRepositorio<Producto>>();
            var productoRepository = new Mock<IProductoRepository>();
            var mapper = new Mock<IMapper>();
            var aDORepositorio = new Mock<IADORepositorio>();
            var productoController = new ProductosController(contexto.Object, imagenHelper.Object, repositorio.Object,
                productoRepository.Object, mapper.Object, aDORepositorio.Object);


            //Prueba -- Act (Actuar, Acción)
            var resultado = await productoController.Create(producto);

            //Verifiación -- Assert (Afirmar, Asegurar, Hacer valer)
            Assert.IsNotNull(resultado);
        }

        [TestMethod()]
        public async Task EditTest()
        {
            //Prepración -- Arrange (Arreglar, Organizar, Ordenar)
            Producto producto = new Producto()
            {
                Id = 2,
                EstaBorrado = false,
                ImagenURL = string.Empty,
                NombreProducto = "Producto desde pruebas unitarias - EDITADO",
                Precio = 12500
            };

            var contexto = ConstruirDbContext();
            var imagenHelper = new Mock<ImagenHelper>();
            var repositorio = new Mock<IRepositorio<Producto>>();
            var productoRepository = new Mock<IProductoRepository>();
            var mapper = new Mock<IMapper>();
            var aDORepositorio = new Mock<IADORepositorio>();
            var productoController = new ProductosController(contexto, imagenHelper.Object, repositorio.Object,
                productoRepository.Object, mapper.Object, aDORepositorio.Object);


            //Prueba -- Act (Actuar, Acción)
            ActionResult resultado = await productoController.Edit(producto.Id, producto) as ActionResult;

            //Verifiación -- Assert (Afirmar, Asegurar, Hacer valer)
            Assert.IsNotNull(resultado);
        }

        [TestMethod()]
        public async Task DetailsTest1()
        {
            //Prepración -- Arrange (Arreglar, Organizar, Ordenar)
            Producto producto = new Producto()
            {
                Id = 1,
                EstaBorrado = false,
                ImagenURL = string.Empty,
                NombreProducto = "Producto desde pruebas unitarias",
                Precio = 12500
            };
            //var contexto = new Mock<ApplicationDbContext>();
            var contexto = ConstruirDbContext();
            var imagenHelper = new Mock<ImagenHelper>();
            var repositorio = new Mock<IRepositorio<Producto>>();
            var productoRepository = new Mock<IProductoRepository>();
            var mapper = new Mock<IMapper>();
            var aDORepositorio = new Mock<IADORepositorio>();
            var productoController = new ProductosController(contexto, imagenHelper.Object, repositorio.Object,
                productoRepository.Object, mapper.Object, aDORepositorio.Object);

            //Prueba -- Act (Actuar, Acción)
            var resultado = await productoController.Details(producto.Id);

            //Verifiación -- Assert (Afirmar, Asegurar, Hacer valer)
            Assert.IsNotNull(resultado);
        }

        [TestMethod()]
        public void DevuelveTrueTest()
        {
            Producto producto = new Producto()
            {
                Id = 1,
                EstaBorrado = false,
                ImagenURL = string.Empty,
                NombreProducto = "Producto desde pruebas unitarias",
                Precio = 12500
            };
            var contexto = new Mock<ApplicationDbContext>();
            //var contexto = ConstruirDbContext();
            var imagenHelper = new Mock<ImagenHelper>();
            var repositorio = new Mock<IRepositorio<Producto>>();
            var productoRepository = new Mock<IProductoRepository>();
            var mapper = new Mock<IMapper>();
            var aDORepositorio = new Mock<IADORepositorio>();
            var productoController = new ProductosController(contexto.Object, imagenHelper.Object, repositorio.Object,
                productoRepository.Object, mapper.Object, aDORepositorio.Object);

            //Prueba
            productoController.DevuelveFalse(1);

            // Assert
            Assert.Fail();
        }
    }
}
