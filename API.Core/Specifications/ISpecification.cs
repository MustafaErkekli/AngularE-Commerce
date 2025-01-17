﻿using System.Linq.Expressions;

namespace API.Core.Specifications
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> Criteria { get; }
		List<Expression<Func<T, object>>> Includes { get;}
		Expression<Func<T,object>>OrderBy { get;}
		Expression<Func<T,object>>OrderByDescending { get;}
		int Take {  get; } //sayfada kaç ürün olacağını tutacak property
		int Skip { get; } //kaç tane ürünü atlayacağının sayısını tutacak property
		bool IsPagingEnabled { get; } // sayfalama yapılsın mı yapılmasın mı tutacak prop
	}
}
