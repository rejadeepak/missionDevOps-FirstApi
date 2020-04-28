using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace VSCodeEventBus.Domain
{
    public class OrderContext : DbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        public OrderContext()
        {

        }

        private static readonly ConsoleLoggerProvider consoleLoggerProvider =
                                new ConsoleLoggerProvider((category, level) => category == DbLoggerCategory.Database.Command.Name
                                                                                            && level == LogLevel.Information, true);


        public static readonly LoggerFactory MyConsoleLoggerFactory =
                                new LoggerFactory(new[] { consoleLoggerProvider });


        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
             contextOptionsBuilder
                            .UseLoggerFactory(MyConsoleLoggerFactory)
                            .UseSqlServer("Server = .\\SQLEXPRESS; Database = OrderAppData; Trusted_Connection = True; ")//Need to change
                            .EnableSensitiveDataLogging(true);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        modelBuilder.Entity<Customer>(entityTypeBuillder => {
                entityTypeBuillder.ToTable("Customer").HasKey(customer=>customer.Id);
                entityTypeBuillder.Property("Id").HasColumnName("StudentId");
                entityTypeBuillder.Property("Name");
                entityTypeBuillder.Property("Email");
                entityTypeBuillder.Property("Address1");
                entityTypeBuillder.Property("Address2");
                entityTypeBuillder.Property("Pincode");
        });


                modelBuilder.Entity<Order>(entityTypeBuillder => {
                entityTypeBuillder.ToTable("Order").HasKey(order=>order.Id);           
                entityTypeBuillder.Property("Id").HasColumnName("OrderId");
                entityTypeBuillder.Property("CustomerId");              
                entityTypeBuillder.Property("Price");
                entityTypeBuillder.Property("Quantity");
               
        });
                                        

        }

    }

}