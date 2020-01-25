using Facturacion_Base_De_Datos.UNA.Facturacion_Base_De_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion_Base_De_Datos.UNA.Facturacion_Base_De_Datos.Formulario
{
    public partial class AgregarCliente : Form
    {
        public  DialogResult itSaved;
        public Cliente cliente;

        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void guadarButton_Click(object sender, EventArgs e)
        {
            itSaved = new DialogResult();
            cliente = new Cliente();
            cliente.Cedula = Convert.ToInt64(cedulaTextBox.Text);
            cliente.Nombre = nombreTextBox.Text;
            cliente.Telefono = Convert.ToInt32(telefonoTextBox.Text);
            cliente.Direccion = direecionTextBox.Text;
            cliente.Correo = emailTextBox.Text;
            itSaved = DialogResult.Yes;
            this.Close();
        }
    }
}
