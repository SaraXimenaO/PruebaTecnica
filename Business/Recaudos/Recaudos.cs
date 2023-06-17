using Application.Services;
using AutoMapper;
using Domain;
using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recaudos
{
    public class Recaudos : IRecaudos
    {
        private readonly IConteoRecaudo _conteoRecaudo;
        private readonly ApplicationDbContext _context;

        public Recaudos(IConteoRecaudo conteoRecaudo, ApplicationDbContext context)
        {
            _conteoRecaudo = conteoRecaudo;
            _context = context;
        }
        public async Task<List<Recaudo>> GetRecaudos(string Date)
        {
            List<Recaudo> EntityRecaudos = new List<Recaudo>();
            var token = await _conteoRecaudo.GetToken();
            var RecaudosTemp = await _conteoRecaudo.GetRecaudos(Date, token.token);
            if (RecaudosTemp.Any())
            {
                _context.Recaudos.RemoveRange();
                EntityRecaudos.AddRange(from recaudo in RecaudosTemp
                                        let temp = new Recaudo(recaudo.estacion, recaudo.sentido, recaudo.hora, recaudo.categoria, recaudo.valorTabulado)
                                        select temp);
                _context.Recaudos.AddRange(EntityRecaudos);
                _context.SaveChanges();
            }

            return EntityRecaudos;
        }

        public async Task<List<RecaudoAgrupadoDTO>> GetReport()
        {
            return await _context.Recaudos
            .GroupBy(r => r.Estacion)
            .Select(g => new RecaudoAgrupadoDTO
            {
                Estacion = g.Key,
                valorCant = g.Count(),
                valorTotal = g.Sum(r => r.ValorTabulado)
            })
            .ToListAsync();

        }
    }
}
