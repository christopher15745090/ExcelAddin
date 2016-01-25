using System;
using System.Windows.Forms;
using PrimeAnalyticsAddin.Global;
using PrimeAnalyticsAddin.UserControls;
using System.Net;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Windows.Controls;
using System.Linq;

namespace PrimeAnalyticsAddin
{
    class ConnectionClasses
    {

    }

    public class LoginTools
    {

        Ribbon r = new Ribbon();
        public Boolean login_Validation(string username, string password)
        {

            Boolean result = false;

            using (CookieWebClient client = new CookieWebClient())
            {

                if (username != "" && password != "")
                {

                    System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("email", username);
                    reqparm.Add("password", password);
                    byte[] responsebytes = client.UploadValues("http://admin.primeanalytics.io/session/start/true", "POST", reqparm);

                    string responsebody = Encoding.ASCII.GetString(responsebytes);
                    
                    if (responsebody == "success")
                    {
                        result = true;
                        SessionData.username = username;
                        SessionData.password = password;
                        SessionData.loggedIn = true;
                    }
                    else
                    {
                        MessageBox.Show(responsebody);
                    }

                }
                else
                {
                    MessageBox.Show("Login Fields not Completed!", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return result;
            }
        }



        public void login_Session(string username, string password)
        {
            SessionData.loggedIn = login_Validation(username, password);

            if (SessionData.loggedIn == true)
            {
                r.btnLogin.Label = "Logout";
            }

        }


        public void logout_Session ()
        {

            resetSessionData();
            r.btnLogin.Label = "Login";

        }


        public void resetSessionData()
        {
            SessionData.username = "";
            SessionData.password = "";
            SessionData.loggedIn = false;
        }
    }

    public class DataRequests
    {
        //List of Urls
        //http://admin.primeanalytics.io/session/start
        //http://admin.primeanalytics.io/process/getProcesses
        //http://admin.primeanalytics.io/process/getHeaders/"id"
        //http://admin.primeanalytics.io/process/processResults/"id"


        public dynamic getDataList(String loginUrl, String targetUrl)
        {
            dynamic obj = null;
            try
            {               

                using (CookieWebClient client = new CookieWebClient())
                {
                    System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("email", SessionData.username);
                    reqparm.Add("password", SessionData.password);
                    byte[] responsebytes = client.UploadValues(loginUrl, "POST", reqparm);

                    reqparm = new System.Collections.Specialized.NameValueCollection();
                    responsebytes = client.UploadValues(targetUrl, "POST", reqparm);

                    string json = System.Text.Encoding.UTF8.GetString(responsebytes);

                    var serializer = new JavaScriptSerializer();
                    serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

                    obj = serializer.Deserialize(json, typeof(object));
                }
                
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return obj;
        }



        public static DataTable DataViewAsDataTable(DataView dv)
        {
            DataTable dt = dv.Table.Clone();
            foreach (DataRowView drv in dv)
                dt.ImportRow(drv.Row);
            return dt;
        }

    }


    public class UploadTools
    {

        /// <summary>
        /// THis class is used for uploading data to the cloud from within excel
        /// </summary>

        public void pushDataToCloud(string tableName, DataTable sheetData)
        {

            //http://admin.primeanalytics.io/get/DBTables
            //http://admin.primeanalytics.io/get/DBColumns/test/true


            //DataTable data = sheetData; //(DataTable)DataViewAsDataTable((DataView)(((Process)System.Windows.Application.Current.MainWindow).resultDataGrid.ItemsSource));

            CookieContainer cookies = new CookieContainer();
            using (CookieWebClient client = new CookieWebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("email", SessionData.username);
                reqparm.Add("password", SessionData.password);
                byte[] responsebytes = client.UploadValues("http://admin.primeanalytics.io/session/start", "POST", reqparm);

                cookies = client.CookieContainer;

            }



            DataTable data = sheetData;//(DataTable)DataViewAsDataTable((DataView)(((Process)System.Windows.Application.Current.MainWindow).resultDataGrid.ItemsSource));

            DataTable dtCloned = data.Clone();

            int totalColumns = data.Columns.Count;

            for (int i = 0; i < totalColumns; i++)
            {
                DateTime number_date;
                int number_integer;
                double number_double;
                if (data.Rows.Cast<DataRow>().All(x => DateTime.TryParse(Convert.ToString(x[i]), out number_date)))
                {
                    dtCloned.Columns[i].DataType = typeof(DateTime);
                    Console.WriteLine("date");
                }
                else if (data.Rows.Cast<DataRow>().All(x => int.TryParse(Convert.ToString(x[i]), out number_integer)))
                {
                    dtCloned.Columns[i].DataType = typeof(Int32);
                    Console.WriteLine("int");
                }
                else if (data.Rows.Cast<DataRow>().All(x => double.TryParse(Convert.ToString(x[i]), out number_double)))
                {
                    dtCloned.Columns[i].DataType = typeof(double);
                    Console.WriteLine("double");
                }
                else
                {
                    dtCloned.Columns[i].DataType = typeof(string);
                    Console.WriteLine("string");
                }
            }


            System.Net.ServicePointManager.DefaultConnectionLimit = 1000;

            string table_name = tableName;
            int countLimit = 80;
            DataTable copyTable = null;

            for (int i = 0; i <= data.Rows.Count; i++)
            {

                if (((i % countLimit) == 0) || i == (data.Rows.Count))
                {
                    if (copyTable != null)
                    {
                        using (CookieWebClient client = new CookieWebClient())
                        {
                            client.CookieContainer = cookies;
                            string jsonString = string.Empty;
                            jsonString = JsonConvert.SerializeObject(copyTable);
                            System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                            reqparm = new System.Collections.Specialized.NameValueCollection();
                            reqparm.Add("data", jsonString);

                            client.UploadValuesAsync(new Uri("http://admin.primeanalytics.io/studio_connect/uploadData/" + table_name + "/update"), reqparm);
                        }

                    }
                    copyTable = new DataTable();
                    copyTable = dtCloned.Copy();
                    copyTable.TableName = "TableCount" + i;
                }
                if (i < data.Rows.Count)
                {
                    copyTable.ImportRow(data.Rows[i]);
                }

            }


        }
    }

    public class CookieWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; set; }

        /// <summary>
        /// This will instanciate an internal CookieContainer.
        /// </summary>
        public CookieWebClient()
        {
            this.CookieContainer = new CookieContainer();
        }

        /// <summary>
        /// Use this if you want to control the CookieContainer outside this class.
        /// </summary>
        public CookieWebClient(CookieContainer cookieContainer)
        {
            this.CookieContainer = cookieContainer;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request == null) return base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            return request;
        }
    }


}
