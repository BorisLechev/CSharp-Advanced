public class Car
{
    public string CarModel { get; set; }
    public double CarSpeed { get; set; }

    public Car(string carModel, double carSpeed)
    {
        this.CarModel = carModel;
        this.CarSpeed = carSpeed;
    }

    public override string ToString()
    {
        return $"{this.CarModel} {this.CarSpeed}";
    }
}