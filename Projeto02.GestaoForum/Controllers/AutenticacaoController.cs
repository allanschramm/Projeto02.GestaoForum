using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto02.GestaoForum.Models;

namespace Projeto02.GestaoForum.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AutenticacaoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            if(ModelState.IsValid)
            {
                // criando o usuario
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email= model.Email
                };
                // incluir o usuario
                var result = await userManager.CreateAsync(user, model.Senha);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
