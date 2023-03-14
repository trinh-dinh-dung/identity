using AutoMapper;
using Application.Common.Appsetting;
using Application.IServices;
using Application.RabbitMQ;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Infrastructure.IRepositories;
using Infrastructure.DataContext;

namespace Application.Services
{
    public partial class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IOptions<Appsettings> _appsettings;
        public readonly IRabbitMQClient _rabbitMQClient;
        private readonly IStringLocalizer<Service> _localizer;
        private readonly MaintenanceManagementContext _context;


        public Service(IStringLocalizer<Service> localize, IUnitOfWork unitOfWork, IConfiguration configuration, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, IMapper mapper, IOptions<Appsettings> appsettings, IRabbitMQClient rabbitMQClient, MaintenanceManagementContext context)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _hostingEnvironment = environment;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _rabbitMQClient = rabbitMQClient;
            _appsettings = appsettings;
            _localizer = localize;
            _context = context;
        }

        /// <summary>
        /// ham DecodeString
        /// </summary>
        /// <returns></returns>
        public string DecodeString()
        {
            return "";
        }
        /// <summary>
        /// ham GetValueKeyHeader
        /// </summary>
        /// <returns></returns>
        public string GetValueKeyHeader() { return ""; }


    }
}
