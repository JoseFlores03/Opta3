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
using Opta3.Modelo;
using Opta3.Repositorio;
using System;
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
            // Validaciones antes de insertar
            ValidarCamposObligatorios(producto);
            ValidarCantidadMinima(producto);
            ValidarPreciosEnterosPositivos(producto);

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
            // Validaciones antes de actualizar
            ValidarCamposObligatorios(producto);
            ValidarCantidadMinima(producto);
            ValidarPreciosEnterosPositivos(producto);

            _productoRepository.ActualizarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            _productoRepository.EliminarProducto(id);
        }

        #region Validaciones

        private void ValidarCamposObligatorios(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(producto.Descripcion))
            {
                throw new ArgumentException("La descripción del producto es obligatoria.");
            }
            if (producto.Precio <= 0)
            {
                throw new ArgumentException("El precio del producto debe ser mayor que cero.");
            }
            if (producto.Stock < 0)
            {
                throw new ArgumentException("El stock del producto no puede ser negativo.");
            }
            if (producto.CantMinima <= 1)
            {
                throw new ArgumentException("La cantidad mínima del producto debe ser mayor que 1.");
            }
            if (producto.PrecioCompra < 0)
            {
                throw new ArgumentException("El precio de compra del producto no puede ser negativo.");
            }
            if (producto.PrecioVenta < 0)
            {
                throw new ArgumentException("El precio de venta del producto no puede ser negativo.");
            }
        }

        private void ValidarCantidadMinima(Producto producto)
        {
            if (producto.CantMinima <= 1)
            {
                throw new ArgumentException("La cantidad mínima del producto debe ser mayor que 1.");
            }
        }

        private void ValidarPreciosEnterosPositivos(Producto producto)
        {
            if (producto.PrecioCompra < 0 || !EsEnteroPositivo(producto.PrecioCompra))
            {
                throw new ArgumentException("El precio de compra del producto debe ser un número entero positivo.");
            }
            if (producto.PrecioVenta < 0 || !EsEnteroPositivo(producto.PrecioVenta))
            {
                throw new ArgumentException("El precio de venta del producto debe ser un número entero positivo.");
            }
        }

        private bool EsEnteroPositivo(decimal valor)
        {
            return Math.Floor(valor) == valor && valor > 0;
        }

        #endregion
    }
}

