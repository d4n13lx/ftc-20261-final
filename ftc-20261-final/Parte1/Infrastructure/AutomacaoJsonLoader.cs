using ftc_20261_final.Parte1.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ftc_20261_final.Parte1.Infrastructure
{
    public class AutomacaoJsonLoader
    {
        public AutomacaoDeterministica CarregarJson(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException($"Arquivo de configuração não foi encontrado: {caminhoArquivo}");
            }

            string jsonString = File.ReadAllText(caminhoArquivo);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dto = JsonSerializer.Deserialize<AutomatoDto>(jsonString, options);

            if (dto == null)
            {
                throw new InvalidOperationException("Falha ao mapear o JSON");
            }

            var transicoesMap = new Dictionary<(string estado, char simbolo), string>();
            foreach (var t in dto.Delta)
            {
                if (t.Simbolo.Length != 1)
                {
                    throw new FormatException($"O símbolo de transição '{t.Simbolo}' deve conter 1 caractere apenas");
                }

                transicoesMap[(t.Origem, t.Simbolo[0])] = t.Destino;
            }

            return new AutomacaoDeterministica(dto.Q, dto.Sigma, transicoesMap, dto.Q0, dto.F);
        }

        private class AutomatoDto
        {
            public HashSet<string> Q { get; set; } = new();
            public HashSet<char> Sigma { get; set; } = new();
            public List<TransicaoDto> Delta { get; set; } = new();
            public string Q0 { get; set; } = string.Empty;
            public HashSet<string> F { get; set; } = new();
        }
        private class TransicaoDto
        {
            public string Origem { get; set; } = string.Empty;
            public string Simbolo { get; set; } = string.Empty;
            public string Destino { get; set;  } = string.Empty;
        }
    }
}
