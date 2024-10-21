using Application.Documents.Commands.CreateDocumentCommand;
using Application.Documents.Commands.CreateGroupDocumentCommand;
using Application.DTOs;
using AutoMapper;
using FlightSystem.Domain.Entities;
using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flights.Commands.CreateFlightCommand
{
    public class CreateFlightCommandhandler : IRequestHandler<CreateFlightCommand, FlightDTO>
    {
        private readonly IFlightService _flightService;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateFlightCommandhandler(IFlightService flightService, IMapper mapper, IMediator mediator)
        {
            _flightService = flightService;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<FlightDTO> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = new Flight()
            {
                FlightNo = request.FlightNo,
                Rotue = request.Rotue,
                TimeFlight = request.TimeFlight,
                Departure_Date = request.Departure_Date
            };
            // create Flight và trả về giá trí 
            var result = await _flightService.CreateFilght(flight);
            // sau đó tạo document cho FlightId
           
           var resultDoc = await _mediator.Send(new CreateDocument
           {
               Document_Name = request.documentCommand.Document_Name,             
               Note = request.documentCommand.Note,
               Document_File = request.documentCommand.Document_File,
               Signature = request.documentCommand.Signature,
               Creator = request.documentCommand.Creator,
               FlightId = result.FlightId,// sử dụng Flight Id trả về
               TypeId = request.documentCommand.TypeId,
           });
            
            await _mediator.Send(new CreateGroupDocument
            {
                DocumentId = resultDoc.DocumentId,
                GroupId = request.documentCommand.GroupId,
            });
            
            return _mapper.Map<FlightDTO>(result);
        }
    }
}
