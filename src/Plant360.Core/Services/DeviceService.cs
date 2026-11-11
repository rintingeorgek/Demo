using Plant360.Core.Models;

namespace Plant360.Core.Services;

/// <summary>
/// Keeps track of registered devices (in memory, to keep the demo simple).
/// </summary>
public class DeviceService
{
    private readonly List<Device> _devices = new();

    public IReadOnlyList<Device> GetAll() => _devices.AsReadOnly();

    public Device? FindById(string id) =>
        _devices.FirstOrDefault(d => string.Equals(d.Id, id, StringComparison.OrdinalIgnoreCase));

    public void Register(Device device)
    {
        // TODO: No validation yet! Empty IDs, bad IDs and duplicates are all accepted.
        // This is fixed on the feature/device-validation branch during the live demo.
        _devices.Add(device);
    }
}
