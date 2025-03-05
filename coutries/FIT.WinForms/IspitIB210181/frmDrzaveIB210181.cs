using FIT.Data.IspitIB210181;
using FIT.Infrastructure;
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
    public partial class frmDrzaveIB210181 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<DrzaveIB210181> drzave;
        public frmDrzaveIB210181()
        {
            InitializeComponent();
        }

        private void frmDrzaveIB210181_Load(object sender, EventArgs e)
        {
            dgvDrzave.AutoGenerateColumns = false;

            UcitajVrijeme();
            UcitajDrzave();
        }

        private void UcitajDrzave()
        {
            drzave = db.DrzaveIB210181.ToList();

            var gradovi = db.GradoviIB210181.ToList();

            if (drzave != null)
            {

                for (int i = 0; i < drzave.Count(); i++)
                {
                    drzave[i].Broj = gradovi.Where(x => x.DrzavaId == drzave[i].Id).Count();
                }
                dgvDrzave.DataSource = null;
                dgvDrzave.DataSource = drzave;
            }
        }

        private void UcitajVrijeme()
        {
            tsslSat.Text = $"Trenutno vrijeme: {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UcitajVrijeme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNovaDrzavaIB210181 frmNovaDrzava = new frmNovaDrzavaIB210181();
            if (frmNovaDrzava.ShowDialog() == DialogResult.OK)
            {
                UcitajDrzave();
            }
        }

        private void dgvDrzave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaDrzava = drzave[e.RowIndex];
            if (e.ColumnIndex != 4)
            {
                frmNovaDrzavaIB210181 frmNovaDrzava = new frmNovaDrzavaIB210181(odabranaDrzava);
                if (frmNovaDrzava.ShowDialog() == DialogResult.OK)
                {
                    UcitajDrzave();
                }
            }
        }

        private void dgvDrzave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaDrzava = drzave[e.RowIndex];
            if (e.ColumnIndex==4)
            {
                frmGradoviIB210181 frmGradovi = new frmGradoviIB210181(odabranaDrzava);
                frmGradovi.ShowDialog();
                UcitajDrzave();
            }
        }
    }
}
