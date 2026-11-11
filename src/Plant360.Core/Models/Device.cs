namespace Plant360.Core.Models;

/// <summary>
/// A field device (meter, sensor, controller) installed in the plant.
/// </summary>
public record Device(string Id, string Name, string Location);
