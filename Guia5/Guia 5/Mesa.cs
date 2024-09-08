using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Guia_5
{
    internal class Mesa:Producto
    {
        private double ancho;
        private double grosor;

        public Mesa(double precio, double largo, double ancho, double grosor) : base(precio, largo)
        {
            this.ancho = ancho;
            this.grosor = grosor;
        }

        public override double Precio()
        {
            double precio = 0;
            precio = Peso() * precioBase * 1.25;
            return precio;
        }

        public override double Peso()
        {
            double peso = 0;
            peso = (largo * ancho * grosor) * 0.3;
            return peso;
        }

        public override string ToString()
        {
            return $"{Codigo}: mesa de {ancho}x{grosor}";
        }
    }
}
