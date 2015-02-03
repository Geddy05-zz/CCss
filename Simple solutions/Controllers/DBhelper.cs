using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_solutions.Controllers {
    public class DBhelper : Controller {

        private MySqlConnection connection;
        private string server, port;
        private string database;
        private string uid;
        private string password;
        private List<string>[] result;

        public DBhelper() {
            server = "localhost";
            port = "8015";
            database = "pcbuilder";
            uid = "root";
            password = "90Cmm77";
            string connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        
        }

        private bool OpenConnection() {
            try {
                connection.Open();
                ViewBag.Connection = "connection established";
                return true;
            } catch (MySqlException ex) {
                ViewBag.Connection = "connection not established";
                return false;
            }
        }

        //Close connection
        private bool CloseConnection() {
            try {
                connection.Close();
                return true;
            } catch (MySqlException ex) {
                return false;
            }
        }

        public List<string>[] Select(String query, int columns, List<String> columnNames) {
            //Create a list to store the result
            result = new List<string>[columns];
            for (int i = 0; i < columns; i++) {
                result[i] = new List<string>();
            }

            //Open connection
            if (this.OpenConnection() == true) {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read()) {
                    for (int i = 0; i < columns; i++) {
                        result[i].Add(dataReader[columnNames[i]] + "");
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return result;
            } else {
                return result;
            }
        }
    }
}
