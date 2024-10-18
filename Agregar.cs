using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1er_parcial2docuatri
{
    public partial class Agregar : Form
    {
        public string Usuario;
        public Agregar(string Usuario)
        {
            this.Usuario = Usuario;
            InitializeComponent();
            
        }
        public void LimpiarCaja()
        {
            txtDNI.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtFechaNac.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
        }

        static string CadenaConexion = "server=tu tabla; database=Empresa; integrated security = true";
        SqlConnection ConexionEmpresa = new SqlConnection(CadenaConexion);

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ConexionEmpresa.Open();

            string CadenaAgregar = "insert into Empleado (DNI," + "Apellido, Nombre,Telefono, FechaNac,Usuario, Clave) values (" +
                "'" + txtDNI.Text + "'," +
                "'" + txtApellido.Text + "'," +
                "'" + txtNombre.Text + "'," +
                "'" + txtTelefono.Text + "'," +
                "'" + txtFechaNac.Text + "'," +
                "'" + txtUsuario.Text + "'," +
                "'" + txtClave.Text + "')";
            SqlCommand ComandoAgregar = new SqlCommand(CadenaAgregar, ConexionEmpresa);
            ComandoAgregar.ExecuteNonQuery();
            //SqlCommand ComandoAgregar = new SqlCommand(CadenaAgregar, ConexionEmpresa);
            // ComandoAgregar.ExecuteNonQuery();
            MessageBox.Show("El Empleado se agrego correctamente");
            LimpiarCaja();


            ConexionEmpresa.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(Usuario);
            Form1.Show();
            this.Hide();
        }


    }
}
