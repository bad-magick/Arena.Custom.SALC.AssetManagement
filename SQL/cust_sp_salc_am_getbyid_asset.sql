USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_am_getbyid_asset]    Script Date: 04/13/2012 13:00:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Den Boice
-- Create date: 04/05/2012
-- Description:	Gets an asset file with the specified ID
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_am_getbyid_asset]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM cust_salc_am_assets WHERE [asset_id] = @id
END


GO

