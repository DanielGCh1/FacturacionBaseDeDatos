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
            mySQL.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBActual"].ConnectionString;
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
                mySQL.EjectSQL(String.Format("INSERT INTO clientes (`nombre`, `telefono`, `direccion`) VALUES ('{0}', '{1}', '{2}')",
                agregarCliente.cliente.Nombre, agregarCliente.cliente.Telefono, agregarCliente.cliente.Direccion));
                mySQL.CommitTransaction();
                mySQL.CloseConnection();
                mySQL.QuerySQL("SELECT * FROM clientes");
                RefrescarClientesDataGrid();
            }
           
        }
        public void AgregarFilaADataGrid(string[] fila)
        {
            clientesDataGridView.Rows.Add(fila);
        }
        public void RefrescarClientesDataGrid()
        {
            clientesDataGridView.DataSource = mySQL.QuerySQL("SELECT * FROM clientes");
        }
        
        public void CargarDataGrid(DataTable data)
        {
            clientesDataGridView.DataSource = data;
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            mySQL.OpenConnection();
            RefrescarClientesDataGrid();
            mySQL.CloseConnection();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
