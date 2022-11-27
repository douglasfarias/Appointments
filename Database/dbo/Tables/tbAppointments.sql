CREATE TABLE [dbo].[tbAppointments]
(
	[Id] int not null identity(1,1),
	[CreatedAt] datetime not null default getdate(),
	[UpdatedAt] datetime null,
	[Deleted] bit not null default 0,
	[Date] datetime not null,
	[Done] bit not null default 0,
	[CustomerId] int not null,
	[EmployeeId] int not null,
	[AmountDue] numeric(10,2) not null,
	[AmountPaid] numeric(10,2) not null default 0,
	constraint pk_tbAppointments_Id primary key (Id),
	constraint fk_tbAppointments_CustomerId_tbUsers_Id foreign key (CustomerId) references tbUsers(Id),
	constraint fk_tbAppointments_EmployeeId_tbUsers_Id foreign key (EmployeeId) references tbUsers(Id)

)

GO

CREATE TRIGGER [dbo].[tg_tbAppointments_Updated]
    ON [dbo].[tbAppointments]
    AFTER UPDATE
    AS
    BEGIN
        update tbAppointments set tbAppointments.UpdatedAt = getdate() where tbAppointments.Id = (select top 1 inserted.Id from inserted)
    END