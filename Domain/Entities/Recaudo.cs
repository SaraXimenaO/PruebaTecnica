using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Recaudo
    {

        public Recaudo(string estacion, string sentido, int hora, string categoria, int valorTabulado)
        {
            Id = new Guid();
            Estacion = estacion;
            Sentido = sentido;
            Hora = hora;
            Categoria = categoria;
            ValorTabulado = valorTabulado;
        }
        public Guid Id { get; set; }
        public string Estacion { get; set; }
        public string Sentido { get; set; }
        public int Hora { get; set; }
        public string Categoria { get; set; }
        public int ValorTabulado { get; set; }
    }
}
