namespace nthAPIWeb.models;

using MongoDB.Driver;
using nthAPIWeb.models;
using Microsoft.Extensions.Options;

public class PlayerService
{
    private readonly IMongoCollection<Player> _players;

    public PlayerService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionURI"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _players = database.GetCollection<Player>(config["MongoDB:CollectionName"]);
    }

    public async Task<List<Player>> GetPlayersAsync() => 
        await _players.Find(player => true).ToListAsync();

    public async Task<Player?> GetPlayerAsync(string id) =>
        await _players.Find(player => player._id == id).FirstOrDefaultAsync();

    public async Task CreatePlayerAsync(Player player) =>
        await _players.InsertOneAsync(player);

    public async Task<bool> UpdatePlayerAsync(string id, Player player)
    {
        var result = await _players.ReplaceOneAsync(p => p._id == id, player);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeletePlayerAsync(string id)
    {
        var result = await _players.DeleteOneAsync(p => p._id == id);
        return result.DeletedCount > 0;
    }
}