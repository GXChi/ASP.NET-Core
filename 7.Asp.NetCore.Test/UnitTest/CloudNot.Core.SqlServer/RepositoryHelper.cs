using CloudNote.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.CloudNot.Core.SqlServer
{
    public class RepositoryHelper
    {
        private static IUserRepository _userRepository;
        public RepositoryHelper(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }
        public static IUserRepository GetUserRepository()
        {
            return _userRepository;
        }
    }
}
