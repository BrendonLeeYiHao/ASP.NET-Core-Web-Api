using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

public class UserService : IUserService {
    
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers() {
        return await _context.Users.OrderBy(user => user.Id).ToListAsync();
    }

    public async Task<string> Register(User user) {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return "Created Successfully!";
    }

    public async Task<string> UpdateUser(User user) {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser == null) {
            return null;
        }
        existingUser.Password = user.Password;
        existingUser.Email= user.Email;
        await _context.SaveChangesAsync();
        return "Update Successfully!";
    }

    public async Task<string> DeleteUser(int id) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) {
            return null;
        }
        _context.Users.Remove(user);
        return "Delete Successfully!";
    }
}
