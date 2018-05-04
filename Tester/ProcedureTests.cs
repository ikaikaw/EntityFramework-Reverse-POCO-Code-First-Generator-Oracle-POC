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
    public class ProcedureTests
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
        public void InvokeSimpleFunc_Expect_CorrectResultFromDb()
        {
            var ret = _db.TestFunc1();
            
            Assert.IsNotNull(ret);
            Assert.AreEqual(10, ret);
        }

        [Test]
        public void InvokeSumTwoNumbersFunc_WithIntParams_Expect_CorrectResultFromDb()
        {
            var ret = _db.TestFunc2(1, 2);
            
            Assert.IsNotNull(ret);
            Assert.AreEqual(3, ret);
        }

        [Test]
        public void InvokeSumTwoNumbersFunc_WithDecimalParams_Expect_CorrectResultFromDb()
        {
            var ret = _db.TestFunc2(1.2m, 2.3m);
            
            Assert.IsNotNull(ret);
            Assert.AreEqual(3.5m, ret);
        }

        [Test]
        public void InvokeSumTwoNumbersFunc_WithOneNullParam_Expect_NullResultFromDb()
        {
            var ret = _db.TestFunc2(1, null);
            
            Assert.IsNull(ret);
        }

        [Test]
        public void InvokeSumTwoNumbersFunc_WithAllNullParams_Expect_NullResultFromDb()
        {
            var ret = _db.TestFunc2(null, null);
            
            Assert.IsNull(ret);
        }

        [Test]
        public void InvokeFuncWithMultipleDirectionParams_Expect_NullResultFromDb()
        {
            var inOutStr = "YYY";
            var ret = _db.TestFunc3(1, 2, ref inOutStr, out var outNum);
            
            Assert.IsNotNull(ret);
            Assert.IsNotNull(inOutStr);
            Assert.IsNotNull(outNum);
            Assert.AreEqual(3, ret);
            Assert.AreEqual(inOutStr, "_XXX_");
            Assert.AreEqual(3, outNum);
        }

        [Test]
        public void InvokeFuncThatReturnsNull_Expect_NullResultFromDb()
        {
            var ret = _db.TestFunc4();
            
            Assert.IsNull(ret);
        }

        [Test]
        public void InvokeFuncThatReturnsString_Expect_CorrectResultFromDb()
        {
            var ret = _db.TestFunc5();
            
            Assert.IsNotNull(ret);
            Assert.AreEqual("_XXX_", ret);
        }

        [Test]
        public void InvokePkgProcedureWithSameNameAsExistingStandaloneProcedure_Expect_CorrectResultFromDb()
        {
            _db.TestPkgTypeNumProc();

            Assert.True(true);
        }

        [Test]
        public void InvokePackageProcedureWithParameterDirections_Expect_CorrectResultFromDb()
        {
            var inOutStr = "YYY";
            _db.TestPkgTestProc1(1, 2, ref inOutStr, out var outNum);
            
            Assert.IsNotNull(inOutStr);
            Assert.IsNotNull(outNum);
            Assert.AreEqual(inOutStr, "_XXX_");
            Assert.AreEqual(3, outNum);
        }

        [Test]
        public void InvokePkgFunctionWithSameNameAsExistingStandaloneFunction_Expect_CorrectResultFromDb()
        {
            
            var inOutStr = "YYY";
            var ret = _db.TestPkgTestFunc3(1, 2, ref inOutStr, out var outNum);
            
            Assert.IsNotNull(ret);
            Assert.IsNotNull(inOutStr);
            Assert.IsNotNull(outNum);
            Assert.AreEqual(2, ret);
            Assert.AreEqual(inOutStr, "_XXXXXX_");
            Assert.AreEqual(2, outNum);
        }
    }
}
