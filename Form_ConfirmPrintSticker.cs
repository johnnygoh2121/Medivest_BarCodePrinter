using Medivest_BarCodePrinter.Helper;
using Medivest_BarCodePrinter.Models.Login.PrintSticker.Medivest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Medivest_BarCodePrinter
{
    public partial class Form_ConfirmPrintSticker : Form
    {
        List<PortalItem> Items { get; set; }
        string Printer { get; set; }
        readonly int maxWidth = 39;

        public Form_ConfirmPrintSticker(string printer, List<PortalItem> list)
        {
            InitializeComponent();
            Items = list;
            dgvItems.DataSource = Items;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.AllowUserToResizeColumns = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvItems.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dgvItems.RowHeadersVisible = false;

            dgvItems.ReadOnly = true;
            Printer = printer;
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            // hadler printer
            Cursor.Current = Cursors.WaitCursor;
            for (int i =0; i < Items.Count; i ++ )
            {
                var layout = $"^XA"+ 
                            $"~DGR:MDVLOGO.GRF,2926,38,N0I4iR0A92948iO050484A4iN028A9291iO0852492H05iL0252494H028iL01292I01H45iQ014908iQ08A42H4iO0A510489iI08J0A4941212iH012902A52404824iH024A5H4890128904iG04A4HA9240491412iG0252414A82A4I28i015152C280490484iH04C892A0124120208i012549H04A849191iI0A4H02A90A4240AiL0914H104852L02L04H0K50I5K01414K0502JAH05E802JAH0A8J054A02A12024V02DB6D02DAECI0140AK0A02DB6DH0HA8036DB6H05280154A90920A0928K03L0CH06JA0K58I080AK0A02IAB02D5602JA014AH54HAH42A854149L01L04H02AI505KAH01405J01402IA90341B02AH54H0A9525H2A849050H24L028J018H05K05I06AH018068I014028J048048H05I024A9549520A4128H528K05L0CH05K028I0D8H0C028I014028J03H03I05I0124A92A90254290H894K038J032H02K05J02801H028I02803K05L05I02HA94HA40948H40524L04CJ01AH05K05J02CH0C028I03H018J05L02I01H54HA502520A82892CK06AJ06AH05K05J014014014I05H028J05L05J024A95H0954128154A2K02AJ02AH05K03K0A014014I05H028J028K06K02A5H02528490AH294K0H5J0D4H02K05K0B014H0EI0AH03K03L03P0IA054054A49K0H5J04AH05K05K05H08H09I0AH028J02CK05O0HA941541H2924K0A28H01HAH05K028J05014H06H014H028J016K02I0D4I0HA95029054A492K0A3J085H05K05K02818H05I0AH028K0BK05I02BJAI504A0H29249K0414H0345H02ADH5058J05H0CH05H02CH03J5H05CJ05I0A8KA521H509H4954K0A18H0106H05B5B605K0281I028028H02ADB6H016J05I0KA95482A8152A5H2K0A0CH0582H0K5028J03H0CH028028H02BI5I0A8I02I02K52A049024A5495K0A06H0505H05K05K01814H01C05I028L058I07I0HA924HA81H505251248K0A0AH0A05H02K05K02814I0805I03M02EI01I0L5402HA08A8A925J01405H0602805K05K05014H0160AI028L012I06I0L5H0A541525H4HAK080281805H06K03K05808I0A0AI028M0BI03I054IA802HA8H294HA91J01403H0C02803K05K0501CI050CI028M058H05I0I548H0IA054AH2H4AJ0180142802804K05K05H04I0614I028M024H05O03H540252A92A4K0C0182802803K028J0A018I0294I03N018H02N014HA815294HA52J014H0C5H01H05K05K0AH0CI0528I028M028H05N0IA5029H4A4915J014H065H03805K058I014014I02BJ028J04H014H05M0KA04AH5124C8J028H0HAI0802K05J02A014I01A8I028J08H02CH05K05KA80A52JA24J01I056H02805K028I054H08I015J028I016H03I02I056LA0252A124954J038H028H01405K05I0158014I016J028J0AH048H07I02MA01491H525H2K08H034H01805K05H016DH018J0AJ03K0580BI01I02LA80D2IA4A954J03I014I0C02B5AD05DBD54I0CJ0AJ02DI506AH5I06I01K54024A4A5294H8J028H018H01406D6B402AC5A8H01K04J02ADB6015HAI03I02KA805295294AH5K028L01402IAB0H57A8J0CJ04J02BH5BH0D58I05I01K5012IA94A5248hM02CO0JA80294A4A52952hY0JAH095292529495hY0H56H02IAH54A52A4hY05AI0951I5294A52iI0252A492A52928iH01H54IA954A548iG01K524A4A94A4i0IA9252JA9529iG0K54AH52H54A5iG02A92JA4A92H54iG012H52I52A4HA9iI0KA49J5248iH0HA9K52A895iI02A52954A926HAiI01J5254HA95iK0H54KA952iK02HA95492528iK012H52J548iL0M54AiM0152HA4928iN02A9I54iP0H52A8iS0AmH0 "+ 
                            $"^FX logo display "+ 
                            $"^FO240,30 "+ 
                            $"^XGR:MDVLOGO.GRF "+ 
                            $"^FS"+ 
                            $"^FX barcode display "+ 
                            $"^BY5,2,90 "+ 
                            $"^FO66,120 "+ 
                            $"^BC"+ 
                            $"^FD{Items[i].itemcode}"+ 
                            $"^FS"+                             
                            $"^FX Item name display "+ 
                            $"^CFA,30";

                var blockDisplay = BlockFormat(Items[i].itemname);
                if (blockDisplay != null && blockDisplay.Length > 0)
                {
                    var starting = 270;
                    for(int b = 0; b < blockDisplay.Length; b ++)
                    {
                        layout += $"^FO30,{starting}^FD{blockDisplay[b]}^FS";
                        starting += 30;
                    }
                    layout += "^XZ";
                }
                
                RawPrinterHelper.SendStringToPrinter(Printer, layout);
            }

            MessageBox.Show($"Done", "Print sticker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Close();
            Cursor.Current = Cursors.Default;
        }

        string[] BlockFormat(string lines)
        {
            try
            {
                var results = new List<string>();
                var result = string.Empty;

                lines = lines.Replace("\n", ""); // replce all new line feed
                var words = lines.Split(' ');

                for (int x = 0; x < words.Length; x++)
                {
                    if ((result.Length + $"{words[x]} ".Length) <= maxWidth)
                    {
                        result += $"{words[x]} ";
                    }
                    else
                    {
                        results.Add(result);
                        result = $"{words[x]} ";
                    }
                }

                if (!string.IsNullOrWhiteSpace(result) && result.Length <= maxWidth)
                {
                    results.Add(result);
                }

                return results.ToArray();
            }
            catch (Exception excep)
            {
                MessageBox.Show($"{excep.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
