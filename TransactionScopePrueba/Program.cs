using CommonCore;
using System;
using System.Transactions;

namespace TransactionScopePrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();
            ApplicationDbContext context = new ApplicationDbContext();
            try
            {
                // Create the TransactionScope to execute the commands, guaranteeing
                // that both commands can commit or roll back as a single unit of work.
                using (TransactionScope scope = new TransactionScope())
                {
                    context.Add(new Producto() 
                    {
                        Precio=12000,
                        NombreProducto = "PruebaTrasaction",
                        EstaBorrado = false,

                    });

                    context.SaveChangesAsync();
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
            }

            // Display messages.
            Console.WriteLine(writer.ToString());
        }
    }
}
