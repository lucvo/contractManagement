SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luc.Vo
-- Create date: 30/4/2015
-- Description:	
-- =============================================
CREATE PROCEDURE spContractorGetById 
	-- Add the parameters for the stored procedure here
	@id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select Id, FirstName, LastName, Email from Friend
	where Id = id
END
GO
