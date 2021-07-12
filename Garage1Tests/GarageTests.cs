using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1.Vehicles;

namespace Garage1.Tests
{
    [TestClass()]
    public class GarageTests
    {
        [TestMethod()]
        public void Park_AdVehicleWithIncorectSlotNumber_ShouldReturnFalse()
        {
            //Arrange
            const int capacity = 2;
            const int slot = 5000;
            var garage = new Garage<IVehicle>("Banan", "Blaha", capacity);


            //Act
            var actual = garage.Park(new Bus(), slot);

            //Assert
            Assert.IsFalse(actual);
        }
    }
}