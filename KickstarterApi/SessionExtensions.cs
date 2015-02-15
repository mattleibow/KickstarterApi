namespace KickstarterApi
{
    using System.Threading.Tasks;

    public static class SessionExtensions
    {
        public static Task<TResult> Query<TResult>(this IKickstarterSession session, IQuery<TResult> results)
        {
            return results.ApplyTo(session);
        }
    }
}