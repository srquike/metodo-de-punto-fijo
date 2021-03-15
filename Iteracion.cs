using System;
using System.Collections.Generic;
using System.Text;

namespace metodo_de_punto_fijo
{
    public class Iteracion
    {
        private double error;

        public int I { get; set; }
        public double Xi { get; set; }
        public double Gx { get; set; }
        public double Error { get => Math.Round(error, 3); set => error = value; }
    }
}
