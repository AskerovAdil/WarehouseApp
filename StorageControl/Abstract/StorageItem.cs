namespace WarehouseApp.Abstract
{
    public abstract class StorageItem
    {
        public int Id { get; }
        public double Width { get; }
        public double Height { get; }
        public double Depth { get; }
        public double Weight { get; protected set; }

        protected StorageItem(int id, double width, double height, double depth)
        {
            Id = id;
            Width = width;
            Height = height;
            Depth = depth;
        }

    }
}
