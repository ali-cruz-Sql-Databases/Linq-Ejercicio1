using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tipos anonimos
            var producto = new { Nombre = "Laptop", Precio = 12500 };

            //ControlEmpresasEmpleados ce = new ControlEmpresasEmpleados();
            ////ce.getCEO();
            ////ce.getEmpleadosOrdenados();
            //ce.getEmpleadosPildoras();

            ControlProductOrder fabricaProductOrder = new ControlProductOrder();
            //fabricaProductOrder.getInnerJoin();
            //fabricaProductOrder.getLeftJoin();
            //fabricaProductOrder.getCrossJoin();
            //fabricaProductOrder.getGroupJoin();

            //fabricaProductOrder.getOrderByProduct();

            fabricaProductOrder.getOrderDetailsExtencionMethods();





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


        /*
         * ****************************************************************************************************************************
         */
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

            public void getEmpleadosOrdenados()
            {
                IEnumerable<Empleado> empleados = from empleado in listaEmpleados orderby empleado.Nombre ascending select empleado;

                foreach (Empleado empleado1 in empleados)
                {
                    empleado1.getDatosEmpleado();
                }
            }


            public void getEmpleadosPildoras()
            {
                IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                                  join empresa in listaEmpresas
                                                  on empleado.EmpresaId equals empresa.Id
                                                  where empresa.Nombre == "Pildoras"
                                                  select empleado;

                foreach (Empleado empleado1 in empleados)
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



        /*
         * ****************************************************************************************************************************
         */

        class ControlProductOrder
        {
            public List<Product> Products;
            public List<Order> Orders;

            public ControlProductOrder()
            {
                Products = new List<Product>();
                Orders = new List<Order>();

                Products.Add(new Product { ProductId = 1, Name = "Book nr 1", Price = 11 });
                Products.Add(new Product { ProductId = 2, Name = "Book nr 2", Price = 12 });
                Products.Add(new Product { ProductId = 3, Name = "Book nr 3", Price = 13 });
                Products.Add(new Product { ProductId = 4, Name = "Book nr 4", Price = 14 });
                Products.Add(new Product { ProductId = 5, Name = "Book nr 5", Price = 15 });

                Orders.Add(new Order { OrderId = 1, ProductId = 1, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 2, ProductId = 2, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 3, ProductId = 1, Movimiento = "Baja" });
                Orders.Add(new Order { OrderId = 4, ProductId = 3, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 5, ProductId = null, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 6, ProductId = 1, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 7, ProductId = null, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 8, ProductId = 3, Movimiento = "Baja" });
                Orders.Add(new Order { OrderId = 9, ProductId = 1, Movimiento = "Baja" });
                Orders.Add(new Order { OrderId = 10, ProductId = 5, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 11, ProductId = null, Movimiento = "Alta" });
            }


            public void getInnerJoin()
            {
                var joined = (from p in Products
                              join o in Orders on p.ProductId equals o.ProductId
                              select new
                              {
                                  o.OrderId,
                                  p.ProductId,
                                  p.Name
                              });
                Console.WriteLine("Inner Join: \n");
                Console.WriteLine(String.Join(",\n", joined));

            }


            public void getLeftJoin()
            {
                //var leftJoin = (from p in Products
                //                join o in Orders on p.ProductId equals o.ProductId into g
                //                from lj in g.DefaultIfEmpty()
                //                select new
                //                {
                //                    OrderId = (int?)lj.OrderId,
                //                    p.ProductId,
                //                    p.Name
                //                });

                var joined = (from p in Products
                              join o in Orders on p.ProductId equals o.ProductId into g
                              from lj in g.DefaultIfEmpty()
                              select new
                              {
                                  //For the empty records in lj, OrderId would be NULL
                                  OrderId = (int?)lj.OrderId,
                                  p.ProductId,
                                  p.Name
                              }).ToList();

                Console.WriteLine("Left Join: \n");
                Console.WriteLine(String.Join(",\n", joined));
            }
            public void getCrossJoin()
            {
                //var crossJoin = (from p in Products
                //                 from o in Orders
                //                 select new
                //                 {
                //                     o.OrderId,
                //                     p.ProductId,
                //                     p.Name
                //                 });

                var joined = (from p in Products
                              from o in Orders
                              select new
                              {
                                  o.OrderId,
                                  p.ProductId,
                                  p.Name
                              }).ToList();

                Console.WriteLine("Cross Join: \n");
                Console.WriteLine(String.Join(",\n", joined));
            }

            public void getGroupJoin()
            {
                var joined = (from p in Products
                              join o in Orders on p.ProductId equals o.ProductId
                              into t
                              select new
                              {
                                  p.ProductId,
                                  p.Name,
                                  Orders = t
                              });

                Console.WriteLine("Group Join: \n");
                Console.WriteLine(String.Join(",\n", joined));
            }

            public void getOrderByProduct()
            {
                var details = from o in Orders
                              orderby o.OrderId
                              join p in Products
                              on o.ProductId equals p.ProductId
                              into G
                              select new
                              {
                                  Orden = o.OrderId,
                                  Producto = from p2
                                             in G
                                             orderby p2.ProductId
                                             select p2

                              };

                

                foreach (var G in details)
                {
                    Console.WriteLine(G.Orden);

                    foreach (var product in G.Producto)
                    {

                        Console.WriteLine("* {0}",
                            product.Price);
                    }
                }


                Console.WriteLine("Ordenes por Prodcuto: \n");

                //Console.WriteLine(String.Join(",\n", details));


            }

            public void getOrderDetailsExtencionMethods()
            {
                var productLastMovement = Orders.GroupBy(a => a.ProductId)
                                            .Select(g => g.OrderByDescending(i => i.OrderId)
                                            .FirstOrDefault());

                var products = Products.GroupBy(p => p.ProductId);

                var ordenes = Orders.GroupBy(a => a.Movimiento);

                //foreach (var producto in productLastMovement)
                //{
                //    Console.WriteLine("Producto: ==== {0} ====", producto.ProductId);

                //    foreach (var order in producto)
                //    {
                //        Console.WriteLine("Orden: * {0}, Movimiento: {1}", order.OrderId, order.Movimiento);
                //    }
                //}


                //var pr = Products.Select(Orders.Where(p => p.ProductId));
            }


        }


        class Product
        {
            public int ProductId { get; set; }

            public string Name { get; set; }

            public double Price { get; set; }

            public void getDatosProduct()
            {
                Console.WriteLine("ProductId: {0}, Name: {1}, Price: {2}", ProductId, Name, Price);
            }
        }

        class Order
        {
            public int OrderId { get; set; }
            public int? ProductId { get; set; }

            public string Movimiento { get; set; }

            public void getDatosOrder()
            {
                Console.WriteLine("OrderId: {0}, ProductId: {1}", OrderId, ProductId);
            }
        }


    }
}
