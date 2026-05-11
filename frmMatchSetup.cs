using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace BRCSS_BasketballStats
{
    public partial class frmAdminInterface : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public frmAdminInterface(bool guestCheck)
        {
            InitializeComponent();
            if (guestCheck == true)
            {
                mnuArchivedTeamsUpdate.Visible = false;
                mnuActiveTeamsUpdate.Visible = false;
                mnuFileStartResumeMatch.Visible = false;
                mnuFileBorder.Visible = false;
            }
            listActiveTeams.MouseClick += listActive_MouseClick;
            listArchive.MouseClick += listArchive_MouseClick;
            listMatchHistory.MouseClick += listMatchHistory_MouseClick;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Royals Basketball Database.accdb; Persist Security Info=False";
            try
            {
                connection.Open();
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Warning : Unable to Establish Connection to the Microsoft Access Database! Please make sure the Microsoft Access Database (labelled 'Royals Basketball Database') is placed in bin/debug/ of this program, then restart the program. Thank you.");
            }
        }
        private void mnuFileStartMatch_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMatchSetup frmMatchSetup = new frmMatchSetup();
            frmMatchSetup.Show();
        }
        private void frmAdminInterface_Load(object sender, EventArgs e)
        {
            OleDbCommand commandGatherPlayers = new OleDbCommand();
            commandGatherPlayers.Connection = connection;
            connection.Open();
            commandGatherPlayers.CommandText = "SELECT * FROM tblActivePlayers";
            OleDbDataReader commandReader = commandGatherPlayers.ExecuteReader();
            string playerName = "";
            while (commandReader.Read())
            {
                playerName = commandReader["LastName"].ToString() + ", " +  commandReader["FirstName"].ToString() + " - #" + commandReader["JerseyNumber"].ToString();
                listActiveTeams.Items.Add(playerName);
            }
            connection.Close();
            commandReader.Close();
            OleDbCommand commandGatherArchives = new OleDbCommand();
            commandGatherArchives.Connection = connection;
            connection.Open();
            commandGatherArchives.CommandText = "SELECT * FROM tblArchivedPlayers";
            OleDbDataReader readerArchives = commandGatherArchives.ExecuteReader();
            string archiveName = "";
            while (readerArchives.Read())
            {
                archiveName = readerArchives["LastName"].ToString() + ", " + readerArchives["FirstName"].ToString() + " - #" + readerArchives["JerseyNumber"].ToString();
                listArchive.Items.Add(archiveName);
            }
            connection.Close();
            commandReader.Close();
            OleDbCommand commandGatherHistory = new OleDbCommand();
            commandGatherHistory.Connection = connection;
            connection.Open();
            commandGatherHistory.CommandText = "SELECT * FROM tblMatchHistory";
            OleDbDataReader readerHistory = commandGatherHistory.ExecuteReader();
            string historyName = "";
            while (readerHistory.Read())
            {
                historyName = readerHistory["TeamBracket"].ToString() + ", " + readerHistory["OpponentName"].ToString() + ", " + readerHistory["MatchDate"].ToString();
                listMatchHistory.Items.Add(historyName);
            }
            connection.Close();
            readerHistory.Close();
        }
        private void listActive_MouseClick(object sender, EventArgs e)
        {
            try
            {
                string[] selectedItem = listActiveTeams.SelectedItem.ToString().Split(',');
                selectedItem[0] = selectedItem[0].Trim();
                selectedItem[1] = selectedItem[1].Trim();
                OleDbCommand infoGather = new OleDbCommand();//new command
                infoGather.Connection = connection;//connect linked
                connection.Open();
                string idNum = "";
                string fName = "";
                for (int searchID = 0; searchID < selectedItem[1].Length; searchID++)
                {
                    if (selectedItem[1][searchID] == '-')
                    {
                        fName = selectedItem[1].Substring(0, searchID - 1);
                    }
                    if (selectedItem[1][searchID] == '#')
                    {
                        idNum = selectedItem[1].Substring(searchID + 1, selectedItem[1].Length - (searchID + 1));
                    }
                }
                infoGather.CommandText = "SELECT * FROM tblActivePlayers WHERE LastName = @LastName AND FirstName = @FirstName";// AND JerseyNumber = @JerseyNumber";
                infoGather.Parameters.AddWithValue("@LastName", selectedItem[0].Trim());
                infoGather.Parameters.AddWithValue("@FirstName", fName);
                //infoGather.Parameters.AddWithValue("@JerseyNumber", idNum);
                OleDbDataReader infoReader = infoGather.ExecuteReader();
                while (infoReader.Read())
                {
                    txtName.Text = infoReader["LastName"].ToString() + ", " + infoReader["FirstName"].ToString();
                    txtBasketballPosition.Text = infoReader["BasketballPosition"].ToString();
                    txtJerseyNumber.Text = idNum;
                    txtTeamBracket.Text = infoReader["TeamBracket"].ToString();
                    txtPTS_OVRL.Text = infoReader["PTS_OVRL"].ToString();
                    txtREB_OVRL.Text = infoReader["REB_OVRL"].ToString();
                    txtAST_OVRL.Text = infoReader["AST_OVRL"].ToString();
                    txtBLK_OVRL.Text = infoReader["BLK_OVRL"].ToString();
                    txtSTL_OVRL.Text = infoReader["STL_OVRL"].ToString();
                    txtTO_OVRL.Text = infoReader["TO_OVRL"].ToString();
                    txtTIPP_OVRL.Text = infoReader["TIPPASS_OVRL"].ToString();
                    txtFTMA_OVRL.Text = infoReader["FTMADE_OVRL"].ToString() + " : " + infoReader["FTATMP_OVRL"].ToString();
                    txt2PTMA_OVRL.Text = infoReader["TWOPTSMADE_OVRL"].ToString() + " : " + infoReader["TWOPTSATMP_OVRL"].ToString();
                    txt3PTMA_OVRL.Text = infoReader["THREEPTSMADE_OVRL"].ToString() + " : " + infoReader["THREEPTSATMP_OVRL"].ToString();
                    txtMIN_OVRL.Text = infoReader["MIN_OVRL"].ToString();
                    txtFTMA_OVRL.Text = infoReader["FTMADE_OVRL"].ToString() + " : " + infoReader["FTATMP_OVRL"].ToString();
                    txtFDRWCMT_OVRL.Text = infoReader["FDRW_OVRL"].ToString() + " : " + infoReader["FCMT_OVRL"].ToString();
                    txtPER_OVRL.Text = infoReader["PER_OVRL"].ToString();
                    string totalPoints = infoReader["PTS_OVRL"].ToString();
                    string totalGames = infoReader["GAMESPLAYED"].ToString();
                    bool totalGamesEqualsZero = false;
                    if (totalGames == "0")
                    {
                        totalGamesEqualsZero = true;
                        totalGames = "1";
                    }
                    int ppgCalc = int.Parse(totalPoints) / int.Parse(totalGames);
                    txtPPG_AVG.Text = ppgCalc.ToString();
                    string minPlayed = infoReader["MIN_OVRL"].ToString();
                    txtMIN_OVRL.Text = minPlayed;
                    if (minPlayed == "0")
                    {
                        minPlayed = "1";
                    }
                    int ppmCalc = (int.Parse(totalPoints) / int.Parse(minPlayed));
                    txtPPM_AVG.Text = ppmCalc.ToString();
                    string toCalc = infoReader["TO_OVRL"].ToString();
                    int TOAVGCalc = (int.Parse(toCalc) / int.Parse(totalGames));
                    txtTO_AVG.Text = TOAVGCalc.ToString();
                    string assistCalc = infoReader["AST_OVRL"].ToString();
                    int ASTAVGCalc = (int.Parse(assistCalc)) / (int.Parse(totalGames));
                    txtAST_AVG.Text = ASTAVGCalc.ToString();
                    string blkCalc = infoReader["BLK_OVRL"].ToString();
                    int BLKAVGCalc = (int.Parse(blkCalc) / int.Parse(totalGames));
                    txtBLK_AVG.Text = BLKAVGCalc.ToString();
                    string tipCalc = infoReader["TIPPASS_OVRL"].ToString();
                    int TIPAVGCalc = (int.Parse(tipCalc) / int.Parse(totalGames));
                    txtTIPP_AVG.Text = TIPAVGCalc.ToString();
                    string twoptCalcOne = infoReader["TWOPTSMADE_OVRL"].ToString();
                    string twoptCalcTwo = infoReader["TWOPTSATMP_OVRL"].ToString();
                    int TWOPTCalc = 0;
                    if (twoptCalcTwo == "0")
                    {
                        TWOPTCalc = (int.Parse(twoptCalcOne) / 1);
                    }
                    else
                    {
                        TWOPTCalc = (int.Parse(twoptCalcOne) / int.Parse(twoptCalcTwo));
                    }
                    txt2PT_AVG.Text = TWOPTCalc.ToString();
                    string threeptCalcOne = infoReader["THREEPTSMADE_OVRL"].ToString();
                    string threeptCalcTwo = infoReader["THREEPTSATMP_OVRL"].ToString();
                    int THREEPTCalc = 0;
                    if (threeptCalcOne == "0")
                    {
                        THREEPTCalc = (int.Parse(threeptCalcOne) / 1);
                    }
                    else
                    {
                        THREEPTCalc = (int.Parse(threeptCalcOne) / int.Parse(threeptCalcTwo));
                    }
                    txt3PT_AVG.Text = THREEPTCalc.ToString();
                    string stlCalc = infoReader["STL_OVRL"].ToString();
                    int STLCalc = (int.Parse(stlCalc) / int.Parse(totalGames));
                    txtSTL_AVG.Text = STLCalc.ToString();
                    string flsDRWCalc = infoReader["FDRW_OVRL"].ToString();
                    int FLSAVGCalc = (int.Parse(flsDRWCalc) / int.Parse(totalGames));
                    txtFLS_AVG.Text = FLSAVGCalc.ToString();
                    string freeThrowCalc1 = infoReader["FTMADE_OVRL"].ToString();
                    string freeThrowCalc2 = infoReader["FTATMP_OVRL"].ToString();
                    int FTAVGCalc = 0;
                    if (freeThrowCalc2 == "0")
                    {
                        FTAVGCalc = (int.Parse(freeThrowCalc1)) / 1;
                    }
                    else
                    {
                        FTAVGCalc =  (int.Parse(freeThrowCalc1)) / (int.Parse(freeThrowCalc2));
                    }
                    txtFT_AVG.Text = FTAVGCalc.ToString();
                    if (totalGamesEqualsZero == true)
                    {
                        totalGames = "0";
                    }
                }
                connection.Close();
                infoReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Note. No Player/Match selected, please try again by selecting a player on the list, thank you!");
            }
            
        }
        private void listArchive_MouseClick(object sender, EventArgs e)
        {
            try
            {
                string[] selectedItem = listArchive.SelectedItem.ToString().Split(',');
                selectedItem[0] = selectedItem[0].Trim();
                selectedItem[1] = selectedItem[1].Trim();
                OleDbCommand infoGather = new OleDbCommand();
                infoGather.Connection = connection;
                connection.Open();
                string idNum = "";
                string fName = "";
                for (int searchID = 0; searchID < selectedItem[1].Length; searchID++)
                {
                    if (selectedItem[1][searchID] == '-')
                    {
                        fName = selectedItem[1].Substring(0, searchID - 1);
                    }
                    if (selectedItem[1][searchID] == '#')
                    {
                        idNum = selectedItem[1].Substring(searchID + 1, selectedItem[1].Length - (searchID + 1));
                    }
                }
                infoGather.CommandText = "SELECT * FROM tblArchivedPlayers WHERE LastName = @LastName AND FirstName = @FirstName";// AND JerseyNumber = @JerseyNumber";
                infoGather.Parameters.AddWithValue("@LastName", selectedItem[0].Trim());
                infoGather.Parameters.AddWithValue("@FirstName", fName);
                //infoGather.Parameters.AddWithValue("@JerseyNumber", idNum);
                OleDbDataReader infoReader = infoGather.ExecuteReader();
                while (infoReader.Read())
                {
                    txtName.Text = infoReader["LastName"].ToString() + ", " + infoReader["FirstName"].ToString();
                    txtBasketballPosition.Text = infoReader["BasketballPosition"].ToString();
                    txtJerseyNumber.Text = idNum;
                    txtTeamBracket.Text = infoReader["TeamBracket"].ToString();
                    txtPTS_OVRL.Text = infoReader["PTS_OVRL"].ToString();
                    txtREB_OVRL.Text = infoReader["REB_OVRL"].ToString();
                    txtAST_OVRL.Text = infoReader["AST_OVRL"].ToString();
                    txtBLK_OVRL.Text = infoReader["BLK_OVRL"].ToString();
                    txtSTL_OVRL.Text = infoReader["STL_OVRL"].ToString();
                    txtTO_OVRL.Text = infoReader["TO_OVRL"].ToString();
                    txtTIPP_OVRL.Text = infoReader["TIPPASS_OVRL"].ToString();
                    txtFTMA_OVRL.Text = infoReader["FTMADE_OVRL"].ToString() + " : " + infoReader["FTATMP_OVRL"].ToString();
                    txt2PTMA_OVRL.Text = infoReader["TWOPTSMADE_OVRL"].ToString() + " : " + infoReader["TWOPTSATMP_OVRL"].ToString();
                    txt3PTMA_OVRL.Text = infoReader["THREEPTSMADE_OVRL"].ToString() + " : " + infoReader["THREEPTSATMP_OVRL"].ToString();
                    txtMIN_OVRL.Text = infoReader["MIN_OVRL"].ToString();
                    txtFTMA_OVRL.Text = infoReader["FTMADE_OVRL"].ToString() + " : " + infoReader["FTATMP_OVRL"].ToString();
                    txtFDRWCMT_OVRL.Text = infoReader["FDRW_OVRL"].ToString() + " : " + infoReader["FCMT_OVRL"].ToString();
                    txtPER_OVRL.Text = infoReader["PER_OVRL"].ToString();
                    string totalPoints = infoReader["PTS_OVRL"].ToString();
                    string totalGames = infoReader["GAMESPLAYED"].ToString();
                    bool totalGamesEqualsZero = false;
                    if (totalGames == "0")
                    {
                        totalGamesEqualsZero = true;
                        totalGames = "1";
                    }
                    int ppgCalc = int.Parse(totalPoints) / int.Parse(totalGames);
                    txtPPG_AVG.Text = ppgCalc.ToString();
                    string minPlayed = infoReader["MIN_OVRL"].ToString();
                    txtMIN_OVRL.Text = minPlayed;
                    if (minPlayed == "0")
                    {
                        minPlayed = "1";
                    }
                    int ppmCalc = (int.Parse(totalPoints) / int.Parse(minPlayed));
                    txtPPM_AVG.Text = ppmCalc.ToString();
                    string toCalc = infoReader["TO_OVRL"].ToString();
                    int TOAVGCalc = (int.Parse(toCalc) / int.Parse(totalGames));
                    txtTO_AVG.Text = TOAVGCalc.ToString();
                    string assistCalc = infoReader["AST_OVRL"].ToString();
                    int ASTAVGCalc = (int.Parse(assistCalc)) / (int.Parse(totalGames));
                    txtAST_AVG.Text = ASTAVGCalc.ToString();
                    string blkCalc = infoReader["BLK_OVRL"].ToString();
                    int BLKAVGCalc = (int.Parse(blkCalc) / int.Parse(totalGames));
                    txtBLK_AVG.Text = BLKAVGCalc.ToString();
                    string tipCalc = infoReader["TIPPASS_OVRL"].ToString();
                    int TIPAVGCalc = (int.Parse(tipCalc) / int.Parse(totalGames));
                    txtTIPP_AVG.Text = TIPAVGCalc.ToString();
                    string twoptCalcOne = infoReader["TWOPTSMADE_OVRL"].ToString();
                    string twoptCalcTwo = infoReader["TWOPTSATMP_OVRL"].ToString();
                    int TWOPTCalc = 0;
                    if (twoptCalcTwo == "0")
                    {
                        TWOPTCalc = (int.Parse(twoptCalcOne) / 1);
                    }
                    else
                    {
                        TWOPTCalc = (int.Parse(twoptCalcOne) / int.Parse(twoptCalcTwo));
                    }
                    txt2PT_AVG.Text = TWOPTCalc.ToString();
                    string threeptCalcOne = infoReader["THREEPTSMADE_OVRL"].ToString();
                    string threeptCalcTwo = infoReader["THREEPTSATMP_OVRL"].ToString();
                    int THREEPTCalc = 0;
                    if (threeptCalcOne == "0")
                    {
                        THREEPTCalc = (int.Parse(threeptCalcOne) / 1);
                    }
                    else
                    {
                        THREEPTCalc = (int.Parse(threeptCalcOne) / int.Parse(threeptCalcTwo));
                    }
                    txt3PT_AVG.Text = THREEPTCalc.ToString();
                    string stlCalc = infoReader["STL_OVRL"].ToString();
                    int STLCalc = (int.Parse(stlCalc) / int.Parse(totalGames));
                    txtSTL_AVG.Text = STLCalc.ToString();
                    string flsDRWCalc = infoReader["FDRW_OVRL"].ToString();
                    int FLSAVGCalc = (int.Parse(flsDRWCalc) / int.Parse(totalGames));
                    txtFLS_AVG.Text = FLSAVGCalc.ToString();
                    string freeThrowCalc1 = infoReader["FTMADE_OVRL"].ToString();
                    string freeThrowCalc2 = infoReader["FTATMP_OVRL"].ToString();
                    int FTAVGCalc = 0;
                    if (freeThrowCalc2 == "0")
                    {
                        FTAVGCalc = (int.Parse(freeThrowCalc1)) / 1;
                    }
                    else
                    {
                        FTAVGCalc = (int.Parse(freeThrowCalc1)) / (int.Parse(freeThrowCalc2));
                    }
                    txtFT_AVG.Text = FTAVGCalc.ToString();
                    if (totalGamesEqualsZero == true)
                    {
                        totalGames = "0";
                    }
                }
                connection.Close();
                infoReader.Close();
            }
            catch
            {
                MessageBox.Show("Note. No Player/Match selected, please try again by selecting a player on the list, thank you!");
            }
        }
        private void listMatchHistory_MouseClick(object sender, EventArgs e)
        {
            try
            {
                string[] selectedItem = listMatchHistory.SelectedItem.ToString().Split(',');
                selectedItem[1] = selectedItem[1].Trim();
                selectedItem[2] = selectedItem[2].Trim();
                OleDbCommand infoGather = new OleDbCommand();//new command
                infoGather.Connection = connection;//connect linked
                connection.Open();
                infoGather.CommandText = "SELECT * FROM tblMatchHistory WHERE OpponentName = @OpponentNameValue AND MatchDate = @MatchDateValue";
                infoGather.Parameters.AddWithValue("@OpponentNameValue", selectedItem[1]);
                infoGather.Parameters.AddWithValue("@FirstName", selectedItem[2]);
                OleDbDataReader infoReader = infoGather.ExecuteReader();
                while (infoReader.Read())
                {
                    MessageBox.Show("Match #" + infoReader["GameNumber"] + " Statistics :\n\nGame Verdict : " + infoReader["GameVerdict"] + "\nTeam Bracket : " + infoReader["TeamBracket"] + "\nVersus Naming : " + infoReader["OpponentName"] + "\nMatch Date : " + infoReader["MatchDate"].ToString() + "\nCourt Location : " + infoReader["CourtLocation"] + "\nTotal Points : " + infoReader["PTS_TEAM"]);
                }
                connection.Close();
                infoReader.Close();
            }
            catch
            {
                MessageBox.Show("Note. No Player/Match selected, please try again by selecting a player on the list, thank you!");
            }
        }
        private void mnuActiveTeamsUpdate_Click(object sender, EventArgs e)
        {
            frmTeamCreation frmTeamCreation = new frmTeamCreation();
            frmTeamCreation.Show();
        }
        private void mnuArchivedTeamsUpdate_Click(object sender, EventArgs e)
        {
            frmTeamCreation frmTeamCreation = new frmTeamCreation();
            frmTeamCreation.Show();
        }
    }
}
