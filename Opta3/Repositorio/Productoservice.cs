/*using Opta3.Modelo;
using Opta3.Repositorio;
using System.Collections.Generic;

namespace Servicios
{
    public class ProductoService
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public void InsertarProducto(Producto producto)
        {
            _productoRepository.InsertarProducto(producto);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return _productoRepository.ObtenerProductoPorId(id);
        }

        public IEnumerable<Producto> ObtenerTodosLosProductos()
        {
            return _productoRepository.ObtenerTodosLosProductos();
        }

        public void ActualizarProducto(Producto producto)
        {
            _productoRepository.ActualizarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            _productoRepository.EliminarProducto(id);
        }
    }
}*/
using System;
using Opta3.Modelo;
using Opta3.Repositorio;

namespace Opta3.Servicio
{
    public class ProductoServicio
    {
        private readonly ProductoRepository _repositorio;

        public ProductoServicio(ProductoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public void Insertar(Producto producto)
        {
            ValidarProducto(producto);
            _repositorio.InsertarProducto(producto);
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _repositorio.ObtenerTodosLosProductos();
        }

        public void Actualizar(Producto producto)
        {
            ValidarProducto(producto);
            _repositorio.ActualizarProducto(producto);
        }

        public void Eliminar(int id)
        {
            _repositorio.EliminarProducto(id);
        }

        private void ValidarProducto(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Descripcion) || producto.Descripcion.Length < 3)
                throw new ArgumentException("Descripcion es obligatorio y debe tener al menos 3 caracteres.");
            if (string.IsNullOrEmpty(producto.Categoria) || producto.Categoria.Length < 3)
                throw new ArgumentException("Categoria es obligatorio y debe tener al menos 3 caracteres.");
            if (producto.Preciocompra <= 0)
                throw new ArgumentException("Preciocompra es obligatorio y debe ser un número positivo.");
            if (string.IsNullOrEmpty(producto.Precioventa) || !decimal.TryParse(producto.Precioventa, out _))
                throw new ArgumentException("Precioventa es obligatorio y debe ser un número válido.");
            if (string.IsNullOrEmpty(producto.Estado) || producto.Estado.Length < 3)
                throw new ArgumentException("Estado es obligatorio y debe tener al menos 3 caracteres.");
        }
    }
}

