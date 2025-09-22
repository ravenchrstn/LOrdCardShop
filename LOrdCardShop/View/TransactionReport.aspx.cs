using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using LOrdCardShop.Controller;
using LOrdCardShop.CrystalReport;
using LOrdCardShop.DataSet;
using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.View
{
	public partial class TransactionReport : System.Web.UI.Page
	{
        AuthController ac = new AuthController();
        TransactionHeaderController thc = new TransactionHeaderController();
		TransactionDetailController tdc = new TransactionDetailController();
		UserController uc = new UserController();
		CardController cc = new CardController();
		protected void Page_Load(object sender, EventArgs e)
		{
            ac.AdminAuthentication("~/View/Home/Home_Customer.aspx");
            LoadCrystalReportData();
		}

		protected void LoadCrystalReportData()
		{
			TransactionReport_CrystalReport cr = new TransactionReport_CrystalReport();
			TransactionReport_DS ds = RetrieveData(thc.GetTransactionHeadersByHandled());

            cr.SetDataSource(ds.Tables);

            cr.Database.Tables["Card"].SetDataSource(ds.Card.DataSet);
            cr.Database.Tables["TransactionHeader"].SetDataSource(ds.TransactionHeader.DataSet);
			cr.Database.Tables["TransactionDetail"].SetDataSource(ds.TransactionDetail.DataSet);
			cr.Database.Tables["User"].SetDataSource(ds.User.DataSet);
            cr.Database.Tables["AA"].SetDataSource(ds.AA.DataSet);
            CrystalReportViewer_TransactionReport.ReportSource = cr;

            cr.Refresh();
            cr.VerifyDatabase();
        }

		protected TransactionReport_DS RetrieveData(List<TransactionHeader> ths)
		{
            TransactionReport_DS ds = new TransactionReport_DS();
			var th_table = ds.TransactionHeader;
			var td_table = ds.TransactionDetail;
			var user_table = ds.User;
			var card_table = ds.Card;
            var aa_table = ds.AA;   

            foreach (TransactionHeader th in ths)
			{
                if (!th_table.AsEnumerable().Any(row => row.Field<int>("TransactionID") == th.TransactionID))
                {
                    var th_row = th_table.NewRow();
                    th_row["TransactionID"] = th.TransactionID;
                    th_row["UserID"] = th.UserID;
                    th_row["TransactionDate"] = th.TransactionDate;
                    th_table.Rows.Add(th_row);

                    var aa_row = aa_table.NewRow();
                    aa_row["TransactionID"] = th.TransactionID;
                    aa_table.Rows.Add(aa_row);
                }

				TransactionDetail td = tdc.GetTransactionDetailByTransactionID(th.TransactionID);
				User user = uc.GetUserByID(th.UserID);
				Card card = cc.GetCardByTransactionID(td.TransactionID);

                if (!td_table.AsEnumerable().Any(row => row.Field<int>("TransactionID") == td.TransactionID))
                {
                    var td_row = td_table.NewRow();
                    td_row["TransactionID"] = td.TransactionID;
                    td_row["CardID"] = td.CardID;
                    td_row["Quantity"] = td.Quantity;
                    td_row["TotalPrice"] = td.Quantity * card.CardPrice;   
                    td_table.Rows.Add(td_row);
                }

                if (!user_table.AsEnumerable().Any(row => row.Field<int>("UserID") == user.UserID))
                {
                    var user_row = user_table.NewRow();
                    user_row["UserID"] = user.UserID;
                    user_row["UserName"] = user.UserName;
                    user_table.Rows.Add(user_row);
                }

                if (!card_table.AsEnumerable().Any(row => row.Field<int>("CardID") == card.CardID))
                {
                    var card_row = card_table.NewRow();
                    card_row["CardID"] = card.CardID;
                    card_row["CardName"] = card.CardName;
                    card_row["CardPrice"] = card.CardPrice;
                    card_row["isFoil"] = cc.GetIsFoil(card.isFoil);
                    card_table.Rows.Add(card_row);
                }
            }

			return ds;
		}
	}
}