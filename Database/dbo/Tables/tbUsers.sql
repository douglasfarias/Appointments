CREATE TABLE [dbo].[tbUsers]
(
	[Id] int not null identity(1,1),
	[CreatedAt] datetime not null default getdate(),
	[UpdatedAt] datetime null,
	[Deleted] bit not null default 0,
	[Role] varchar(50) not null,
	[GivenName] varchar(300) not null,
	[Surename] varchar(300) not null,
	[Email] varchar(500) null, 
    [Phone] varchar(500) null, 
    constraint pk_tbUsers_Id primary key (Id)
)
