using System.Data;
using System.Data.SqlClient;

namespace BusquedaSelectivaDataGridView
{
    public partial class Form1 : Form
    {
        private DataTable dataTable;


        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string sCnn = "Server=localhost;Database=pruebaDB;Integrated Security=True;";
            string sSel = "SELECT * FROM Prueba ORDER BY ID";

            using (SqlConnection connection = new SqlConnection(sCnn))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sSel, connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            ResetCellStyles();

            if (!string.IsNullOrEmpty(textSearch.Text))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().IndexOf(textSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                            cell.Style.BackColor = Color.Red;
                    }
                }
            }
        }

        private void ResetCellStyles()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Style.BackColor = Color.White;
            }
        }
    }
}
