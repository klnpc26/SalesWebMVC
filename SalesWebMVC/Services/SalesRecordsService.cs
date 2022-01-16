using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SalesRecordsService
    {
        private readonly SalesWebMVCContext _context;

        public SalesRecordsService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? dtStart, DateTime? dtEnd)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (dtStart.HasValue)
            {
                result = result.Where(x => x.Date >= dtStart.Value);
            }

            if (dtEnd.HasValue)
            {
                result = result.Where(x => x.Date >= dtEnd.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? dtStart, DateTime? dtEnd)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (dtStart.HasValue)
            {
                result = result.Where(x => x.Date >= dtStart.Value);
            }

            if (dtEnd.HasValue)
            {
                result = result.Where(x => x.Date >= dtEnd.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
