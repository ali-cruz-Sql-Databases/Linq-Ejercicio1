using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlEmpresasEmpleados ce = new ControlEmpresasEmpleados();
            ce.getCEO();


            //int[] valoresNumericos = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Console.WriteLine("Numeros Pares: ");

            ////List<int> numerosPares = new List<int>();

            ////foreach (int i in valoresNumericos)
            ////{
            ////    if (i % 2 == 0)
            ////    {
            ////        numerosPares.Add(i);
            ////    }
            ////}


            //IEnumerable<int> numerosPares = from par in valoresNumericos 
            //                                where par % 2 == 0 
            //                                select par;

            //foreach (int i in numerosPares)
            //{
            //    Console.WriteLine(i);
            //}

        }

        class ControlEmpresasEmpleados
        {

            public ControlEmpresasEmpleados()
            {
                listaEmpresas = new List<Empresa>();
                listaEmpleados = new List<Empleado>();

                listaEmpresas.Add(new Empresa { Id = 1, Nombre = "Google" });
                listaEmpresas.Add(new Empresa { Id = 2, Nombre = "Pildoras" });
                listaEmpleados.Add(new Empleado { Id = 1, Nombre = "Sergey", Cargo = "CEO", EmpresaId = 1, Salario = 15000 });
                listaEmpleados.Add(new Empleado { Id = 2, Nombre = "Juan", Cargo = "CEO", EmpresaId = 2, Salario = 15000 });
                listaEmpleados.Add(new Empleado { Id = 3, Nombre = "Larry", Cargo = "Co-CEO", EmpresaId = 1, Salario = 15000 });
                listaEmpleados.Add(new Empleado { Id = 4, Nombre = "Irina", Cargo = "Co-CEO", EmpresaId = 2, Salario = 15000 });

            }

            public void getCEO()
            {
                IEnumerable<Empleado> ceos = from empleado in listaEmpleados where empleado.Cargo == "CEO" select empleado;

                foreach (Empleado empleado1 in ceos)
                {
                    empleado1.getDatosEmpleado();

                }
            }


            public List<Empresa> listaEmpresas;
            public List<Empleado> listaEmpleados;


        }

        class Empresa
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public void getDatosEmpresa()
            {
                Console.WriteLine("Empresa {0} con Id {1} ", Nombre, Id);
            }
        }

        class Empleado
        {
            public int Id { get; set; }

            public string Nombre { get; set; }

            public string Cargo { get; set; }

            public double Salario { get; set; }

            public int EmpresaId { get; set; }

            public void getDatosEmpleado()
            {
                Console.WriteLine("Empleado {0} con Id {1}, cargo {2}, con salario {3} " +
                    "perteneciente a la empresa {4} ", Nombre, Id, Cargo, Salario, EmpresaId);
            }
        }    
    }
}
