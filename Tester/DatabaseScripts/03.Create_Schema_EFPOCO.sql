--
-- data type tests
--
--
 
-- drop table type_num_table;
create table type_num_table (
pk                  number(18) primary key,
deccol              dec(38),
deccol2             dec(38,10),
decdefaultcol       dec(38,10) default 10.0,
decdefault2col       dec(38,10) default (10.0),
decdefault3col       dec(38,10) default ((10.0)),
decimalcol          decimal(38),
decimalcol2         decimal(38,10),
doubleprecisioncol  double precision,
floatcol            float(126),
intcol              int,
integercol          integer,
numbercol           number(38),
numberdefaultcol    number(38) default 1,
numberdefault2col   number(38) default to_number('1'),
numberdefault3col   number(38) default (1 + to_number('1')),
numberfcol          number,
numericcol          numeric(38),
numericfcol         numeric,
realcol             real,
smallintcol         smallint,
number1col          number(1),
number1col2         number(1,0),
number2col          number(2),
number3col          number(3),
number4col          number(4),
number4col2         number(4,0),
number5col          number(5),
number5col2         number(5,0),
number6col          number(6),
number7col          number(7),
number8col          number(8),
number9col          number(9),
number10col         number(10),
number10col2        number(10,0),
number11col         number(11),
number11col2        number(11,0),
number12col         number(12),
number13col         number(13),
number14col         number(14),
number15col         number(15),
number16col         number(16),
number17col         number(17),
number18col         number(18),
number19col         number(19),
number19col2        number(19,0),
number20col         number(20),
number20col2        number(20,0),
number21col         number(21),
number22col         number(22),
number23col         number(23),
number24col         number(24),
number25col         number(25)
);

create or replace procedure type_num_proc (
    p_decvar				in dec,
    p_decimalvar			in decimal,
    p_doubleprecisionvar	in double precision,
    p_floatvar				in float,
    p_intvar				in int,
    p_integervar			in integer,
    p_naturalvar			in natural,
    p_naturalnvar			in naturaln,
    p_numberfvar			in number,
    p_numericvar			in numeric,
    p_plsvar				in pls_integer,
    p_binaryvar             in binary_integer,
    p_positivevar			in positive,
    p_positivenvar			in positiven,
    p_realvar				in real,
    p_signtypevar			in signtype,
    p_smallintvar			in smallint,
    --p_simplevar           in simple_integer;-- 11g
    p_binarydoublevar		in binary_double,
    p_binaryfloatvar		in binary_float,
	x_decvar				out dec,
    x_decimalvar			out decimal,
    x_doubleprecisionvar	out double precision,
    x_floatvar				out float,
    x_intvar				out int,
    x_integervar			out integer,
    x_naturalvar			out natural,
    x_naturalnvar			out naturaln,
    x_numberfvar			out number,
    x_numericvar			out numeric,
    x_plsvar				out pls_integer,
    x_binaryvar             out binary_integer,
    x_positivevar			out positive,
    x_positivenvar			out positiven,
    x_realvar				out real,
    x_signtypevar			out signtype,
    x_smallintvar			out smallint,
    --x_simplevar           out simple_integer;-- 11g
    x_binarydoublevar		out binary_double,
    x_binaryfloatvar		out binary_float
) 
is
begin
	x_decvar := p_decvar;
	x_decimalvar := p_decimalvar;
	x_doubleprecisionvar := p_doubleprecisionvar;
	x_floatvar := p_floatvar;
	x_intvar := p_intvar;
	x_integervar := p_integervar;
	x_naturalvar := p_naturalvar;
	x_naturalnvar := p_naturalnvar;
	x_numberfvar := p_numberfvar;
	x_numericvar := p_numericvar;
	x_plsvar := p_plsvar;
	x_binaryvar := p_binaryvar;
	x_positivevar := p_positivevar;
	x_positivenvar := p_positivenvar;
	x_realvar := p_realvar;
	x_signtypevar := p_signtypevar;
	x_smallintvar := p_smallintvar;
	x_binarydoublevar := p_binarydoublevar;
	x_binaryfloatvar := p_binaryfloatvar;
end;
/

