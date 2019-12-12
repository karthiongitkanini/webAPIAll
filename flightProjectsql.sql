create database BreezeAirways
use BreezeAirways

---registration----------------------------
create table Airline_Registration(User_fname varchar(20),User_lname varchar(20),D_of_b date,
                nationality varchar(20),phone_number varchar(20) ,gender varchar(20),
gmail varchar(20) ,
                password varchar(20),primary key(gmail,phone_number))

--------proc for registration------------------------

create proc Insert_User_data(@ufname varchar(20),@ulname varchar(20),@dob date,@nat varchar(20),
@pnumber varchar(20),@gender varchar(20),@gmail varchar(20),@password varchar(20))
as
begin
insert into Airline_Registration values(@ufname,@ulname,@dob,@nat,@pnumber,@gender,@gmail,@password)
end
select * from Airline_Registration

exec Insert_User_data 'aaaa','bbb','1-2-1998','indian','9751075790','male','bhuvanait1997@gmail.com','1234'

--------------Login---------------------------------------
create proc Proc_UserLogin(@email varchar(20),@password varchar(20) out)
as
begin
  set @password=(select password from Airline_Registration where gmail=@email)
end

declare
@pass varchar(20)
exec Proc_UserLogin 'bhuvanait1997@gmail.com',@pass out
select @pass

------search flight-------------