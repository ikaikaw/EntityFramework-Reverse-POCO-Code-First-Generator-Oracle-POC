
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

TODO
* StoreGeneratedPattern
  * oracle 12.2 identity ?
  * oracle <12.2 poor man's trigger ?
		
* Tables and Views
  * Reevaluate LONG
  * Filter tables containing columns of type "interval day to second"

* PL/SQL
  * Add "Setting" for PL/SQL string parameter size: 32767
  * Create comments for each parameter of SP describing it's oracle type (example, System.DateTime vs DATE VS TIMESTAMP)
  * Reevaluate LONG  

		
Notes and Limitations
* Tables and Views
  * Data type "interval day to second" is not supported by Oracle.ManagedDataAccess.Client
* PL/SQL
  * Ditched Database.ExecuteSqlCommand in favor of OracleCommand because LOB parameters would be inaccessible (since the connection is closed after Database.ExecuteSqlCommand is executed)
  * Output Parameters of type Lob and Clob higher than 3999 and NClob higher than 1999 are not working with Oracle.ManagedDataAccess.Client (they do work with the old Oracle.DataAccessClient)
  * System.DateTime To Oracle DATE only has second precision
  * System.DateTime To Oracle TIMESTAMP only has 6 fractional places
    * Expected: 63660970567.0488750
    * But was:  63660970567.0488748
  
