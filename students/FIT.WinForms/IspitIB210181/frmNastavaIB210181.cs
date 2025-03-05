using FIT.Data;
using FIT.Data.IspitIB210181;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
    public partial class frmNastavaIB210181 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<NastavaIB210181> nastave;
        private ProstorijeIB210181 odabranaProstorija;

        public frmNastavaIB210181()
        {
            InitializeComponent();
        }

        public frmNastavaIB210181(ProstorijeIB210181 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmNastavaIB210181_Load(object sender, EventArgs e)
        {
            dgvNastava.AutoGenerateColumns = false;
            lblNastava.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";
            cmbPredmet.DataSource = db.Predmeti.ToList();

            UcitajNastave();
        }

        private void UcitajNastave()
        {
            nastave = db.NastavaIB210181.Include(x => x.Prostorija).
                Include(x => x.Predmet).
                Where(x => x.ProstorijaId == odabranaProstorija.Id).
                ToList();

            if (nastave != null)
            {
                dgvNastava.DataSource = null;
                dgvNastava.DataSource = nastave;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var predmet = cmbPredmet.SelectedItem as PredmetiIB210181;
                var dan = cmbDan.SelectedItem.ToString();
                var vrijeme = cmbVrijeme.SelectedItem.ToString();

                if (nastave.Exists(x=>x.PredmetId==predmet.Id && x.Dan == dan && x.Vrijeme == vrijeme))
                {
                    MessageBox.Show("Nije moguce dodati istu nastavu na isti dan u isto vrimeme");
                }
                else
                {
                var novaNastava = new NastavaIB210181()
                {
                    PredmetId = predmet.Id,
                    ProstorijaId = odabranaProstorija.Id,
                    Vrijeme = vrijeme,
                    Dan = dan,
                    Oznaka = $"{predmet.Naziv} :: {dan} :: {vrijeme}"
                };
                db.NastavaIB210181.Add(novaNastava);
                }
                db.SaveChanges();
                UcitajNastave();
            }
        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(cmbDan, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(cmbVrijeme, err, Kljucevi.ReqiredValue);
        }

        private void frmNastavaIB210181_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
