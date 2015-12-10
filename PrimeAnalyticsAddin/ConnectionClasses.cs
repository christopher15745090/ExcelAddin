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

namespace PrimeAnalyticsAddin
{
    class ConnectionClasses
    {

    }

    public class LoginTools
    {
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
            dynamic obj;

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
                serializer.RegisterConverters(new[] {new DynamicJsonConverter()});

                 obj = serializer.Deserialize(json, typeof(object));
            }
            return obj;
        }



        public void pushDataToCloud (System.Windows.Forms.TextBox tbTableName, DataTable sheetData)
        {

            //http://admin.primeanalytics.io/get/DBTables
            //http://admin.primeanalytics.io/get/DBColumns/test/true


            DataTable data = (DataTable)sheetData; //(DataTable)DataViewAsDataTable((DataView)(((Process)System.Windows.Application.Current.MainWindow).resultDataGrid.ItemsSource));



            CookieContainer cookies = new CookieContainer();
            using (CookieWebClient client = new CookieWebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("email", SessionData.username);
                reqparm.Add("password", SessionData.password);
                byte[] responsebytes = client.UploadValues("http://admin.primeanalytics.io/session/start", "POST", reqparm);

                cookies = client.CookieContainer;

            }

            System.Net.ServicePointManager.DefaultConnectionLimit = 1000;

            string table_name = tbTableName.Text;
            int countLimit = 80;
            int count = 0;
            DataTable copyTable = null;

            foreach (DataRow dr in data.Rows)
            {
                if ((count++ % countLimit) == 0)
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
                    copyTable = data.Clone();
                    copyTable.TableName = "TableCount" + count;


                }
                copyTable.ImportRow(dr);
            }
        }

        public static DataTable DataViewAsDataTable(DataView dv)
        {
            DataTable dt = dv.Table.Clone();
            foreach (DataRowView drv in dv)
                dt.ImportRow(drv.Row);
            return dt;
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
