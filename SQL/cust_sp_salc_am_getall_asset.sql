USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_am_getall_asset]    Script Date: 04/13/2012 13:00:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 03/12/2012
-- Description:	Returns all meals from the meals table
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_am_getall_asset]
	@TypeId int = -1,
	@ParentId int = -1,
	@OrganizationId int = 1,
	@Real bit = '0'
AS
BEGIN
	SELECT
		*
	FROM [cust_salc_am_assets]
	WHERE
		(CASE
			WHEN @ParentId > -1
			THEN
				CASE
					WHEN [parent_id] = @ParentId
						AND [organization_id] = @OrganizationId
						AND [real] = @Real
					THEN 1
					ELSE 0
				END
			WHEN @TypeId > -1
			THEN
				CASE
					WHEN [type_id] = @TypeId
						AND [organization_id] = @OrganizationId
					THEN 1
					ELSE 0
				END
			ELSE 0
		END) = 1
	ORDER BY [description] ASC
END


GO

