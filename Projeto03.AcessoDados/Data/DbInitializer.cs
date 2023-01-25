namespace Projeto03.AcessoDados.Data
{
    public class DbInitializer
    {
        public static void Initialize(ForumContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
