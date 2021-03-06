﻿using FriendOrganizer.Model;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
    public interface IProgrammingLanguageRepository : IGenericRepository<ProgrammingLanguage>
    {
        Task<bool> IsReferenceByFriendAsync(int programmingLanguageId);
    }
}