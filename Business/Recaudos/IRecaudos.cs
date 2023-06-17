using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recaudos
{
    public interface IRecaudos
    {
        Task<List<Recaudo>> GetRecaudos(string Date);
        Task<List<RecaudoAgrupadoDTO>> GetReport();
    }
}
