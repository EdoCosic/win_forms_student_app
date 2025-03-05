﻿using FIT.Infrastructure;
using FIT.WinForms.IspitIB210181;
using FIT.WinForms.Izvjestaji;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms
{
    public partial class frmPocetna : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        public frmPocetna()
        {
            InitializeComponent();
        }

        private void frmPocetna_Load(object sender, EventArgs e)
        {
            lblKonekcijaInfo.Text = $"Broj studenata u bazi -> {db.Studenti.Count()}";
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            new frmIzvjestaji().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDrzaveIB210181 frmDrzave = new frmDrzaveIB210181();
            frmDrzave.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPretragaIB210181 frmPretraga = new frmPretragaIB210181();
            frmPretraga.ShowDialog();
        }
    }
}
