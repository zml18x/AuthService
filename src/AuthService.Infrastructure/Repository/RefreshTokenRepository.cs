using Microsoft.EntityFrameworkCore;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Data.Context;

namespace AuthService.Infrastructure.Repository;

public class RefreshTokenRepository(AppDbContext context) : Repository<RefreshToken>(context), IRefreshTokenRepository
{
    private readonly AppDbContext _context = context;


    
    public async Task<RefreshToken?> GetByUserId(Guid userId)
        => await _context.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == userId);
}