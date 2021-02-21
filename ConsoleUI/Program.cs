using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
	class Program
	{
		public string ModelYear { get; }
		public int DailyPrice { get; }
		public string CarName { get; }
		public int CarId { get; }
		public int BrandId { get; }
		public int ColorId { get; }
		//yukardaki kısma da tekrar bak
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			foreach(var car in carManager.GetAll())
			{
				Console.WriteLine(car.CarId);
			}
		}
		carManager.Add(new Car())
		{
			CarId = 5;
			BrandId = 4;
			ColorId = 1;
			ModelYear = "2019";
			DailyPrice = 1500;
			CarName = "Opel";          //bu kısıma tekrar bak
		}

		

	}
}
