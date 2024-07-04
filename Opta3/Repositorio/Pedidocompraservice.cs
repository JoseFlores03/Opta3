/*using Opta3.Modelo;
using Opta3.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Servicios
{
    public class PedidoCompraService
    {
        private readonly PedidoCompraRepository _pedidoCompraRepository;
        private readonly DetallePedidoRepository _detallePedidoRepository;

        public PedidoCompraService(PedidoCompraRepository pedidoCompraRepository, DetallePedidoRepository detallePedidoRepository)
        {
            _pedidoCompraRepository = pedidoCompraRepository;
            _detallePedidoRepository = detallePedidoRepository;
        }

        public void InsertarPedidoCompra(Pedidocompra pedidoCompra)
        {
            ValidarPedidoCompra(pedidoCompra);
            pedidoCompra.Total = CalcularTotalPedido(pedidoCompra.Id);
            _pedidoCompraRepository.InsertarPedidoCompra(pedidoCompra);
        }

        public Pedidocompra ObtenerPedidoCompraPorId(int id)
        {
            return _pedidoCompraRepository.ObtenerPedidoCompraPorId(id);
        }

        public IEnumerable<Pedidocompra> ObtenerTodosLosPedidosCompra()
        {
            return _pedidoCompraRepository.ObtenerTodosLosPedidosCompra();
        }

        public void ActualizarPedidoCompra(Pedidocompra pedidoCompra)
        {
            ValidarPedidoCompra(pedidoCompra);
            pedidoCompra.Total = CalcularTotalPedido(pedidoCompra.Id);
            _pedidoCompraRepository.ActualizarPedidoCompra(pedidoCompra);
        }

        public void EliminarPedidoCompra(int id)
        {
            _pedidoCompraRepository.EliminarPedidoCompra(id);
        }

        private void ValidarPedidoCompra(Pedidocompra pedidoCompra)
        {
            if (pedidoCompra.Total <= 0)
            {
                throw new ArgumentException("El total del pedido debe ser mayor que cero.");
            }

            if (pedidoCompra.Fechahora == DateTime.MinValue)
            {
                throw new ArgumentException("La fecha y hora del pedido son obligatorias.");
            }
        }

        private decimal CalcularTotalPedido(int pedidoId)
        {
            var detalles = _detallePedidoRepository.ObtenerDetallesPorPedidoId(pedidoId);
            return detalles.Sum(d => d.PrecioCompra * d.Cantidad);
        }
    }
}*/
using System;
using Opta3.Modelo;
using Opta3.Repositorio;

namespace Opta3.Servicio
{
    public class PedidocompraServicio
    {
        private readonly PedidocompraRepositorio _repositorio;

        public PedidocompraServicio(PedidocompraRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Insertar(Pedidocompra pedidocompra)
        {
            ValidarPedidocompra(pedidocompra);
            _repositorio.Insertar(pedidocompra);
        }

        public Pedidocompra ObtenerPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }

        public IEnumerable<Pedidocompra> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        public void Actualizar(Pedidocompra pedidocompra)
        {
            ValidarPedidocompra(pedidocompra);
            _repositorio.Actualizar(pedidocompra);
        }

        public void Eliminar(int id)
        {
            _repositorio.Eliminar(id);
        }

        private void ValidarPedidocompra(Pedidocompra pedidocompra)
        {
            if (pedidocompra.Idproveedor <= 0)
                throw new ArgumentException("Idproveedor es obligatorio y debe ser un número positivo.");
            if (pedidocompra.Idsucursal <= 0)
                throw new ArgumentException("Idsucursal es obligatorio y debe ser un número positivo.");
            if (string.IsNullOrEmpty(pedidocompra.Fechahora))
                throw new ArgumentException("Fechahora es obligatorio.");
            if (pedidocompra.Total <= 0)
                throw new ArgumentException("Total es obligatorio y debe ser un número positivo.");
        }
    }
}


