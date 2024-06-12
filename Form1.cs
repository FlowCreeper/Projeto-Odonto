using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
            UpdatecbxDentista();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void UpdatecbxDentista()
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
        }

        private void UpdateDGV()
        {
            var c = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");

            try
            {
                var select = "SELECT * FROM Dentista";
                var dataAdapter = new SqlDataAdapter(select, c);


                _ = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dgvCadastro.DataSource = ds.Tables[0];

                var select1 = "SELECT * FROM Cliente";
                var dataAdapter1 = new SqlDataAdapter(select1, c);

                _ = new SqlCommandBuilder(dataAdapter1);
                var ds1 = new DataSet();
                dataAdapter1.Fill(ds1);
                dgvCliente.DataSource = ds1.Tables[0];

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao pegar informações do banco de dados: " + ex.Message);
            } 
            finally
            {
                if (c.State != ConnectionState.Closed)
                {
                    c.Close();
                }
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
            mclCadastro.SelectionStart = DateTime.Now;
            mclCadastro.SelectionEnd = DateTime.Now;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            try
            {
                if (cbxHorario1.SelectedItem == null)
                {
                    MessageBox.Show("Algum campo está vazio");
                    return;
                }

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
                    UpdatecbxDentista();
                    UpdatecbxHorario1();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Algum campo está vazio");
            }
        }

        private void bntReagendar_Click(object sender, EventArgs e)
        {
            try
            {
                string q1 = $"SELECT Cliente.Nome, Cliente.Telefone, Cliente.Email, Dentista.Nome, Dentista.Horario, Dentista.Dia FROM Cliente JOIN Dentista ON Cliente.Dentista = Dentista.Cod WHERE Cliente.Cod = {dgvCliente.Rows[dgvCliente.SelectedCells[0].RowIndex].Cells[0].Value}";
                var dt = SqlReader(q1);

                tbxNomeCliente.Text = dt.Rows[0][0].ToString();
                mtbTelefone.Text = $"{dt.Rows[0][1]:00000000000}";
                tbxEmail.Text = dt.Rows[0][2].ToString();
                if (cbxMedico.Items.Contains(dt.Rows[0][3].ToString()))
                    cbxMedico.Items.RemoveAt(cbxMedico.FindString(dt.Rows[0][3].ToString()));
                cbxMedico.SelectedItem = cbxMedico.Items[cbxMedico.Items.Add(dt.Rows[0][3].ToString())];
                mclCliente.SelectionEnd = DateTime.Today;
                mclCliente.SelectionStart = DateTime.Today;
                cbxHorario.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: \n" + ex.Message);
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
            mclCliente.RemoveAllBoldedDates();
            mclCliente.UpdateBoldedDates();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");

            
            SqlCommand cmdGet = new($"SELECT Cod, Disponivel FROM Dentista WHERE Nome = '{cbxMedico.SelectedItem}' AND Horario = '{cbxHorario.SelectedItem}' AND Dia = '{mclCliente.SelectionStart.ToShortDateString()}'", conn);
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
            catch (InvalidOperationException)
            {
                MessageBox.Show("Algum campo está vazio");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao puxar as informações do banco de dados:\n" + ex.GetType().ToString());
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
                if (Disponivel)
                {
                    {
                        SqlCommand cmd = new($"INSERT INTO Cliente(Nome, Telefone, Email, Dentista) VALUES ('{tbxNomeCliente.Text}', {Convert.ToInt64(mtbTelefone.Text)}, '{tbxEmail.Text}', {CodDoutor}) UPDATE Dentista SET Disponivel = 0 WHERE Cod = {CodDoutor}", conn);

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
                            mclCliente.SelectionStart = DateTime.Today;
                            mclCliente.SelectionEnd = DateTime.Today;
                            mclCliente.RemoveAllBoldedDates();
                            mclCliente.UpdateBoldedDates();
                            UpdateDGV();
                            UpdatecbxDentista();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Horário já cadastrado");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Algum campo está vazio");
            }
        }

        private void dgvCadastro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("Não é possível mudar o código");
                UpdateDGV();
                UpdatecbxDentista();
                return;
            }

            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");

            {
                try
                {
                    SqlCommand cmd = new($"UPDATE Dentista SET Nome = '{dgvCadastro.Rows[e.RowIndex].Cells[1].Value}', Consultorio = {Convert.ToInt32(dgvCadastro.Rows[e.RowIndex].Cells[2].Value)}, Disponivel = {Convert.ToInt32(dgvCadastro.Rows[e.RowIndex].Cells[3].Value)}, Horario = '{dgvCadastro.Rows[e.RowIndex].Cells[4].Value}', Dia = '{dgvCadastro.Rows[e.RowIndex].Cells[5].Value}' WHERE Cod = {Convert.ToInt32(dgvCadastro.Rows[e.RowIndex].Cells[0].Value)}", conn);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Horário Modificado!");
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
                        UpdatecbxDentista();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Entrada Inválida:\n" + ex.Message);
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
            var q = $"SELECT Cod FROM Dentista WHERE Cod = {dgvCadastro.Rows[dgvCadastro.SelectedCells[0].RowIndex].Cells[0].Value}";

            var dt = SqlReader(q);

            var conn = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            var cmd = new SqlCommand($"DELETE FROM Dentista WHERE Cod = {dt.Rows[0][0]}", conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso");
            }
            catch (SqlException ex)
            {
                if (ex.Errors.Count > 0)
                {
                    switch (ex.Errors[0].Number)
                    {
                        case 547: 
                            MessageBox.Show("Há um cliente agendado nesse horário\nExclua ele para excluir o horário");
                            break;
                    }
                }
                
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
                UpdatecbxDentista();
                mclCliente.RemoveAllBoldedDates();
                mclCliente.UpdateBoldedDates();
                cbxHorario.Items.Clear();
            }
        }

        private void btnDelCliente_Click(object sender, EventArgs e)
        {
            var q = $"SELECT Cod, Dentista FROM Cliente WHERE Cod = {dgvCliente.Rows[dgvCliente.SelectedCells[0].RowIndex].Cells[0].Value}";

            var dt = SqlReader(q);

            var conn = new SqlConnection("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            var cmd = new SqlCommand($"DELETE FROM Cliente WHERE Cod = {dt.Rows[0][0]} UPDATE Dentista SET Disponivel = 1 WHERE Cod = {dt.Rows[0][1]}", conn);

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
                UpdatecbxDentista();
            }
        }

        private void cbxMedico_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxMedico.SelectedItem == null)
                return;

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

        private void dgvCliente_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("Não é possível mudar o código");
                UpdateDGV();
                UpdatecbxDentista();
                return;
            }
            if (e.ColumnIndex == 4)
            {
                MessageBox.Show("Não é possível mudar o horário");
                UpdateDGV();
                UpdatecbxDentista();
                return;
            }

            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");

            {
                try
                {
                    SqlCommand cmd = new($"UPDATE Cliente SET Nome = '{dgvCliente.Rows[e.RowIndex].Cells[1].Value}', Telefone = {Convert.ToInt64(dgvCliente.Rows[e.RowIndex].Cells[2].Value)}, Email = '{dgvCliente.Rows[e.RowIndex].Cells[3].Value.ToString()}' WHERE Cod = {Convert.ToInt32(dgvCliente.Rows[e.RowIndex].Cells[0].Value)}", conn);
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
                        UpdatecbxDentista();
                    }
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Entrada Inválida:\n" + ex);
                    return;
                }

                
            }
        }

        private void mclCadastro_DateSelected(object sender, DateRangeEventArgs e)
        {
            UpdatecbxHorario1();
        }

        private void UpdatecbxHorario1()
        {
            cbxHorario1.Items.Clear();

            if (tbxNomeDr.Text == String.Empty)
            {
                MessageBox.Show("Insira o nome do dentista");
                return;
            }

            string[] s = { "08:00:00", "09:00:00", "10:00:00", "11:00:00", "13:00:00", "14:00:00", "15:00:00", "16:00:00" };
            cbxHorario1.Items.AddRange(s);
            
            var q = $"SELECT Horario FROM Dentista WHERE Nome = '{tbxNomeDr.Text}' AND Dia = '{mclCadastro.SelectionStart.ToString()}'";
            var dt = SqlReader(q);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbxHorario1.Items.Remove(dt.Rows[i][0].ToString());
            }
        }

        private void mclCliente_DateSelected(object sender, DateRangeEventArgs e)
        {
            SqlConnection conn = new("Data Source=DESKTOP-86JIQKU\\SQLEXPRESS;Initial Catalog=Odonto;Integrated Security=True");
            if (cbxMedico.SelectedItem == null)
            {
                MessageBox.Show("Selecione o médico");
                return;
            }

            SqlCommand cmd = new($"SELECT Horario, Disponivel FROM Dentista WHERE Nome = '{cbxMedico.SelectedItem}' AND Dia = '{e.Start.Date}'", conn);

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
    }
}