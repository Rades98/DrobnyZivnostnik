namespace DrobnyZivnostnik.Models.Vehicle
{
    using System;

    public class VehicleModel
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        /// <value>
        /// The vehicle identifier.
        /// </value>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the vehicle.
        /// </summary>
        /// <value>
        /// The type of the vehicle.
        /// </value>
        public string VehicleType { get; set; }

        /// <summary>
        /// Gets or sets the number plate.
        /// </summary>
        /// <value>
        /// The number plate.
        /// </value>
        public string NumberPlate { get; set; }

        /// <summary>
        /// Gets or sets the fuel consumption.
        /// </summary>
        /// <value>
        /// The fuel consumption.
        /// </value>
        public double FuelConsumption { get; set; }

        /// <summary>
        /// Gets or sets the type of the fuel.
        /// </summary>
        /// <value>
        /// The type of the fuel.
        /// </value>
        public string FuelType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="VehicleModel"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }
    }
}
