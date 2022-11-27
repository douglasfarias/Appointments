CREATE PROCEDURE [dbo].[spAppointmentsAdd]
	@CustomerId int,
	@EmployeeId int,
	@Date datetime,
	@AmountDue numeric null = 0, 
	@AmountPaid numeric null = 0

AS
	insert into tbAppointments (CustomerId, EmployeeId, Date, AmountDue, AmountPaid) 
	values (@CustomerId, @EmployeeId, @Date, @AmountDue, @AmountPaid)
	select 
		[Appointments].[Id], 
		[Appointments].[CreatedAt], 
		[Appointments].[UpdatedAt], 
		[Appointments].[Deleted], 
		[Appointments].[Date], 
		[Appointments].[Done], 
		[Appointments].[AmountDue], 
		[Appointments].[AmountPaid],
		[Appointments].[CustomerId], 
		[Appointments].[EmployeeId],
		[Customer].[Id],
		[Customer].[GivenName],
		[Customer].[Surename],
		[Employee].[Id],
		[Employee].[GivenName],
		[Employee].[Surename]
	from tbAppointments Appointments 
	left join tbUsers Customer on Customer.Id = Appointments.CustomerId
	left join tbUsers Employee on Employee.Id = Appointments.EmployeeId
	where Appointments.Id = @@IDENTITY