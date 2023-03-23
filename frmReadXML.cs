using System.Data;
using System.Xml.Serialization;

namespace ReadXML
{
    public partial class frmReadXML : Form
    {
        Lists lists;
        DataTable dt;
        DataGridView dgv;
        Value valueSelected;

        public frmReadXML()
        {
            InitializeComponent();
            MessageBox.Show(txtCompany.Location.ToString() + Environment.NewLine + txtCompany.Top.ToString() + Environment.NewLine + txtCompany.Left.ToString());
            //lists = new Lists();
            //lists.ListValues = new List<ListValue>();
            //ListValue l1 = new ListValue { Name = "Empresas" };
            //ListValue l2 = new ListValue { Name = "Status" };

            //lists.ListValues.Add(l1);
            //lists.ListValues.Add(l2);

            //string filePath = @"C:\GitProjects\ReadXML\ReadXML\TestFiles\SerializeFile.xml";

            //XmlSerializer ser = new XmlSerializer(typeof(Lists));
            //TextWriter writer = new StreamWriter(filePath);
            //ser.Serialize(writer, lists);
            //writer.Close();
        }

        #region Events

        #region Buttons

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;

            using (OpenFileDialog ofd = new())
            {
                ofd.Title = "Select admin file";
                ofd.DefaultExt = "xml";
                ofd.Filter = "XML Files (*.xml) | *.xml";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    strFilePath = ofd.FileName;
                    btnLoad.Enabled = true;
                }
            }

            txtPath.Text = strFilePath;

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                throw new Exception("Should select a file.");
            }

            string text = File.ReadAllText(txtPath.Text);

            rtxFileLoaded.Text = text;
            btnDeserialize.Enabled = true;
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            try
            {
                lists = Deserializer.Load<Lists>(txtPath.Text);

                if (lists.ListValues.Count == 0)
                    throw new Exception("The lists are empty.");

                txtCompany.Enabled = true;
                txtStatus.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "A error has ocurred");
            }
        }

        #endregion

        #region TextBox

        // txtCompany
        private void txtCompany_Enter(object sender, EventArgs e)
        {
            ShowDataGrid(txtCompany);
        }

        private void txtCompany_Leave(object sender, EventArgs e)
        {
            Control ctr = GetControl(txtCompany.Tag.ToString().Split(':')[1]);

            if (valueSelected != null)
            {
                txtCompany.Text = valueSelected.Description;
                ctr.Text = valueSelected.ValueId;

                valueSelected = null;
            }

            CleanDataGrid();
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            FilterDataGrid(txtCompany);
        }

        private void txtCompany_KeyDown(object sender, KeyEventArgs e)
        {
            MoveRowDataGrid(e);
        }

        // txtStatus
        private void txtStatus_Enter(object sender, EventArgs e)
        {
            ShowDataGrid(txtStatus);
        }

        private void txtStatus_Leave(object sender, EventArgs e)
        {
            Control ctr = GetControl(txtStatus.Tag.ToString().Split(':')[1]);

            if (valueSelected != null)
            {
                txtStatus.Text = valueSelected.Description;
                ctr.Text = valueSelected.ValueId;

                valueSelected = null;
            }

            CleanDataGrid();
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            FilterDataGrid(txtStatus);
        }

        private void txtStatus_KeyDown(object sender, KeyEventArgs e)
        {
            MoveRowDataGrid(e);
        }

        #endregion

        #endregion

        #region Methods

        private void ShowDataGrid(TextBox txt)
        {
            try
            {
                // Checking Tag
                string tag = txt.Tag.ToString();

                if (string.IsNullOrEmpty(tag))
                    throw new Exception("The confguration of the field is incorrect.");

                // Searching List
                ListValue listValue = SelectList(tag.Split(':')[0]);

                if (listValue.Name != tag.Split(':')[0])
                    throw new Exception(string.Format("The list [{0}] does not exist in the configuration file.", tag.Split(':')[0]));

                // Create Data Grid
                dgv = CreateDataGrid(listValue, txt);
                dgv.Columns[0].Width = 24;
                dgv.BringToFront();
                dgv.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Label GetControl(string name)
        {
            Label lbl = new Label();
            lbl.Name = "lbl";

            foreach (Label ctrl in this.Controls.OfType<Label>())
            {
                if (ctrl.Name == name)
                {
                    lbl = ctrl;
                }
            }

            return lbl;
        }

        private ListValue SelectList(string listName)
        {
            ListValue retval = null;

            //foreach (ListValue listValue in lists.ListValues)
            //{
            //    if (listValue.Name == listName)
            //    {
            //        retval = listValue;
            //        break;
            //    }
            //}

            return retval;
        }

        private DataGridView CreateDataGrid(ListValue listValue, TextBox txt)
        {
            DataGridView dgv = new DataGridView();

            // Location
            Point txtLocation = txt.Location;
            Point dgvLocation = new Point(txtLocation.X, txtLocation.Y + txt.Height);
            dgv.Location = dgvLocation;

            // Size
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Width = txt.Width + 15;
            dgv.Height = txt.Height * 5;

            // Design
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ScrollBars = ScrollBars.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersVisible = false;

            // DataSource
            dgv.DataSource = null;
            dt = CreateDataTable(listValue);
            dgv.DataSource = dt;

            // Add Control
            this.Controls.Add(dgv);

            return dgv;
        }

        private DataTable CreateDataTable(ListValue listValue)
        {
            DataTable dt = new DataTable();

            //dt.Columns.Add("Id", typeof(string));
            //dt.Columns.Add(listValue.Name, typeof(string));

            //foreach (Value value in listValue.Values)
            //{
            //    DataRow row = dt.NewRow();
            //    row[0] = value.ValueId;
            //    row[1] = value.Description;

            //    dt.Rows.Add(row);
            //}

            return dt;
        }

        private void CleanDataGrid()
        {
            dgv.Visible = false;
        }

        private void MoveRowDataGrid(KeyEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                int row = dgv.SelectedCells[0].RowIndex;

                if (e.KeyCode == Keys.Down)
                {
                    if (row < (dgv.RowCount - 1))
                    {
                        dgv.ClearSelection();
                        dgv.Rows[row + 1].Selected = true;
                    }
                }

                if (e.KeyCode == Keys.Up)
                {
                    if (row > 0)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[row - 1].Selected = true;
                    }
                }

                if (e.KeyCode == Keys.Enter)
                {
                    valueSelected = new Value
                    {
                        ValueId = dgv.SelectedCells[0].Value.ToString(),
                        Description = dgv.SelectedCells[1].Value.ToString()
                    };

                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void FilterDataGrid(TextBox txt)
        {
            string listName = txt.Tag.ToString().Split(':')[0];

            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("Id LIKE '%{0}%' OR {1} LIKE '%{0}%'", txt.Text, listName);

        }

        #endregion

    }
}