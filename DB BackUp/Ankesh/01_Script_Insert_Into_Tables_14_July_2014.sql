--select * from tb_users
--1) Inser into tb_users
insert into tb_Users
(
User_Name,
Password,
First_Name,
Last_Name,
Email_Address,
Phone,
Is_Active,
Created_Date,
Created_By,
Modify_Date,
Modify_By
)

select 'Admin',
'123456',
'Ankesh',
'Verma',
'Ankesh1989@gmail.com',
'9888023423',
1,
GETDATE(),
1,
GETDATE(),
1



go

create proc usp_CheckLogin
(
	@Username nvarchar(50),
	@Password nvarchar(50)
)
As
if exists(select top 1 1 from tb_Users where USER_NAME=@Username and password=@Password)
BEGIN
	select 1

END

ELSE
BEGIN
	Select 2
END

