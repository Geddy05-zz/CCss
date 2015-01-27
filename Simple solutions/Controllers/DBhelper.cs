using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_solutions.Controllers {
    public class DBhelper : Controller {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private List<string>[] result;

        public DBhelper() {
            server = "localhost";
            database = "pcbuilder";
            uid = "root";
            password = "Nocando123";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
           /* String typeDiversityQuery = "SELECT type, count(DISTINCT url) as count FROM pcbuilder.products group by type order by type;";
            List<String> typeDiversityColumnNames = new List<String>(2);
            typeDiversityColumnNames.Add("type");
            typeDiversityColumnNames.Add("count");

            List<string>[] typeDiversityResult = Select(typeDiversityQuery, 2, typeDiversityColumnNames);
            ViewBag.CountBehuizing = typeDiversityResult[1][0];
            ViewBag.CountGeheugen = typeDiversityResult[1][1];
            ViewBag.CountGrafischekaart = typeDiversityResult[1][2];
            ViewBag.CountHardeschijf = typeDiversityResult[1][3];
            ViewBag.CountKoeler = typeDiversityResult[1][4];
            ViewBag.CountMoederbord = typeDiversityResult[1][5];
            ViewBag.CountOptischedrives = typeDiversityResult[1][6];
            ViewBag.CountProcessor = typeDiversityResult[1][7];
            ViewBag.CountProcessorKoeler = typeDiversityResult[1][8];
            ViewBag.Voeding = typeDiversityResult[1][9];*/
        }

        public void FetchMysqlData() {

        }

        private bool OpenConnection() {
            try {
                connection.Open();
                return true;
            } catch (MySqlException ex) {
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