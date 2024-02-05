using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class Form_Vehiculo1 : Form
    {


        private bool IsNuevo = false;

        private bool IsEditar = false;

        EntidadVehiculo1 vehiculo = new EntidadVehiculo1();
        private static Form_Vehiculo1 _Instancia;

        public static Form_Vehiculo1 GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new Form_Vehiculo1();
            }
            return _Instancia;
        }

        public void setPropietario(string idCliente, string nombre)
        {
            this.txtPropietario.Text = nombre.ToString();
            this.txtIdCliente.Text = idCliente.ToString();
        }

        public Form_Vehiculo1()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtMarca, "Ingrese la Marca del Vehiculo");
            this.ttMensaje.SetToolTip(this.txtModelo, "Seleccione el Modelo del Vehiculo");
            this.ttMensaje.SetToolTip(this.txtPlaca, "Seleccione la Placa del Vehiculo");
            this.ttMensaje.SetToolTip(this.cbColor, "Seleccione el Color del Vehiculo");
            this.ttMensaje.SetToolTip(this.txtPropietario, "Seleccione el Propietario del Vehiculo");
            this.txtIdCliente.Visible = false;
            this.txtPropietario.ReadOnly = true;
           
        }


        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Mantenimiento Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Mantenimiento Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdVehiculo.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtPropietario.Text = string.Empty;
            this.txtPlaca.Text = string.Empty;
            this.txtEstado.Text = string.Empty;
            this.txtChasis.Text = string.Empty;
            this.txtAnio.Text = string.Empty;
            this.txtKilometraje.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdVehiculo.ReadOnly = !valor;
            this.txtMarca.ReadOnly = !valor;
            this.txtModelo.ReadOnly = !valor;
            this.txtIdCliente.ReadOnly = !valor;
            this.txtPropietario.ReadOnly = !valor;
            this.txtPlaca.ReadOnly = !valor;
            this.txtEstado.ReadOnly = !valor;
            this.txtChasis.ReadOnly = !valor;
            this.txtAnio.ReadOnly = !valor;
            this.txtKilometraje.ReadOnly = !valor;
            this.btnBuscar_Propietario.Enabled = valor;
            this.cbColor.Enabled = valor;
            
           
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            //this.dataListado.Columns[6].Visible = false;//ocultar la columna idcategoria
           // this.dataListado.Columns[8].Visible = false;//ocultar la columna idArticulo
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NegocioVehiculo1.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarPlaca()
        {
            vehiculo.TextoBuscar = txtBuscar.Text;
            this.dataListado.DataSource = NegocioVehiculo1.BuscarPlaca(vehiculo);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarModelo()
        {
            vehiculo.TextoBuscar = txtBuscar.Text;
            this.dataListado.DataSource = NegocioVehiculo1.BuscarModelo(vehiculo);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }




        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Placa"))
            {
                this.BuscarPlaca();
            }
            else if (cbBuscar.Text.Equals("Modelo"))
            {
                this.BuscarModelo();
            }
            
        }

        private void Form_Vehiculo1_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Placa"))
            {
                this.BuscarPlaca();
            }
            else if (cbBuscar.Text.Equals("Modelo"))
            {
                this.BuscarModelo();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtMarca.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtMarca.Text == string.Empty || this.txtIdCliente.Text == string.Empty || this.txtModelo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtMarca, "Ingrese un Valor");
                    errorIcono.SetError(txtIdCliente, "Ingrese un Valor");
                    errorIcono.SetError(txtModelo, "Ingrese un Valor");
                }
                else
                {
                   


                    if (this.IsNuevo)
                    {
                        vehiculo.Marca = txtMarca.Text.Trim().ToUpper();
                        vehiculo.Modelo = txtModelo.Text.Trim().ToUpper();
                        vehiculo.Color = cbColor.Text;
                        vehiculo.Placa = txtPlaca.Text.Trim().ToUpper();
                        vehiculo.Estado = txtEstado.Text;
                        vehiculo.Chasis = txtChasis.Text;
                        vehiculo.Kilometraje = Convert.ToDouble(txtKilometraje.Text);
                        vehiculo.Anio = txtAnio.Text;
                        vehiculo.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                        rpta = NegocioVehiculo1.Insertar(vehiculo);

                    }
                    else
                    {
                        vehiculo.Id = Convert.ToInt32(txtIdVehiculo.Text);
                        vehiculo.Marca = txtMarca.Text.Trim().ToUpper();
                        vehiculo.Modelo = txtModelo.Text.Trim().ToUpper();
                        vehiculo.Color = cbColor.Text;
                        vehiculo.Placa = txtPlaca.Text.Trim().ToUpper();
                        vehiculo.Estado = txtEstado.Text;
                        vehiculo.Chasis = txtChasis.Text.Trim().ToUpper();
                        vehiculo.Kilometraje = Convert.ToDouble(txtKilometraje.Text);
                        vehiculo.Anio = txtAnio.Text;
                        vehiculo.IdCliente = Convert.ToInt32(txtIdCliente.Text);

                        rpta = NegocioVehiculo1.Editar(vehiculo);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdVehiculo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Mantenimiento Vehicular", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NegocioVehiculo1.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                                
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Propietario_Click(object sender, EventArgs e)
        {
            Form_VistaPropietario form = new Form_VistaPropietario();
            form.ShowDialog();
        }

        private void Form_Vehiculo1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            this.txtIdVehiculo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Id"].Value);
            this.txtMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["marca"].Value);
            this.txtModelo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["modelo"].Value);
            this.cbColor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["color"].Value);
            this.txtPlaca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["placa"].Value);
            this.txtAnio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["año"].Value);
            this.txtChasis.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["chasis"].Value);
            this.txtKilometraje.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["kilometraje"].Value);
            this.txtEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["estado"].Value);

            this.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCliente"].Value);
            this.txtPropietario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value ) ;

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Form_ReporteVehiculo frm = new Form_ReporteVehiculo();
            frm.ShowDialog();
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
             if ((e.KeyChar == 32))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    MessageBox.Show("Sin caracteres especiales porfavor", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }

            }
        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
             if ((e.KeyChar == 32))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    MessageBox.Show("Sin caracteres especiales porfavor", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }

            }
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                MessageBox.Show("Únicamente números porfavor", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if ((e.KeyChar == 32))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    MessageBox.Show("Sin caracteres especiales porfavor", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }

            }
        }

        private void txtChasis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if ((e.KeyChar == 32))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    MessageBox.Show("Sin caracteres especiales porfavor", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }

            }
        }

        private void txtKilometraje_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
           if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                MessageBox.Show("Únicamente números porfavor", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
