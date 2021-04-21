using AutoMapper;
using ConcertApp.BLL.DTO;
using ConcertApp.DAL.Context;
using ConcertApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.BLL.Services
{
    public class TicketService
    {
        IRepository<Tickets> ticketRepository;
        IMapper mapper;


        public TicketService(IRepository<Tickets> repository)
        {
            MapperConfiguration config = new MapperConfiguration((x) =>
            {
                x.CreateMap<Tickets, TicketDTO>();
                x.CreateMap<TicketDTO, Tickets>();
            });
            mapper = new Mapper(config);

            ticketRepository = repository;
        }

        public TicketDTO Get(int id)
        {
            Tickets t = ticketRepository.Get(id);
            return mapper.Map<Tickets, TicketDTO>(t);
        }

        public IEnumerable<TicketDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Tickets>, IEnumerable<TicketDTO>>(ticketRepository.GetAll());
        }

        public TicketDTO Delete(TicketDTO ticketDTO)
        {
            Tickets ticketToRemove = ticketRepository.Get(ticketDTO.Id);
            ticketRepository.Delete(ticketToRemove);
            ticketRepository.SaveChanges();
            return ticketDTO;
        }

        public void CreateOrUpdate(TicketDTO ticketDTO)
        {
            Tickets ticket = ticketRepository.Get(ticketDTO.Id);
            ticket = mapper.Map<TicketDTO, Tickets>(ticketDTO);
            ticketRepository.CreateOrUpdate(ticket);
            ticketRepository.SaveChanges();
        }
    }
}
