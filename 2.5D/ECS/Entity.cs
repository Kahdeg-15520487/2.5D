using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5D.ECS {
	struct Entity {
		public Guid ID;
		public List<int> ComponentsID;
		public List<Component> Components;
		public Entity(params Component[] components) {
			ID = Guid.NewGuid();
			Components = new List<Component>();
			ComponentsID = new List<int>();

			foreach (var c in components) {
				AddComponent(c);
			}
		}

		public void AddComponent(Component component) {
			if (!ComponentsID.Contains(component.ID)) {
				ComponentsID.Add(component.ID);
				Components.Add(component);
			}
		}

		public void RemoveComponent(int id) {
			if (ComponentsID.Contains(id)) {
				ComponentsID.Add(id);
				Components.RemoveAll(c => {
					return c.ID == id;
				});
			}
		}
	}
	class EntityManager {
		List<Entity> entities;
		List<Component> components;
		List<ISystem> systems;

	}
}
