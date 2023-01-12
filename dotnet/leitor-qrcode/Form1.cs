using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using HtmlAgilityPack;
using System.Web;

namespace leitor_qrcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        DocumentoNFCe documento;

        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cbCameras.Items.Add(filterInfo.Name);

            cbCameras.SelectedIndex = 0;
        }

        private void btnLer_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameras.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbCamera.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pbCamera.Image);
                if (result != null)
                {
                    txtQRCode.Text = result.ToString();
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }
            }
        }

        private void btnLer_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtQRCode.Text))
            {
                MessageBox.Show("Não existe QRCode lido.", "Atenção", MessageBoxButtons.OK);
            }

            try
            {


                documento = new DocumentoNFCe();
                var wc = new WebClient();
                string pagina = wc.DownloadString(txtQRCode.Text);

                var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(pagina);

                //if (htmlDocument.DocumentNode.SelectNodes("//infos/div[1]/div/ul/li")
                //    .Any(a => HttpUtility.HtmlDecode(a.InnerText).Contains("Número:")))
                //{

                //}

                foreach (HtmlNode node in htmlDocument.GetElementbyId("infos").ChildNodes)
                {
                    if (!String.IsNullOrEmpty(node.InnerText) && node.InnerText.Contains("NÃºmero:"))
                    {
                        string[] dados = node.InnerText.Split('\n');
                        string[] numeroNota = dados[6].Split(':');
                        string[] serieNota = dados[7].Split(':');
                        string[] emissaoNota = dados[8].Split(':');
                        documento.Numero = numeroNota[1].Trim();
                        documento.Serie = serieNota[1].Trim();
                        documento.Emissao = emissaoNota[1].Trim();
                    }

                    if (!String.IsNullOrEmpty(node.InnerText) && node.InnerText.Contains("Chave de acesso:"))
                    {
                        string[] dados = node.InnerText.Split('\n');
                        documento.Chave = dados[10].Trim();
                    }
                }

                foreach (HtmlNode node in htmlDocument.GetElementbyId("totalNota").ChildNodes)
                {
                    if (!String.IsNullOrEmpty(node.InnerText) && node.InnerText.Contains("total de itens:"))
                    {
                        string[] dados = node.InnerText.Split('\n');
                        documento.Quantidade = dados[2].Trim();
                    }
                    if (!String.IsNullOrEmpty(node.InnerText) && node.InnerText.Contains("Valor total"))
                    {
                        string[] dados = node.InnerText.Split('\n');
                        documento.Total = dados[2].Trim();
                    }
                }

                foreach (HtmlNode node in htmlDocument.GetElementbyId("tabResult").ChildNodes)
                {
                    if (!String.IsNullOrEmpty(node.InnerText) && !String.IsNullOrEmpty(node.Id))
                    {
                        string[] dados = node.InnerText.Split('\n');
                        documento.Itens += $"({dados[2].Trim()} - {dados[6].Trim()})";
                    }
                }

                var lstDocumento = new List<DocumentoNFCe>();
                lstDocumento.Add(documento);
                var frmGrade = new frmGrade();
                frmGrade.CarregaDadosGrade(lstDocumento);
                frmGrade.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao ler QRCode: {ex.Message}", "Atenção", MessageBoxButtons.OK);
            }
        }
    }
}
