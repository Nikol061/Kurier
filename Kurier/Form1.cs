using Kurier.Controller;
using Kurier.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurier
{
    public partial class Form1 : Form
    {
        ParcelLogic parcelController = new ParcelLogic();   
        ParcelTypeController typeController = new ParcelTypeController();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ParcelType> allParcels = typeController.GetAllParcels();
            cmb.DataSource = allParcels;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "Id";
          
            btnSelectAll_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt2.Text)|| txt2.Text == " ")
            {
                MessageBox.Show("Въведете данни");
                txt2.Focus();
                return;
            }
            Parcel parcel = new Parcel();
            parcel.Id = int.Parse(txt1.Text);
            parcel.Name = txt2.Text;
            parcel.Description = txt3.Text;
            parcel.Price = double.Parse(txt4.Text);
            parcel.Kg = double.Parse(txt5.Text);
            parcel.TypesId = (int)cmb.SelectedValue;

            parcelController.Create(parcel);
            MessageBox.Show("Записът е успешно добавен");
            ClearScreen();
            
            btnSelectAll_Click( sender, e );
        }
        private void LoadRecord(Parcel parcel)
        {
            txt1.BackColor = Color.White;
            txt1.Text = parcel.Id.ToString();
            txt2.Text = parcel.Name;
            txt3.Text = parcel.Description;
            txt4.Text = parcel.Price.ToString();
            txt5.Text = parcel.Kg.ToString();
            cmb.Text = parcel.TypesId.ToString();
        }
        private void ClearScreen()
        {
            txt1.BackColor = Color.White;
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            txt4.Clear();
            txt5.Clear();
            cmb.Text = " ";
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Parcel> AllParcels = parcelController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in AllParcels)
            {
                listBox1.Items.Add($"№:{item.Id} Name:{item.Name} Description:{item.Description} {item.Kg}kg Paket Type: {item.Types.Name}");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text)|| !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            Parcel findedparcel = parcelController.Get(findId);
            if (findedparcel == null)
            {
                MessageBox.Show("Няма такъв запис");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            LoadRecord(findedparcel);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID за търсене");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            if (string.IsNullOrEmpty(txt2.Text))
            {
                Parcel findedparcel = parcelController.Get(findId);
                if (findedparcel == null)
                {
                    MessageBox.Show("Няма такъв запис");
                    txt1.BackColor = Color.Red;
                    txt1.Focus();
                    return;
                }
                LoadRecord(findedparcel);
            }
            else
            {
                Parcel updateParcel = new Parcel();
                updateParcel.Name = txt2.Text;
                updateParcel.Description = txt3.Text;
                updateParcel.Price = double.Parse(txt4.Text);
                updateParcel.Kg = double.Parse(txt5.Text);
                updateParcel.TypesId = (int)cmb.SelectedValue;

                parcelController.Update(findId, updateParcel);

                
            }
            btnSelectAll_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text)|| ! txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            Parcel findedParcel = parcelController.Get(findId);
            if (findedParcel == null)
            {
                MessageBox.Show("Няма такъв запис");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            LoadRecord(findedParcel);
            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете този запис" + findId + " ? ", "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                parcelController.Delete(findId);
            }
            btnSelectAll_Click(sender , e);

        }
    }
}
