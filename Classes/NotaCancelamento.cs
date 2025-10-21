using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadangNovamente.Classes
{
    public class NotaCancelamento
    {
        private string arquivo;
        private string idLote;
        private string evento;
        private string id;
        private string cOrgao;
        private string tpAmb;
        private string cnpj;
        private string chNFe;
        private string dhEvento;
        private string tpEvento;
        private string nSeqEvento;
        private string verEvento;
        private string descEvento;
        private string nProt;
        private string xJust;

        public string Arquivo { get => arquivo; set => arquivo = value; }
        public string IdLote { get => idLote; set => idLote = value; }
        public string Evento { get => evento; set => evento = value; }
        public string Id { get => id; set => id = value; }
        public string COrgao { get => cOrgao; set => cOrgao = value; }
        public string TpAmb { get => tpAmb; set => tpAmb = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string ChNFe { get => chNFe; set => chNFe = value; }
        public string DhEvento { get => dhEvento; set => dhEvento = value; }
        public string TpEvento { get => tpEvento; set => tpEvento = value; }
        public string NSeqEvento { get => nSeqEvento; set => nSeqEvento = value; }
        public string VerEvento { get => verEvento; set => verEvento = value; }
        public string DescEvento { get => descEvento; set => descEvento = value; }
        public string NProt { get => nProt; set => nProt = value; }
        public string XJust { get => xJust; set => xJust = value; }
    }
}
