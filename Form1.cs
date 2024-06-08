using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PovaIgor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            var select = "SELECT * FROM Dentista";
            var c = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvCadastro.DataSource = ds.Tables[0];

            select = "SELECT * FROM Cliente";
            c = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True"); // Your Connection String here
            dataAdapter = new SqlDataAdapter(select, c);

            commandBuilder = new SqlCommandBuilder(dataAdapter);
            ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvCliente.DataSource = ds.Tables[0];
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private void button2_Click(object sender, EventArgs e)
        {
            tbxNomeCliente.Text = string.Empty;
            tbxEmail.Text = "email@mail.com";
            mtbTelefone.Text = string.Empty;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            tbxEmail.Text = string.Empty;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (tbxEmail.Text == string.Empty)
            {
                tbxEmail.Text = "email@mail.com";
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpar1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");

            {
                SqlCommand cmd = new($"INSERT INTO Dentista(Nome, Consultorio, Disponivel, Horario, Dia) VALUES ('{tbxNomeDr.Text}', {int.Parse(mtbConsultorio.Text.Trim())}, 1, '{cbxHorario1.Text}', '{mclCadastro.SelectionRange.Start.ToShortDateString()}')", conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente registrado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao mandar as informações para o banco de dados:\n" + ex.ToString());

                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void bntReagendar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            SqlCommand cmdGet = new($"SELECT Cod, Disponivel FROM Doutor WHERE Nome = {cbxMedico.SelectedText} AND Horario = {cbxHorario.SelectedText} AND Dia = {mclCliente.SelectionRange.Start.Date}");

            int CodDoutor = 0;
            bool Disponivel = false;

            try
            {
                SqlDataReader dr = cmdGet.ExecuteReader();
                CodDoutor = (int)dr["Cod"];
                Disponivel = (bool)dr["Disponivel"];
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao puxar as informações do banco de dados:\n" + ex.Message);
            }

            if (Disponivel)
            {
                SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
                if (int.TryParse(mtbTelefone.Text, out int Telefone))
                {
                    SqlCommand cmd = new($"INSERT INTO Cliente(Nome, Telefone, Email, Dentista) VALUES ('{tbxNomeCliente.Text}', {Telefone}, '{tbxEmail.Text}', {CodDoutor}), UPDATE Dentista SET Disponivel = 0 WHERE Cod = {CodDoutor}", conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cliente registrado!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao mandar as informações para o banco de dados:\n" + ex.Message);

                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        private void dgvCadastro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");

            {
                SqlCommand cmd = new($"UPDATE Dentista SET Nome = '{dgvCadastro.Rows[e.RowIndex].Cells[1].Value}', Consultorio = {Convert.ToInt32(dgvCadastro.Rows[e.RowIndex].Cells[2].Value)}, Disponivel = {Convert.ToInt32(dgvCadastro.Rows[e.RowIndex].Cells[3].Value)}, Horario = '{dgvCadastro.Rows[e.RowIndex].Cells[4].Value}', Dia = '{dgvCadastro.Rows[e.RowIndex].Cells[5].Value}' WHERE Cod = {Convert.ToInt32(dgvCadastro.Rows[e.RowIndex].Cells[0].Value)}", conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente Modificado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao mandar as informações para o banco de dados:\n" + ex.Message);

                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}