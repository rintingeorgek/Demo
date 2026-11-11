using Plant360.Core.Models;
using Plant360.Core.Services;

namespace Plant360.Tests;

public class DeviceServiceTests
{
    [Fact]
    public void Register_ValidDevice_AddsDevice()
    {
        var service = new DeviceService();

        service.Register(new Device("DEV-001", "Boiler Meter", "Block A"));

        Assert.Single(service.GetAll());
    }

    [Fact]
    public void FindById_IsCaseInsensitive()
    {
        var service = new DeviceService();
        service.Register(new Device("DEV-001", "Boiler Meter", "Block A"));

        var found = service.FindById("dev-001");

        Assert.NotNull(found);
        Assert.Equal("Boiler Meter", found!.Name);
    }
}
