using FIT.Data;
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
    public partial class frmPretragaIB210181 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<Student> studentiPodaci;
        DrzaveIB210181 drzava;
        public frmPretragaIB210181()
        {
            InitializeComponent();
        }

        private void frmPretragaIB210181_Load(object sender, EventArgs e)
        {
            dgvPretraga.AutoGenerateColumns = false;

            cmbDrzava.DataSource = db.DrzaveIB210181.ToList();
            
        }

        private void UcitajPodatke()
        {

            var grad = cmbGrad.SelectedItem as GradoviIB210181;

            studentiPodaci = db.Studenti.Where(x => x.GradId == grad.Id).ToList();

            if (studentiPodaci!=null)
            {
                var Tabela = new DataTable();
                Tabela.Columns.Add("Ime");
                Tabela.Columns.Add("Prezime");
                Tabela.Columns.Add("Grad");
                Tabela.Columns.Add("Drzava");
                Tabela.Columns.Add("Prosjek");
                for (int i = 0; i < studentiPodaci.Count(); i++)
                {
                    var student = studentiPodaci[i];
                    var Red = Tabela.NewRow();
                    Red["Ime"] = student.Ime;
                    Red["Prezime"] = student.Prezime;
                    Red["Grad"] = grad.ToString();
                    Red["Drzava"] = drzava.ToString();
                    Red["Prosjek"] = db.PolozeniPredmeti.Where(x => x.StudentId == student.Id).Count() == 0 ? "5" :
                        db.PolozeniPredmeti.Where(x => x.StudentId == student.Id).Average(x => x.Ocjena).ToString();
                    Tabela.Rows.Add(Red);
                }
                dgvPretraga.DataSource = null;
                dgvPretraga.DataSource = Tabela;
            }
        }

        private void cmbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            // var drzava = db.DrzaveIB210181.First(); -> ne mozes ovako pisat onda ti uzme prvu iz baze zato ti ne radi kako treba
            drzava = cmbDrzava.SelectedItem as DrzaveIB210181;


            cmbGrad.DataSource = db.GradoviIB210181.Where(x => x.DrzavaId == drzava.Id).ToList();
        }

        private void cmbGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPodatke();
        }
    }
}
