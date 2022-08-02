using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == textBox1.Text && u.Clave == textBox2.Text).FirstOrDefault();

            if (ousuario != null)
            {
                Inicio form = new Inicio();

                form.Show();
                this.Hide();

                //Permite el retorno al formulario de logeo
                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("Usuario erroneo","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); 
            }
            
        }

        //Referencia al retorno del formulario de logeo
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            //Permite que los espacios retornen vacios en el formulario
            textBox1.Text = "";
            textBox2.Text = "";
            this.Show();
        }
    }
}
