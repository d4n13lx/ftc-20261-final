using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte2.Domain
{
    /// <summary>
    /// Representa o destino de uma transição, contendo o novo estado e a string a
    /// ser inserida no topo da pilha
    /// </summary>
    /// <param name="ProximoEstado"></param>
    /// <param name="ElementosEmpilhar"></param>
    public record DestinoTransicao(string ProximoEstado, string ElementosEmpilhar);
}
