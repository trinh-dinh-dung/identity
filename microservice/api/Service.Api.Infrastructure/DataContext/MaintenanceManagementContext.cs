using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public partial class MaintenanceManagementContext : DbContext
    {
        public MaintenanceManagementContext(DbContextOptions<MaintenanceManagementContext> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<Domain.Entities.Configgenmachine> Configgenmachines { get; set; }

        public virtual DbSet<Domain.Entities.File> Files { get; set; }

        public virtual DbSet<Domain.Entities.Machine> Machines { get; set; }

        public virtual DbSet<Domain.Entities.Machinetype> Machinetypes { get; set; }

        public virtual DbSet<Domain.Entities.MaintenanceschedulePeriod> MaintenanceschedulePeriods { get; set; }

        public virtual DbSet<Domain.Entities.Maintenanceschedule> Maintenanceschedules { get; set; }

        public virtual DbSet<Domain.Entities.MaterialExpectedMaintenance> MaterialExpectedMaintenances { get; set; }

        public virtual DbSet<Domain.Entities.MaterialsUsedForMaintenance> MaterialsUsedForMaintenances { get; set; }

        public virtual DbSet<Domain.Entities.Period> Periods { get; set; }

        public virtual DbSet<Domain.Entities.Repairinfo> Repairinfos { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.ConfiggenmachineMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.FileMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.MachineMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.MachinetypeMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.MaintenancescheduleMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.MaintenanceschedulePeriodMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.MaterialExpectedMaintenanceMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.MaterialsUsedForMaintenanceMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.PeriodMap());
            //modelBuilder.ApplyConfiguration(new Evo.Mes.MaintenanceManagement.Infrastructure.DataContext.Mapping.RepairinfoMap());
            #endregion
        }
    }
}
