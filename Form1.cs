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
            TextBox textbox = (TextBox)sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show("Ingrese valores correctos para el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }

        }
        private void validarEdad(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EdadValida(textbox.Text))
            {
                MessageBox.Show("Ingrese un valor entero valido para la edad",
                "Error Edad", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);
                //textbox.Clear();
            }

        }
        private bool EdadValida(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
            //return false;
        }

        private void validarApellidos(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show("Por favor ingrese valores correctos para el apellidos", "Error Nombre", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                textbox.Clear();
            }

        }
        private void validarTelefono(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Text.Length == 10 && EsEnteroValido10Digitos
            (textbox.Text))
            {
                textbox.BackColor = Color.Green;
            }
            else
            {
                textbox.BackColor = Color.Red;
                MessageBox.Show("Ingrese un telefono de 10 digitos", "Error telefono",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //textbox.Clear();
            }

        }
        private bool EstaturaValida(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);
            //return false;
        }
        private void validarEstatura(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EstaturaValida(textbox.Text))
            {
                MessageBox.Show("Ingrese un valor decimal valido para la estatura", "Estatura", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                //textbox.Clear();
            }

        }

        private bool EsEnteroValido(string valor)
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
            //long resultado;
            //return long.TryParse(valor, out resultado) && valor.Length == 10

            return valor.Length == 10 && valor.All(char.IsDigit) &&
            long.TryParse(valor, out _);
            //string formato = @"^\d{10}$";
            //return Regex.IsMatch(valor, formato);

            //return false;

        }


        private bool EsTextoValido(string texto)
        {

            return Regex.IsMatch(texto, @"^{[A-Za-z\\s]+$");
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

            if (rbMasculino.Checked)
            {
                genero = "Hombre";

            }
            else if (rbFemenino.Checked)
            {
                genero = "Mujer";
            }
            if (!string.IsNullOrEmpty(tbApellidos.Text) && !string.IsNullOrEmpty(tbNombre.Text) && !string.IsNullOrEmpty(tbEdad.Text) && !string.IsNullOrEmpty(tbEstatura.Text) && !string.IsNullOrEmpty(tbTelefono.Text))
            {
                string datos = $"Nombre:{nombre}\n\rApellidos:{apellidos}\n\r" +
                    $"Telefono:{tel}\n\rEdad:{edad}\n\rEstatura:{estatura}\n\rGenero:{genero}\n\r";
                //el \r es inicio de renglon
                //MessageBox.Show(datos,"Valores ingresados", MessageBoxButtons.OK,MessageBoxIcon.Information);
                string ruta = "C:\\Users\\rodri\\Downloads\\3OLIDTS2025.txt";
                //string ruta = "C:/Users/rodri/Downloads/3OLIDTS2025.txt"; 
                //string ruta = @"C:\Users\rodri\Downloads\3OLIDTS2025.txt";
                bool archivoExiste = File.Exists(ruta);
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    if (archivoExiste)
                    {
                        writer.WriteLine();
                    }
                    writer.WriteLine(datos);
                }
                MessageBox.Show(datos, "Valores ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ingrese valores a los textBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

        }

            private void btnCerrar_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        }
    }

