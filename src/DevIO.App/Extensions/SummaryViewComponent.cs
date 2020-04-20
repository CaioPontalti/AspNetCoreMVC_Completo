using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        { 
            var notificacoes = await Task.FromResult(_notificador.ObterNotificaoes());

            foreach (var item in notificacoes)
            {
                ViewData.ModelState.AddModelError(string.Empty, item.Mensagem);
            }

            return View();
        }

    }
}
