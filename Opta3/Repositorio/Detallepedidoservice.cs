/*using Opta3.Modelo;
using Opta3.Repositorio;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public class DetallePedidoService
    {
        private readonly DetallePedidoRepository _detallePedidoRepository;

        public DetallePedidoService(DetallePedidoRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
        }

        public void InsertarDetallePedido(Detallepedido detallePedido)
        {
            _detallePedidoRepository.InsertarDetallePedido(detallePedido);
        }

        public Detallepedido ObtenerDetallePedidoPorId(int id)
        {
            return _detallePedidoRepository.ObtenerDetallePedidoPorId(id);
        }

        public IEnumerable<Detallepedido> ObtenerTodosLosDetallePedidos()
        {
            return _detallePedidoRepository.ObtenerTodosLosDetallePedidos();
        }

        public void ActualizarDetallePedido(Detallepedido detallePedido)
        {
            _detallePedidoRepository.ActualizarDetallePedido(detallePedido);
        }

        public void EliminarDetallePedido(int id)
        {
            _detallePedidoRepository.EliminarDetallePedido(id);
        }
    }
}*/
/*using Opta3.Modelos;
using Repositorio;

namespace Servicios
{
    public class DetallePedidoService
    {
        private readonly DetallePedidoRepository _detallePedidoRepository;

        public DetallePedidoService(DetallePedidoRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
        }

        public void InsertarDetallePedido(Detallepedido detallePedido)
        {
            // Validaciones necesarias
            if (detallePedido.Cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a 0");
            }
            if (detallePedido.PrecioCompra <= 0)
            {
                throw new ArgumentException("El precio de compra debe ser mayor a 0");
            }

            _detallePedidoRepository.InsertarDetallePedido(detallePedido);
        }

        public DetallePedido ObtenerDetallePedidoPorId(int id)
        {
            return _detallePedidoRepository.ObtenerDetallePedidoPorId(id);
        }

        public IEnumerable<DetallePedido> ObtenerDetallesPorPedidoId(int pedidoId)
        {
            return _detallePedidoRepository.ObtenerDetallesPorPedidoId(pedidoId);
        }
    }
}*/
using System;
using System.Collections.Generic;
using Opta3.Modelo;
using Opta3.Repositorio;

namespace Opta3.Servicio
{
    public class DetallepedidoServicio
    {
        private readonly DetallepedidoRepositorio _repositorio;

        public DetallepedidoServicio(DetallepedidoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Insertar(Detallepedido detallepedido)
        {
            ValidarDetallepedido(detallepedido);
            _repositorio.Insertar(detallepedido);
        }

        public Detallepedido ObtenerPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }

        public IEnumerable<Detallepedido> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        public void Actualizar(Detallepedido detallepedido)
        {
            ValidarDetallepedido(detallepedido);
            _repositorio.Actualizar(detallepedido);
        }

        public void Eliminar(int id)
        {
            _repositorio.Eliminar(id);
        }

        private void ValidarDetallepedido(Detallepedido detallepedido)
        {
            if (detallepedido.Idpedido <= 0)
                throw new ArgumentException("Idpedido es obligatorio y debe ser un número positivo.");
            if (detallepedido.Idproducto <= 0)
                throw new ArgumentException("Idproducto es obligatorio y debe ser un número positivo.");
            if (detallepedido.Cantproducto <= 0)
                throw new ArgumentException("Cantproducto es obligatorio y debe ser un número positivo.");
            if (detallepedido.Subtotal <= 0)
                throw new ArgumentException("Subtotal es obligatorio y debe ser un número positivo.");
        }
    }
}



