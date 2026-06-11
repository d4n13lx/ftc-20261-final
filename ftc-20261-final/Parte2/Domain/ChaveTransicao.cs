using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte2.Domain
{
    /// <summary>
    /// Representa a chave de busca da função δ(q, a, X)
    /// </summary>
    /// <param name="Estado"></param>
    /// <param name="Simbolo"></param>
    /// <param name="TopoPilha"></param>
    public record ChaveTransicao(string Estado, char Simbolo, char TopoPilha);
}
