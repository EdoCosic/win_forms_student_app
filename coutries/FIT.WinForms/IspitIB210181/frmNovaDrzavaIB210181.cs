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
    public partial class frmNovaDrzavaIB210181 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private DrzaveIB210181 odabranaDrzava;

        public frmNovaDrzavaIB210181()
        {
            InitializeComponent();
        }

        public frmNovaDrzavaIB210181(DrzaveIB210181 odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var zastava = Ekstenzije.ToByteArray(pbZastava.Image);
                var naziv = txtNaziv.Text;
                var status = cbStatus.Checked;

                if (odabranaDrzava==null)
                {
                var novaDrzava = new DrzaveIB210181()
                {
                    Naziv = naziv,
                    Status = status,
                    Zastava = zastava
                };
                db.DrzaveIB210181.Add(novaDrzava);
                }
                else
                {
                    odabranaDrzava.Naziv = naziv;
                    odabranaDrzava.Status = status;
                    odabranaDrzava.Zastava = zastava;

                    db.Entry(odabranaDrzava).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                db.SaveChanges();

                DialogResult = DialogResult.OK;
            }
        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue) &&
                 Helpers.Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void pbZastava_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbZastava.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void frmNovaDrzavaIB210181_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if (odabranaDrzava!=null)
            {
                txtNaziv.Text = odabranaDrzava.Naziv;
                pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);
                cbStatus.Checked = odabranaDrzava.Status;
            }
        }
    }
}
