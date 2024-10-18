using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IFlightService
    {
        Task<Flight> CreateFilght(Flight flight);
        Task<List<Flight>> GetFlight();
        Task<Flight> GetFlightById(Guid Id);
    }
}
