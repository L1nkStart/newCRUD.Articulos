using System;
using newCRUD.DataSet1TableAdapters;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using Dapper;

namespace newCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initialize();
            Action();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
        }



        private void Initialize()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            DataSet1TableAdapters.saArtPrecioTableAdapter ta =
                new DataSet1TableAdapters.saArtPrecioTableAdapter();
            DataSet1.saArtPrecioDataTable dt = ta.GetData();


            dataGridView1.DataSource = dt;
            button6.Enabled = false;
            button3.Enabled = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void Action()
        {
            button6.Enabled = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("1", "PRODUCTO");
            dataGridView1.Columns.Add("2", "DESCRIPCION");
            dataGridView1.Columns.Add("3", "LINEA");
            dataGridView1.Columns.Add("4", "SUBLINEA");
            dataGridView1.Columns.Add("5", "CATEGORIA");
            dataGridView1.Columns.Add("6", "PROCEDENCIA");

            button6.Enabled = false;
            button3.Enabled = true;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void InsertarDatosDesdeDataGridView()
        {
            // Cadena de conexión a tu base de datos SQL Server.
            string connectionString = "Data Source=25.55.146.112\\SQL2019;Initial Catalog=INVMMB_P;User ID=profit;Password=profit;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Supongamos que 'dataGridView1' es tu DataGridView.
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            // Verifica si la fila no es la fila de encabezado y contiene datos válidos.
                            if (!row.IsNewRow && row.Cells[0].Value != null)
                            {
                                string co_art = row.Cells[0].Value.ToString();
                                DateTime fecha_reg = DateTime.Now;
                                string art_des = row.Cells[1].Value.ToString();
                                string tipo = "V";
                                string anulado = "0";
                                string co_lin = row.Cells[2].Value.ToString();
                                string co_subl = row.Cells[3].Value.ToString();
                                string co_cat = row.Cells[4].Value.ToString();
                                string co_color = "NA";
                                string co_ubicacion = "NA";
                                string cod_proc = row.Cells[5].Value.ToString();
                                string generico = "0";
                                string maneja_serial = "0";
                                string maneja_lote = "0";
                                string maneja_lote_venc = "0";
                                string margen_min = "0";
                                string margen_max = "0";
                                string tipo_imp = "7";
                                string garantia = "n/a";
                                string volumen = "0";
                                string peso = "0";
                                string stock_min = "0";
                                string stock_max = "0";
                                string stock_pedido = "0";
                                string relac_unidad = "1";
                                string punt_ven = "0";
                                string punt_cli = "0";
                                string lic_mon_ilc = "0";
                                string lic_capacidad = "0";
                                string lic_grado_al = "0";
                                string prec_om = "0";
                                string tipo_cos = "1";
                                string porc_margen_minimo = "0";
                                string porc_margen_maximo = "0";
                                string mont_comi = "0";
                                string porc_arancel = "0";
                                string co_us_in = "999";
                                string co_sucu_in = "1";
                                DateTime fe_us_in = DateTime.Now;
                                string co_us_mo = "PROFIT";
                                string co_sucu_mo = "1";
                                DateTime fe_us_mo = DateTime.Now;
                                string co_uni = "UNI";
                                // Consulta SQL para la inserción.
                                string query = "INSERT INTO saArticulo (co_art, fecha_reg, art_des, tipo, anulado, co_lin, co_subl, co_cat, co_color, co_ubicacion, cod_proc, generico, maneja_serial, maneja_lote, maneja_lote_venc, margen_min, margen_max, tipo_imp, garantia, volumen, peso, stock_min, stock_max, stock_pedido, relac_unidad, punt_ven, punt_cli, lic_mon_ilc, lic_capacidad, lic_grado_al, prec_om, tipo_cos, porc_margen_minimo, porc_margen_maximo, mont_comi, porc_arancel, co_us_in, co_sucu_in, fe_us_in ,co_us_mo , co_sucu_mo, fe_us_mo) VALUES (@co_art, @fecha_reg, @art_des, @tipo, @anulado, @co_lin, @co_subl, @co_cat, @co_color, @co_ubicacion, @cod_proc, @generico, @maneja_serial, @maneja_lote, @maneja_lote_venc, @margen_min, @margen_max, @tipo_imp, @garantia, @volumen, @peso, @stock_min, @stock_max, @stock_pedido, @relac_unidad, @punt_ven, @punt_cli, @lic_mon_ilc, @lic_capacidad, @lic_grado_al, @prec_om, @tipo_cos, @porc_margen_minimo, @porc_margen_maximo, @mont_comi, @porc_arancel, @co_us_in, @co_sucu_in, @fe_us_in, @co_us_mo, @co_sucu_mo, @fe_us_mo)" +
                                    "insert into saArtUnidad (co_art, co_uni, relacion, equivalencia, uso_venta, uso_compra, uni_principal, uso_principal, uni_secundaria, uso_secundaria, uso_numDecimales, num_decimales, co_us_in, co_sucu_in, fe_us_in, co_us_mo, co_sucu_mo, fe_us_mo) VALUES (@co_art, @co_uni, @punt_ven, @tipo_cos, @punt_ven, @punt_ven, @tipo_cos, @tipo_cos, @punt_ven, @punt_ven, @punt_ven, @punt_ven, @co_us_mo, @tipo_cos, @fe_us_in, @co_us_mo, @tipo_cos, @fe_us_in)";
                                using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@co_art", co_art);
                                    cmd.Parameters.AddWithValue("@fecha_reg", fecha_reg);
                                    cmd.Parameters.AddWithValue("@art_des", art_des);
                                    cmd.Parameters.AddWithValue("@tipo", tipo);
                                    cmd.Parameters.AddWithValue("@anulado", anulado);
                                    cmd.Parameters.AddWithValue("@co_lin", co_lin);
                                    cmd.Parameters.AddWithValue("@co_subl", co_subl);
                                    cmd.Parameters.AddWithValue("@co_cat", co_cat);
                                    cmd.Parameters.AddWithValue("@co_color", co_color);
                                    cmd.Parameters.AddWithValue("@co_ubicacion", co_ubicacion);
                                    cmd.Parameters.AddWithValue("@cod_proc", cod_proc);
                                    cmd.Parameters.AddWithValue("@generico", generico);
                                    cmd.Parameters.AddWithValue("@maneja_serial", maneja_serial);
                                    cmd.Parameters.AddWithValue("@maneja_lote", maneja_lote);
                                    cmd.Parameters.AddWithValue("@maneja_lote_venc", maneja_lote_venc);
                                    cmd.Parameters.AddWithValue("@margen_min", margen_min);
                                    cmd.Parameters.AddWithValue("@margen_max", margen_max);
                                    cmd.Parameters.AddWithValue("@tipo_imp", tipo_imp);
                                    cmd.Parameters.AddWithValue("@garantia", garantia);
                                    cmd.Parameters.AddWithValue("@volumen", volumen);
                                    cmd.Parameters.AddWithValue("@peso", peso);
                                    cmd.Parameters.AddWithValue("@stock_min", stock_min);
                                    cmd.Parameters.AddWithValue("@stock_max", stock_max);
                                    cmd.Parameters.AddWithValue("@stock_pedido", stock_pedido);
                                    cmd.Parameters.AddWithValue("@relac_unidad", relac_unidad);
                                    cmd.Parameters.AddWithValue("@punt_ven", punt_ven);
                                    cmd.Parameters.AddWithValue("@punt_cli", punt_cli);
                                    cmd.Parameters.AddWithValue("@lic_mon_ilc", lic_mon_ilc);
                                    cmd.Parameters.AddWithValue("@lic_capacidad", lic_capacidad);
                                    cmd.Parameters.AddWithValue("@lic_grado_al", lic_grado_al);
                                    cmd.Parameters.AddWithValue("@prec_om", prec_om);
                                    cmd.Parameters.AddWithValue("@tipo_cos", tipo_cos);
                                    cmd.Parameters.AddWithValue("@porc_margen_minimo", porc_margen_minimo);
                                    cmd.Parameters.AddWithValue("@porc_margen_maximo", porc_margen_maximo);
                                    cmd.Parameters.AddWithValue("@mont_comi", mont_comi);
                                    cmd.Parameters.AddWithValue("@porc_arancel", porc_arancel);
                                    cmd.Parameters.AddWithValue("@co_us_in", co_us_in);
                                    cmd.Parameters.AddWithValue("@co_sucu_in", co_sucu_in);
                                    cmd.Parameters.AddWithValue("@fe_us_in", fe_us_in);
                                    cmd.Parameters.AddWithValue("@co_us_mo", co_us_mo);
                                    cmd.Parameters.AddWithValue("@co_sucu_mo", co_sucu_mo);
                                    cmd.Parameters.AddWithValue("@fe_us_mo", fe_us_mo);
                                    cmd.Parameters.AddWithValue("@co_uni", co_uni);

                                    // Añade parámetros para otras columnas si es necesario.

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Datos insertados correctamente.");
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            MessageBox.Show("Error al insertar datos: " + ex.Message);
                            transaction.Rollback();


                        }
                        catch (Exception )
                        {
                            MessageBox.Show("Error al insertar datos: " + ex.Message);

                        }
                    }
                }
            }
        }




        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si se ha presionado Ctrl+V (Ctrl y la tecla V al mismo tiempo).
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Obtén el contenido del portapapeles.
                string clipboardText = Clipboard.GetText();

                // Divide el texto en líneas y luego en celdas separadas por tabulaciones.
                string[] lines = clipboardText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string[] cells = line.Split('\t');

                    // Agrega una nueva fila y asigna los valores de las celdas.
                    int rowIndex = dataGridView1.Rows.Add();
                    for (int i = 0; i < cells.Length; i++)
                    {
                        dataGridView1.Rows[rowIndex].Cells[i].Value = cells[i];
                    }
                }

                // Indica que el evento ha sido manejado.
                e.Handled = true;
            }
        }

        private void EliminarDatosDesdeDataGridView()
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            InsertarDatosDesdeDataGridView();
            Initialize();
            Action();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EliminarDatosDesdeDataGridView();
            Initialize();
            Action();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            // Muestra un cuadro de diálogo de confirmación.
            DialogResult resultado = MessageBox.Show("¿Estás seguro de ejecutar esta acción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Comprueba la respuesta del usuario.
            if (resultado == DialogResult.Yes)
            {
                InsertarDatosDesdeDataGridView();
            }
            else
            {
                // El usuario ha cancelado la acción o ha elegido "No".
                // Puedes colocar aquí el código para manejar la cancelación.
            }
        }
    }
}