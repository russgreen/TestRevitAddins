using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingV8.Services;
internal class ServiceDemo : IServiceDemo
{
    private readonly ILogger<ServiceDemo> _logger;

    public ServiceDemo(ILogger<ServiceDemo> logger)
    {
        _logger = logger;
    }

    public void DoSomething()
    {
        _logger.LogDebug("ServiceDemo.DoSomething");
    }
}

