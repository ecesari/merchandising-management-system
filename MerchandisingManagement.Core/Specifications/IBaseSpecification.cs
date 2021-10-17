using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MerchandisingManagement.Domain.Specifications
{
	public interface IBaseSpecification<T>
	{
		Expression<Func<T, bool>> Criteria { get; }
		List<Expression<Func<T, object>>> Includes { get; }
		List<string> IncludeStrings { get; }
		Expression<Func<T, object>> OrderBy { get; }
		Expression<Func<T, object>> OrderByDescending { get; }

		int Take { get; }
		int Skip { get; }
		bool isPagingEnabled { get; }

		//public Expression<Func<T, bool>> Expression();
		//public bool IsSatisfiedBy(T candidate);
		//IBaseSpecification<T> And(IBaseSpecification<T> other);
		//IBaseSpecification<T> AndNot(IBaseSpecification<T> other);
		//IBaseSpecification<T> Or(IBaseSpecification<T> other);
		//IBaseSpecification<T> OrNot(IBaseSpecification<T> other);
		//IBaseSpecification<T> Not();
	}

	//public abstract class LinqSpecification<T> : CompositeSpecification<T>
	//{
	//	protected LinqSpecification(Expression<Func<T, bool>> criteria) : base(criteria)
	//	{
	//	}
	//	public abstract Expression<Func<T, bool>> AsExpression();
	//	public override bool IsSatisfiedBy(T candidate) => AsExpression().Compile()(candidate);


	//}

	//public abstract class CompositeSpecification<T> : IBaseSpecification<T>
	//{
	//	protected CompositeSpecification(Expression<Func<T, bool>> criteria)
	//	{
	//		Criteria = criteria;
	//	}
	//	public Expression<Func<T, bool>> Criteria { get; }

	//	public abstract bool IsSatisfiedBy(T candidate);
	//	public IBaseSpecification<T> And(IBaseSpecification<T> other) => new AndSpecification<T>(this, other);
	//	public IBaseSpecification<T> AndNot(IBaseSpecification<T> other) => new AndNotSpecification<T>(this, other);
	//	public IBaseSpecification<T> Or(IBaseSpecification<T> other) => new OrSpecification<T>(this, other);
	//	public IBaseSpecification<T> OrNot(IBaseSpecification<T> other) => new OrNotSpecification<T>(this, other);
	//	public IBaseSpecification<T> Not() => new NotSpecification<T>(this);
	//}

	//public class AndSpecification<T> : CompositeSpecification<T>
	//{
	//	IBaseSpecification<T> left;
	//	IBaseSpecification<T> right;

	//	public AndSpecification(IBaseSpecification<T> left, IBaseSpecification<T> right)
	//	{
	//		this.left = left;
	//		this.right = right;
	//	}

	//	public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) && right.IsSatisfiedBy(candidate);
	//}

	//public class AndNotSpecification<T> : CompositeSpecification<T>
	//{
	//	IBaseSpecification<T> left;
	//	IBaseSpecification<T> right;

	//	public AndNotSpecification(IBaseSpecification<T> left, IBaseSpecification<T> right)
	//	{
	//		this.left = left;
	//		this.right = right;
	//	}

	//	public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) && !right.IsSatisfiedBy(candidate);
	//}

	//public class OrSpecification<T> : CompositeSpecification<T>
	//{
	//	IBaseSpecification<T> left;
	//	IBaseSpecification<T> right;

	//	public OrSpecification(IBaseSpecification<T> left, IBaseSpecification<T> right)
	//	{
	//		this.left = left;
	//		this.right = right;
	//	}

	//	public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) || right.IsSatisfiedBy(candidate);
	//}
	//public class OrNotSpecification<T> : CompositeSpecification<T>
	//{
	//	IBaseSpecification<T> left;
	//	IBaseSpecification<T> right;

	//	public OrNotSpecification(IBaseSpecification<T> left, IBaseSpecification<T> right)
	//	{
	//		this.left = left;
	//		this.right = right;
	//	}

	//	public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) || !right.IsSatisfiedBy(candidate);
	//}

	//public class NotSpecification<T> : CompositeSpecification<T>
	//{
	//	IBaseSpecification<T> other;
	//	public NotSpecification(IBaseSpecification<T> other) => this.other = other;
	//	public override bool IsSatisfiedBy(T candidate) => !other.IsSatisfiedBy(candidate);
	//}
}
