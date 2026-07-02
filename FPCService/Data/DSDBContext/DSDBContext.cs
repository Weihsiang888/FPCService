using Microsoft.EntityFrameworkCore;

namespace FPCService.Data
{
    public partial class DSDBContext : DbContext
    {
        public DSDBContext()
        {
        }

        public DSDBContext(DbContextOptions<DSDBContext> options) : base(options)
        {
        }

        // -----------------------------
        // 撚紗機相關
        // -----------------------------
        public DbSet<MainYarnMachine> MainYarnMachine { get; set; }
        public DbSet<DetialYarnMachine> DetialYarnMachine { get; set; }
        public DbSet<MainYarnMachineSlot> MainYarnMachineSlot { get; set; }
        public DbSet<DetialYarnMachineSlot> DetialYarnMachineSlot { get; set; }
        public DbSet<QueueYarnMachineSlot> QueueYarnMachineSlot { get; set; }
        public DbSet<LogYarnMachineSlot> LogYarnMachineSlot { get; set; }

        // -----------------------------
        // 紗卷主檔
        // -----------------------------
        public DbSet<YarnSpool> YarnSpool { get; set; }

        // -----------------------------
        // AGV / MobileRobot
        // -----------------------------
        public DbSet<MainMobileRobot> MainMobileRobot { get; set; }
        public DbSet<DetialMobileRobot> DetialMobileRobot { get; set; }
        public DbSet<MobileRobotPoint> MobileRobotPoint { get; set; }
        public DbSet<QueueMobileRobot> QueueMobileRobot { get; set; }
        public DbSet<LogMobileRobot> LogMobileRobot { get; set; }

        // -----------------------------
        // 放置區 Place
        // -----------------------------
        public DbSet<MainPlace> MainPlace { get; set; }
        public DbSet<MainPlaceSlot> MainPlaceSlot { get; set; }
        public DbSet<DetialPlaceSlot> DetialPlaceSlot { get; set; }
        public DbSet<QueuePlaceSlot> QueuePlaceSlot { get; set; }
        public DbSet<LogPlaceSlot> LogPlaceSlot { get; set; }

        // -----------------------------
        // 料架 StorageRack
        // -----------------------------
        public DbSet<MainStorageRack> MainStorageRack { get; set; }
        public DbSet<MainRackSlot> MainRackSlot { get; set; }
        public DbSet<DetialRackSlot> DetialRackSlot { get; set; }
        public DbSet<QueueRackSlot> QueueRackSlot { get; set; }
        public DbSet<LogRackSlot> LogRackSlot { get; set; }

        // -----------------------------
        // 包裝區 Packaging
        // -----------------------------
        public DbSet<MainPackaging> MainPackaging { get; set; }
        public DbSet<DetialPackaging> DetialPackaging { get; set; }
        public DbSet<QueuePackaging> QueuePackaging { get; set; }
        public DbSet<LogPackaging> LogPackaging { get; set; }

        // -----------------------------
        // EF Core 基本設定
        // -----------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // 你可以在這裡加入連線字串（如果你需要）
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

