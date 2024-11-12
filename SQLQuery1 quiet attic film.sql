create database quiet_attic_films

create table client(
client_id int primary key not null,
client_name varchar(100) not null,
client_address varchar(100) not null,
client_phone_number varchar(10) not null);

create table staff_type(
staff_type_id int primary key not null,
staff_type_name varchar(100)not null,
salary float not null);

create table staff(
staff_id int primary key not null,
staff_name varchar (100)not null,
staff_age int not null,
staff_address varchar(100)not null,
staff_phone_number varchar(10)not null,
staff_type_id int not null
foreign key (staff_type_id) references staff_type(staff_type_id));


select * from client 






create table property_type(
property_type_id int primary key not null,
property_type_name varchar(100) not null);

create table property(
property_id int primary key not null,
property_name varchar (100) not null,
property_type_id int not null,
foreign key (property_type_id) references property_type(property_type_id));

create table locations(
location_id int primary key not null,
location_name varchar(100)not null);

 create table production(
 production_id int primary key not null,
 production_name varchar(100)not null,
 production_budget float not null,
 production_number_of_days date not null,
 production_type varchar(100) not null,
 client_id int not null,
 staff_id int not null,
 location_id int not null,
 property_id int not null,
 foreign key (client_id)references client(client_id),
 foreign key (staff_id)references staff(staff_id),
 foreign key (location_id)references locations(location_id),
 foreign key (property_id)references property(property_id));


 select * from client


 insert into client(client_id,client_name,client_address,client_phone_number)
 values ('10','raja','vavuniya','0752700851');





 update client
 set client_phone_number='0752928888',client_address='colombo'
 where client_id=1



 delete from client where client_id='7'

 
 select * from client where client_name ='thiru';



 select client_id, client_name from client order by client_name desc;


 select client_id,client_name,client_address,client_phone_number 
 from client 
 where client_id between 2 and 5;

 select client_address, count (*) as Total_clients
 from client
 group by client_address;

 SELECT client_address, count (*) as Total_clients 
 from client
 GROUP BY  client_address
 HAVING COUNT (*) >1



 select client_name from client;


