using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfColorDal : IColorDal
	{
		public void Add(Color entity)
		{
			using (RentACarContext context = new RentACarContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
			}
		}

		public void Delete(Color entity)
		{
			using (RentACarContext context = new RentACarContext())
			{
				var deletedEntity = context.Entry(entity); //Entry -> framework ile ilgili
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public Color Get(Expression<Func<Color, bool>> filter)
		{
			using (RentACarContext context = new RentACarContext()) //using içerisine yazılan kodlar bellekten işi bitince atılır, bu yüzden daha performanslı oluyor
			{
				return context.Set<Color>().SingleOrDefault(filter);
			}
		}
		public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
		{
			using (RentACarContext context = new RentACarContext())
			{
				return filter != null ? context.Set<Color>().Where(filter).ToList() : context.Set<Color>().ToList(); // ? -> eğer filter null ise ilk kısmı yani tümünü getirir değilse diğer kısmı getirir
			}
		}

		public void Update(Color entity)
		{
			using (RentACarContext context = new RentACarContext())
			{
				var updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();

			}
		}
	}
}
