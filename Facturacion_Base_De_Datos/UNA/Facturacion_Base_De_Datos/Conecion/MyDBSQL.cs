using MySql.Data.MySqlClient;
using System.Data;

namespace Facturacion_Base_De_Datos.UNA.Facturacion_Base_De_Datos.Conecion
{
    public class MyDBSQL : DbAccess
    {
        public override void OpenConnection()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
            
        }
        public override void CloseConnection()
        {
            if (Connection != null)
            {
                Connection.Close();
            }

        }
        public override DataTable QuerySQL(string query)
        {
      //      MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable result = new DataTable();
     //       adapter.SelectCommand = new MySqlCommand(query, (MySqlConnection)Connection);
     //       adapter.Fill(result);
            return result;
        }
        public override long EjectSQL(string query)
        {
            //MySqlCommand cmd = new MySqlCommand(query, (MySqlConnection)Connection);
            //return cmd.ExecuteNonQuery();
            return 0;
        }
        public override bool IsTransaction()
        {
            return (Transaction!=null);
        }
        public override void CommitTransaction()
        {
            if (IsTransaction())
            {
                Transaction.Commit();
            }
        }
        public override void RollBackTransaction()
        {
            if (IsTransaction())
            {
                Transaction.Rollback();
            }
        }

        public override void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }
    }
}
