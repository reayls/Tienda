using ProyectoTienda.DAO;
using ProyectoTienda.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtDni.MaxLength = 8;
            ListarGrid();
        }
        bool consulta = false;
        private void Guardar_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim() == "" || txtDni.Text.Trim().Length != 8)
            {
                MessageBox.Show("Debe Ingresar un DNI valido");
            }
            else if (txtNombres.Text.Trim() == ""||
                     txtApellidos.Text.Trim() == "" ||
                     txtEdad.Text.Trim() == "" ||
                     txtCiudad.Text.Trim() == "")
            {
                MessageBox.Show("Debe llenar todos los datos");
            }
            else
            {
                try
                {
                    Cliente c = new Cliente();

                    //c.Id = "1";
                    c.Dni = txtDni.Text.Trim();
                    c.Nombres = txtNombres.Text.Trim().ToUpper();
                    c.Apellidos = txtApellidos.Text.Trim().ToUpper();
                    c.Nombres = txtNombres.Text.Trim().ToUpper();
                    c.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    c.Ciudad = txtCiudad.Text.Trim();
                    if (ClienteDAO.guardar(c))
                    {
                        ListarGrid();
                        limpiarCampos();
                        MessageBox.Show("Cliente Agregado Exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Error en guardar Verifique");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en guardar Verifique","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (consulta)
            {
                try
                {
                    Cliente c = new Cliente();

                    //c.Id = "1";
                    c.Dni = txtDni.Text.Trim();
                    c.Nombres = txtNombres.Text.Trim().ToUpper();
                    c.Apellidos = txtApellidos.Text.Trim().ToUpper();
                    c.Nombres = txtNombres.Text.Trim().ToUpper();
                    c.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    c.Ciudad = txtCiudad.Text.Trim();
                    if (ClienteDAO.actualizar(c))
                    {
                        ListarGrid();
                        limpiarCampos();
                        MessageBox.Show("Datos Actualizados Exitosamente");
                        consulta = false;
                    }
                    else
                    {
                        MessageBox.Show("Error en Actualizar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Primero haga la consulta de busqueda");
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim() == "" || txtDni.Text.Trim().Length != 8)
            {
                MessageBox.Show("Debe Ingresar un DNI valido");
            }
            else
            {
                Cliente cl = ClienteDAO.consultar(txtDni.Text.Trim());
                if (cl == null)
                {
                    MessageBox.Show("El cliente no existe");
                    limpiarCampos();
                    consulta = false;
                }
                else
                {
                    //txtDocumento.Text = cl.Documento;
                    txtNombres.Text = cl.Nombres;
                    txtApellidos.Text = cl.Apellidos;
                    txtCiudad.Text = cl.Ciudad;
                    txtEdad.Text = cl.Edad.ToString();
                    consulta = true;
                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Trim() == "" || txtDni.Text.Trim().Length != 8)
            {
                MessageBox.Show("Debe Ingresar un DNI valido");
            }
            else if (DialogResult.Yes == MessageBox.Show("Desea Eliminar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (ClienteDAO.eliminar(txtDni.Text.Trim()))
                {
                    ListarGrid();
                    MessageBox.Show("Cliente eliminado con nro de DNI: " + txtDni.Text.Trim());
                }
                else
                {
                    MessageBox.Show("El cliente a eliminar no existe");
                }
            }
        }
        private void ListarGrid()
        {
            DataTable datos = ClienteDAO.Listar();
            if (datos == null)
            {
                MessageBox.Show("NO se pudo acceder a la lista");
            }
            else
            {
                dgView.DataSource = datos.DefaultView;
            }
        }
        private void limpiarCampos()
        {
            txtDni.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtCiudad.Text = "";
        }
    }
}
