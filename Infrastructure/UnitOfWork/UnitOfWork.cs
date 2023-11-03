
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly APIContext _context;
    private IDriver _driver;
    private ITeam _team;
    public UnitOfWork(APIContext context){
        _context = context;
    }
    public IDriver Drivers {
        get {
            _driver ??= new DriverRepository(_context);
            return _driver;
        }
    }
    public ITeam Teams {
        get {
            _team ??= new TeamRepository(_context);
            return _team;
        }
    }
    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}