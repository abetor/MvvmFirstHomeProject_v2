﻿using System.Threading.Tasks;
using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data.Repositories
{
    public interface IMeetingRepository : IGenericRepository<Meeting>
    {
        Task<List<Friend>> GetAllFriendAsync();
        Task ReloadFriendAsync(int friendId);
    }
}