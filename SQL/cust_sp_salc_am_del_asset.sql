USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_am_del_asset]    Script Date: 04/13/2012 13:00:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 04/06/2012
-- Description:	Delete asset data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_am_del_asset]
	@AssetId int
AS
BEGIN
	DELETE
		cust_salc_am_assets
	WHERE
		[asset_id] = @AssetId		
END



GO

