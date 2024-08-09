using SqlViewer.Dal;
using SqlViewer.Models;
using System.Data;

namespace SqlViewer.View
{
    public partial class MainForm : Form
    {
        private const string FileFilter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
        private const string FileName = "{0}.xml";

        private List<Database>? databases;
        private Database? database;
        private DBEntity? dbEntity;
        private enum TagType
        {
            Databases, Tables, Views, Procedures
        }
        public MainForm()
        {
            InitializeComponent();
            LoadDatabases();
            InitTreeView();
            ClearForm();
        }

        private void LoadDatabases() => databases = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());

        private void InitTreeView()
        {
            // we need empty so it is expandable
            var databaseNode = new TreeNode(TagType.Databases.ToString(), new[] { new TreeNode() }) { Tag = TagType.Databases };
            _ = twServer?.Nodes.Add(databaseNode);
        }

        private void ClearForm()
        {
            tbContent.Text = string.Empty;
            tsbSelect.Enabled = false;
            tsbXML.Enabled = false;
            dbEntity = null;
        }

        private void TsbSelect_Click(object sender, EventArgs e)
        {
            if (dbEntity == null)
            {
                return;
            }
            DataSet ds = RepositoryFactory.GetRepository().CreateDataSet(dbEntity);
            new SelectResultsForm(ds.Tables[0]).ShowDialog();
        }

        private void TsbXML_Click(object sender, EventArgs e)
        {
            if (dbEntity == null)
            {
                return;
            }
            var dialog = new SaveFileDialog
            {
                FileName = string.Format(FileName, dbEntity.Name),
                Filter = FileFilter
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = RepositoryFactory.GetRepository().CreateDataSet(dbEntity);
                ds.WriteXml(dialog.FileName, XmlWriteMode.WriteSchema);
            }
        }

        private void TwServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is null || databases == null)
            {
                return;
            }
            ClearForm();
            twServer.BeginUpdate();

            switch (e.Node)
            {
                case { Tag: TagType.Databases }:
                    e.Node.Nodes.Clear();
                    databases.ForEach(db => e.Node.Nodes.Add(new TreeNode(db.ToString(), new[] { new TreeNode() }) { Tag = db }));
                    break;
                case { Tag: Database db }:
                    e.Node.Nodes.Clear();
                    e.Node.Nodes.Add(new TreeNode(TagType.Tables.ToString(), new[] { new TreeNode() }) { Tag = TagType.Tables });
                    e.Node.Nodes.Add(new TreeNode(TagType.Views.ToString(), new[] { new TreeNode() }) { Tag = TagType.Views });
                    e.Node.Nodes.Add(new TreeNode(TagType.Procedures.ToString(), new[] { new TreeNode() }) { Tag = TagType.Procedures });
                    break;
                case { Tag: TagType.Tables }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?.Tables.ToList().ForEach(table => e.Node.Nodes.Add(new TreeNode(table.ToString(), new[] { new TreeNode() }) { Tag = table }));
                    break;

                case { Tag: TagType.Views }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?.Tables.ToList().ForEach(table => e.Node.Nodes.Add(new TreeNode(table.ToString(), new[] { new TreeNode() }) { Tag = table }));
                    database?.Views.ToList().ForEach(view => e.Node.Nodes.Add(new TreeNode(view.ToString(), new[] { new TreeNode() }) { Tag = view }));
                    
                    break;

                case { Tag: TagType.Procedures }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?.Procedures.ToList().ForEach(proc => e.Node.Nodes.Add(new TreeNode(proc.ToString(), new[] { new TreeNode() }) { Tag = proc }));
                    break;
                case { Tag: DBEntity entity }:
                    e.Node.Nodes.Clear();
                    dbEntity = entity;
                    entity.Columns.ToList().ForEach(column => e.Node.Nodes.Add(new TreeNode(column.ToString())));
                    tsbSelect.Enabled = true;
                    tsbXML.Enabled = true;
                    break;
                case { Tag: Procedure procedure }:
                    e.Node.Nodes.Clear();
                    tbContent.Text = procedure.Definition;
                    procedure.Parameters.ToList().ForEach(param => e.Node.Nodes.Add(new TreeNode(param.ToString())));
                    break;
            }

            twServer.EndUpdate();
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            // Get the SQL query from the tbContent textbox
            string sqlQuery = tbContent.Text;

            // Ensure the query is not empty
            if (string.IsNullOrWhiteSpace(sqlQuery))
            {
                MessageBox.Show("Please enter a valid SQL statement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // If the SQL query is a SELECT statement, execute it and display the results
                if (sqlQuery.Trim().Contains("SELECT", StringComparison.OrdinalIgnoreCase))
                {
                    // Execute the SELECT query and get the results as a DataTable
                    DataTable results = RepositoryFactory.GetRepository().ExecuteSelectCommand(sqlQuery);

                    // Check if the results contain any rows
                    if (results.Rows.Count > 0)
                    {
                        // Instantiate and display the SelectResultsForm with the results
                        SelectResultsForm resultsForm = new SelectResultsForm(results);
                        resultsForm.ShowDialog();  // Display the form modally
                    }
                    else
                    {
                        MessageBox.Show("The query did not return any results.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // For non-SELECT queries (INSERT, UPDATE, DELETE), execute the command
                    int affectedRows = RepositoryFactory.GetRepository().ExecuteCustomCommand(sqlQuery);
                    tbDisplayOnly.Text = $"Query executed successfully. Rows affected: {affectedRows}";
                }
            }
            catch (Exception ex)
            {
                tbDisplayOnly.Text = $"Error executing query: {ex.Message}";
            }
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void TwServer_AfterCollapse(object sender, TreeViewEventArgs e) => ClearForm();
    }
}