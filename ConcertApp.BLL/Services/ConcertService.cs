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
    public class ConcertService
    {
        IRepository<Concerts> concertRepository;
        IMapper mapper;


        public ConcertService(IRepository<Concerts> repository)
        {
            MapperConfiguration config = new MapperConfiguration((x) =>
            {
                x.CreateMap<Concerts, ConcertDTO>();
                x.CreateMap<ConcertDTO, Concerts>();
            });
            mapper = new Mapper(config);

            concertRepository = repository;
        }

        public ConcertDTO Get(int id)
        {
            Concerts c = concertRepository.Get(id);
            return mapper.Map<Concerts, ConcertDTO>(c);
        }

        public IEnumerable<ConcertDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Concerts>, IEnumerable<ConcertDTO>>(concertRepository.GetAll());
        }

        public ConcertDTO Delete(ConcertDTO concertDTO)
        {
            Concerts concertToRemove = concertRepository.Get(concertDTO.Id);
            concertRepository.Delete(concertToRemove);
            concertRepository.SaveChanges();
            return concertDTO;
        }

        public void CreateOrUpdate(ConcertDTO concertDTO)
        {
            Concerts concert = concertRepository.Get(concertDTO.Id);
            concert = mapper.Map<ConcertDTO, Concerts>(concertDTO);
            concertRepository.CreateOrUpdate(concert);
            concertRepository.SaveChanges();
        }
    }
}
