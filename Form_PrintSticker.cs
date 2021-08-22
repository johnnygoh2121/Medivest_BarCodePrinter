using Medivest_BarCodePrinter.Helper;
using Medivest_BarCodePrinter.Models.Login.PrintSticker.Medivest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Medivest_BarCodePrinter
{
    public partial class Form_PrintSticker : Form
    {
        List<PortalItem> Items;
        DataTable dt = new DataTable();

        readonly string _printCellName = "isprint";
        readonly string _itemcode = "itemcode";
        
        // constructor
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
                    dgvItems.Columns[_printCellName].DisplayIndex = 0;
                    dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvItems.RowsDefaultCellStyle.BackColor = Color.Bisque;
                    dgvItems.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
                    dgvItems.RowHeadersVisible = false;

                    InitCboSearchFields(dgvItems);
                    InitiDataTable();
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void InitiDataTable()
        {
            try
            {
                // get ready the datatable 
                //Adding the Columns.
                dt = new DataTable();
                foreach (DataGridViewColumn column in dgvItems.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Adding the Rows.
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = $"{cell.Value}";
                    }
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void InitCboSearchFields(DataGridView dgv)
        {
            try
            {
                if (dgv == null) return;

                // 20210822T1108
                // fill in the property field for user selection 
                
                var columns = new List<string>();
                for (int c = 0; c < dgvItems.Columns.Count; c++)
                {
                    var column_name = dgvItems.Columns[c].HeaderText;
                    if (string.IsNullOrWhiteSpace(column_name)) continue;
                    columns.Add(column_name);
                }

                cbxSearchField.DataSource = columns;
                if (cbxSearchField.Items == null) return;

                if (cbxSearchField.Items.Count > 0)
                {
                    cbxSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbxSearchField.SelectedIndex = 0;
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
                if (printerList.Count == 0) return;

                // 20200818T0917 
                // hard code the printer name 
                int locId = printerList.FindIndex(x => x.ToLower().Contains("ZDesigner ZD230-203dpi ZPL".ToLower()));
                if (locId > printerList.Count) return;
                cboPrinterNames.SelectedIndex = locId;
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (dgvItems == null) return;
                if (dgvItems.Rows == null) return;
                if (dgvItems.Rows.Count == 0) return;

                if (dgvItems.CurrentRow == null) return;
                var index = dgvItems.CurrentRow.Index;

                var setValue = (bool)dgvItems.Rows[index].Cells[_printCellName].Value;
                dgvItems.Rows[index].Cells[_printCellName].Value = !setValue;
                dgvItems.Rows[index].Selected = true;

                // update the main source s
                if (Items == null) return;

                var itemCode = $"{dgvItems.Rows[index].Cells[_itemcode].Value}";
                if (string.IsNullOrWhiteSpace(itemCode)) return;

                var listIdx = Items.FindIndex(x => x.itemcode.Equals(itemCode));

                if (listIdx < 0) return;
                Items[listIdx].isprint = !setValue;
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cbxSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItems == null) return;
                if (dgvItems.Rows == null) return;
                if (dgvItems.Rows.Count == 0) return;

                Cursor.Current = Cursors.WaitCursor;
                if (dgvItems.Rows.Count < 0) return;

                for (int x = 0; x < dgvItems.Rows.Count; x++)
                {
                    dgvItems.Rows[x].Cells[_printCellName].Value = (bool)cbxSelectAll.Checked;

                    // update the main sources
                    if (Items == null) continue;

                    var itemCode = $"{dgvItems.Rows[x].Cells[_itemcode].Value}";
                    if (string.IsNullOrWhiteSpace(itemCode)) return;

                    var listIdx = Items.FindIndex(x => x.itemcode.Equals(itemCode));
                    if (listIdx < 0) continue;

                    Items[listIdx].isprint = (bool)cbxSelectAll.Checked;
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void brnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (Items == null) return;
                if (Items.Count == 0) return;

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
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void HandlerSearch()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cbxSearchField.Text))
                {
                    MessageBox.Show("Search field selected invalid.");
                    cbxSearchField.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbSearcgVal.Text))
                {
                    dgvItems.DataSource = Items;
                    tbSearcgVal.Focus();
                    return;
                }

                var dtView = dt.DefaultView;
                dtView.RowFilter =
                        string.Format(cbxSearchField.Text + " LIKE '%{0}%'", tbSearcgVal.Text);

                dgvItems.DataSource = dtView;
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            HandlerSearch();
        }

        private void cbxSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearcgVal.Focus();
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                HandlerSearch();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbSearcgVal.Text = "";
            tbSearcgVal.Focus();
            HandlerSearch();
        }
    }
}