create or replace procedure type_num_proc_inout (
    p_decvar				in out dec,
    p_decimalvar			in out decimal,
    p_doubleprecisionvar	in out double precision,
    p_floatvar				in out float,
    p_intvar				in out int,
    p_integervar			in out integer,
    p_naturalvar			in out natural,
    p_naturalnvar			in out naturaln,
    p_numberfvar			in out number,
    p_numericvar			in out numeric,
    p_plsvar				in out pls_integer,
    p_binaryvar             in out binary_integer,
    p_positivevar			in out positive,
    p_positivenvar			in out positiven,
    p_realvar				in out real,
    p_signtypevar			in out signtype,
    p_smallintvar			in out smallint,
    --p_simplevar           in out simple_integer;-- 11g
    p_binarydoublevar		in out binary_double,
    p_binaryfloatvar		in out binary_float
) 
is
begin
	p_decvar := p_decvar * -1;
	p_decimalvar := p_decimalvar * -1;
	p_doubleprecisionvar := p_doubleprecisionvar * -1;
	p_floatvar := p_floatvar * -1;
	p_intvar := p_intvar * -1;
	p_integervar := p_integervar * -1;
	p_naturalvar := p_naturalvar * -1;
	p_naturalnvar := p_naturalnvar * -1;
	p_numberfvar := p_numberfvar * -1;
	p_numericvar := p_numericvar * -1;
	p_plsvar := p_plsvar * -1;
	p_binaryvar := p_binaryvar * -1;
	p_positivevar := p_positivevar * -1;
	p_positivenvar := p_positivenvar * -1;
	p_realvar := p_realvar * -1;
	p_signtypevar := p_signtypevar * -1;
	p_smallintvar := p_smallintvar * -1;
	p_binarydoublevar := p_binarydoublevar * -1;
	p_binaryfloatvar := p_binaryfloatvar * -1;
end;
/



