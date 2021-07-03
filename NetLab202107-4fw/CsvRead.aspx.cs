using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetLab202107_4fw
{
    public partial class CsvRead : System.Web.UI.Page
    {
        public List<Data> datas = new List<Data>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string csvPath = ConfigurationManager.AppSettings["csvpath"];
                using (TextFieldParser parser = new TextFieldParser(csvPath, Encoding.GetEncoding(932)))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.Delimiters = new string[] { "," };

                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields();
                        Data datarow = new Data();
                        datarow.Kokyo_cd = row[0];
                        datarow.Yubin_5 = row[1];
                        datarow.Yubin_7 = row[2];
                        datarow.Todofuke_kana = row[3];
                        datarow.City_kana = row[4];
                        datarow.Tyo_kana = row[5];
                        datarow.Todofuken = row[6];
                        datarow.City = row[7];
                        datarow.Tyo = row[8];
                        datas.Add(datarow);
                    }
                }
                Page.Session.Add("list", datas);
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