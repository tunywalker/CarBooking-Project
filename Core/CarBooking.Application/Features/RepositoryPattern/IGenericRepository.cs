﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.RepositoryPattern
{
	public interface IGenericRepository<T> where T : class
	{
		List<T> GetAll();
		void Create(T entity);
		void Update(T entity);
		void Remove(T entity);
		T GetById(int id);

	}
}
