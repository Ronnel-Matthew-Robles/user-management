using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagementAPI.Configurations;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services;

public class UserService {
    private readonly IMongoCollection<User> _users;

    public UserService(IOptions<DatabaseSettings> databaseSettings) {
        // Initialize mongodb client
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

        // Connect to the MongoDb database
        var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        
        _users = mongoDb.GetCollection<User>(databaseSettings.Value.CollectionName);
    }

    public async Task<User> AddUserAsync(User user)
    {
        await _users.InsertOneAsync(user);
        return user;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _users.Find(user => true).ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(string id)
    {
        return await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User> UpdateUserAsync(string id, User updatedUser)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        var update = Builders<User>.Update
            .Set(u => u.Name, updatedUser.Name)
            .Set(u => u.Email, updatedUser.Email)
            .Set(u => u.PhoneNumber, updatedUser.PhoneNumber);

        await _users.UpdateOneAsync(filter, update);

        return updatedUser;
    }

    public async Task DeleteUserAsync(string id)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        await _users.DeleteOneAsync(filter);
    }

}