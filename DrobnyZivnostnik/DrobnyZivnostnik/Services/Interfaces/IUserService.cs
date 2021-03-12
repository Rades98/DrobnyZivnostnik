namespace DrobnyZivnostnik.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.User;

    public interface IUserService
    {
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task AddAsync(UserModel model);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(Guid userId);

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<UserModel> GetByIdAsync(Guid userId);

        /// <summary>
        /// Gets the user list asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<UserListModel>> GetUserListAsync();

        /// <summary>
        /// Sets user active flag
        /// Active user is for managing data
        /// to show only data of currently active user
        /// Case application allows user to make several
        /// user accounts on one device
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task SetUserActive(Guid userId);
    }
}
