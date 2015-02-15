namespace KickstarterApi
{
    using System.Threading.Tasks;

    public interface IQuery<TResult>
    {
        Task<TResult> ApplyTo(IKickstarterSession session);
    }
}