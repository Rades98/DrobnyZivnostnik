namespace DrobnyZivnostnik.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.User;

    public interface IUserService : IBaseService<UserModel>
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<UserModel> GetAsync();
    }
}
