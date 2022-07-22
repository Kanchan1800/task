// using System;
// using System.Data.SqlClient;
// using System.Text;

// namespace walkinapi
// {
//     class SqlConnects
//     {
//         static void Main(string[] args)
//         {
//             try 
//             { 
//                 SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

//                 builder.DataSource = "localhost:3306"; 
//                 builder.UserID = "sqluser";            
//                 builder.Password = "password";     
//                 builder.InitialCatalog = "mydb";
         
//                 using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//                 {
//                     Console.WriteLine("\nQuery data example:");
//                     Console.WriteLine("=========================================\n");
                    
//                     connection.Open();       

//                     String sql = "Show tables";

//                     using (SqlCommand command = new SqlCommand(sql, connection))
//                     {
//                         using (SqlDataReader reader = command.ExecuteReader())
//                         {
//                             while (reader.Read())
//                             {
//                                 Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
//                             }
//                         }
//                     }                    
//                 }
//             }
//             catch (SqlException e)
//             {
//                 Console.WriteLine(e.ToString());
//             }
//             Console.WriteLine("\nDone. Press enter.");
//             // Console.ReadLine(); 
//         }
//     }
// }