using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly HotelsManagementContext _context;

        public HotelsRepository(HotelsManagementContext context)
        {
            this._context = context;
        }

        public async Task Register(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Hotel>> Get(int id = 0, string? name = null)
        {
            return await _context.Hotels
                .Where(x => (id == 0 || x.Id == id) && (string.IsNullOrEmpty(name) || x.Name.Contains(name)))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Hotel> GetById(int id)
        {
            return await _context.Hotels.Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
