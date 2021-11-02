create procedure [InsertFood]
	@ID int output,
	@Name nvarchar(1000),
	@Unit nvarchar(100),
	@FoodCategoryID int,
	@Price int,
	@Notes nvarchar(3000)
as
insert into [Food]
([Name],[Unit],[FoodCategoryID],[Price],[Notes])
values (@Name,@Unit,@FoodCategoryID,@Price,@Notes)

select @ID = SCOPE_IDENTITY();
GO


create procedure [Update Food]
	@ID int,
	@Name nvarchar(1000),
	@Unit nvarchar(100),
	@FoodCategoryID int,
	@Price int,
	@Notes nvarchar(3000)
as
update [Food]
set
	[Name] = @Name,
	[Unit] =@Unit,
	[FoodCategoryID] = @FoodCategoryID,
	[Price] = @Price,
	[Notes] = @Notes

where ID = @ID
if @@ERROR <>0
return 0
else
return 1
go
