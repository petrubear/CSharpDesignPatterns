using DesignPatterns.Model;

namespace DesignPatterns.Patterns.Structural.Facade
{
    /* 
     * expone una interfaz unica a un conjunto
     * de interfaces?, haciendolas mas faciles de usar
     */
    public class VehicleFacade
    {
        public virtual void PrepareForSale(IVehicle vehicle)
        {
            var reg = new Registration(vehicle);
            reg.AllocateLicensePlate();
            Documentation.PrintBrochure(vehicle);

            vehicle.CleanInterior();
            vehicle.ClearExteriorBody();
            vehicle.PolishWindows();
            vehicle.TakeForTestDrive();
        }
	}
}

