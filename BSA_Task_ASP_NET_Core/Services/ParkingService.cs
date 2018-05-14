using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_Task;

namespace BSA_Task_ASP_NET_Core.Services
{
    public class ParkingService
    {
        public Parking CarParking { get; }

        public ParkingService()
        {
            CarParking = Parking.Instance;
        }
        public IEnumerable<Car> GetAllCars()
        {
            return CarParking.GetAllCars();
        }
        public bool ContainsCar(int id)
        {
            return CarParking.ContainsCar(id);
        }
        public Car GetCarById(int id)
        {
            return CarParking.GetCarById(id);
        }
        public void AddCar(int carTypeNumber, decimal balance)
        {
            CarParking.AddCar(new Car((CarType)carTypeNumber, balance));
        }
        public bool RemoveCar(int id)
        {
            return CarParking.RemoveCar(id);
        }
        public bool IsCarTypeExists(int carTypeNumber)
        {
            return Car.IsCarTypeExists(carTypeNumber);
        }
        public decimal GetParkingBalance()
        {
            return CarParking.Balance;
        }
        public int GetAvailableParkingSpace()
        {
            return CarParking.AvailableParkingSpace;
        }
        public int GetUnavailableParkingSpace()
        {
            return CarParking.UnavailableParkingSpace;
        }
        public IEnumerable<string> GetTransactionsLog()
        {
            return CarParking.GetTransactionsLog();
        }
        public IEnumerable<Transaction> GetLastMinuteTransactions()
        {
            return CarParking.GetLastMinuteTransactions();
        }
        public IEnumerable<Transaction> GetLastMinuteTransactions(int id)
        {
            return CarParking.GetLastMinuteTransactions(id);
        }
        public void RechargeCarBalance(int id, decimal rechargeSum)
        {
            CarParking.RechargeCarBalance(id, rechargeSum);
        }
        public bool IsFull()
        {
            return CarParking.IsFull();
        }
    }
}
