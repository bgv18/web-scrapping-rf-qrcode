using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leitor_qrcode
{
    public partial class frmGrade : Form
    {
        public frmGrade()
        {
            InitializeComponent();
        }

        public void CarregaDadosGrade(List<DocumentoNFCe> doc)
        {
            dgNota.DataSource = doc;
        }
    }
}
