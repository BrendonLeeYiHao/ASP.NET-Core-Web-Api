using Microsoft.EntityFrameworkCore;

public interface IUserService {

    Task<List<User>> GetAllUsers();
    Task<string> Register(User user);

    Task<string> UpdateUser(User user);

    Task<string> DeleteUser(int id);
}