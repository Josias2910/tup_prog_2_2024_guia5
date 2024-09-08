using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_5
{
    internal class Presupuesto
    {
        public double Precio { get; set; }
        private ArrayList listaProductos = new ArrayList();
        private Cliente solicitante;
        public Presupuesto(string nombre, string direccion)
        {
            solicitante = new Cliente(nombre,direccion);
        }

        public void AgregarProducto(Producto unProducto)
        {
            listaProductos.Add(unProducto);
            Precio += unProducto.Precio();
        }

        public bool QuitarProducto(int codigo)
        {
            listaProductos.Sort();
            Producto producto = BuscarProducto(codigo);
            if(producto != null)
            {
                listaProductos.Remove(producto);
                return true;
            }
            return false;
        }

        private Producto BuscarProducto(int codigo)
        {
            listaProductos.Sort();
            Banco banco = new Banco(0, 0);
            banco.Codigo = codigo;
            int idx = listaProductos.BinarySearch(banco);
            if (idx >= 0)
            {
                return listaProductos[idx] as Producto;
            }
            return null;
        }

        public string[] Resumen()
        {
            int contResumen = 0;
            int numProductos = listaProductos.Count;
            string[] resumen = new string[numProductos];

            foreach(Producto p in listaProductos)
            {
                if (p != null)
                {
                    resumen[contResumen] = $"Código: {p.Codigo}, Nombre y Direccion: {solicitante.ToString()}, Precio: {p.Precio()}";
                    contResumen++;
                }
            }
            return resumen;
        }
    }
}
