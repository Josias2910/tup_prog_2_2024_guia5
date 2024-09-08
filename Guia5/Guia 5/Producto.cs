using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_5
{
    abstract internal class Producto:IComparable
    {
        protected double precioBase;
        protected double largo;
        private int codigo;
        public int Codigo { get { return codigo; } set { codigo = value; } }

        public Producto(double precio, double largo)
        {
            this.precioBase = precio;
            this.largo = largo;
        }

        public abstract double Peso();
        public abstract double Precio();

        public int CompareTo(object obj)
        {
            Producto p = obj as Producto;
            if (p != null)
            {
                return codigo.CompareTo(p.codigo);
            }
            return 1;
        }
    }
}
