using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}
		public void Add(Car car)
		{
			using (RentACarContext context= new RentACarContext())
			{
				if(car.DailyPrice>0 && context.Brands.SingleOrDefault(b=>b.BrandId== car.BrandId).BrandName.Length>2)
				{
					_carDal.Add(car);
					Console.WriteLine("Car added database succesfully");

				}
			}
		}

		public List<Car> GetAllGetCarsByBrandId(int Id)
		{
			return _carDal.GetAll(c => c.BrandId == Id);
		}

		public List<Car> GetAllGetCarsByColorId(int Id)
		{
			return _carDal.GetAll(c => c.ColorId == Id);
		}
	}
}
//carDal olan kısımda sorun olursa ICarDal olarak değiştirip dene