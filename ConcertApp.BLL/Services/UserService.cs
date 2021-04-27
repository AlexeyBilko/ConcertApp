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
    public class UserService
    {
        IRepository<Users> userRepository;
        IMapper mapper;


        public UserService(IRepository<Users> repository)
        {
            MapperConfiguration config = new MapperConfiguration((x) =>
            {
                x.CreateMap<Users, UserDTO>();
                x.CreateMap<UserDTO, Users>();
                x.CreateMap<Tickets, TicketDTO>();
                x.CreateMap<TicketDTO, Tickets>();
            });
            mapper = new Mapper(config);

            userRepository = repository;
        }

        public UserDTO Get(int id)
        {
            Users u = userRepository.Get(id);
            return mapper.Map<Users, UserDTO>(u);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Users>, IEnumerable<UserDTO>>(userRepository.GetAll());
        }

        public UserDTO Delete(UserDTO userDTO)
        {
            Users userToRemove = userRepository.Get(userDTO.Id);
            userRepository.Delete(userToRemove);
            userRepository.SaveChanges();
            return userDTO;
        }

        public void CreateOrUpdate(UserDTO userDTO)
        {
            Users user = userRepository.Get(userDTO.Id);
            user = mapper.Map<UserDTO, Users>(userDTO);
            userRepository.CreateOrUpdate(user);
            userRepository.SaveChanges();
        }

        public UserDTO GetSameEmail(string email)
        {
            return GetAll().FirstOrDefault((user) => 
            { 
                return user.Email == email; 
            });
        }
    }
}
