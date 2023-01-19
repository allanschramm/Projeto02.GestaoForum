namespace Projeto02.GestaoForum.Models
{
    public class DbInitializer
    {
        public static void Initialize(ForumContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
