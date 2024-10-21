using FlightSystem.Domain.Entities;
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

        public async Task<bool> DeleteFlight(Guid Id)
        {
           var flight = await _dbContext.Flights.FindAsync(Id);
            if (flight == null)
            {
                return false;
            }
            _dbContext.Flights.Remove(flight);
            await _dbContext.SaveChangesAsync();
            return true;
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

        public async Task<Flight> UpdateFlight(Guid Id, Flight flight)
        {
            var flightId = await _dbContext.Flights.FindAsync(Id);
            if(flightId == null)
            {
                throw new ArgumentNullException("flight is null");
            }
            flightId.FlightNo = flight.FlightNo;
            flightId.Rotue = flight.Rotue;
            flightId.TimeFlight = flight.TimeFlight;
            flightId.Departure_Date = flight.Departure_Date;
            await _dbContext.SaveChangesAsync();
            return flightId;
        }
    }
}
