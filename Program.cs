using System;
using System.Diagnostics.Metrics;

class Programm
{
    abstract class MetallProducts                                                       // Абстрактный класс - Металлопродукция
    {
        public string grade;                                                            // Марка стали
        public double quantity;                                                         // Количество, т
        public double price;                                                            // Цена, руб/т
    }

    class Wire : MetallProducts                                                         // Класс наследник - Проволока
    {
        public double diameter;                                                         // Диаметр проволоки
    }

    class Corner : MetallProducts                                                       // Класс наследник - Уголок
    {
        public int polka;                                                               // Номер уголка (размер полки)
    }

    class Sclad                                                                         // Класс - Склад 
    {
        Wire[] wires;
        Corner[] corners;

        public double premium;                                                          // Сбытовая надбавка
        public double Premium
        {
            get
            {
                return premium;
            }
            set
            {
                premium = value;
            }
        }

        public void InitWire(int x)
        {
            wires = new Wire[x];
        }

        public void AddWire(int x, Wire wire)
        {
            wires[x] = wire;
        }

        public void ViewWire()                                                          // Вывод данных по проволоке на складе
        {
            Console.WriteLine("Запасы металлопродукции на складе:\n");
            foreach (Wire wire in wires)
            {
                Console.WriteLine("Проволока, диаметр (мм): " + wire.diameter + ", марка стали: " + wire.grade + ", количество (т): " + wire.quantity + ", цена (руб/т): " + wire.price);
            }
            Console.WriteLine();
        }

        public void InitCorner(int y)
        {
            corners = new Corner[y];
        }

        public void AddCorner(int y, Corner corner)
        {
            corners[y] = corner;
        }

        public void ViewCorner()                                                            // Вывод данных по уголку на складе
        {
            foreach (Corner corner in corners)
            {
                Console.WriteLine("Уголок, номер: " + corner.polka + ", марка стали: " + corner.grade + ", количество (т): " + corner.quantity + ", цена (руб/т): " + corner.price);
            }
            Console.WriteLine();
        }

        public void ViewCost()
        { 
            Cost();
        }

        private void Cost()                                                                 // Приватный класс - расчет стоимости металла на складе с учетом сбытовой надбавки
        {
            double cost = 0;

            foreach (Wire wire in wires)
            {
                cost = cost + wire.price * wire.quantity;
            }

            foreach (Corner corner in corners)
            {
                cost = cost + corner.price * corner.quantity;
            }
            cost = cost * premium;

            Console.WriteLine("\nПРИВАТНАЯ ИНФОРМАЦИЯ\nСтоимость металлопродукции на складе (с учетом сбытовой надбавки): " + cost + " рублей.");
        }
    }

    static void Main(string[] args)
    {
        Sclad sclad = new Sclad();
        sclad.InitWire(2);
        sclad.InitCorner(4);

        sclad.Premium = 1.15;

        Wire wire1 = new Wire();
        wire1.grade = "Сталь3";wire1.price = 86354;wire1.diameter = 6; wire1.quantity = 8.3;
        sclad.AddWire(0,wire1);
        Wire wire2 = new Wire();
        wire2.grade = "Сталь20"; wire2.price = 124508;wire2.diameter = 6; wire2.quantity = 6.7;
        sclad.AddWire(1, wire2);

        Corner corner1 = new Corner();
        corner1.grade = "Сталь3"; corner1.price = 73299; corner1.polka = 63; corner1.quantity = 12.0;
        sclad.AddCorner(0, corner1);
        Corner corner2 = new Corner();
        corner2.grade = "Сталь20"; corner2.price = 89120; corner2.polka = 63; corner2.quantity = 9.1;
        sclad.AddCorner(1, corner2);
        Corner corner3 = new Corner();
        corner3.grade = "Сталь3"; corner3.price = 71313; corner3.polka = 75; corner3.quantity = 15.4;
        sclad.AddCorner(2, corner3);
        Corner corner4 = new Corner();
        corner4.grade = "Сталь20"; corner4.price = 85425; corner4.polka = 75; corner4.quantity = 21.5;
        sclad.AddCorner(3, corner4);

        sclad.ViewWire();
        sclad.ViewCorner();
        sclad.ViewCost();
   }
}
