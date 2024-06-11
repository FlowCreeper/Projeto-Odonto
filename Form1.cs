using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace PovaIgor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            UpdateDGV();


        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void UpdateDGV()
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            SqlCommand cmd = new("SELECT Nome From Dentista", conn);

            try
            {
                cbxMedico.Items.Clear();
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!cbxMedico.Items.Contains(reader["Nome"].ToString()))
                        cbxMedico.Items.Add(reader["Nome"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao puxar as informações do banco de dados:\n" + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            try
            {
                var select = "SELECT * FROM Dentista";
                var c = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True"); // Your Connection String here
                var dataAdapter = new SqlDataAdapter(select, c);


                _ = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dgvCadastro.DataSource = ds.Tables[0];

                select = "SELECT * FROM Cliente";
                c = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True"); // Your Connection String here
                dataAdapter = new SqlDataAdapter(select, c);

                _ = new SqlCommandBuilder(dataAdapter);
                ds = new DataSet();
                dataAdapter.Fill(ds);
                dgvCliente.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao pegar informações do banco de dados: " + ex.Message);
            }
        }

        static private DataTable SqlReader(string query)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            SqlDataAdapter sqlDataAdapter = new(query, conn);
            DataSet ds = new();
            DataTable dt = new();

            try
            {
                _ = new SqlCommandBuilder(sqlDataAdapter);

                sqlDataAdapter.Fill(ds);

                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao pegar informações do banco de dados: " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return dt;
        }

        private void btnLimpar1_Click(object sender, EventArgs e)
        {
            tbxNomeDr.Clear();
            mtbConsultorio.Clear();
            cbxHorario1.SelectedItem = null;
            mclCliente.SelectionStart = DateTime.Now;
            mclCliente.SelectionEnd = DateTime.Now;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");

            {
                SqlCommand cmd = new($"INSERT INTO Dentista(Nome, Consultorio, Disponivel, Horario, Dia) VALUES ('{tbxNomeDr.Text}', {int.Parse(mtbConsultorio.Text.Trim())}, 1, '{cbxHorario1.Text}', '{mclCadastro.SelectionStart.ToShortDateString()}')", conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Horário registrado!");
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
                    UpdateDGV();
                }
            }
        }

        private void bntReagendar_Click(object sender, EventArgs e)
        {
            {
                string q1 = $"SELECT Cliente.Nome, Cliente.Telefone, Cliente.Email, Dentista.Nome, Dentista.Horario, Dentista.Dia FROM Cliente JOIN Dentista ON Cliente.Dentista = Dentista.Cod WHERE Cliente.Cod = {dgvCliente.Rows[dgvCliente.SelectedCells[0].RowIndex].Cells[0].Value}";
                var dt = SqlReader(q1);

                tbxNomeCliente.Text = dt.Rows[0][0].ToString();
                mtbTelefone.Text = $"{dt.Rows[0][1]:00000000000}";
                tbxEmail.Text = dt.Rows[0][2].ToString();
                if (cbxMedico.Items.Contains(dt.Rows[0][3].ToString()))
                    cbxMedico.Items.RemoveAt(cbxMedico.FindString(dt.Rows[0][3].ToString()));
                cbxMedico.SelectedItem = cbxMedico.Items[cbxMedico.Items.Add(dt.Rows[0][3].ToString())];
                mclCliente.SelectionEnd = Convert.ToDateTime(dt.Rows[0][5]);
                mclCliente.SelectionStart = Convert.ToDateTime(dt.Rows[0][5]);
                if (cbxHorario.Items.Contains(dt.Rows[0][4].ToString()))
                    cbxHorario.Items.RemoveAt(cbxHorario.FindString(dt.Rows[0][4].ToString()));
                cbxHorario.SelectedItem = cbxHorario.Items[cbxHorario.Items.Add(dt.Rows[0][4].ToString())];
            }
        }

        private void btnLimpar2_Click(object sender, EventArgs e)
        {
            tbxNomeCliente.Text = string.Empty;
            tbxEmail.Text = "email@mail.com";
            mtbTelefone.Text = string.Empty;
            cbxMedico.SelectedItem = null;
            cbxHorario.SelectedItem = null;
            mclCliente.SelectionStart = DateTime.Now;
            mclCliente.SelectionEnd = DateTime.Now;
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            SqlCommand cmdGet = new($"SELECT Cod, Disponivel FROM Dentista WHERE Nome = '{cbxMedico.SelectedItem.ToString()}' AND Horario = '{cbxHorario.SelectedItem.ToString()}' AND Dia = '{mclCliente.SelectionStart.ToShortDateString()}'", conn);

            int CodDoutor = 0;
            bool Disponivel = false;

            try
            {
                conn.Open();
                SqlDataReader dr = cmdGet.ExecuteReader();
                dr.Read();
                CodDoutor = (int)dr["Cod"];
                Disponivel = (bool)dr["Disponivel"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao puxar as informações do banco de dados:\n" + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            if (Disponivel)
            {
                {
                    SqlCommand cmd = new($"INSERT INTO Cliente(Nome, Telefone, Email, Dentista) VALUES ('{tbxNomeCliente.Text}', {Convert.ToInt32(mtbTelefone.Text)}, '{tbxEmail.Text}', {CodDoutor}) UPDATE Dentista SET Disponivel = 0 WHERE Cod = {CodDoutor}", conn);

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
                        UpdateDGV();
                    }
                }
            }
            else
            {
                MessageBox.Show("Horário já cadastrado");
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
                    UpdateDGV();
                }
            }
        }

        private void mclCliente_DateChanged(object sender, DateRangeEventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            SqlCommand cmd = new($"SELECT Horario, Disponivel FROM Dentista WHERE Dia = '{e.Start.Date}'", conn);

            try
            {
                cbxHorario.Items.Clear();
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToBoolean(reader["Disponivel"]))
                    {
                        cbxHorario.Items.Add(reader["Horario"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao puxar as informações do banco de dados:\n" + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    UpdateDGV();
                }
            }
        }

        private void tbxEmail_Enter(object sender, EventArgs e)
        {
            if (tbxEmail.Text == "email@mail.com")
                tbxEmail.Text = string.Empty;
        }

        private void tbxEmail_Leave(object sender, EventArgs e)
        {
            if (tbxEmail.Text == string.Empty)
            {
                tbxEmail.Text = "email@mail.com";
            }
        }

        private void btnDelDr_Click(object sender, EventArgs e)
        {
            var q = $"SELECT Cod FROM Dentista WHERE Cod = {dgvCadastro.Rows[0].Cells[0].Value}";

            var dt = SqlReader(q);

            var conn = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            var cmd = new SqlCommand($"DELETE FROM Dentista WHERE Cod = {dt.Rows[0][0]}", conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao mandar as informações para o banco de dados:\n" + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                UpdateDGV();
            }
        }

        private void btnDelCliente_Click(object sender, EventArgs e)
        {
            var q = $"SELECT Cod FROM Cliente WHERE Cod = {dgvCliente.Rows[0].Cells[0].Value}";

            var dt = SqlReader(q);

            var conn = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            var cmd = new SqlCommand($"DELETE FROM Cliente WHERE Cod = {dt.Rows[0][0]} UPDATE Dentista SET Disponivel = 1 WHERE Cod = {dt.Rows[0][0]}", conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao mandar as informações para o banco de dados:\n" + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
                UpdateDGV();
            }
        }

        private void cbxMedico_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            SqlCommand cmd = new($"SELECT Dia, Disponivel From Dentista WHERE Nome = '{cbxMedico.SelectedItem.ToString()}'", conn);

            try
            {
                mclCliente.RemoveAllBoldedDates();
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToBoolean(reader["Disponivel"]))
                        mclCliente.AddBoldedDate(Convert.ToDateTime(reader["Dia"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao puxar as informações do banco de dados:\n" + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                mclCliente.UpdateBoldedDates();
            }
        }
    }
}