namespace KickstarterApi
{
    using System.Threading.Tasks;

    public interface IKickstarterSession
    {
        Task<TResult> Get<TResult>(string path);
        Task<TResult> Post<TResult>(string path, object parameters);
    }
}