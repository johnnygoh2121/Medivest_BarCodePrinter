using Medivest_BarCodePrinter.Helper;
using Medivest_BarCodePrinter.Models.Login.PrintSticker.Medivest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Medivest_BarCodePrinter
{
    public partial class Form_PrintSticker : Form
    {
        List<PortalItem> Items;
        readonly string _printCellName = "isprint";
        public Form_PrintSticker()
        {
            InitializeComponent();
        }

        void FixedToScreen()
        {
            // StartPosition was set to FormStartPosition.Manual in the properties window.
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(w, h);
        }

        void InitScreen()
        {
            tbWhs.Text = Program.LogonUser.whsCode;
        }

        void LoadWhsItem()
        {
            try
            {
                var info = new Info();
                var address = $"{info.BaseAdd}{info.Get_Whsitem}{Program.LogonUser.whsCode}";

                var client = new RestClient(address);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var isValidJson = IsValidJson(response.Content);

                if (response.IsSuccessful && isValidJson)
                {
                    Items = JsonConvert.DeserializeObject<List<PortalItem>>(response.Content);
                    dgvItems.DataSource = Items;
                    dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvItems.AllowUserToResizeColumns = false;
                    dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dgvItems.Columns["isprint"].DisplayIndex = 0;
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        void GetListOfPrinter()
        {
            try
            {
                var printerList = new List<string>();
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    printerList.Add(printer);
                }

                cboPrinterNames.DataSource = printerList;
                if (printerList.Count == 0)
                {
                    return;
                }

                // 20200818T0917 
                // hard code the printer name 
                int locId = printerList.FindIndex(x => x.ToLower().Contains("ZDesigner ZD230-203dpi ZPL".ToLower()));
                if (locId <= printerList.Count)
                {
                    cboPrinterNames.SelectedIndex = locId;
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void Form_PrintSticker_Load(object sender, EventArgs e)
        {
            FixedToScreen();
            InitScreen();
            LoadWhsItem();
            GetListOfPrinter();
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dgvItems == null) return;
            if (dgvItems.Rows == null) return;
            if (dgvItems.Rows.Count == 0) return;

            if (dgvItems.CurrentRow == null) return;
            var index = dgvItems.CurrentRow.Index;

            var setValue = (bool)dgvItems.Rows[index].Cells[_printCellName].Value;
            dgvItems.Rows[index].Cells[_printCellName].Value = !setValue;
            Cursor.Current = Cursors.Default;
        }

        private void cbxSelectAll_Click(object sender, EventArgs e)
        {
            if (dgvItems == null) return;
            if (dgvItems.Rows == null) return;
            if (dgvItems.Rows.Count == 0) return;

            Cursor.Current = Cursors.WaitCursor;

            if (dgvItems.Rows.Count > 0)
            {
                for (int x = 0; x < dgvItems.Rows.Count; x++)
                {
                    dgvItems.Rows[x].Cells[_printCellName].Value = (bool)cbxSelectAll.Checked;
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void tbSearcgVal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (dgvItems == null) return;
                if (dgvItems.Rows == null) return;
                if (dgvItems.Rows.Count == 0) return;

                if (Items == null) return;
                if (string.IsNullOrWhiteSpace(tbSearcgVal.Text)) return;

                var queryLowCs = tbSearcgVal.Text;
                var filter = Items.Where(i => $"{i.itemcode}".ToLower().Contains(queryLowCs) ||
                                               $"{i.itemname}".ToLower().Contains(queryLowCs) ||
                                               $"{i.model}".ToLower().Contains(queryLowCs) ||
                                               $"{i.brand}".ToLower().Contains(queryLowCs) ||
                                               $"{i.uom}".ToLower().Contains(queryLowCs)
                                               ).ToList();
                
                if (filter == null) return;
                if (filter.Count == 0) return;

                dgvItems.DataSource = filter;
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void brnPrint_Click(object sender, EventArgs e)
        {

            if (Items == null)
            {
                return;
            }
            if (Items.Count == 0)
            {
                return;
            }

            var printedItems = Items.Where(x => x.isprint == true).ToList();
            if (printedItems == null)
            {
                MessageBox.Show($"0 item selected for print sticker", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (printedItems.Count == 0)
            {
                MessageBox.Show($"0 item selected for print sticker", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(cboPrinterNames.Text))
            {
                MessageBox.Show($"Please select a printer to print sticker.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var frm = new Form_ConfirmPrintSticker(cboPrinterNames.Text, printedItems);
            frm.ShowDialog(this);
        }
    }
}
