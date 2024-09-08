using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia_5
{
    public partial class Form1 : Form
    {
        Presupuesto presupuesto;
        public Form1()
        {
            InitializeComponent();
            gbProductos.Enabled = false;
        }
        private void rbMesa_CheckedChanged(object sender, EventArgs e)
        {
            tbAncho.Enabled = true;
            tbGrosor.Enabled = true;
        }

        private void rbBanco_CheckedChanged(object sender, EventArgs e)
        {
            tbAncho.Clear();
            tbGrosor.Clear();
            tbAncho.Enabled = false;
            tbGrosor.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double precio = Convert.ToDouble(tbPrecioBase.Text);
            double largo = Convert.ToDouble(tbLargo.Text);
            int codigo = Convert.ToInt32(tbCodigo.Text);
            if (rbBanco.Checked)
            {
                Producto banco = new Banco(precio, largo);
                banco.Codigo = codigo;
                presupuesto.AgregarProducto(banco);
                cbxBorrar.Items.Add(banco);
            }
            else if(rbMesa.Checked)
            {
                double ancho = Convert.ToDouble(tbAncho.Text);
                double grosor = Convert.ToDouble(tbGrosor.Text);
                Producto mesa = new Mesa(precio, largo, ancho, grosor);
                mesa.Codigo = codigo;
                presupuesto.AgregarProducto(mesa);
                cbxBorrar.Items.Add(mesa);
            }
            gbCliente.Enabled = true;
            tbNombre.Enabled = false;
            tbDireccion.Enabled = false;
            btnIniciarPresupuesto.Enabled = false;
            tbAncho.Clear();
            tbCodigo.Clear();
            tbGrosor.Clear();
            tbLargo.Clear();
            tbPrecioBase.Clear();
        }

        private void btnIniciarPresupuesto_Click(object sender, EventArgs e)
        {
            gbProductos.Enabled = true;
            string nombre = tbNombre.Text;
            string direccion = tbDireccion.Text;
            presupuesto = new Presupuesto(nombre,direccion);
            tbNombre.Clear();
            tbDireccion.Clear();
            gbCliente.Enabled = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Producto p = cbxBorrar.SelectedItem as Producto;
            if (cbxBorrar.SelectedItem != null)
            {
                int codigo = p.Codigo;
                presupuesto.QuitarProducto(codigo);
                cbxBorrar.Items.Remove(cbxBorrar.SelectedItem);
            }
        }

        private void btnCerrarPresupuesto_Click(object sender, EventArgs e)
        {
            string[] resumenArray = presupuesto.Resumen();
            Resultados resultados = new Resultados();
            resultados.lbResultados.Items.AddRange(resumenArray);
            resultados.ShowDialog();
            tbNombre.Enabled = true;
            tbDireccion.Enabled = true;
            btnIniciarPresupuesto.Enabled = true;
            cbxBorrar.Items.Clear();
            gbProductos.Enabled = false;
        }
    }
}
