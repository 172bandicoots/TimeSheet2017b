USE [aspnet-TimeSheet2017-20160730103016]
GO

DECLARE	@return_value VarChar(50)

EXEC	@return_value = [dbo].[GetAssociateName]
		@UserIdent = N'Manager@Timesheet2017.com'

SELECT	@return_value as 'Return Value'

GO
