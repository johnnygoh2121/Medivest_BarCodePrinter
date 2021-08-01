using Medivest_BarCodePrinter.Helper;
using Medivest_BarCodePrinter.Models.Login.Medivest;
using Medivest_BarCodePrinter.Models.Replied.Medivest;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Medivest_BarCodePrinter
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbUserId.Text))
                {
                    MessageBox.Show($"Invalid user id", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbPw.Text))
                {
                    MessageBox.Show($"Invalid user password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                // Do something here  

                var info = new Info();
                var adressEndPoint = $"{tbServerAddr.Text}{info.Post_LoginEnPoint}"; //info.BaseAdd + info.Post_LoginEnPoint;

                var param = new { code = tbUserId.Text, password = tbPw.Text };
                var json = JsonConvert.SerializeObject(param);

                var client = new RestClient(adressEndPoint);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var isSuccess = response.IsSuccessful;

                if (isSuccess)
                {
                    // if connected svr address user entry diff. from the currently save
                    if (!tbServerAddr.Text.Equals(Program.SvrBaseAddress))
                    {
                        var dialogResult = MessageBox.Show("Save this new address", $"{tbServerAddr.Text}", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {   
                            var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                            config.AppSettings.Settings.Remove("svr");

                            config.AppSettings.Settings.Add("svr", tbServerAddr.Text);
                            config.Save(ConfigurationSaveMode.Minimal);
                        }                        
                    }

                    Program.LogonUser = JsonConvert.DeserializeObject<UserProfile>(response.Content);
                    var formMain = new Form_PrintSticker();
                    formMain.Show(this);
                    return;
                }

                var failObject = JsonConvert.DeserializeObject<PortalReplied>(response.Content);
                if (failObject == null)
                {
                    MessageBox.Show($"{failObject.message} [NO]", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show($"{failObject.message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void tb_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb == null) return;

            if (!string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            tbServerAddr.Text = Program.SvrBaseAddress;
        }
    }
}
