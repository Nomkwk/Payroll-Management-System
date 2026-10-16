using System;
using System.Collections.Generic;

namespace EmployeeLibrary
{
    public static class Data
    {
        //static class with static method
        public static List<Employee> GetSampleEmployees()
        {
            return new List<Employee>
       {
    // 5 Hourly Employees
    new Hourly("123456789", "James", "Holden", new DateTime(2020, 05, 10), new DateTime(1985, 04, 23), "j.holden@roc.com", "9055551001",
        new Address("821 Canterbury Dr", "Welland", "ON", "L3C0L1"), false, 25.50m, 40.0m),
    new Hourly("234567890", "Naomi", "Nagata", new DateTime(2021, 03, 12), new DateTime(1988, 07, 22), "n.nagata@roc.com", "4165551002",
        new Address("45 Ceres St", "Toronto", "ON", "M5H2N2"), true, 45.00m, 37.5m),
    new Hourly("345678901", "Amos", "Burton", new DateTime(2019, 08, 30), new DateTime(1984, 11, 02), "a.burton@roc.com", "2895551003",
        new Address("102 Baltimore Ave", "Hamilton", "ON", "L8P1A1"), true, 30.00m, 50.0m),
    new Hourly("456789012", "Alex", "Kamal", new DateTime(2022, 01, 15), new DateTime(1982, 04, 23), "a.kamal@roc.com", "5195551004",
        new Address("22 Mariner Valley", "London", "ON", "N6A3K7"), true, 28.75m, 42.0m),
    new Hourly("567890123", "Roberta", "Draper", new DateTime(2023, 06, 20), new DateTime(1995, 04, 12), "b.draper@mars.com", "6135551005",
        new Address("117 MCRN Way", "Ottawa", "ON", "K1P5M7"), true, 35.00m, 38.0m),

    // 5 Salary Employees
    new Salary("678901234", "Chrisjen", "Avasarala", new DateTime(2010, 09, 01), new DateTime(1960, 01, 30), "c.avasarala@un.gov", "2125552001",
        new Address("1 UN Plaza", "New York", "NY", "100170"), true, 150000m),
    new Salary("789012345", "Fred", "Johnson", new DateTime(2015, 11, 15), new DateTime(1970, 06, 14), "f.johnson@tycho.org", "9055552002",
        new Address("500 Tycho Station", "Niagara", "ON", "L2E6X5"), true, 95000m),
    new Salary("890123456", "Camina", "Drummer", new DateTime(2018, 04, 25), new DateTime(1989, 10, 05), "c.drummer@belter.com", "9055552003",
        new Address("88 Pallas Blvd", "St. Catharines", "ON", "L2R7K4"), true, 110000m),
    new Salary("901234567", "Sadavir", "Errinwright", new DateTime(2012, 02, 10), new DateTime(1968, 12, 21), "s.errin@un.gov", "9055552004",
        new Address("404 High Tower", "Welland", "ON", "L3C1W1"), true, 200000m),
    new Salary("012345678", "Jules-Pierre", "Mao", new DateTime(2005, 01, 01), new DateTime(1965, 08, 09), "jp.mao@mao-kwik.com", "4165552005",
        new Address("999 Wealth Row", "Toronto", "ON", "M4W2G8"), true, 500000m),

    // 5 Training Employees
    new Training("111222333", "Elvi", "Okoye", new DateTime(2026, 04, 18), new DateTime(1993, 06, 18), "e.okoye@science.edu", "9055553001",
        new Address("314 Pi Lane", "Thorold", "ON", "L2V4Y6"), true, 50),
    new Training("222333444", "Praxidike", "Meng", new DateTime(2026, 04, 17), new DateTime(1987, 09, 25), "p.meng@ganymede.org", "9055553002",
        new Address("77 Botanical Gdns", "Welland", "ON", "L3B3A1"), true, 60),
    new Training("333444555", "Filip", "Inaros", new DateTime(2026, 03, 15), new DateTime(2002, 12, 12), "f.inaros@belt.com", "9055553003",
        new Address("12 Free Navy Rd", "Port Colborne", "ON", "L3K5V3"), true, 20),
    new Training("444555666", "Alvin", "Mao", new DateTime(2026, 04, 14), new DateTime(1995, 02, 28), "c.mao@mao-kwid.com", "9055553004",
        new Address("14 Cell Block B", "Welland", "ON", "L3C5Z8"), true, 50),
    new Training("555666777", "Cotyar", "Ghazi", new DateTime(2026, 03, 12), new DateTime(1980, 04, 15), "c.ghazi@security.un", "9055553005",
        new Address("21 Spyglass Crt", "Hamilton", "ON", "L9G3K1"), true, 30)
};

        }

    }
}
