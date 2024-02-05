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
    public partial class Form_Servicio : Form
    {

        private bool IsNuevo = false;

        private bool IsEditar = false;

        EntidadServicio servicio = new EntidadServicio();



       



        public Form_Servicio()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Servicio");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese la descripcion del Servicio");
            this.ttMensaje.SetToolTip(this.txtCosto, "Ingrese el Costo del Servicio");
            this.ttMensaje.SetToolTip(this.cbTipoServicio, "Seleccione el Tipo de Servicio");

            
            this.LlenarComboPresentacion();
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
            this.txtIdServicio.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtCosto.Text = string.Empty;


        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdServicio.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtCosto.ReadOnly = !valor;
            this.cbTipoServicio.Enabled = valor;
            
           
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
            this.dataListado.Columns[5].Visible = false;
            
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NegocioServicio.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            servicio.TextoBuscar = this.txtBuscar.Text;
            this.dataListado.DataSource = NegocioServicio.BuscarNombre(servicio.TextoBuscar);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void LlenarComboPresentacion()
        {
            cbTipoServicio.DataSource = NegocioTipoServicio.Mostrar();
            cbTipoServicio.ValueMember = "id";
            cbTipoServicio.DisplayMember = "nombre";

        }

        private void Form_Servicio_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty  || this.txtCosto.Text == string.Empty || this.txtDescripcion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtCosto, "Ingrese un Valor");
                    errorIcono.SetError(txtDescripcion, "Ingrese un Valor");
                   
                }
                else
                {
                    

                    if (this.IsNuevo)
                    {

                        servicio.Nombre = this.txtNombre.Text.Trim().ToUpper();
                        servicio.descripcion = this.txtDescripcion.Text.Trim();
                        servicio.Costo = Convert.ToDecimal(this.txtCosto.Text);
                        servicio.Id_Tipo = Convert.ToInt32(this.cbTipoServicio.SelectedValue);
                        rpta = NegocioServicio.Insertar(servicio);

                    }
                    else
                    {
                        servicio.IdServicio = Convert.ToInt32(this.txtIdServicio.Text);
                        servicio.Nombre = this.txtNombre.Text.Trim().ToUpper();
                        servicio.descripcion = this.txtDescripcion.Text.Trim();
                        servicio.Costo = Convert.ToDecimal(this.txtCosto.Text);
                        servicio.Id_Tipo = Convert.ToInt32(this.cbTipoServicio.SelectedValue);
                        rpta = NegocioServicio.Editar(servicio);
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
            if (!this.txtIdServicio.Text.Equals(""))
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
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdServicio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            this.txtCosto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["costo"].Value);
            this.cbTipoServicio.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["id_tipo"].Value);

            this.tabControl1.SelectedIndex = 1;
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
                            Rpta = NegocioServicio.Eliminar(Convert.ToInt32(Codigo));

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            From_ReporteServicios frm = new From_ReporteServicios();
            frm.ShowDialog();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 32))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsLetter(e.KeyChar))
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
                    MessageBox.Show("Únicamente letras porfavor", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 32))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsLetter(e.KeyChar))
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
                    MessageBox.Show("Únicamente letras porfavor", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
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
