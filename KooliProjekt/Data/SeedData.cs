namespace KooliProjekt.Data
{
    public static class SeedData
    {

        public static void Generate(ApplicationDbContext context)
        {
            if (!context.Cars.Any())
            {

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

            if (!context.Statuses.Any())
            {

                var status1 = new Status();
                status1.StatusType = "Uus";
                context.Statuses.Add(status1);

                var status2 = new Status();
                status2.StatusType = "Tegemisel";
                context.Statuses.Add(status2);

                var status3 = new Status();
                status3.StatusType = "Ootel";
                context.Statuses.Add(status3);

                var status4 = new Status();
                status4.StatusType = "Valmis";
                context.Statuses.Add(status4);

                var status5 = new Status();
                status5.StatusType = "Uuesti tegemisele";
                context.Statuses.Add(status5);

                context.SaveChanges();
            }

            if (!context.Workers.Any())
            {

                var worker1 = new Worker();
                worker1.WorkerName = "Marek Tamm";
                worker1.Phone = "28473";
                worker1.Email = "marek.tamm@example.com";
                context.Workers.Add(worker1);

                var worker2 = new Worker();
                worker2.WorkerName = "Liis Mägi";
                worker2.Phone = "91542";
                worker2.Email = "liis.magi@example.com";
                context.Workers.Add(worker2);

                var worker3 = new Worker();
                worker3.WorkerName = "Karl Reimann";
                worker3.Phone = "63718";
                worker3.Email = "karl.reimann@example.com";
                context.Workers.Add(worker3);

                var worker4 = new Worker();
                worker4.WorkerName = "Annika Laanemets";
                worker4.Phone = "45029";
                worker4.Email = "annika.laanemets@example.com";
                context.Workers.Add(worker4);

                var worker5 = new Worker();
                worker5.WorkerName = "Toomas Põld";
                worker5.Phone = "38261";
                worker5.Email = "toomas.pold@example.com";
                context.Workers.Add(worker5);

                var worker6 = new Worker();
                worker6.WorkerName = "Kadi Sepp";
                worker6.Phone = "71904";
                worker6.Email = "kadi.sepp@example.com";
                context.Workers.Add(worker6);

                var worker7 = new Worker();
                worker7.WorkerName = "Martin Kask";
                worker7.Phone = "56387";
                worker7.Email = "martin.kask@example.com";
                context.Workers.Add(worker7);

                var worker8 = new Worker();
                worker8.WorkerName = "Helena Võsu";
                worker8.Phone = "80416";
                worker8.Email = "helena.vosu@example.com";
                context.Workers.Add(worker8);

                var worker9 = new Worker();
                worker9.WorkerName = "Rasmus Saar";
                worker9.Phone = "27639";
                worker9.Email = "rasmus.saar@example.com";
                context.Workers.Add(worker9);

                var worker10 = new Worker();
                worker10.WorkerName = "Laura Luik";
                worker10.Phone = "49285";
                worker10.Email = "laura.luik@example.com";
                context.Workers.Add(worker10);

                context.SaveChanges();
            }

            if (!context.Operations.Any())
            {
                var operation1 = new Operation();
                operation1.Action = "Auto tankimine";
                operation1.OperationDate = new DateTime(2024, 12, 20);
                operation1.Cost = 40;
                operation1.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "001 AUD").Id;
                operation1.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Marek Tamm").Id;
                operation1.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Uus").Id;
                context.Operations.Add(operation1);

                var operation2 = new Operation();
                operation2.Action = "Auto pesu";
                operation2.OperationDate = new DateTime(2024, 12, 06);
                operation2.Cost = 30;
                operation2.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "002 BMV").Id;
                operation2.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Liis Mägi").Id;
                operation2.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Tegemisel").Id;
                context.Operations.Add(operation2);

                var operation3 = new Operation();
                operation3.Action = "Pukseerimine";
                operation3.OperationDate = new DateTime(2024, 11, 25);
                operation3.Cost = 120;
                operation3.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "003 MBE").Id;
                operation3.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Karl Reimann").Id;
                operation3.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Ootel").Id;
                context.Operations.Add(operation3);

                var operation4 = new Operation();
                operation4.Action = "Pisiremont";
                operation4.OperationDate = new DateTime(2024, 11, 17);
                operation4.Cost = 73;
                operation4.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "004 LRD").Id;
                operation4.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Annika Laanemets").Id;
                operation4.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Valmis").Id;
                context.Operations.Add(operation4);

                var operation5 = new Operation();
                operation5.Action = "Suur remont";
                operation5.OperationDate = new DateTime(2024, 10, 15);
                operation5.Cost = 1450;
                operation5.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "005 TES").Id;
                operation5.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Toomas Põld").Id;
                operation5.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Uuesti tegemisele").Id;
                context.Operations.Add(operation5);

                var operation6 = new Operation();
                operation6.Action = "Kapitaalremont";
                operation6.OperationDate = new DateTime(2024, 10, 05);
                operation6.Cost = 7200;
                operation6.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "006 SAB").Id;
                operation6.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Kadi Sepp").Id;
                operation6.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Uus").Id;
                context.Operations.Add(operation6);

                var operation7 = new Operation();
                operation7.Action = "Auto transport";
                operation7.OperationDate = new DateTime(2024, 10, 03);
                operation7.Cost = 50;
                operation7.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "007 SUZ").Id;
                operation7.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Martin Kask").Id;
                operation7.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Tegemisel").Id;
                context.Operations.Add(operation7);

                var operation8 = new Operation();
                operation8.Action = "Hooldus";
                operation8.OperationDate = new DateTime(2024, 09, 30);
                operation8.Cost = 290;
                operation8.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "008 OPL").Id;
                operation8.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Helena Võsu").Id;
                operation8.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Ootel").Id;
                context.Operations.Add(operation8);

                var operation9 = new Operation();
                operation9.Action = "Poleerimine";
                operation9.OperationDate = new DateTime(2024, 09, 26);
                operation9.Cost = 85;
                operation9.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "009 DAC").Id;
                operation9.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Rasmus Saar").Id;
                operation9.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Valmis").Id;
                context.Operations.Add(operation9);

                var operation10 = new Operation();
                operation10.Action = "Salongi puhastus";
                operation10.OperationDate = new DateTime(2024, 09, 23);
                operation10.Cost = 25;
                operation10.CarId = context.Cars.FirstOrDefault(c => c.RegistrationNumber == "010 CTR").Id;
                operation10.WorkerId = context.Workers.FirstOrDefault(w => w.WorkerName == "Laura Luik").Id;
                operation10.StatusId = context.Statuses.FirstOrDefault(s => s.StatusType == "Uuesti tegemisele").Id;
                context.Operations.Add(operation10);

                context.SaveChanges();
            }
        }
    }
}
