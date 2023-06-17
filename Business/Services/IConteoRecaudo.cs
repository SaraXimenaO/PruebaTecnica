using Application.Entities;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IConteoRecaudo
    {
         Task<Token> GetToken();
        Task<List<RecaudoDTO>> GetRecaudos(string Date, string token);
    }
}
