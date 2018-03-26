using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrginizer.UI.Data.Lookups
{
    public class LookUpDataService : IFriendLookUpDataService, IProgrammingLanguageLookUpDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public LookUpDataService(Func<FriendOrganizerDbContext> contetCreator)
        {
            _contextCreator = contetCreator;
        }

        public async Task<IEnumerable<LookUpItem>> GetFriendLookUpAsync()
        {
            using (var _context = _contextCreator())
            {
                return await _context.Friends.AsNoTracking()
                    .Select(f =>
                    new LookUpItem
                    {
                        Id = f.Id,
                        DisplayMember = f.FirstName + " " + f.LastName
                    })
            .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookUpItem>> GetProgrammingLanguageLookUpAsync()
        {
            using (var _context = _contextCreator())
            {
                return await _context.ProgrammingLanguages.AsNoTracking()
                    .Select(f =>
                    new LookUpItem
                    {
                        Id = f.Id,
                        DisplayMember = f.Name
                    })
            .ToListAsync();
            }
        }
    }
}
