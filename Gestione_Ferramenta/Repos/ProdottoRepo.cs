using Gestione_Ferramenta.Models;

namespace Gestione_Ferramenta.Repos
{
    public class ProdottoRepo : IRepo<Prodotto>
    {
        private static ProdottoRepo? _instance;

        public static ProdottoRepo getInstance()
        {
            if (_instance == null)
                _instance = new ProdottoRepo();
            return _instance;
        }

        private ProdottoRepo() { }

        public bool delete(int id)
        {
            bool risultato = false;
            using (GestioneFerramentaContext ctx = new GestioneFerramentaContext())
            {
                try
                {
                    Prodotto prod = ctx.Prodottos.Single(c => c.ProdottoId == id);
                    ctx.Prodottos.Remove(prod);
                    ctx.SaveChanges();

                    risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }

        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = new List<Prodotto>();

            using (GestioneFerramentaContext ctx = new GestioneFerramentaContext())
            {
                elenco = ctx.Prodottos.ToList();
            }

            return elenco;
        }

        public Prodotto? GetById(int id)
        {
            Prodotto? prod = null;

            using (GestioneFerramentaContext ctx = new GestioneFerramentaContext())
                prod = ctx.Prodottos.FirstOrDefault(p => p.ProdottoId == id);

            return prod;
        }

        public bool insert(Prodotto t)
        {
            bool risultato = false;
            using (GestioneFerramentaContext ctx = new GestioneFerramentaContext())
            {
                try
                {
                    ctx.Prodottos.Add(t);
                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }

        public bool update(Prodotto t)
        {
            bool risultato = false;

            using (GestioneFerramentaContext ctx = new GestioneFerramentaContext())
            {
                try
                {
                    Prodotto temp = ctx.Prodottos.Single(p => p.Codice == t.Codice);

                    t.ProdottoId = temp.ProdottoId;
                    t.Nome = t.Nome is not null ? t.Nome : temp.Nome;                   
                    t.Descrizione = t.Descrizione is not null ? t.Descrizione : temp.Descrizione;
                    t.Prezzo = t.Prezzo == 0 ? temp.Prezzo : t.Prezzo;
                    t.Quantita = t.Quantita is null ? temp.Quantita : t.Quantita;
                    t.Categoria = t.Categoria is not null ? t.Categoria : temp.Categoria;

                    ctx.Entry(temp).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;

        }
        public Prodotto? GetByCodice(string codice)
        {
            Prodotto? prod = null;

            using (GestioneFerramentaContext ctx = new GestioneFerramentaContext())
                prod = ctx.Prodottos.FirstOrDefault(l => l.Codice == codice);

            return prod;
        }
    }

}
