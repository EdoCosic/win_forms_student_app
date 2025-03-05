using FIT.Data;
using FIT.Data.IspitIB210181;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB210181
{
    public partial class frmPrisustvoIB210181 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<PrisustvoIB210181> prisustva;
        private ProstorijeIB210181 odabranaProstorija;

        int brojac = 0;

        public frmPrisustvoIB210181()
        {
            InitializeComponent();
        }

        public frmPrisustvoIB210181(ProstorijeIB210181 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmPrisustvoIB210181_Load(object sender, EventArgs e)
        {
            dgvPrisustvo.AutoGenerateColumns = false;
            lblPrisustvo.Text = $"{odabranaProstorija.Naziv} - {odabranaProstorija.Oznaka}";

            cmbNastava.DataSource = db.NastavaIB210181.Include(x => x.Predmet).
                Where(x => x.ProstorijaId == odabranaProstorija.Id).ToList();
            cmbStudent.DataSource = db.Studenti.ToList();

            UcitajPrisustva();
            UcitajPrebrojavanja();
        }
        private void UcitajPrisustva()
        {
            prisustva = db.PrisustvoIB210181.Include(x => x.Nastava).ThenInclude(x => x.Prostorija).
                Include(x => x.Nastava).ThenInclude(x => x.Predmet).
                Include(x => x.Student).
                Where(x => x.Nastava.ProstorijaId == odabranaProstorija.Id).
                ToList();

            if (prisustva != null)
            {
                dgvPrisustvo.DataSource = null;
                dgvPrisustvo.DataSource = prisustva;
            }

            brojac = prisustva.Count();

            UcitajPrebrojavanja();
        }

        private void UcitajPrebrojavanja()
        {
            lblOd.Text = brojac.ToString();
            lblDo.Text = odabranaProstorija.Kapacitet.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var student = cmbStudent.SelectedItem as Student;
            var nastava = cmbNastava.SelectedItem as NastavaIB210181;
            if (prisustva.Exists(x => x.StudentId == student.Id && x.NastavaId == nastava.Id))
            {
                MessageBox.Show("Prisustvo vec postoji!");
            }
            else
            {
                if (odabranaProstorija.Kapacitet == prisustva.Count())
                {
                    MessageBox.Show("Kapacitet prostorije je pun!");
                }
                else
                {
                    var novoPrisustvo = new PrisustvoIB210181()
                    {
                        StudentId = student.Id,
                        NastavaId = nastava.Id
                    };
                    db.PrisustvoIB210181.Add(novoPrisustvo);
                }
            }
            db.SaveChanges();
            UcitajPrisustva();
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            var student = cmbStudent.SelectedItem as Student;
            var nastava = cmbNastava.SelectedItem as NastavaIB210181;

            if (Validiraj())
            {
                Thread thread = new Thread(() => GenerisiPrisustva(student, nastava));
                thread.Start();
            }
        }

        private void GenerisiPrisustva(Student? student, NastavaIB210181? nastava)
        {
            Thread.Sleep(300);
            string info = "";
            var broj = int.Parse(txtBroj.Text);
            for (int i = 0; i < broj; i++)
            {
                var novoPrisustvo = new PrisustvoIB210181()
                {
                    StudentId = student.Id,
                    NastavaId = nastava.Id
                };
                db.PrisustvoIB210181.Add(novoPrisustvo);
                db.SaveChanges();

                info += $"{DateTime.Now.ToString("dd:MM HH:mm:ss")} -> {student} za {nastava}{Environment.NewLine}";
            }

            Action action = () =>
            {
                UcitajPrisustva();
                txtInfo.Text=info;
                MessageBox.Show($"Generisano je {broj} prisustva");
            };
            BeginInvoke(action);
        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(txtBroj, err, Kljucevi.ReqiredValue);
        }
    }
}
