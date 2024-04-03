using System;
using System.Collections.Generic;

namespace Gestione_Ferramenta.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string? Codice { get; set; }

    public string? Nome { get; set; }

    public string? Descrizione { get; set; }

    public decimal? Prezzo { get; set; }

    public int? Quantita { get; set; }

    public string? Categoria { get; set; }

    public DateOnly? DataCreazione { get; set; }
}
