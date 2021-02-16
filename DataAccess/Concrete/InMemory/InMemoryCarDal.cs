using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;
		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
				new Car{Id=1,BrandId=2,ColorId=2,ModelYear=2020,DailyPrice=150, Description="Mercedes - X"},
				new Car{Id=2,BrandId=3,ColorId=3,ModelYear=2018,DailyPrice=120, Description="Doblo - X"},
				new Car{Id=6,BrandId=1,ColorId=7,ModelYear=2016,DailyPrice=185, Description="Opel - X"},
				new Car{Id=4,BrandId=5,ColorId=9,ModelYear=2015,DailyPrice=210, Description="Range Rover - X"},
				new Car{Id=5,BrandId=4,ColorId=4,ModelYear=2019,DailyPrice=170, Description="Dacia Duster - X"},

			};
		}

		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			//LINQ - Language Integrated Query
			Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
			_cars.Remove(carToDelete);
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetById(int Id)
		{
			return _cars.Where(c => c.Id == Id ).ToList();
		    //Where - içindeki şarta uyan tüm elemanları bir liste haline getirir ve okutur.
		}

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.Description = car.Description;
			carToUpdate.ModelYear = car.ModelYear;
		}
	}
}
