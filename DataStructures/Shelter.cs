using System;
using System.Collections.Generic;

namespace DataStructures
{
	public enum Species { Cat, Dog };

	public class Animal
	{
		public Species species { get; private set; }
		public string name { get; set; }
		public Animal(string name, Species species)
		{
			this.name = name;
			this.species = species;
		}
		public override string ToString()
		{
			return name + " " + species;
		}

	}

	public class Shelter
	{
		Queue<Animal> cats = new Queue<Animal>();
		Queue<Animal> dogs = new Queue<Animal>();
		Queue<Animal> all = new Queue<Animal>();

		public void Enqueue(Animal a)
		{
			all.Enqueue(a);
			if (a.species == 0)
			{
				cats.Enqueue(a);
			}
			else {
				dogs.Enqueue(a);
			}
		}

		public Animal DequeueAny()
		{
			var animal = all.Dequeue();
			while ((dogs.Count == 0 || animal.name != dogs.Peek().name) &&
				   (cats.Count == 0 || animal.name != cats.Peek().name))
			{
				animal = all.Dequeue();
			}

			if (animal.species == Species.Cat)
			{
				cats.Dequeue();
			}
			else {
				dogs.Dequeue();
			}

			return animal;
		}

		public Animal DequeueCat()
		{
			return cats.Dequeue();
		}

		public Animal DequeueDog()
		{
			return dogs.Dequeue();
		}
	}
}
