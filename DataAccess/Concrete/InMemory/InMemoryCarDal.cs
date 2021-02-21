using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
				new Car{CarId=1,BrandId=2,ColorId=2,ModelYear=2020,DailyPrice=150, CarName="Mercedes - X"},
				new Car{CarId=2,BrandId=3,ColorId=3,ModelYear=2018,DailyPrice=120, CarName="Doblo - X"},
				new Car{CarId=6,BrandId=1,ColorId=7,ModelYear=2016,DailyPrice=185, CarName="Opel - X"},
				new Car{CarId=4,BrandId=5,ColorId=9,ModelYear=2015,DailyPrice=210, CarName="Range Rover - X"},
				new Car{CarId=5,BrandId=4,ColorId=4,ModelYear=2019,DailyPrice=170, CarName="Dacia Duster - X"},

			};
		}

		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			//LINQ - Language Integrated Query
			Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			_cars.Remove(carToDelete);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			return null;
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			return _cars;
		}

		public List<Car> GetById(int Id)
		{
			return _cars.Where(c => c.CarId == Id ).ToList();
		    //Where - içindeki şarta uyan tüm elemanları bir liste haline getirir ve okutur.
		}

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.CarName = car.CarName;
			carToUpdate.ModelYear = car.ModelYear;
		}
	}
}
