using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PadangNovamente.Formularios
{
    public partial class frmPrincipal: Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Tem certeza que deseja sair?",
                "Confirmação de saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void telaCheiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCancelarNota().Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime dataHora = DateTime.Now;

            lblDataHora.Text = $"{dataHora.ToString("dd/MM/yyyy")}  -  {dataHora.ToString("HH:mm:ss")}  -  Versão: 1.00";
        }
    }
}
