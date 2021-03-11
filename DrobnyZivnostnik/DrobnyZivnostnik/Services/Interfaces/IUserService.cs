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
        /// Sets the user active.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task SetUserActive(Guid userId);
    }
}
