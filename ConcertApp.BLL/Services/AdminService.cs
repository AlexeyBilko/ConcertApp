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
    public class AdminService
    {
        IRepository<Admins> adminRepository;
        IMapper mapper;


        public AdminService(IRepository<Admins> repository)
        {
            MapperConfiguration config = new MapperConfiguration((x) =>
            {
                x.CreateMap<Admins, AdminDTO>();
                x.CreateMap<AdminDTO, Admins>();
            });
            mapper = new Mapper(config);

            adminRepository = repository;
        }

        public AdminDTO Get(int id)
        {
            Admins a = adminRepository.Get(id);
            return mapper.Map<Admins, AdminDTO>(a);
        }

        public IEnumerable<AdminDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Admins>, IEnumerable<AdminDTO>>(adminRepository.GetAll());
        }

        public AdminDTO Delete(AdminDTO adminDTO)
        {
            Admins adminToRemove = adminRepository.Get(adminDTO.Id);
            adminRepository.Delete(adminToRemove);
            adminRepository.SaveChanges();
            return adminDTO;
        }

        public void CreateOrUpdate(AdminDTO adminDTO)
        {
            Admins admin = adminRepository.Get(adminDTO.Id);
            admin = mapper.Map<AdminDTO, Admins>(adminDTO);
            adminRepository.CreateOrUpdate(admin);
            adminRepository.SaveChanges();
        }
    }
}
