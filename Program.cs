using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


SqlCommand command;
string connectionString;
SqlDataReader reader;
SqlDataAdapter adapter = new SqlDataAdapter();

SqlConnection cnn;
string sql, Output = "";


connectionString = @"Data Source=DESKTOP-SFORHI9;Initial Catalog=test;User ID=vocal;Password=spider12";

cnn = new SqlConnection(connectionString);
cnn.Open();
Console.WriteLine("Connection open !");
/* Select from database
sql = "SELECT * from test_table";

command = new SqlCommand(sql, cnn);
reader = command.ExecuteReader();

while (reader.Read()) {
    Console.WriteLine("\n---------\n");
    Console.WriteLine(reader.GetValue(0));
    Console.WriteLine(reader.GetValue(1));
}
*/
/*
sql = "Insert into Cards (front, back, stack_id) values('test', 'another', 1)";
command = new SqlCommand(sql, cnn);
adapter.InsertCommand = command;
adapter.InsertCommand.ExecuteNonQuery();

command.Dispose();
cnn.Close();
*/

/* Update Database
sql = "UPDATE test_table set name = 'Another test' WHERE id=2";

command = new SqlCommand(sql, cnn);
adapter.UpdateCommand = command;
adapter.UpdateCommand.ExecuteNonQuery();

command.Dispose();
cnn.Close();
*/

/* Delete from database
sql = "DELETE test_table where id = 3";

command = new SqlCommand(sql, cnn);
adapter.DeleteCommand = command;
adapter.DeleteCommand.ExecuteNonQuery();

command.Dispose();
cnn.Close();
*/