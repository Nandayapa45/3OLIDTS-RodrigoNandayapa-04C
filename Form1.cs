using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //lIBRERIA PARA LECTURA Y ESCRITURA

namespace _3OLIDTS_RodrigoNandayapa_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbTelefono.Clear();
            tbEstatura.Clear();
            tbEdad.Clear();
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text;
            string apellidos = tbApellidos.Text;
            string tel = tbTelefono.Text;
            string edad = tbEdad.Text;
            string estatura = tbEstatura.Text;

            string genero = "";

            if (rbFemenino.Checked)
            {
                genero = "Femenino";

            }
            else if (rbMasculino.Checked)
            {
                genero = "Masculino";
            }
            string datos = $"Nombre: {nombre}\n\r Apellidos : {apellidos}\n\r" +
                $" Telefono : {tel}\n\r Edad : {edad}\n\r " +
                $"Estatura : {estatura}\n\r Genero : {genero}\n\r";

           
            string ruta = "C:\\Users\\rodri\\Downloads\\3OLIDTS.text";

            bool archivoExiste = File.Exists(ruta);
            using (StreamWriter writer = new StreamWriter(ruta, true))
            {
                if (archivoExiste)
                {
                    writer.WriteLine();

                }
                writer.WriteLine(datos);

            }
            MessageBox.Show(datos, "Valores ingresados", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
