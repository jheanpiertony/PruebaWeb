using CommonCore;
using System;
using System.Transactions;

namespace TransactionScopePrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    context.Add(new Producto()
                    {
                        Precio = 12000,
                        NombreProducto = $"PruebaTrasaction {DateTime.Now.ToString()}",
                        EstaBorrado = false,
                        ImagenURL = string.Empty,
                    });
                    context.SaveChanges();
                    
                    
                    scope.Complete();
                }


            }
            catch (TransactionAbortedException ex)
            {
                Console.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
            }

            // Display messages.
            Console.WriteLine("Todo bien");
        }
    }
}
