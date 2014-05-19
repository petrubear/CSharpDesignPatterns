using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Patterns.Structural.Composite
{
    /*
     * Permite describir las partes y el todo.
     * 
     * en el ejemplo, cada item tiene sus propiedades, y varios items
     * se pueden ensamblar en un item nuevo donde el costo
     * es igual a la suma de las partes
     */
    public abstract class Item
    {
        private readonly string _description;
        private readonly int _cost;

        protected Item(string description, int cost)
        {
            _description = description;
            _cost = cost;
        }

        public virtual string Description
        {
            get
            {
                return _description;
            }
        }

        public virtual int Cost
        {
            get
            {
                return _cost;
            }
        }

        public abstract void AddItem(Item item);
        public abstract void RemoveItem(Item item);
        public abstract Item[] Items { get; }
        public override string ToString()
        {
            return String.Format(@"{0} (cost: {1:C})",
                _description, Cost);
        }
    }

    public class Part : Item
    {
        public Part(string description, int cost):
            base(description, cost) { }
        public override void AddItem(Item item)
        {           
        }

        public override void RemoveItem(Item item)
        {
        }
        public override Item[] Items
        {
            get { return new Item[0]; }
        }
    }

    public class Assembly : Part
    {
        private readonly IList<Item>_items; 
        public Assembly(string description) : base(description, 0)
        {
            _items = new List<Item>();
        }

        public override void AddItem(Item item)
        {
            _items.Add(item);
        }

        public override void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public override Item[] Items
        {
            get { return _items.ToArray(); }
        }

        public override int Cost
        {
            get
            {
                return Items.Sum(item => item.Cost);
            }
        }
    }
}