--drop table type_char_table;
create table type_char_table (
pk                          number(18) primary key,
charcol                     char(2000),
charvaryingcol              char varying(4000),
charactercol                character(2000),
charactervaryingcol         character varying(4000),
nationalcharvarying         national char varying(2000),
nationalcharactervaryingcol national character varying(2000),
ncharcol                    nchar(1000),
ncharvaryingcol             nchar varying(2000),
nvarchar2col                nvarchar2(2000),
varcharcol                  varchar(4000),
varchar2col                 varchar2(4000),
varchar2defaultcol          varchar2(4000) default 'default_value_for_varchar2',
varchar2default2col          varchar2(4000) default ('default_value_for_varchar2'),
varchar2default3col         varchar2(4000) default to_char(sysdate, 'rrrr-mm-dd'),
varchar2default4col         varchar2(4000) default to_char    (     sysdate, 'rrrr-mm-dd'),
varchar2default6col         varchar2(4000) default to_char    
(     
sysdate,
 'rrrr-mm-dd'
),
varchar2default7col         varchar2(4000) default '''should_be_wrapped_in_single_quotes'' - "more text in double quotes" - yet more text',
longdefaultcol              long default 'default_value_for_long',
clobcol                     clob,
clobdefaultcol              clob default 'default_value_for_clob',
nclobcol                    nclob
);


create or replace procedure type_char_proc ( 
    p_charcol                     in char,
    p_charvaryingvar              in char varying,
    p_charactervar                in character,
    p_charactervaryingvar         in character varying,
    p_nationalcharvaryvar         in national char varying,
    p_nationalcharactervaryingvar in national character varying,
    p_ncharvar                    in nchar,
    p_ncharvaryingvar             in nchar varying,
    p_nvarchar2var                in nvarchar2,
    p_stringvar                   in string,
    p_varcharvar                  in varchar,
    p_varchar2var                 in varchar2,
   -- p_long                      in long,
    p_clobcol                     in clob,
    p_nclobcol                    in nclob,
	x_charcol                     out char,
    x_charvaryingvar              out char varying,
    x_charactervar                out character,
    x_charactervaryingvar         out character varying,
    x_nationalcharvaryvar         out national char varying,
    x_nationalcharactervaryingvar out national character varying,
    x_ncharvar                    out nchar,
    x_ncharvaryingvar             out nchar varying,
    x_nvarchar2var                out nvarchar2,
    x_stringvar                   out string,
    x_varcharvar                  out varchar,
    x_varchar2var                 out varchar2,
   -- x_long                      out long,
    x_clobcol                     out clob,
    x_nclobcol                    out nclob
)
is
v_charcol                     char(32767);
v_charvaryingvar              char varying(32767);
v_charactervar                character(32767);
v_charactervaryingvar         character varying(32767);
v_nationalcharvaryvar         national char varying(32767);
v_nationalcharactervaryingvar national character varying(32767);
v_ncharvar                    nchar(32767);
v_ncharvaryingvar             nchar varying(32767);
v_nvarchar2var                nvarchar2(32767);
v_stringvar                   string(32767);
v_varcharvar                  varchar(32767);
v_varchar2var                 varchar2(32767);
v_varlong                    long;
begin
	x_charcol := p_charcol;
	x_charvaryingvar := p_charvaryingvar;
	x_charactervar := p_charactervar;
	x_charactervaryingvar := p_charactervaryingvar;
	x_nationalcharvaryvar := p_nationalcharvaryvar;
	x_nationalcharactervaryingvar := p_nationalcharactervaryingvar;
	x_ncharvar := p_ncharvar;
	x_ncharvaryingvar := p_ncharvaryingvar;
	x_nvarchar2var := p_nvarchar2var;
	x_stringvar := p_stringvar;
	x_varcharvar := p_varcharvar;
	x_varchar2var := p_varchar2var;
	--x_long := --p_long;
	x_clobcol := p_clobcol;
	x_nclobcol := p_nclobcol;
end;
/

create or replace procedure type_char_proc_inout ( 
    p_charcol                     in out char,
    p_charvaryingvar              in out char varying,
    p_charactervar                in out character,
    p_charactervaryingvar         in out character varying,
    p_nationalcharvaryvar         in out national char varying,
    p_nationalcharactervaryingvar in out national character varying,
    p_ncharvar                    in out nchar,
    p_ncharvaryingvar             in out nchar varying,
    p_nvarchar2var                in out nvarchar2,
    p_stringvar                   in out string,
    p_varcharvar                  in out varchar,
    p_varchar2var                 in out varchar2,
   -- p_long                      in out long,
    p_clobcol                     in out clob,
    p_nclobcol                    in out nclob
)
is
begin
	p_charcol := p_charcol || '_XXX_';
	p_charvaryingvar := p_charvaryingvar || '_XXX_';
	p_charactervar := p_charactervar || '_XXX_';
	p_charactervaryingvar := p_charactervaryingvar || '_XXX_';
	p_nationalcharvaryvar := p_nationalcharvaryvar || '_XXX_';
	p_nationalcharactervaryingvar := p_nationalcharactervaryingvar || '_XXX_';
	p_ncharvar := p_ncharvar || '_XXX_';
	p_ncharvaryingvar := p_ncharvaryingvar || '_XXX_';
	p_nvarchar2var := p_nvarchar2var || '_XXX_';
	p_stringvar := p_stringvar || '_XXX_';
	p_varcharvar := p_varcharvar || '_XXX_';
	p_varchar2var := p_varchar2var || '_XXX_';
	--x_long := --p_long || '_XXX_';
	p_clobcol := p_clobcol || '_XXX_';
	p_nclobcol := p_nclobcol || '_XXX_';
end;
/

create table type_date_table (
pk                      number(18) primary key,
datecol                 date,
datedefaultcol          date default sysdate,
datedefault2col         date default to_date('2018-01-01 13:59:59','rrrr-mm-dd hh24:mi:ss'),
--datedefault3col         date default '2018-01-01 13:59:59', -- this does not work
timestampcol            timestamp,
timestampdefaultcol     timestamp default systimestamp,
timestampdefault2col    timestamp default to_timestamp('2018-01-01 13:59:59.123456','rrrr-mm-dd hh24:mi:ss.ff'),
timestampcol2           timestamp(0),
timestampcol3           timestamp(9),
timestamptzcol          timestamp with time zone,
timestamptzcol2         timestamp(0) with time zone,
timestamptzcol3         timestamp(9) with time zone,
timestampltzzcol        timestamp with local time zone,
timestampltzcol2        timestamp(0) with local time zone,
timestampltzcol3        timestamp(9) with local time zone
);


create or replace procedure type_date_proc ( 
    p_datecol			in date,
    p_timestampcol		in timestamp,
	x_datecol			out date,
    x_timestampcol		out timestamp
)
is 
begin
	x_datecol := p_datecol;
	x_timestampcol := p_timestampcol; 
end;
/

create or replace procedure type_date_proc_inout ( 
    p_datecol			in out date,
    p_timestampcol		in out timestamp
)
is 
begin
	null;
end;
/

--
-- functions mixed with in out params
--
create or replace function test_func_1
return number
is
begin
    return 10;
end;
/

create or replace function test_func_2 (
    p_x        number, -- absence of "in" is on purpose
    p_y        in number
) return number
is
begin
    return p_x + p_y;
end;
/

create or replace function test_func_3 (
    p_x			number, -- absence of "in" is on purpose
    p_y			in number,
    p_str		in out varchar2,
    x_z			out number
) return number
is
begin
    p_str := '_XXX_';
    x_z := p_x + p_y;
    return x_z;
end;
/

--
-- package tests
--
create or replace package test_pkg as

    -- intentionally named with name of existing standalone procedure
    procedure type_num_proc;
    
    procedure test_proc_1 (
        p_x            number,
        p_y            in number,
        p_str        in out varchar2,
        x_z            out number
    );
    
    -- intentionally named with name of existing standalone function
    function test_func_3 (
        p_x            number,
        p_y            in number,
        p_str        in out varchar2,
        x_z            out number
    ) return number;

end;
/
create or replace package body test_pkg as

    -- intentionally named with name of existing standalone procedure
    procedure type_num_proc
    is
    begin
        null;
    end;
    
    procedure test_proc_1 (
        p_x            number,
        p_y            in number,
        p_str        in out varchar2,
        x_z            out number
    )
    is
    begin
        p_str := '_XXX_';
        x_z := p_x + p_y;
    end;
    
    -- intentionally named with name of existing standalone function
    function test_func_3 (
        p_x            number,
        p_y            in number,
        p_str        in out varchar2,
        x_z            out number
    ) return number
    is
    begin
        p_str := '_XXX_';
        x_z := p_x + p_y;
        return x_z;
    end;
end;
/


--
-- synonyms
--
create synonym efpoco.countries for hr.countries;
create synonym efpoco.my_employees for hr.employees;
