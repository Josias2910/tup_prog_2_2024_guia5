using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_5
{
    internal class Banco:Producto
    {
        public Banco(double precio, double largo) : base(precio, largo)
        {

        }

        public override double Peso()
        {
            double peso = 0;
            peso = (largo * 0.25) * 0.42;
            return peso;
        }

        public override double Precio()
        {
            double precio = 0;
            precio = Peso() * precioBase * 1.15;
            return precio;
        }

        public override string ToString()
        {
            return $"{Codigo}: banco de {largo}";
        }
    }
}
