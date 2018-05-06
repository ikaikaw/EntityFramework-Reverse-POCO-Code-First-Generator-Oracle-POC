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
    public class ProcedureNumberTests
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
        public void InvokeProcedureWithNumberNullParams_Expect_NumericOrValueExceptionFromDb()
        {
            // NATURALN and POSITIVEN must not be null
            Assert.That(() => 
                {
                    _db.TypeNumProc(
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null, // should not be null
                        null,
                        null,
                        null,
                        null,
                        null,
                        null, // should not be null
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        out var xDec,
                        out var xDecimal,
                        out var xDoublePrecisionVar,
                        out var xFloat,
                        out var xInt,
                        out var xInteger,
                        out var xNatural,
                        // out var xNaturalN,
                        out var xNumberF,
                        out var xNumeric,
                        out var xPls,
                        out var xBinary,
                        out var xPositive,
                        // out var xPositiveN,
                        out var xReal,
                        out var xSignType,
                        out var xSmallInt,
                        out var xBinaryDouble,
                        out var xBinaryFloat,
                        out var xNumber3Col
                        
                    );
                }, 
                Throws.Exception
                .TypeOf<OracleException>()
                .With.Message.StringContaining("ORA-06502: PL/SQL: numeric or value error")
            );
        }

        [Test]
        public void InvokeProcedureWithNumberNullableNullParams_Expect_CorrectResultFromDb()
        {
            _db.TypeNumProc(
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                1,
                null,
                null,
                null,
                null,
                null,
                1,
                null,
                null,
                null,
                null,
                null,
                null,
                out var xDec,
                out var xDecimal,
                out var xDoublePrecisionVar,
                out var xFloat,
                out var xInt,
                out var xInteger,
                out var xNatural,
                // out var xNaturalN,
                out var xNumberF,
                out var xNumeric,
                out var xPls,
                out var xBinary,
                out var xPositive,
                // out var xPositiveN,
                out var xReal,
                out var xSignType,
                out var xSmallInt,
                out var xBinaryDouble,
                out var xBinaryFloat,
                out var xNumber3Col
                
            );
            
            Assert.IsNull(xDec);
            Assert.IsNull(xDecimal);
            Assert.IsNull(xDoublePrecisionVar);
            Assert.IsNull(xFloat);
            Assert.IsNull(xInt);
            Assert.IsNull(xInteger);
            Assert.IsNull(xNatural);
            // Assert.IsNull(xNaturalN);
            Assert.IsNull(xNumberF);
            Assert.IsNull(xNumeric);
            Assert.IsNull(xPls);
            Assert.IsNull(xBinary);
            Assert.IsNull(xPositive);
            // Assert.IsNull(xPositiveN);
            Assert.IsNull(xReal);
            Assert.IsNull(xSignType);
            Assert.IsNull(xSmallInt);
            Assert.IsNull(xBinaryDouble);
            Assert.IsNull(xBinaryFloat);
            Assert.IsNull(xNumber3Col);
        }

        [Test]
        public void InvokeProcedureWithNumberParams_Expect_CorrectResultFromDb()
        {
            decimal vDec = 1.5m;
            decimal vDecimal = 1.5m;
            decimal vDoublePrecisionVar = 1.7m;
            decimal vFloat = 1.7m;
            decimal vInt = 1;
            decimal vInteger = 2;
            int vNatural = 5;
            int vNaturalN = 6;
            decimal vNumberF = 2;
            decimal vNumeric = 5;
            int vPls = 1;
            int vBinary = 1;
            int vPositive = 1;
            int vPositiveN = 3;
            decimal vReal = 5.5m;
            int vSignType = 1;
            decimal vSmallInt = 5;
            double vBinaryDouble = 54.3455d;
            float vBinaryFloat = 45.3454f;
            decimal vNumber3Col = 34;
            _db.TypeNumProc(
                vDec,
                vDecimal,
                vDoublePrecisionVar,
                vFloat,
                vInt,
                vInteger,
                vNatural,
                vNaturalN,
                vNumberF,
                vNumeric,
                vPls,
                vBinary,
                vPositive,
                vPositiveN,
                vReal,
                vSignType,
                vSmallInt,
                vBinaryDouble,
                vBinaryFloat,
                vNumber3Col,
                out var xDec,
                out var xDecimal,
                out var xDoublePrecisionVar,
                out var xFloat,
                out var xInt,
                out var xInteger,
                out var xNatural,
                // out var xNaturalN,
                out var xNumberF,
                out var xNumeric,
                out var xPls,
                out var xBinary,
                out var xPositive,
                // out var xPositiveN,
                out var xReal,
                out var xSignType,
                out var xSmallInt,
                out var xBinaryDouble,
                out var xBinaryFloat,
                out var xNumber3Col
            );
            
            Assert.AreEqual(xDec, vDec);
            Assert.AreEqual(xDecimal, vDecimal);
            Assert.AreEqual(xDoublePrecisionVar, vDoublePrecisionVar);
            Assert.AreEqual(xFloat, vFloat);
            Assert.AreEqual(xInt, vInt);
            Assert.AreEqual(xInteger, vInteger);
            Assert.AreEqual(xNatural, vNatural);
            // Assert.AreEqual(xNaturalN, vNaturalN);
            Assert.AreEqual(xNumberF, vNumberF);
            Assert.AreEqual(xNumeric, vNumeric);
            Assert.AreEqual(xPls, vPls);
            Assert.AreEqual(xBinary, vBinary);
            Assert.AreEqual(xPositive, vPositive);
            // Assert.AreEqual(xPositiveN, vPositiveN);
            Assert.AreEqual(xReal, vReal);
            Assert.AreEqual(xSignType, vSignType);
            Assert.AreEqual(xSmallInt, vSmallInt);
            Assert.AreEqual(xBinaryDouble, vBinaryDouble);
            Assert.AreEqual(xBinaryFloat, vBinaryFloat);
            Assert.AreEqual(xNumber3Col, vNumber3Col);
        }

        [Test]
        public void InvokeProcedureWith_NATURALN_NullInputParam_Expect_NumericOrValueExceptionFromDb()
        {
            Assert.That(() => 
                {
                    _db.TypeNaturalnProc2(
                        null
                    );
                }, 
                Throws.Exception
                .TypeOf<OracleException>()
                .With.Message.StringContaining("ORA-06502: PL/SQL: numeric or value error")
            );
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void InvokeProcedureWith_NATURALN_ValidInputParam_Expect_CorrectResultFromDb(int? value)
        {
            _db.TypeNaturalnProc2(
                value
            );
            Assert.True(true);
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(-1)]
        public void InvokeProcedureWith_NATURALN_InvalidInputParam_Expect_NumericOrValueExceptionFromDb(int? value)
        {
            // NATURALN requires non-nullable non-negative integers up to 2^31
            Assert.That(() => 
                {
                    _db.TypeNaturalnProc2(
                        value
                    );
                }, 
                Throws.Exception
                .TypeOf<OracleException>()
                .With.Message.StringContaining("ORA-06502: PL/SQL: numeric or value error")
            );
        }

        [Test]
        public void InvokeProcedureWith_NATURALN_OutputParam_Expect_NumericOrValueExceptionFromDb()
        {
            Assert.That(() => 
                {
                    _db.TypeNaturalnProc(
                        null,
                        out var xNaturalN
                    );
                }, 
                Throws.Exception
                .TypeOf<OracleException>()
                .With.Message.StringContaining("ORA-06502: PL/SQL: numeric or value error")
            );
        }
    }
}
