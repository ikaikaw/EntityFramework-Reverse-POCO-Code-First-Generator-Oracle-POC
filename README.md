
## EntityFramework Reverse POCO Code First Generator Oracle POC

This a proof-of-concept of modifying the excellent EntityFramework Reverse POCO Code First Generator to target Oracle databases. The purpose is to test and tweak the necessary oracle dictionary queries as well identify potential additional changes on the original templates themselves.

Please check the original repository [here](https://github.com/sjh37/EntityFramework-Reverse-POCO-Code-First-Generator) for the latest production release, which targets MS SQL Server.

Summary of changes:
* EntityFramework.Reverse.POCO.Generator project
  * Add NuGet package Oracle.ManagedDataAccess

* EF.Reverse.POCO.Core.ttinclude
  * Reference assembly Oracle.ManagedDataAccess.dll
  * Change method GetDbProviderFactory() to support OracleFactory
  * Changed casts to Converts
  * Changed method GetPropertyType() to receive additional params (precision, scale, etc)
  * Changed TableSQL() and IndexSQL() methods to query the Oracle dictionary

* TODO:
  * Handle table default values 
  * Handle PL/SQL procedures, functions and packages
  * Add more unit tests 
