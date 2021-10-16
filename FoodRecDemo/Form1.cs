using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Security;

namespace FoodRecDemo
{
    public partial class Form1 : Form
    {
        public static decimal[] tasteComponents = new decimal[28];
        public static decimal[] myTaste = new decimal[28];
        public static List<decimal> rankings = new List<decimal>();
        public static List<string> rankNames = new List<string>();

        static String logPath = @"\\vmdevdsm5.711dev.pvt\c$\Documents and Settings\vprabh01\Desktop\TestFoodRec.txt";
        StreamWriter reportLog;
        SqlConnection conn;
        public Form1()
        {
            try
            {
                InitializeComponent();
                reportLog = new StreamWriter(logPath, true);
                reportLog.AutoFlush = true;
            }
            catch (Exception ex)
            {
                reportLog.WriteLine(DateTime.Now.ToString() + ":\nApplication experienced the following error: " + ex.ToString() + "\nStack Trace:\n" + ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message.ToString() + " - Please contact support at Varun.Prabhakar@Cognizant.com.");
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (choiceBox.CheckedItems.Count == 5)
                {
                    setMyTastes();
                    recLabel.Visible = true;
                    returnTop5();
                }
                else
                {
                    MessageBox.Show("Please select exactly 5 items");
                }
            }
            catch (Exception ex)
            {
                reportLog.WriteLine(DateTime.Now.ToString() + ":\nApplication experienced the following error: " + ex.ToString() + "\nStack Trace:\n" + ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message.ToString() + " - Please contact support at Varun.Prabhakar@Cognizant.com.");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                reportLog.WriteLine(DateTime.Now.ToString() + ":\nApplication experienced the following error: " + ex.ToString() + "\nStack Trace:\n" + ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message.ToString() + " - Please contact support at Varun.Prabhakar@Cognizant.com.");
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            try
            {
                choiceBox.SelectedItems.Clear();
                foreach(int i in choiceBox.CheckedIndices)
                    choiceBox.SetItemCheckState(i, CheckState.Unchecked);
                tasteComponents = new decimal[28];
                myTaste = new decimal[28];
                rankings = new List<decimal>();
                rankNames = new List<string>();
                recLabel.Visible = false;
                recList.Visible = false;
                recList.Text = "";
            }
            catch (Exception ex)
            {
                reportLog.WriteLine(DateTime.Now.ToString() + ":\nApplication experienced the following error: " + ex.ToString() + "\nStack Trace:\n" + ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message.ToString() + " - Please contact support at Varun.Prabhakar@Cognizant.com.");
            }
        }

        private void setMyTastes()
        {
            try
            {
                conn = new SqlConnection("server=localhost;database=FoodRec;integrated security=SSPI;");
                //conn.Open();
                string foodItem;
                SqlCommand ds = new SqlCommand("getFoodRatings", conn);
                ds.CommandType = CommandType.StoredProcedure;
                SqlDataReader Reader;
                foreach (object checkedItem in choiceBox.CheckedItems)
                {
                    foodItem = checkedItem.ToString();
                    //MessageBox.Show(foodItem);
                    conn.Open();
                    ds = new SqlCommand("getFoodRatings", conn);
                    ds.CommandType = CommandType.StoredProcedure;
                    ds.Parameters.Add("@foodItem", SqlDbType.VarChar).Value = foodItem.ToString().Trim();

                    Reader = ds.ExecuteReader();
                    //int j = 1;
                    if (Reader.HasRows)
                        Reader.Read();
                    //MessageBox.Show(foodItem);
                    //MessageBox.Show(Reader[0].ToString());
                    //for (int j = 1; j < 28; j++)
                    //    MessageBox.Show("Loop " + Reader[j].ToString());
                    decimal numDiv = decimal.Parse(Reader[0].ToString());
                    for (int k = 1; k < 29; k++)
                        myTaste[k - 1] += decimal.Parse(Reader[k].ToString()) / (decimal)numDiv;
                    //while (Reader.Read())
                    //while (j < 28)
                    //{
                    //    myTaste[j - 1] += (decimal)((decimal)Reader[j] / (decimal)numDiv);
                    //    MessageBox.Show("Test: " + Reader[j].ToString());
                    //    j++;
                    //}
                    conn.Close();
                    //myTaste[0] += (decimal)Reader[1] / (decimal)Reader[0];
                    //myTaste[1] += (decimal)Reader[2] / (decimal)Reader[0];
                    //myTaste[2] += (decimal)Reader[3] / (decimal)Reader[0];
                    //myTaste[3] += (decimal)Reader[4] / (decimal)Reader[0];
                    //myTaste[4] += (decimal)Reader[5] / (decimal)Reader[0];
                    //myTaste[5] += (decimal)Reader[6] / (decimal)Reader[0];
                    //myTaste[6] += (decimal)Reader[7] / (decimal)Reader[0];
                    //myTaste[7] += (decimal)Reader[8] / (decimal)Reader[0];
                    //myTaste[8] += (decimal)Reader[9] / (decimal)Reader[0];
                    //myTaste[9] += (decimal)Reader[10] / (decimal)Reader[0];
                    //myTaste[10] += (decimal)Reader[11] / (decimal)Reader[0];
                    //myTaste[11] += (decimal)Reader[12] / (decimal)Reader[0];
                    //myTaste[12] += (decimal)Reader[13] / (decimal)Reader[0];
                    //myTaste[13] += (decimal)Reader[14] / (decimal)Reader[0];
                    //myTaste[14] += (decimal)Reader[15] / (decimal)Reader[0];
                    //myTaste[15] += (decimal)Reader[16] / (decimal)Reader[0];
                    //myTaste[16] += (decimal)Reader[17] / (decimal)Reader[0];
                    //myTaste[17] += (decimal)Reader[18] / (decimal)Reader[0];
                    //myTaste[18] += (decimal)Reader[19] / (decimal)Reader[0];
                    //myTaste[19] += (decimal)Reader[20] / (decimal)Reader[0];
                    //myTaste[20] += (decimal)Reader[21] / (decimal)Reader[0];
                    //myTaste[21] += (decimal)Reader[22] / (decimal)Reader[0];
                    //myTaste[22] += (decimal)Reader[23] / (decimal)Reader[0];
                    //myTaste[23] += (decimal)Reader[24] / (decimal)Reader[0];
                    //myTaste[24] += (decimal)Reader[25] / (decimal)Reader[0];
                    //myTaste[25] += (decimal)Reader[26] / (decimal)Reader[0];
                    //myTaste[26] += (decimal)Reader[27] / (decimal)Reader[0];
                    //myTaste[27] += (decimal)Reader[28] / (decimal)Reader[0];
                }
                //MessageBox.Show(myTaste[0].ToString());
                //Decimal.Divide((decimal)myTaste[0], (decimal)5.0);
                //MessageBox.Show(myTaste[0].ToString());
                myTaste[0] = (decimal)myTaste[0] / (decimal)5.0;
                myTaste[1] = (decimal)myTaste[1] / (decimal)5.0;
                myTaste[2] = (decimal)myTaste[2] / (decimal)5.0;
                myTaste[3] = (decimal)myTaste[3] / (decimal)5.0;
                myTaste[4] = (decimal)myTaste[4] / (decimal)5.0;
                myTaste[5] = (decimal)myTaste[5] / (decimal)5.0;
                myTaste[6] = (decimal)myTaste[6] / (decimal)5.0;
                myTaste[7] = (decimal)myTaste[7] / (decimal)5.0;
                myTaste[8] = (decimal)myTaste[8] / (decimal)5.0;
                myTaste[9] = (decimal)myTaste[9] / (decimal)5.0;
                myTaste[10] = (decimal)myTaste[10] / (decimal)5.0;
                myTaste[11] = (decimal)myTaste[11] / (decimal)5.0;
                myTaste[12] = (decimal)myTaste[12] / (decimal)5.0;
                myTaste[13] = (decimal)myTaste[13] / (decimal)5.0;
                myTaste[14] = (decimal)myTaste[14] / (decimal)5.0;
                myTaste[15] = (decimal)myTaste[15] / (decimal)5.0;
                myTaste[16] = (decimal)myTaste[16] / (decimal)5.0;
                myTaste[17] = (decimal)myTaste[17] / (decimal)5.0;
                myTaste[18] = (decimal)myTaste[18] / (decimal)5.0;
                myTaste[19] = (decimal)myTaste[19] / (decimal)5.0;
                myTaste[20] = (decimal)myTaste[20] / (decimal)5.0;
                myTaste[21] = (decimal)myTaste[21] / (decimal)5.0;
                myTaste[22] = (decimal)myTaste[22] / (decimal)5.0;
                myTaste[23] = (decimal)myTaste[23] / (decimal)5.0;
                myTaste[24] = (decimal)myTaste[24] / (decimal)5.0;
                myTaste[25] = (decimal)myTaste[25] / (decimal)5.0;
                myTaste[26] = (decimal)myTaste[26] / (decimal)5.0;
                myTaste[27] = (decimal)myTaste[27] / (decimal)5.0;
                //MessageBox.Show(myTaste[0].ToString());
            }
            catch (Exception ex)
            {
                reportLog.WriteLine(DateTime.Now.ToString() + ":\nApplication experienced the following error: " + ex.ToString() + "\nStack Trace:\n" + ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message.ToString() + " - Please contact support at Varun.Prabhakar@Cognizant.com.");
            }
        }

        private void returnTop5()
        {
            try
            {
                conn = new SqlConnection("server=localhost;database=FoodRec;integrated security=SSPI;");
                conn.Open();
                string foodItem;
                SqlCommand ds = new SqlCommand("getFoodList", conn);
                ds.CommandType = CommandType.StoredProcedure;
                SqlDataReader Reader;
                Reader = ds.ExecuteReader();
                //for (int j = 0; j < 29; j++)
                //    rankNames[j] = (string)Reader[j];
                //int j = 0;
                //Reader.Read();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        //MessageBox.Show((string)Reader[0].ToString());
                        if( Reader[0] != null & Reader[0].ToString() != "")
                                if (!choiceBox.CheckedItems.Contains(Reader[0].ToString()))
                                    rankNames.Add((string)Reader[0].ToString());
                    }
                }
                //for (int j = 0; j < 40; j++)
                //{
                //    rankNames.Add((string)Reader[j].ToString());
                //    MessageBox.Show(rankNames[j]);
                //}
                /*
                 * for (int k = 1; k < 28; k++)
                        myTaste[k - 1] += decimal.Parse(Reader[k].ToString()) / (decimal)numDiv;
                 * */
                conn.Close();
                conn = new SqlConnection("server=localhost;database=FoodRec;integrated security=SSPI;");
                int k = 0;
                //decimal component;
                //decimal numDiv;
                foreach (string x in rankNames)
                {
                    //if (!choiceBox.CheckedItems.Contains(x))
                    //{
                    foodItem = x;
                    conn.Open();
                    ds = new SqlCommand("getFoodRatings", conn);
                    ds.CommandType = CommandType.StoredProcedure;
                    if (foodItem != null)
                    {
                        ds.Parameters.Add("@foodItem", SqlDbType.VarChar).Value = foodItem.ToString().Trim();
                        if (foodItem.ToString() != "")
                        {
                            Reader = ds.ExecuteReader();
                            Reader.Read();
                            //tasteComponents[k] = (decimal)Reader[1] / (decimal)Reader[0];

                            for (int z = 1; z < 29; z++)
                                if (Reader[z] != null)
                                    tasteComponents[z - 1] = decimal.Parse(Reader[z].ToString()) / decimal.Parse(Reader[0].ToString());


                            findSimularity();
                            k++;
                            conn.Close();
                        }
                    }
                }
                orderBySimularity();
            }
            catch (Exception ex)
            {
                reportLog.WriteLine(DateTime.Now.ToString() + ":\nApplication experienced the following error: " + ex.ToString() + "\nStack Trace:\n" + ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message.ToString() + " - Please contact support at Varun.Prabhakar@Cognizant.com.");
            }
        }
        private void findSimularity()
        {
            try
            {
                rankings.Add((tasteComponents[0] * myTaste[0] + tasteComponents[1] * myTaste[1] + tasteComponents[2] * myTaste[2] +
                    tasteComponents[3] * myTaste[3] + tasteComponents[4] * myTaste[4] + tasteComponents[5] * myTaste[5] +
                    tasteComponents[6] * myTaste[6] + tasteComponents[7] * myTaste[7] + tasteComponents[8] * myTaste[8] +
                    tasteComponents[9] * myTaste[9] + tasteComponents[10] * myTaste[10] + tasteComponents[11] * myTaste[11] +
                    tasteComponents[12] * myTaste[12] + tasteComponents[13] * myTaste[13] + tasteComponents[14] * myTaste[14] +
                    tasteComponents[15] * myTaste[15] + tasteComponents[16] * myTaste[16] + tasteComponents[17] * myTaste[17] +
                    tasteComponents[18] * myTaste[18] + tasteComponents[19] * myTaste[19] + tasteComponents[20] * myTaste[20] +
                    tasteComponents[21] * myTaste[21] + tasteComponents[22] * myTaste[22] + tasteComponents[23] * myTaste[23] +
                    tasteComponents[24] * myTaste[24] + tasteComponents[25] * myTaste[25] + tasteComponents[26] * myTaste[26] +
                    tasteComponents[27] * myTaste[27]) / (tasteComponents.Length * myTaste.Length));
            }
            catch (Exception ex)
            {
                reportLog.WriteLine(DateTime.Now.ToString() + ":\nApplication experienced the following error: " + ex.ToString() + "\nStack Trace:\n" + ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message.ToString() + " - Please contact support at Varun.Prabhakar@Cognizant.com.");
            }
        }
        private void orderBySimularity()
        {
            try
            {
                //MessageBox.Show(rankNames[0].ToString());
                string[] rankNames2 = rankNames.ToArray();
                decimal[] rankings2 = rankings.ToArray();
                recList.Visible = true;
                if (rankings2.Length == rankNames2.Length)
                    for (int j = 0; j < rankings2.Length; j++)
                    {
                    //MessageBox.Show(rankNames2[j]);
                    //MessageBox.Show(rankings2[j].ToString());
                        if (rankings2[j] > (decimal)0.6)
                            recList.Text += "\n" + rankNames2[j];
                    }

               /* foreach (decimal x in rankings.ToArray())
                    MessageBox.Show(x.ToString());
                */
                //rankNames
            }
            catch (Exception ex)
            {
                reportLog.WriteLine(DateTime.Now.ToString() + ":\nApplication experienced the following error: " + ex.ToString() + "\nStack Trace:\n" + ex.StackTrace);
                MessageBox.Show("Error: " + ex.Message.ToString() + " - Please contact support at Varun.Prabhakar@Cognizant.com.");
            }
        }
    }
}
