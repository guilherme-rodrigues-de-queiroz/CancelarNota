using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PadangNovamente.Classes;
using System.Xml;
using PadangNovamente.Repositorios;

namespace PadangNovamente.Formularios
{
    public partial class frmCancelarNota: Form
    {
        public frmCancelarNota()
        {
            InitializeComponent();
        }

        private void frmCancelarNota_Shown(object sender, EventArgs e)
        {
            txtArquivo.Focus();
        }

        private void txtArquivo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtArquivo_DragDrop(object sender, DragEventArgs e)
        {
            string[] arquivos = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (arquivos.Length > 0 && Path.GetExtension(arquivos[0]).ToLower() == ".xml")
            {
                CarregarXmlParaTela(arquivos[0]);
            }
        }

        private void txtArquivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                var data = Clipboard.GetDataObject();

                if (data != null && data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] arquivos = (string[])data.GetData(DataFormats.FileDrop);

                    if (arquivos.Length > 0 && Path.GetExtension(arquivos[0]).ToLower() == ".xml")
                    {
                        CarregarXmlParaTela(arquivos[0]);
                    }
                }
            }
        }

        private void btnSelectArquivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Arquivos XML (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CarregarXmlParaTela(openFileDialog.FileName);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string retorno = ValidarCampos();

            if (retorno != "")
            {
                MessageBox.Show(retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NotaCancelamento nota = new NotaCancelamento();
            nota.Arquivo = txtArquivo.Text;
            nota.IdLote = txtIdLote.Text;
            nota.Evento = txtEvento.Text;
            nota.Id = txtId.Text;
            nota.COrgao = txtOrgao.Text;
            nota.TpAmb = txtAmb.Text;
            nota.Cnpj = txtCnpj.Text;
            nota.ChNFe = txtChnfe.Text;
            nota.DhEvento = txtDhEvento.Text;
            nota.TpEvento = txtTpEvento.Text;
            nota.NSeqEvento = txtSeqEvento.Text;
            nota.VerEvento = txtVerEvento.Text;
            nota.DescEvento = txtDescEvento.Text;
            nota.NProt = txtNProt.Text;
            nota.XJust = cbXJust.Text;

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecione a pasta onde deseja salvar o arquivo .txt";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    var repositorio = new NotaCancelamentoRepositorio();

                    string resposta = repositorio.SalvarComoTxt(nota, folderDialog.SelectedPath);

                    if (resposta == "")
                    {
                        MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(resposta, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            lbNota.Items.Clear();

            lbNota.Items.Add($"idLote|{txtIdLote.Text}");
            lbNota.Items.Add($"evento|{txtEvento.Text}");
            lbNota.Items.Add($"id|{txtId.Text}");
            lbNota.Items.Add($"cOrgao|{txtOrgao.Text}");
            lbNota.Items.Add($"tpAmb|{txtAmb.Text}");
            lbNota.Items.Add($"CNPJ|{txtCnpj.Text}");
            lbNota.Items.Add($"chNFe|{txtChnfe.Text}");
            lbNota.Items.Add($"dhEvento|{txtDhEvento.Text}");
            lbNota.Items.Add($"tpEvento|{txtTpEvento.Text}");
            lbNota.Items.Add($"nSeqEvento|{txtSeqEvento.Text}");
            lbNota.Items.Add($"verEvento|{txtVerEvento.Text}");
            lbNota.Items.Add($"descEvento|{txtDescEvento.Text}");
            lbNota.Items.Add($"nProt|{txtNProt.Text}");
            lbNota.Items.Add($"xJust|{cbXJust.Text}");
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (lbNota.Items.Count > 0)
            {
                string textoCopiado = string.Join(Environment.NewLine, lbNota.Items.Cast<string>());

                Clipboard.SetText(textoCopiado);

                MessageBox.Show("Conteúdo copiado para a área de transferência!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("A lista está vazia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void LimparCampos()
        {
            txtArquivo.Clear();
            txtId.Clear();
            txtIdLote.Clear();
            txtEvento.Clear();
            txtOrgao.Clear();
            txtAmb.Clear();
            txtChnfe.Clear();
            txtDhEvento.Clear();
            txtCnpj.Clear();
            txtTpEvento.Clear();
            txtDescEvento.Clear();
            txtNProt.Clear();
            txtSeqEvento.Clear();
            txtVerEvento.Clear();
            cbXJust.SelectedIndex = -1;
            lbNota.Items.Clear();
        }

        private string ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtArquivo.Text) ||
                string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtIdLote.Text) ||
                string.IsNullOrWhiteSpace(txtEvento.Text) ||
                string.IsNullOrWhiteSpace(txtOrgao.Text) ||
                string.IsNullOrWhiteSpace(txtAmb.Text) ||
                string.IsNullOrWhiteSpace(txtChnfe.Text) ||
                string.IsNullOrWhiteSpace(txtDhEvento.Text) ||
                string.IsNullOrWhiteSpace(txtCnpj.Text) ||
                string.IsNullOrWhiteSpace(txtTpEvento.Text) ||
                string.IsNullOrWhiteSpace(txtDescEvento.Text) ||
                string.IsNullOrWhiteSpace(txtNProt.Text) ||
                string.IsNullOrWhiteSpace(txtSeqEvento.Text) ||
                string.IsNullOrWhiteSpace(txtVerEvento.Text) ||
                string.IsNullOrWhiteSpace(cbXJust.Text))
            {
                return "Preencha todos os campos!";
            }

            return "";
        }

        private void CarregarXmlParaTela(string caminhoXml)
        {
            if (!File.Exists(caminhoXml)) return;

            XmlDocument doc = new XmlDocument();

            doc.Load(caminhoXml);

            XmlNode infNFe = doc.GetElementsByTagName("ide")?.Item(0);

            XmlNode infNFe_emit = doc.GetElementsByTagName("emit")?.Item(0);

            XmlNode protNFe = doc.GetElementsByTagName("infProt")?.Item(0);

            txtArquivo.Text = caminhoXml;

            DateTime Data = DateTime.Now;
            DateTime Tempo = Data.AddMinutes(5);

            // Preenche os campos com os valores extraídos do XML
            txtIdLote.Text = infNFe?["nNF"]?.InnerText.PadLeft(15, '0') ?? "";
            txtEvento.Text = "1"; // fixo
            txtId.Text = $"ID110111{protNFe?["chNFe"]?.InnerText}01" ?? ""; // <Id>
            txtOrgao.Text = infNFe?["cUF"]?.InnerText ?? ""; // <cOrgao>
            txtAmb.Text = protNFe?["tpAmb"]?.InnerText ?? ""; // <tpAmb>
            txtCnpj.Text = infNFe_emit?["CNPJ"]?.InnerText ?? ""; // <CNPJ>
            txtChnfe.Text = protNFe?["chNFe"]?.InnerText ?? ""; // <chNFe>
            txtDhEvento.Text = $"{Data.ToString("yyyy-MM-dd")}T{Tempo.ToString("HH:mm:ss")}-03:00"; // <dhEvento>
            txtTpEvento.Text = "110111"; // fixo
            txtSeqEvento.Text = "1"; // fixo
            txtVerEvento.Text = "1.00"; // fixo
            txtDescEvento.Text = "Cancelamento"; // fixo
            txtNProt.Text = protNFe?["nProt"]?.InnerText ?? ""; // <nProt>
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            new frmTutorial().Show();
        }
    }
}
