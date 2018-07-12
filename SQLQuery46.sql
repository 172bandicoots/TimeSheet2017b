USE [aspnet-TimeSheet2017-20160730103016]
GO

DECLARE	@return_value Int,
		@NAME varchar(50)

EXEC	@return_value = [dbo].[sp_GetAssociateName]
		@UserIdent = N'Associate@Timesheet2017.com',
		@NAME = @NAME OUTPUT

SELECT	@NAME as N'@NAME'

SELECT	@return_value as 'Return Value'

GO
