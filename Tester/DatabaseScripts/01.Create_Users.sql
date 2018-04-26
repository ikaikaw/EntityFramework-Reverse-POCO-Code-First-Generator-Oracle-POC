-- run as user with sufficent privileges

--drop user hr cascade;
create user hr identified by "Password123!" default tablespace users;

grant 
	create session,
	unlimited tablespace,
	query rewrite,
	create table,
	create view,
	create synonym,
	create trigger,
	create procedure,
	create sequence,
	create materialized view,
	create database link
to hr;


--drop user efpoco cascade;
create user efpoco identified by "Password123!" default tablespace users;

grant 
    create session,
    unlimited tablespace,
    query rewrite,
    create table,
    create view,
    create synonym,
    create trigger,
    create procedure,
    create sequence,
	create materialized view,
    create database link
to efpoco;