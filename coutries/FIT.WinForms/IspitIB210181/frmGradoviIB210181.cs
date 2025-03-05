using FIT.Data;
using FIT.Data.IspitIB210181;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB210181
{
    public partial class frmGradoviIB210181 : Form
    {
        private DrzaveIB210181 odabranaDrzava;
        DLWMSDbContext db = new DLWMSDbContext();
        List<GradoviIB210181> gradovi;

        public frmGradoviIB210181()
        {
            InitializeComponent();
        }

        public frmGradoviIB210181(DrzaveIB210181 odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void frmGradoviIB210181_Load(object sender, EventArgs e)
        {
            dgvGradovi.AutoGenerateColumns = false;

            lblNaziv.Text = odabranaDrzava.Naziv;
            pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);

            UcitajGradove();
        }

        private void UcitajGradove()
        {
            gradovi = db.GradoviIB210181.Where(x => x.DrzavaId == odabranaDrzava.Id).ToList();

            if (gradovi != null)
            {
                dgvGradovi.DataSource = null;
                dgvGradovi.DataSource = gradovi;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var naziv = txtNaziv.Text;
                if (db.GradoviIB210181.ToList().Exists(x => x.DrzavaId == odabranaDrzava.Id && x.Naziv == naziv))
                {
                    MessageBox.Show("Vec je unesen grad sa tim imenom");
                }
                else
                {
                    var noviGrad = new GradoviIB210181()
                    {
                        DrzavaId = odabranaDrzava.Id,
                        Naziv = naziv,
                        Status = true,
                    };
                    db.GradoviIB210181.Add(noviGrad);
                }
                db.SaveChanges();
            }
            UcitajGradove();
        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void dgvGradovi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabraniGrad = gradovi[e.RowIndex];
            if (e.ColumnIndex == 2)
            {
                if (odabraniGrad.Status)
                {
                    odabraniGrad.Status = false;
                }
                else
                {
                    odabraniGrad.Status = true;
                }
                db.Entry(odabraniGrad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            UcitajGradove();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (ValidirajThread())
            {
                Thread thread = new Thread(() => GenerisiGradovi());
                thread.Start();
            }

        }

        private void GenerisiGradovi()
        {
            var broj = int.Parse(txtBroj.Text);
            var status = cbStatus.Checked;
            var info = "";

            for (int i = 0; i < broj; i++)
            {
                Thread.Sleep(300);
                var noviGrad = new GradoviIB210181()
                {
                    DrzavaId = odabranaDrzava.Id,
                    Naziv = $"Grad {i + 1}.",
                    Status = status,
                };
                db.GradoviIB210181.Add(noviGrad);
                db.SaveChanges();

                info += $"{DateTime.Now.ToString("dd:MM HH:mm:ss")} -> dodat grad {i+1}. za drzavu {odabranaDrzava} {Environment.NewLine}";
            }
            Action action = () =>
            {
                UcitajGradove();
                MessageBox.Show($"Generisano je {broj} gradova.");
                txtInfo.Text=info;
            };
            BeginInvoke(action);
        }

        private bool ValidirajThread()
        {
            return Helpers.Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
