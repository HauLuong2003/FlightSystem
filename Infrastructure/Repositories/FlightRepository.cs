using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FlightRepository : IFlightService
    {
        private readonly FlightSystemDBContext _dbContext;
        public FlightRepository(FlightSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Flight> CreateFilght(Flight flight)
        {
            return null!;
        }
    }
}
