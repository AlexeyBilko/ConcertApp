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
    public class CreditCardService
    {
        IRepository<CreditCards> cardRepository;
        IMapper mapper;


        public CreditCardService(IRepository<CreditCards> repository)
        {
            MapperConfiguration config = new MapperConfiguration((x) =>
            {
                x.CreateMap<CreditCards, CreditCardDTO>();
                x.CreateMap<CreditCardDTO, CreditCards>();
            });
            mapper = new Mapper(config);

            cardRepository = repository;
        }

        public CreditCardDTO Get(int id)
        {
            CreditCards c = cardRepository.Get(id);
            return mapper.Map<CreditCards, CreditCardDTO>(c);
        }

        public IEnumerable<CreditCardDTO> GetAll()
        {
            return mapper.Map<IEnumerable<CreditCards>, IEnumerable<CreditCardDTO>>(cardRepository.GetAll());
        }


        public CreditCardDTO Delete(CreditCardDTO cardDTO)
        {
            CreditCards cardToRemove = cardRepository.Get(cardDTO.Id);
            cardRepository.Delete(cardToRemove);
            cardRepository.SaveChanges();
            return cardDTO;
        }

        public void CreateOrUpdate(CreditCardDTO cardDTO)
        {
            CreditCards card = cardRepository.Get(cardDTO.Id);
            card = mapper.Map<CreditCardDTO, CreditCards>(cardDTO);
            cardRepository.CreateOrUpdate(card);
            cardRepository.SaveChanges();
        }
    }
}
