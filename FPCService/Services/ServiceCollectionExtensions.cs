using FPCService.Services.YarnMachine;
using FPCService.Services.YarnSpool;
using FPCService.Services.MobileRobot;
using FPCService.Services.Place;
using FPCService.Services.StorageRack;
using FPCService.Services.Packaging;

namespace FPCService.Services
{
    /// <summary>
    /// Service 註冊擴充方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 註冊所有領域 Service
        /// </summary>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // YarnMachine 領域
            services.AddScoped<YarnMachineService>();
            services.AddScoped<YarnMachineSlotService>();

            // YarnSpool 領域
            services.AddScoped<YarnSpoolService>();

            // MobileRobot 領域
            services.AddScoped<MobileRobotService>();

            // Place 領域
            services.AddScoped<PlaceService>();
            services.AddScoped<PlaceSlotService>();

            // StorageRack 領域
            services.AddScoped<StorageRackService>();
            services.AddScoped<RackSlotService>();

            // Packaging 領域
            services.AddScoped<PackagingService>();

            return services;
        }
    }
}
