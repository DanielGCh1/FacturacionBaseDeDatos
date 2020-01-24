using DBConnection.Connection;
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
    public partial class Clientes : Form
    {
        MyDBSQL mySQL;
        public Clientes()
        {
            mySQL  = new MyDBSQL();
            InitializeComponent();
        }

        private void addClientButton_Click(object sender, EventArgs e)
        {
            AgregarCliente agregarCliente = new AgregarCliente();
            agregarCliente.ShowDialog();
            if(agregarCliente.itSaved == DialogResult.Yes)
            {
                mySQL.OpenConnection();
                mySQL.BeginTransaction();
                mySQL.EjectSQL(String.Format("INSERT INTO clientes (`idCliente`, `nombre`, `telefono`, `direccion`, `correo`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                agregarCliente.cliente.Cedula, agregarCliente.cliente.Nombre, agregarCliente.cliente.Telefono, agregarCliente.cliente.Direccion, agregarCliente.cliente.Correo));
                mySQL.CommitTransaction();
                mySQL.CloseConnection();
                mySQL.QuerySQL("SELECT * FROM facturacion.clientes");
                RefrescarClientesDataGrid();
            }
           
        }
        public void AgregarFilaADataGrid(string[] fila)
        {
            clientesDataGridView.Rows.Add(fila);
        }
        public void RefrescarClientesDataGrid()
        {
            clientesDataGridView.DataSource = mySQL.QuerySQL("SELECT * FROM facturacion.clientes");
        }
        
        public void CargarDataGrid(DataTable data)
        {
            clientesDataGridView.DataSource = data;
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            mySQL.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBActual"].ConnectionString;
            mySQL.OpenConnection();
            RefrescarClientesDataGrid();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
