using FlightSystem.Domain.Domain.Entities;
using FlightSystem.Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Flight> CreateFilght(Flight flight)
        {
          
            await _dbContext.AddAsync(flight);
            await _dbContext.SaveChangesAsync();
            return flight;
        }

        public async Task<List<Flight>> GetFlight()
        {
           var flight = await _dbContext.Flights.Include(f => f.Documents).ToListAsync();
            if(flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }
            return flight;
        }

        public async Task<Flight> GetFlightById(Guid Id)
        {
            var flight = await _dbContext.Flights.Include(f => f.Documents).FirstOrDefaultAsync(f => f.FlightId == Id);
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight), "flight is null");
            }
            return flight;
        }
    }
}
