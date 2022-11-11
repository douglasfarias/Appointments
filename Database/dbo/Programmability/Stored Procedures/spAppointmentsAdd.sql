CREATE PROCEDURE [dbo].[spAppointmentsAdd]
	@CustomerId nvarchar(450),
	@EmployeeId nvarchar(450),
	@Date datetime

AS
	return insert into tbAppointments (CustomerId, EmployeeId, Date) 
	output [inserted].[Id], 
		[inserted].[CreatedAt], 
		[inserted].[UpdatedAt], 
		[inserted].[Deleted], 
		[inserted].[Date], 
		[inserted].[Done], 
		[inserted].[CustomerId], 
		[inserted].[EmployeeId], 
		[inserted].[AmountDue], 
		[inserted].[AmountPaid] 
	values (@CustomerId, @EmployeeId, @Date)