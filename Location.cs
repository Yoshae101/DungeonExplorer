namespace DungeonExplorer
{
    public class Location
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Item { get; private set; }

        public Location(string name, string description, string item)
        {
            Name = name;
            Description = description;
            Item = item;
        }

        // When picking up the item, return it and remove it from the location.
        public string PickUpItem()
        {
            string foundItem = Item;
            Item = null;
            return foundItem;
        }
    }
}
