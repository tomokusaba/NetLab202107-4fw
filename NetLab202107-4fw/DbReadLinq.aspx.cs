using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetLab202107_4fw
{
    public partial class DbReadLinq : System.Web.UI.Page
    {
        public List<Data> datas = new List<Data>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbstring = ConfigurationManager.AppSettings["dbstring"];
            string sql = "select * from yubin ";
            using (OracleConnection con = new OracleConnection(dbstring))
            {
                con.Open();
                using (OracleCommand command = new OracleCommand(sql, con))
                {
                    OracleDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Data table = new Data();
                        table.Kokyo_cd = reader.GetString(0);
                        table.Yubin_5 = reader.GetString(1);
                        table.Yubin_7 = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        {
                            table.Todofuke_kana = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            table.City_kana = reader.GetString(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            table.Tyo_kana = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6))
                        {
                            table.Todofuken = reader.GetString(6);
                        }
                        if (!reader.IsDBNull(7))
                        {
                            table.City = reader.GetString(7);
                        }
                        if (!reader.IsDBNull(8))
                        {
                            table.Tyo = reader.GetString(8);
                        }
                        datas.Add(table);
                    }

                    Page.Session.Add("list", datas);
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            datas = (List<Data>)Page.Session["list"];
            List<Data> newdata = datas.Where(x => $"{ x.Todofuken}{x.City}{x.Tyo}{x.Yubin_7}".Contains(TextBox1.Text)).ToList();
            GridView1.DataSource = newdata;
            GridView1.DataBind();

        }
    }
}
