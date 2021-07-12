namespace Garage1
{
    public interface IVehicle
    {
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        string RegistrationNumber { get; set; }
        string Length { get; set; }

        string ToString();
    }
}