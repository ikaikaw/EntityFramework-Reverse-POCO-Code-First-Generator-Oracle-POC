using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using TestDatabaseDataAnnotation;

namespace Tester
{
    [TestFixture]
    public class CrudTests
    {
        private ITestDatabaseDataAnnotationDbContext _db;
        private Dictionary<decimal, string> _regionDictionary;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _regionDictionary = new Dictionary<decimal, string>
            {
                { 1, "Europe" },
                { 2, "Americas" },
                { 3, "Asia" },
                { 4, "Middle East and Africa" }
            };
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            var employee = _db.Employees.FirstOrDefault(x => x.EmployeeId == 1000);
            if (employee == null)
                return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }

        [SetUp]
        public void SetUp()
        {
            _db = new TestDatabaseDataAnnotationDbContext();
            //_db.Database.Log = s => Console.WriteLine(s);
        }

        [Test]
        public void SimpleTableQuery_Expect_ExpectedResultSet()
        {
            var data = _db.Regions.Take(10).OrderBy(x => x.RegionId).ToList();

            AssertRegionData(data);
        }

        public void AssertRegionData(List<Region> data)
        {
            Assert.AreEqual(_regionDictionary.Count, data.Count);
            foreach (var region in data)
            {
                Assert.IsTrue(_regionDictionary.ContainsKey(region.RegionId));
                Assert.AreEqual(_regionDictionary[region.RegionId], region.RegionName);
            }
        }

        [Test]
        public void SelfReferencingTableQuery_Expect_CorrectRowCount()
        {
            var data = _db.Employees.OrderBy(c => c.FirstName).Take(10).ToList();
            Assert.AreEqual(10, data.Count);
        }

        [Test]
        public void Insert_and_delete_TEST_record_successfully_via_Find()
        {
            var db2 = new TestDatabaseDataAnnotationDbContext();
            var db3 = new TestDatabaseDataAnnotationDbContext();
            var employee = new Employee
            {
                EmployeeId = 1000,
                FirstName = "Nuno",
                LastName = "Leong",
                Email = "nuno.leong@email.com",
                PhoneNumber = "999,999,999",
                HireDate = DateTime.Now,
                JobId = "SH_CLERK",
                Salary = 1000,
                CommissionPct = 0,
                ManagerId = 123,
                DepartmentId = 50
            };

            db2.Employees.Add(employee);
            var customer2 = db2.Employees.Find(employee.EmployeeId);
            db2.Employees.Remove(customer2);
            var customer3 = db3.Employees.Find(employee.EmployeeId); // Should not be found

            Assert.IsNotNull(customer2);
            Assert.AreEqual(employee.EmployeeId, customer2.EmployeeId);
            Assert.AreEqual(employee.FirstName, customer2.FirstName);
            Assert.IsNull(customer3);
        }
    }
}
