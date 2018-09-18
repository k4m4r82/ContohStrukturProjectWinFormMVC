using StrukturProjectMVC.Controller;
using StrukturProjectMVC.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrukturProjectMVC.View
{
    public partial class FrmMahasiswa : Form
    {
        private IMahasiswaController _controller;

        public FrmMahasiswa()
        {
            InitializeComponent();

            _controller = new MahasiswaController();
            LoadDataMahasiswa();
        }

        private void LoadDataMahasiswa()
        {
            var listOfMahasiswa = _controller.GetAll();

            listBox1.Items.Clear();
            foreach (var mhs in listOfMahasiswa)
            {
                listBox1.Items.Add(string.Format("{0}, {1}, {2}", mhs.npm, mhs.nama, mhs.alamat));
            }
        }

        private void LoadDataMahasiswa(string name)
        {
            var listOfMahasiswa = _controller.GetByName(name);

            listBox1.Items.Clear();
            foreach (var mhs in listOfMahasiswa)
            {
                listBox1.Items.Add(string.Format("{0}, {1}, {2}", mhs.npm, mhs.nama, mhs.alamat));
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            var mhs = new Mahasiswa();
            mhs.npm = "00.01.0801";
            mhs.nama = "NOVIANA KARTIKA DEWI";
            mhs.alamat = "Yogya";

            var result = _controller.Save(mhs);
            if (result > 0)
            {
                listBox1.Items.Add(string.Format("{0}, {1}, {2}", mhs.npm, mhs.nama, mhs.alamat));
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (txtCari.Text.Length > 0)
                LoadDataMahasiswa(txtCari.Text);
            else
                LoadDataMahasiswa();
        }
    }
}
