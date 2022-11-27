CREATE PROCEDURE [dbo].[spAppointmentsList]
	@StartDate datetime,
	@EndDate datetime

AS
	select 
	[Appointments].[Id], 
	[Appointments].[CreatedAt], 
	[Appointments].[UpdatedAt], 
	[Appointments].[Deleted], 
	[Appointments].[Date], 
	[Appointments].[Done], 
	[Appointments].[AmountDue], 
	[Appointments].[AmountPaid],
	[Customer].[Id], 
	[Customer].[GivenName], 
	[Customer].[Surename], 
	[Customer].[Email], 
	[Customer].[Phone],
	[Employee].[Id], 
	[Employee].[GivenName], 
	[Employee].[Surename], 
	[Employee].[Email], 
	[Employee].[Phone]
	from tbAppointments Appointments
	left join tbUsers Customer on Customer.Id = Appointments.CustomerId
	left join tbUsers Employee on Employee.Id = Appointments.EmployeeId
	where Appointments.[Date] between @StartDate and @EndDate;
