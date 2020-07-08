using CommonCore;
using System; 
using System.Transactions;

namespace CreateTransactionScopePrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext _context = new ApplicationDbContext(); 
            System.IO.StringWriter writer = new System.IO.StringWriter();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
            }
            Console.WriteLine(writer.ToString());
        }
        // This function takes arguments for 2 connection strings and commands to create a transaction
        // involving two SQL Servers. It returns a value > 0 if the transaction is committed, 0 if the
        // transaction is rolled back. To test this code, you can connect to two different databases
        // on the same server by altering the connection string, or to another 3rd party RDBMS by
        // altering the code in the connection2 code block.
        static public int CreateTransactionScope(
            string connectString1, string connectString2,
            string commandText1, string commandText2)
        {
            // Initialize the return value to zero and create a StringWriter to display results.
            int returnValue = 0;
            System.IO.StringWriter writer = new System.IO.StringWriter();

            try
            {
                // Create the TransactionScope to execute the commands, guaranteeing
                // that both commands can commit or roll back as a single unit of work.
                using (TransactionScope scope = new TransactionScope())
                {

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

            return returnValue;
        }
    }
}
