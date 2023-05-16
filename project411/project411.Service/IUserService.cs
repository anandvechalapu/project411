using System;

namespace project411.Service
{
    public interface IUserService
    {
        void GetUserDetails(int userId);

        void UpdateUser(project411.DTO.User user);

        void DeleteUser(int userId);
    }
}