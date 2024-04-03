const stampaTabella = () => {
    $.ajax(
        {
            url: "https://localhost:7126/api/prodotti",
            type: "GET",
            success: function(risultato){
                let contenuto = "";

                for(let [idx, item] of risultato.entries()){
                    contenuto += `
                        <tr>
                            <td>${item.nome}</td>
                            <td>${item.descrizione}</td>
                            <td>${item.prezzo}</td>
                            <td>${item.quantita}</td>
                            <td>${item.categoria}</td>
                            <td>
                                <button class="btn btn-danger" onclick="elimina('${item.codice}')">Elimina</button>
                            </td>
                        </tr>
                    `;
                }

                $("#corpo-tabella").html(contenuto);
            }, 
            error: function(errore){
                alert("ERRORE");
                console.log(errore)
            }
        }
    );
}

const elimina = (codice) => {
    
    $.ajax(
        {
            url: "https://localhost:7126/api/prodotti/codice/" + codice,
            type: "POST",
            success: function(){
                alert("Stappooooo");
                stampaTabella();
            },
            error: function(errore){
                alert("Errore");
                console.log(errore);
            }
        }
    )
}




const salvaElemento = () => {
    let nom = $("#nome").val();
    let desc = $("#descrizione").val();
    let prez = $("#prezzo").val();
    let quan = $("#quantita").val();
    let cate = $("#categoria").val();

    $.ajax(
        {
            url: "https://localhost:7126/api/prodotti",
            type: "POST",
            data: JSON.stringify({
                nome: nom,               
                descrizione: desc,
                prezzo: prez,
                quantita: quan,
                categoria: cate
            }),
            contentType: "application/json",
            dataType: "json",
            success: function(){
                alert("Stappooooo");
                stampaTabella();
            },
            error: function(errore){
                alert("Inserito");
                console.log(errore);
            }
        
        }
    )
}

$(document).ready(
    function(){

        stampaTabella();

        $(".salva").on("click", () => {
            salvaElemento();
        })

    }
);

