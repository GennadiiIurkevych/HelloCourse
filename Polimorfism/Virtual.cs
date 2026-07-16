//class Car
//{
//    protected virtual void StartEngine()
//    {
//        Console.WriteLine("The engine has been started");
//    }
//    public virtual void Drive()
//    {
//        Console.WriteLine("Car is going.");
//    }
//}

//class SportCar : Car
//{
//    protected override void StartEngine()
//    {
//        Console.WriteLine("I'm hitting the gas!");
//    }
//    public override void Drive()
//    {
//        StartEngine();
//        Console.WriteLine("SportCar is going fast.");
//    }
//}

//class Person
//{
//    public void Drive(Car car)
//    {
//        car.Drive();
//    }
//}

//class Virtual
//{
//    static void Main(string[] args)
//    {
//        Person person = new Person();
//        //person.Drive(new Car());
//        person.Drive(new SportCar());
//    }
//}