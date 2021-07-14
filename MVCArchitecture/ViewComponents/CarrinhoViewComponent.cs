using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCArchitecture.ViewComponents
{
    [ViewComponent(Name = "Carrinho")]
    public class CarrinhoViewComponent : ViewComponent
    {
        // As propriedades em uma View Component, podem ser usadas para manipular e processar dados.
        public int ItensCarrinho { get; set; }

        public CarrinhoViewComponent()
        {
            ItensCarrinho = 3;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Após o processameto/captura de dados, pode ser enviado para ser renderizado.
            return View(ItensCarrinho);
        }
    }
}
