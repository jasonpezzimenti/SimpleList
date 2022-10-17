using System.Collections;

namespace SimpleList
{
	public class SimpleList<T> : IEnumerable<T>
	{
		private T[] Items;

		public SimpleList(int capacity = 0)
		{
			Items = new T[capacity];
		}

		public int Count { get { return Items.Length; } }
		public int Capacity { get { return Count; } }

		private void ResizeArray()
		{
			T[] newArray = new T[Items.Length + 1];

			for (int index = 0; index < Items.Length; index++)
			{
				newArray[index] = Items[index];
			}
		}

		public void IncreaseCapacity(int newCapacity)
		{
			Items = new T[newCapacity];
			ResizeArray();
		}

		public void Add(T item)
		{
			ResizeArray();

			Items[Count - 1] = item;
		}

		public void Remove(T item)
		{
			int index = Array.IndexOf(Items, item);
			Items = Items.Where<T>((value, i) => i != index).ToArray<T>();
		}

		public void Remove(int index)
		{
			Items = Items.Where<T>((value, i) => i != index).ToArray<T>();
		}

		public T this[int index]
		{
			get
			{
				return Items[index];
			}
		}

		public T this[T item]
		{
			get
			{
				int index = Array.IndexOf(Items, item);
				return Items[index];
			}
		}

		public T this[string value]
		{
			get
			{
				int index = Array.IndexOf(Items, value);
				return Items[index];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int index = 0; index < Count; index++)
			{
				yield return Items[index];
			}
		}
	}
}