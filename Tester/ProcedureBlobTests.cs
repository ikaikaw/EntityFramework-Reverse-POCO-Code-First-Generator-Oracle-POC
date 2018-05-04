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
    public class ProcedureBlobTests
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
        public void InvokeProcedureWithBlobOutputParam_Expect_CorrectResultFromDb()
        {
            byte[] pBlobcol = new byte[3999];
            new Random().NextBytes(pBlobcol);
            
            _db.TypeBlobProc(
                pBlobcol,
                out var xBlobcol
            );

            Assert.NotNull(xBlobcol);
            Assert.True(ByteArrayCompare(xBlobcol, pBlobcol));
        }

        [Test]
        public void InvokeProcedureWithLargeBlobOutputParam_Expect_OracleExceptionFromDB()
        {
            // blob's larger than 3999 will throw an error, if used as Out parameter
            byte[] pBlobcol = new byte[4000];
            new Random().NextBytes(pBlobcol);
            
            Assert.Throws<OracleException>( () =>
            {
                _db.TypeBlobProc(
                    pBlobcol,
                    out var xBlobcol
                );
            });
        }

        [Test]
        public void InvokeProcedureWithBlobInputOutputParam_Expect_EmptyResultFromDb()
        {
            byte[] pBlobcol = new byte[1];
            new Random().NextBytes(pBlobcol);
            
            _db.TypeBlobProcInout(
                ref pBlobcol
            );

            Assert.NotNull(pBlobcol);
            Assert.AreEqual(0, pBlobcol.Length);
        }
        [Test]
        public void InvokeProcedureWithBlobInputOutputParam_Expect_CorrectResultFromDb()
        {
            byte[] pBlobcol = new byte[3999];
            new Random().NextBytes(pBlobcol);
            
            _db.TypeBlobProcInout2(
                ref pBlobcol
            );

            Assert.NotNull(pBlobcol);
            Assert.AreEqual(3999, pBlobcol.Length);
        }

        [Test]
        public void InvokeProcedureWithLargeBlobInputOutputParam_Expect_CorrectResultFromDb()
        {
            byte[] pBlobcol = new byte[50000];
            new Random().NextBytes(pBlobcol);
            
            _db.TypeBlobProcInout2(
                ref pBlobcol
            );

            Assert.NotNull(pBlobcol);
            Assert.AreEqual(50000, pBlobcol.Length);
        }

        [Test]
        public void InvokeProcedure2WithBlobInputOutputParam_Expect_CorrectResultFromDb()
        {
            byte[] pBlobcol = new byte[3999];
            new Random().NextBytes(pBlobcol);
            
            _db.TypeBlobProcInout3(
                ref pBlobcol
            );

            Assert.NotNull(pBlobcol);
            Assert.AreEqual(3999, pBlobcol.Length);
        }

        [Test]
        public void InvokeProcedure2WithLargeBlobInputOutputParam_Expect_CorrectResultFromDb()
        {
            byte[] pBlobcol = new byte[50000];
            new Random().NextBytes(pBlobcol);
            
            _db.TypeBlobProcInout3(
                ref pBlobcol
            );

            Assert.NotNull(pBlobcol);
            Assert.AreEqual(50000, pBlobcol.Length);
        }

        [Test]
        public void InvokeFuncWithBlobReturnValue_Expect_CorrectResultFromDb()
        {
            byte[] pBlobcol = new byte[3999];
            new Random().NextBytes(pBlobcol);
            
            var xBlobcol = _db.TypeBlobFunc(
                pBlobcol
            );

            Assert.NotNull(xBlobcol);
            Assert.True(ByteArrayCompare(xBlobcol, pBlobcol));
        }

        [Test]
        public void InvokeFuncWithLargeBlobReturnValue_Expect_CorrectResultFromDb()
        {
            byte[] pBlobcol = new byte[500000];
            new Random().NextBytes(pBlobcol);
            
            var xBlobcol = _db.TypeBlobFunc(
                    pBlobcol
                );
            
            Assert.NotNull(xBlobcol);
            Assert.True(ByteArrayCompare(xBlobcol, pBlobcol));
        }

        private static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (var i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }
    }
}
