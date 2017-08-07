namespace ErrorHandlingExt.Samples.Data
{
    public class CarEntity
    {
        public int Id { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public CarEntity(int id)
        {
            Id = id;
        }
    }
}
