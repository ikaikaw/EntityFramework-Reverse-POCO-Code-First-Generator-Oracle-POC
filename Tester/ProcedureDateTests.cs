using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Schema;
using NUnit.Framework;
using Oracle.ManagedDataAccess.Client;
using TestDatabaseDataAnnotation;

namespace Tester
{
    [TestFixture]
    public class ProcedureDateTests
    {
        private ITestDatabaseDataAnnotationDbContext _db;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }

        [SetUp]
        public void SetUp()
        {
            _db = new TestDatabaseDataAnnotationDbContext();
        }
        
        [Test]
        public void InvokeProcedureWithDateParams_Expect_CorrectResultFromDb()
        {
            System.DateTime? pDatecol = DateTime.Now;
            System.DateTime? pTimestampcol = DateTime.Now;
            System.DateTime? pDatedefaultcol = DateTime.Now;
            System.DateTime? pDatedefault2Col = DateTime.Now;
            System.DateTime? pTimestampdefaultcol = DateTime.Now;
            System.DateTime? pTimestampdefault2Col = DateTime.Now;
            System.DateTimeOffset? pTimestamptzcol = DateTimeOffset.Now;
            System.DateTime? pTimestampltzzcol = DateTime.Now;
            decimal? pIntervalYearToMonth = 50;
            System.TimeSpan? pIntervalDayToSec = new TimeSpan(20, 15, 10, 5);
            _db.TypeDateProc(
                pDatecol,
                pTimestampcol,
                pDatedefaultcol,
                pDatedefault2Col,
                pTimestampdefaultcol,
                pTimestampdefault2Col,
                pTimestamptzcol,
                pTimestampltzzcol,
                pIntervalYearToMonth,
                pIntervalDayToSec,
                out var xDatecol,
                out var xTimestampcol,
                out var xDatedefaultcol,
                out var xDatedefault2Col,
                out var xTimestampdefaultcol,
                out var xTimestampdefault2Col,
                out var xTimestamptzcol,
                out var xTimestampltzzcol,
                out var xIntervalYearToMonth,
                out var xIntervalDayToSec
            );

            Assert.NotNull(xDatecol);
            // we can't directly compare System.DateTime to Oracle Date. Oracle Date does not have ms precision.
            Assert.AreEqual(xDatecol.Value.ToString("s"), pDatecol.Value.ToString("s"));

            Assert.NotNull(xTimestampcol);
            // we can't directly compare System.DateTime to Oracle Timestamp(6). System.DateTime has precision 7 and default Oracle Timestamp has 6.
            // Expected: 636609705670488750 -> passing through Oracle and back to .NET
            // But was:  636609705670488748 -> original value
            Assert.AreEqual(RoundOneDigit(xTimestampcol.Value.Ticks), RoundOneDigit(xTimestampcol.Value.Ticks));

            Assert.NotNull(xDatecol);
            Assert.AreEqual(xDatedefaultcol.Value.ToString("s"), pDatedefaultcol.Value.ToString("s"));

            Assert.NotNull(xDatecol);
            Assert.AreEqual(xDatedefault2Col.Value.ToString("s"), pDatedefault2Col.Value.ToString("s"));

            Assert.NotNull(xTimestampdefaultcol);
            Assert.AreEqual(RoundOneDigit(xTimestampdefaultcol.Value.Ticks), RoundOneDigit(pTimestampdefaultcol.Value.Ticks));

            Assert.NotNull(xTimestampdefault2Col);
            Assert.AreEqual(RoundOneDigit(xTimestampdefault2Col.Value.Ticks), RoundOneDigit(pTimestampdefault2Col.Value.Ticks));

            Assert.NotNull(xTimestamptzcol);
            Assert.AreEqual(RoundOneDigit(xTimestamptzcol.Value.Ticks), RoundOneDigit(pTimestamptzcol.Value.Ticks));
            Assert.AreEqual(xTimestamptzcol.Value.Offset.Ticks, pTimestamptzcol.Value.Offset.Ticks);

            Assert.NotNull(xTimestampltzzcol);
            Assert.AreEqual(RoundOneDigit(xTimestampltzzcol.Value.Ticks), RoundOneDigit(pTimestampltzzcol.Value.Ticks));

            Assert.AreEqual(xIntervalYearToMonth, pIntervalYearToMonth);
            Assert.AreEqual(xIntervalDayToSec.Value.Ticks, pIntervalDayToSec.Value.Ticks);
        }

        private static long RoundOneDigit(long value)
        {
            return (long)Math.Round(value / 10m);
        }
    }
}
