using GenericApi.Model.Interfaces;
using GenericApi.Model.DataContext;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericApi.Model.Repositories
{
    public interface IUserRepository : IBaseRepository<User> { }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WorkShopDbContext context) : base(context)
        {
        }
    }
}
