using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PadangNovamente.Classes;

namespace PadangNovamente.Repositorios
{
    public class NotaCancelamentoRepositorio
    {
        public string SalvarComoTxt(NotaCancelamento nota, string caminhoDestino)
        {
            string retorno = ValidarDados(nota);
            if (retorno != "") return retorno;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"idLote|{nota.IdLote}");
                sb.AppendLine($"evento|{nota.Evento}");
                sb.AppendLine($"id|{nota.Id}");
                sb.AppendLine($"cOrgao|{nota.COrgao}");
                sb.AppendLine($"tpAmb|{nota.TpAmb}");
                sb.AppendLine($"CNPJ|{nota.Cnpj}");
                sb.AppendLine($"chNFe|{nota.ChNFe}");
                sb.AppendLine($"dhEvento|{nota.DhEvento}");
                sb.AppendLine($"tpEvento|{nota.TpEvento}");
                sb.AppendLine($"nSeqEvento|{nota.NSeqEvento}");
                sb.AppendLine($"verEvento|{nota.VerEvento}");
                sb.AppendLine($"descEvento|{nota.DescEvento}");
                sb.AppendLine($"nProt|{nota.NProt}");
                sb.AppendLine($"xJust|{nota.XJust}");

                Directory.CreateDirectory(caminhoDestino);

                string caminhoCompleto = Path.Combine(caminhoDestino, $"Cancel{nota.ChNFe}-ped-eve.txt");

                File.WriteAllText(caminhoCompleto, sb.ToString(), Encoding.UTF8);

                retorno = "";
            } 
            catch (Exception ex)
            {
                retorno = $"Erro: ${ex.Message}";
            }

            return retorno;
        }

        private string ValidarDados(NotaCancelamento pNotaCancelamento)
        {
            string retorno = "";

            if (string.IsNullOrEmpty(pNotaCancelamento.Arquivo) ||
                string.IsNullOrEmpty(pNotaCancelamento.IdLote) ||
                string.IsNullOrEmpty(pNotaCancelamento.Evento) ||
                string.IsNullOrEmpty(pNotaCancelamento.Id) ||
                string.IsNullOrEmpty(pNotaCancelamento.COrgao) ||
                string.IsNullOrEmpty(pNotaCancelamento.TpAmb) ||
                string.IsNullOrEmpty(pNotaCancelamento.Cnpj) ||
                string.IsNullOrEmpty(pNotaCancelamento.ChNFe) ||
                string.IsNullOrEmpty(pNotaCancelamento.DhEvento) ||
                string.IsNullOrEmpty(pNotaCancelamento.TpEvento) ||
                string.IsNullOrEmpty(pNotaCancelamento.NSeqEvento) ||
                string.IsNullOrEmpty(pNotaCancelamento.VerEvento) ||
                string.IsNullOrEmpty(pNotaCancelamento.DescEvento) ||
                string.IsNullOrEmpty(pNotaCancelamento.NProt) ||
                string.IsNullOrEmpty(pNotaCancelamento.XJust))
            {
                retorno = "Preencha todos os campos!";
            }

            return retorno;
        }
    }
}
