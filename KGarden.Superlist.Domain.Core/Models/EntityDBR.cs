namespace KGarden.Superlist.Domain.Core.Models
{
	public abstract class EntityDBR
	{
		public Guid Id { get; protected set; }

		public override bool Equals(object? obj)
		{
			var compareTo = obj as EntityDBR;

			if(ReferenceEquals(this, compareTo)) return true;
			if(ReferenceEquals(null, compareTo)) return false;

			return Id.Equals(compareTo.Id);
		}

		public static bool operator ==(EntityDBR a, EntityDBR b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
				return true;

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
				return false;

			return a.Equals(b);
		}

		public static bool operator !=(EntityDBR a, EntityDBR b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return (GetType().GetHashCode() * 907) + Id.GetHashCode();
		}

		public override string ToString()
		{
			return GetType().Name + " [Id=" + Id + "]";
		}
	}
}
