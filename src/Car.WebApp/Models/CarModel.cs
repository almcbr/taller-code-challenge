namespace Car.WebApp.Models
{
    public class CarModel
    {
        public CarModel()
        {
            Cars = new List<Car>();
        }
        public List<Car> Cars { get; set; }
    }
}
