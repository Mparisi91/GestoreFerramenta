using Gestione_Ferramenta.Models;
using Gestione_Ferramenta.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Gestione_Ferramenta.Controllers
{
    [ApiController]
    [Route("api/prodotti")]

    public class ProdottoController : Controller
    {
        [HttpGet]
        public IActionResult ElencoProdotti()          //https://localhost:7126/api/prodotti
        {
            return Ok(ProdottoRepo.getInstance().GetAll());
        }

        [HttpGet("{valCodice}")]
        public IActionResult DettaglioProdotto(string valCodice)
        {
            Prodotto? prod = ProdottoRepo.getInstance().GetByCodice(valCodice);
            if (prod is not null)
                return Ok(prod);

            return NotFound();
        }

        [HttpPost]
        public IActionResult InserisciProdotto(Prodotto objProd)
        {
            if (ProdottoRepo.getInstance().insert(objProd))
                return Ok();

            return BadRequest();
        }
        private IActionResult EliminaProdotto(int varId)
        {
            if (ProdottoRepo.getInstance().delete(varId))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("codice/{varCodice}"), HttpPost("codice/{varCodice}")]
        public IActionResult EliminaPerCodiceProdotto(string varCodice)
        {
            Prodotto? prod = ProdottoRepo.getInstance().GetByCodice(varCodice);
            if (prod is null)
                return BadRequest();

            return EliminaProdotto(prod.ProdottoId);
        }

        [HttpPut]
        public IActionResult ModificaProdotto(Prodotto objProd)
        {
            if (ProdottoRepo.getInstance().update(objProd))
                return Ok();

            return BadRequest();
        }
      
    }
}
