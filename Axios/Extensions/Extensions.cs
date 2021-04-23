namespace Axios.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Determines whether [is not null].
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>
        ///   <c>true</c> if [is not null] [the specified o]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNull(this object o)
        {
            return (!(o is null));
        }
    }
}
