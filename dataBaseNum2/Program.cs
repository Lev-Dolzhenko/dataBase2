using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;



OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=WIN-7USK4AL356A\\SQLEXPRESS;" +
    "TrustServerCertificate=True;Integrated Security=SSPI;Initial Catalog=Students");

con.Open();
OleDbCommand cmd = new("select * from students", con);
OleDbCommand command = new OleDbCommand("select * from students", con);

OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

DataSet ds = new DataSet();
adapter.Fill(ds);
cmd.ExecuteNonQuery();
con.Close();

for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
{
    Console.WriteLine($"{ds.Tables[0].Rows[i].ItemArray[0].ToString()}\t " +
        $"{ds.Tables[0].Rows[i].ItemArray[1].ToString()}");

}


OdbcConnection con2 = new OdbcConnection("DSN=dataBaseNum2"); // Подключение через Odbc
con2.Open();

string query = "SELECT id, name, quantity FROM producte;";
OdbcCommand cmd2 = new("select * from tabletest", con2);

OdbcDataReader reader = cmd2.ExecuteReader();
 while (reader.Read())
 {
 
 Console.WriteLine($"{reader}");
 Console.ReadLine();
 }
 
 reader.Close();


OdbcDataAdapter adapterOdbc = new OdbcDataAdapter(cmd2);

DataSet ds2 = new DataSet();

adapterOdbc.Fill(ds2);

con2.Close();

for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
{
    Console.WriteLine($"\n{ds2.Tables[0].Rows[i].ItemArray[0].ToString()}" +
        $"{ds2.Tables[0].Rows[i].ItemArray[1].ToString()}");

} 



List<string> list = new List<string>()
{
    { "BMW" },
    { "AUDI" },
    { "MERSEDES" },
    { "LADA" },
    {"TESLA" }
};

var cars = from p in list
             where p.EndsWith('A') // Выборка через Linq
             select p;
foreach (var item in cars)
{
    Console.WriteLine(item);
}

