using BlacksmithWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BlacksmithWorkshopDatabaseImplement
{
    public class BlacksmithWorkshopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlacksmithWorkshopDatabase;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Manufacture> Manufactures { set; get; }
        public virtual DbSet<ManufactureComponent> ManufactureComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Shop> Shops { set; get; }
        public virtual DbSet<ShopManufacture> ListManufacture { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
		public virtual DbSet<Implementer> Implementers { set; get; }
		public virtual DbSet<MessageInfo> MessageInfos { set; get; }
	}
}
