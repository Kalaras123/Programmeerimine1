namespace KooliProjekt.Data
{
    public static class SeedData
    {

        public static void Generate(ApplicationDbContext context)
        {
            if (context.Cars.Any())
            {
                return;
            }

            var car1 = new Car();
            car1.Mark = "Audi";
            car1.Model = "A4";
            car1.RegistrationNumber = "001 AUD";
            context.Cars.Add(car1);

            var car2 = new Car();
            car2.Mark = "BMW";
            car2.Model = "330x";
            car2.RegistrationNumber = "002 BMV";
            context.Cars.Add(car2);

            var car3 = new Car();
            car3.Mark = "Mercedes";
            car3.Model = "E220";
            car3.RegistrationNumber = "003 MBE";
            context.Cars.Add(car3);

            var car4 = new Car();
            car4.Mark = "Land Rover";
            car4.Model = "Discovery 6";
            car4.RegistrationNumber = "004 LRD";
            context.Cars.Add(car4);

            var car5 = new Car();
            car5.Mark = "Tesla";
            car5.Model = "Model X";
            car5.RegistrationNumber = "005 TES";
            context.Cars.Add(car5);

            var car6 = new Car();
            car6.Mark = "Saab";
            car6.Model = "9-5 Aero";
            car6.RegistrationNumber = "006 SAB";
            context.Cars.Add(car6);

            var car7 = new Car();
            car7.Mark = "Suzuki";
            car7.Model = "Vitara";
            car7.RegistrationNumber = "007 SUZ";
            context.Cars.Add(car7);

            var car8 = new Car();
            car8.Mark = "Opel";
            car8.Model = "Insignia";
            car8.RegistrationNumber = "008 OPL";
            context.Cars.Add(car8);

            var car9 = new Car();
            car9.Mark = "Dacia";
            car9.Model = "Duster";
            car9.RegistrationNumber = "009 DAC";
            context.Cars.Add(car9);

            var car10 = new Car();
            car10.Mark = "Citroen";
            car10.Model = "Xantia";
            car10.RegistrationNumber = "010 CTR";
            context.Cars.Add(car10);

            context.SaveChanges();
        }
    }
}
