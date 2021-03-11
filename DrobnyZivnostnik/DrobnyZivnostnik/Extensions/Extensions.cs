namespace DrobnyZivnostnik.Extensions
{
    public static class Extensions
    {
        public static bool IsNotNull(this object o)
        {
            return (!(o is null));
        }
    }
}
