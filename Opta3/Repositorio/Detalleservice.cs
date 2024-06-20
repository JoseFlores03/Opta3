using Opta3.Modelo;
using Opta3.Repositorio;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public class DetallefacturaService
    {
        private readonly DetallefacturaRepository _detallefacturaRepository;

        public DetallefacturaService(DetallefacturaRepository detallefacturaRepository)
        {
            _detallefacturaRepository = detallefacturaRepository;
        }

        public void InsertarDetallefactura(Detallefactura detallefactura)
        {
            _detallefacturaRepository.InsertarDetallefactura(detallefactura);
        }

        public Detallefactura ObtenerDetallefacturaPorId(int id)
        {
            return _detallefacturaRepository.ObtenerDetallefacturaPorId(id);
        }

        public IEnumerable<Detallefactura> ObtenerTodosLosDetallefacturas()
        {
            return _detallefacturaRepository.ObtenerTodosLosDetallefacturas();
        }

        public void ActualizarDetallefactura(Detallefactura detallefactura)
        {
            _detallefacturaRepository.ActualizarDetallefactura(detallefactura);
        }

        public void EliminarDetallefactura(int id)
        {
            _detallefacturaRepository.EliminarDetallefactura(id);
        }
    }
}
