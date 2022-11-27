CREATE PROCEDURE [dbo].[spUsersAdd]
	@GivenName varchar(300),
	@Surename varchar(300),
	@Role int,
	@Email varchar(500),
	@Phone varchar(500)
AS
		insert into tbUsers (
			[Role],
			[GivenName],
			[Surename],
			[Email],
			[Phone]
		) output 
			[inserted].[Id], 
			[inserted].[CreatedAt], 
			[inserted].[UpdatedAt], 
			[inserted].[Deleted], 
			[inserted].[Role], 
			[inserted].[GivenName], 
			[inserted].[Surename],
			[inserted].[Email],
			[inserted].[Phone]
		values (
			@Role,
			@GivenName,
			@Surename,
			@Email,
			@Phone
		);