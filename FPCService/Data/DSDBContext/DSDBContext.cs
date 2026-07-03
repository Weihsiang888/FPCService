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
            #region Main_YarnMachine
            modelBuilder.Entity<MainYarnMachine>(entity =>
            {
                entity.ToTable("Main_YarnMachine");

                entity.HasKey(e => e.YarnMachineUid);

                entity.Property(e => e.YarnMachineUid).HasColumnName("YarnMachine_UID").HasMaxLength(60);
                entity.Property(e => e.YarnMachineStatus).HasColumnName("YarnMachine_Status").HasMaxLength(60);
                entity.Property(e => e.WorderOrder).HasColumnName("WorderOrder").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.YarnSpoolCompletedCount).HasColumnName("YarnSpoolCompleted_Count");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region Detial_YarnMachine
            modelBuilder.Entity<DetialYarnMachine>(entity =>
            {
                entity.ToTable("Detial_YarnMachine");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.YarnMachineUid).HasColumnName("YarnMachine_UID").HasMaxLength(60);
                entity.Property(e => e.YarnMachineStatus).HasColumnName("YarnMachine_Status").HasMaxLength(60);
                entity.Property(e => e.WorderOrder).HasColumnName("WorderOrder").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.YarnSpoolCompletedCount).HasColumnName("YarnSpoolCompleted_Count");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.OccurrenceTime).HasColumnName("Occurrence_Time").HasColumnType("datetime");
            });
            #endregion

            #region Main_YarnMachineSlot
            modelBuilder.Entity<MainYarnMachineSlot>(entity =>
            {
                entity.ToTable("Main_YarnMachineSlot");

                entity.HasKey(e => e.YarnMachineSlotUid);

                entity.Property(e => e.YarnMachineSlotUid).HasColumnName("YarnMachineSlot_UID").HasMaxLength(60);
                entity.Property(e => e.YarnMachineUid).HasColumnName("YarnMachine_UID").HasMaxLength(60);
                entity.Property(e => e.YarnMachineSlotPoint).HasColumnName("YarnMachineSlot_Point");
                entity.Property(e => e.YarnMachineSlotStatus).HasColumnName("YarnMachineSlot_Status").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.PointCode).HasColumnName("Point_Code").HasMaxLength(60);
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
            });
            #endregion

            #region Detial_YarnMachineSlot
            modelBuilder.Entity<DetialYarnMachineSlot>(entity =>
            {
                entity.ToTable("Detial_YarnMachineSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.YarnMachineSlotUid).HasColumnName("YarnMachineSlot_UID").HasMaxLength(60);
                entity.Property(e => e.YarnMachineUid).HasColumnName("YarnMachine_UID").HasMaxLength(60);
                entity.Property(e => e.YarnMachineSlotPoint).HasColumnName("YarnMachineSlot_Point");
                entity.Property(e => e.YarnMachineSlotStatus).HasColumnName("YarnMachineSlot_Status").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.PointCode).HasColumnName("Point_Code").HasMaxLength(60);
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.OccurrenceTime).HasColumnName("Occurrence_Time").HasColumnType("datetime");
            });
            #endregion

            #region Queue_YarnMachineSlot
            modelBuilder.Entity<QueueYarnMachineSlot>(entity =>
            {
                entity.ToTable("Queue_YarnMachineSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.QueueStatus).HasColumnName("Queue_Status");
                entity.Property(e => e.YarnMachineSlotUid).HasColumnName("YarnMachineSlot_UID").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.PointCode).HasColumnName("Point_Code").HasMaxLength(60);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
                entity.Property(e => e.CreateTime).HasColumnName("Create_Time").HasColumnType("datetime");
                entity.Property(e => e.CompleteTime).HasColumnName("Complete_Time").HasColumnType("datetime");
            });
            #endregion

            #region Log_YarnMachineSlot
            modelBuilder.Entity<LogYarnMachineSlot>(entity =>
            {
                entity.ToTable("Log_YarnMachineSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.YarnMachineSlotUid).HasColumnName("YarnMachineSlot_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.Message).HasColumnName("Message").HasMaxLength(200);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region YarnSpool
            modelBuilder.Entity<YarnSpool>(entity =>
            {
                entity.ToTable("Table_YarnSpool");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.YarnSpoolUid).HasColumnName("YarnSpool_UID").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolStatus).HasColumnName("YarnSpool_Status").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.AgvUid).HasColumnName("AGV_UID").HasMaxLength(60);
                entity.Property(e => e.PlaceUid).HasColumnName("Place_UID").HasMaxLength(60);
                entity.Property(e => e.PlaceSlotUid).HasColumnName("PlaceSlot_UID").HasMaxLength(60);
                entity.Property(e => e.StorageRackUid).HasColumnName("StorageRack_UID").HasMaxLength(60);
                entity.Property(e => e.RackSlotUid).HasColumnName("RackSlot_UID").HasMaxLength(60);
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
                entity.Property(e => e.CreateTime).HasColumnName("Create_Time").HasColumnType("datetime");
                entity.Property(e => e.CompleteTime).HasColumnName("Complete_Time").HasColumnType("datetime");
                entity.Property(e => e.PlaceTime).HasColumnName("Place_Time").HasColumnType("datetime");
                entity.Property(e => e.StorageTime).HasColumnName("Storage_Time").HasColumnType("datetime");
                entity.Property(e => e.PackagingTime).HasColumnName("Packaging_Time").HasColumnType("datetime");
                entity.Property(e => e.EventTime).HasColumnName("Event_Time").HasColumnType("datetime");
            });
            #endregion

            #region Main_MobileRobot
            modelBuilder.Entity<MainMobileRobot>(entity =>
            {
                entity.ToTable("Main_MobileRobot");

                entity.HasKey(e => e.MobileRobotUid);

                entity.Property(e => e.MobileRobotUid).HasColumnName("MobileRobot_UID").HasMaxLength(60);
                entity.Property(e => e.MobileRobotStatus).HasColumnName("MobileRobot_Status").HasMaxLength(60);
                entity.Property(e => e.MobileRobotType).HasColumnName("MobileRobot_Type").HasMaxLength(60);
                entity.Property(e => e.SwarmCoreId).HasColumnName("SwarmCore_ID").HasMaxLength(60);
                entity.Property(e => e.PlaceUid).HasColumnName("Place_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.Battery).HasColumnName("Battery");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region Detial_MobileRobot
            modelBuilder.Entity<DetialMobileRobot>(entity =>
            {
                entity.ToTable("Detial_MobileRobot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.MobileRobotUid).HasColumnName("MobileRobot_UID").HasMaxLength(60);
                entity.Property(e => e.MobileRobotStatus).HasColumnName("MobileRobot_Status").HasMaxLength(60);
                entity.Property(e => e.MobileRobotType).HasColumnName("MobileRobot_Type").HasMaxLength(60);
                entity.Property(e => e.SwarmCoreId).HasColumnName("SwarmCore_ID").HasMaxLength(60);
                entity.Property(e => e.PointCode).HasColumnName("Point_Code").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.OccurrenceTime).HasColumnName("Occurrence_Time").HasColumnType("datetime");
            });
            #endregion

            #region MobileRobotPoint
            modelBuilder.Entity<MobileRobotPoint>(entity =>
            {
                entity.ToTable("Main_MobileRobot_Point");

                entity.HasKey(e => e.PointUid);

                entity.Property(e => e.PointUid).HasColumnName("Point_UID").HasMaxLength(60);
                entity.Property(e => e.PointName).HasColumnName("Point_Name").HasMaxLength(60);
                entity.Property(e => e.PointCode).HasColumnName("Point_Code").HasMaxLength(60);
                entity.Property(e => e.PointNumber).HasColumnName("Point_Number");
                entity.Property(e => e.PointArea).HasColumnName("Point_Area").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
            });
            #endregion

            #region Queue_MobileRobot
            modelBuilder.Entity<QueueMobileRobot>(entity =>
            {
                entity.ToTable("Queue_MobileRobot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.QueueStatus).HasColumnName("Queue_Status");
                entity.Property(e => e.MobileRobotUid).HasColumnName("MobileRobot_UID").HasMaxLength(60);
                entity.Property(e => e.PointCode).HasColumnName("Point_Code").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
                entity.Property(e => e.CreateTime).HasColumnName("Create_Time").HasColumnType("datetime");
                entity.Property(e => e.CompleteTime).HasColumnName("Complete_Time").HasColumnType("datetime");
            });
            #endregion

            #region Log_MobileRobot
            modelBuilder.Entity<LogMobileRobot>(entity =>
            {
                entity.ToTable("Log_MobileRobot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.MobileRobotUid).HasColumnName("MobileRobot_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.Message).HasColumnName("Message").HasMaxLength(200);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region Main_Place
            modelBuilder.Entity<MainPlace>(entity =>
            {
                entity.ToTable("Main_Place");

                entity.HasKey(e => e.PlaceUid);

                entity.Property(e => e.PlaceUid).HasColumnName("Place_UID").HasMaxLength(60);
                entity.Property(e => e.PlaceName).HasColumnName("Place_Name").HasMaxLength(60);
                entity.Property(e => e.PlaceId).HasColumnName("Place_ID");
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.PlaceCompletedCount).HasColumnName("PlaceCompleted_Count");
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region Main_PlaceSlot
            modelBuilder.Entity<MainPlaceSlot>(entity =>
            {
                entity.ToTable("Main_PlaceSlot");

                entity.HasKey(e => e.PlaceSlotUid);

                entity.Property(e => e.PlaceSlotUid).HasColumnName("PlaceSlot_UID").HasMaxLength(60);
                entity.Property(e => e.PlaceUid).HasColumnName("Place_UID").HasMaxLength(60);
                entity.Property(e => e.PlaceSlotPoint).HasColumnName("PlaceSlot_Point");
                entity.Property(e => e.PlaceSlotStatus).HasColumnName("PlaceSlot_Status").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
            });
            #endregion

            #region Detial_PlaceSlot
            modelBuilder.Entity<DetialPlaceSlot>(entity =>
            {
                entity.ToTable("Detial_PlaceSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.PlaceSlotUid).HasColumnName("PlaceSlot_UID").HasMaxLength(60);
                entity.Property(e => e.PlaceUid).HasColumnName("Place_UID").HasMaxLength(60);
                entity.Property(e => e.PlaceSlotPoint).HasColumnName("PlaceSlot_Point");
                entity.Property(e => e.PlaceSlotStatus).HasColumnName("PlaceSlot_Status").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.OccurrenceTime).HasColumnName("Occurrence_Time").HasColumnType("datetime");
            });
            #endregion

            #region Queue_PlaceSlot
            modelBuilder.Entity<QueuePlaceSlot>(entity =>
            {
                entity.ToTable("Queue_PlaceSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.QueueStatus).HasColumnName("Queue_Status");
                entity.Property(e => e.PlaceSlotUid).HasColumnName("PlaceSlot_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
                entity.Property(e => e.CreateTime).HasColumnName("Create_Time").HasColumnType("datetime");
                entity.Property(e => e.CompleteTime).HasColumnName("Complete_Time").HasColumnType("datetime");
            });
            #endregion

            #region Log_PlaceSlot
            modelBuilder.Entity<LogPlaceSlot>(entity =>
            {
                entity.ToTable("Log_PlaceSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.PlaceSlotUid).HasColumnName("PlaceSlot_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.Message).HasColumnName("Message").HasMaxLength(200);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region Main_StorageRack
            modelBuilder.Entity<MainStorageRack>(entity =>
            {
                entity.ToTable("Main_StorageRack");

                entity.HasKey(e => e.StorageRackUid);

                entity.Property(e => e.StorageRackUid).HasColumnName("StorageRack_UID").HasMaxLength(60);
                entity.Property(e => e.StorageRackName).HasColumnName("StorageRack_Name").HasMaxLength(60);
                entity.Property(e => e.StorageRackPoint).HasColumnName("StorageRack_Point");
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.StorageCompletedCount).HasColumnName("StorageCompleted_Count");
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region Main_RackSlot
            modelBuilder.Entity<MainRackSlot>(entity =>
            {
                entity.ToTable("Main_RackSlot");

                entity.HasKey(e => e.RackSlotUid);

                entity.Property(e => e.RackSlotUid).HasColumnName("RackSlot_UID").HasMaxLength(60);
                entity.Property(e => e.StorageRackUid).HasColumnName("StorageRack_UID").HasMaxLength(60);
                entity.Property(e => e.RackSlotPoint).HasColumnName("RackSlot_Point");
                entity.Property(e => e.RackSlotStatus).HasColumnName("RackSlot_Status").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
            });
            #endregion

            #region Detial_RackSlot
            modelBuilder.Entity<DetialRackSlot>(entity =>
            {
                entity.ToTable("Detial_RackSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.RackSlotUid).HasColumnName("RackSlot_UID").HasMaxLength(60);
                entity.Property(e => e.StorageRackUid).HasColumnName("StorageRack_UID").HasMaxLength(60);
                entity.Property(e => e.RackSlotPoint).HasColumnName("RackSlot_Point");
                entity.Property(e => e.RackSlotStatus).HasColumnName("RackSlot_Status").HasMaxLength(60);
                entity.Property(e => e.YarnSpoolType).HasColumnName("YarnSpool_Type").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.OccurrenceTime).HasColumnName("Occurrence_Time").HasColumnType("datetime");
            });
            #endregion

            #region Queue_RackSlot
            modelBuilder.Entity<QueueRackSlot>(entity =>
            {
                entity.ToTable("Queue_RackSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.QueueStatus).HasColumnName("Queue_Status");
                entity.Property(e => e.RackSlotUid).HasColumnName("RackSlot_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
                entity.Property(e => e.CreateTime).HasColumnName("Create_Time").HasColumnType("datetime");
                entity.Property(e => e.CompleteTime).HasColumnName("Complete_Time").HasColumnType("datetime");
            });
            #endregion

            #region Log_RackSlot
            modelBuilder.Entity<LogRackSlot>(entity =>
            {
                entity.ToTable("Log_RackSlot");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.RackSlotUid).HasColumnName("RackSlot_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.Message).HasColumnName("Message").HasMaxLength(200);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region Main_Packaging
            modelBuilder.Entity<MainPackaging>(entity =>
            {
                entity.ToTable("Main_Packaging");

                entity.HasKey(e => e.PackagingUid);

                entity.Property(e => e.PackagingUid).HasColumnName("Packaging_UID").HasMaxLength(60);
                entity.Property(e => e.PackagingPoint).HasColumnName("Packaging_Point");
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion

            #region Detial_Packaging
            modelBuilder.Entity<DetialPackaging>(entity =>
            {
                entity.ToTable("Detial_Packaging");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.PackagingUid).HasColumnName("Packaging_UID").HasMaxLength(60);
                entity.Property(e => e.PackagingPoint).HasColumnName("Packaging_Point");
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.OccurrenceTime).HasColumnName("Occurrence_Time").HasColumnType("datetime");
            });
            #endregion

            #region Queue_Packaging
            modelBuilder.Entity<QueuePackaging>(entity =>
            {
                entity.ToTable("Queue_Packaging");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.QueueStatus).HasColumnName("Queue_Status");
                entity.Property(e => e.PackagingUid).HasColumnName("Packaging_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
                entity.Property(e => e.CreateTime).HasColumnName("Create_Time").HasColumnType("datetime");
                entity.Property(e => e.CompleteTime).HasColumnName("Complete_Time").HasColumnType("datetime");
            });
            #endregion

            #region Log_Packaging
            modelBuilder.Entity<LogPackaging>(entity =>
            {
                entity.ToTable("Log_Packaging");

                entity.HasKey(e => e.UID);

                entity.Property(e => e.UID).HasColumnName("UID");
                entity.Property(e => e.PackagingUid).HasColumnName("Packaging_UID").HasMaxLength(60);
                entity.Property(e => e.Floor).HasColumnName("Floor");
                entity.Property(e => e.TaskUid).HasColumnName("TaskUID").HasMaxLength(60);
                entity.Property(e => e.Message).HasColumnName("Message").HasMaxLength(200);
                entity.Property(e => e.ProcessTime).HasColumnName("Process_Time").HasColumnType("datetime");
            });
            #endregion


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

