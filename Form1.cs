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
using System.Text.RegularExpressions; //Libreria para la validación de formato de texto

namespace _3OLIDTS_RodrigoNandayapa_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Creacion de manejadores de eventos
            tbNombre.TextChanged += validarNombre;
            tbApellidos.TextChanged += validarApellidos;
            tbEstatura.TextChanged += validarEstatura;
            tbEdad.TextChanged += validarEdad;
            tbTelefono.Leave += validarTelefono; 

        }
        private void validarNombre(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox) sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show ("Ingrese valores correctos para el nombre", "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void validarEdad(object sender, EventArgs e)
        {


        }
        private void validarApellidos(object sender, EventArgs e)
        {


        }
        private void validarTelefono(object sender, EventArgs e)
        {


        }
        private void validarEstatura(object sender, EventArgs e)
        {


        }

        private bool EsEnteroValido (string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);

            //return false;

        }

        private bool EsDecimalValido(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);

            //return false;

        }

        private bool EsEnteroValido10Digitos(string valor)
        {
            long resultado;
            return long.TryParse(valor, out resultado) && valor.Length == 10;

            //return false;

        }


        private bool EsTextoValido(string valor)
        {

            return Regex.IsMatch(valor, @"^{[A-Za-z\s]+$");
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
