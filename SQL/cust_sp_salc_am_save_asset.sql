USE [ArenaDB]
GO

/****** Object:  StoredProcedure [dbo].[cust_sp_salc_am_save_asset]    Script Date: 04/13/2012 13:01:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Den Boice
-- Create date: 04/05/2012
-- Description:	Save Asset data
-- =============================================
CREATE PROCEDURE [dbo].[cust_sp_salc_am_save_asset]
	@AssetId int,
	@ParentId int,
	@Real bit,
	@TypeId int,
	@CategoryId int,
	@GroupId int,
	@BudgetId int,
	@SaleVendorId int,
	@InstallVendorId int,
	@Status int,
	@Location int,
	@Active bit,
	@Name varchar(255),
	@Description text,
	@Manufacturer varchar(255),
	@Model varchar(255),
	@SerialNumber varchar(255),
	@AcquisitionDate date,
	@InstallDate date,
	@DecommissionDate date,
	@WarrantyExpirationDate date,
	@WarrantyInfo text,
	@SizeX decimal(18,0),
	@SizeY decimal(18,0),
	@PaintCode varchar(50),
	@Notes text,
	@OrganizationId int,
	@Image varbinary(MAX) = null,
	@ID int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS(
		SELECT * FROM cust_salc_am_assets
		WHERE [asset_id] = @AssetId
		)
	BEGIN
		INSERT INTO cust_salc_am_assets
		(
			[parent_id],
			[real],
			[type_id],
			[category_id],
			[group_id],
			[budget_id],
			[sale_vendor_id],
			[install_vendor_id],
			[asset_status_id],
			[location_id],
			[active],
			[name],
			[description],
			[manufacturer],
			[model],
			[serial_number],
			[acquisition_date],
			[install_date],
			[decommission_date],
			[warranty_expiration_date],
			[warranty_info],
			[size_x],
			[size_y],
			[paint_code],
			[notes],
			[organization_id],
			[image]
		)
		values
		(
			@ParentId,
			@Real,
			@TypeId,
			@CategoryId,
			@GroupId,
			@BudgetId,
			@SaleVendorId,
			@InstallVendorId,
			@Status,
			@Location,
			@Active,
			@Name,
			@Description,
			@Manufacturer,
			@Model,
			@SerialNumber,
			@AcquisitionDate,
			@InstallDate,
			@DecommissionDate,
			@WarrantyExpirationDate,
			@WarrantyInfo,
			@SizeX,
			@SizeY,
			@PaintCode,
			@Notes,
			@OrganizationId,
			@Image
		)
		SET @ID = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE cust_salc_am_assets Set
			[parent_id] = @ParentId,
			[real] = @Real,
			[type_id] = @TypeId,
			[category_id] = @CategoryId,
			[group_id] = @GroupId,
			[budget_id] = @BudgetId,
			[sale_vendor_id] = @SaleVendorId,
			[install_vendor_id] = @InstallVendorId,
			[asset_status_id] = @Status,
			[location_id] = @Location,
			[active] = @Active,
			[name] = @Name,
			[description] = @Description,
			[manufacturer] = @Manufacturer,
			[model] = @Model,
			[serial_number] = @SerialNumber,
			[acquisition_date] = @AcquisitionDate,
			[install_date] = @InstallDate,
			[decommission_date] = @DecommissionDate,
			[warranty_expiration_date] = @WarrantyExpirationDate,
			[warranty_info] = @WarrantyInfo,
			[size_x] = @SizeX,
			[size_y] = @SizeY,
			[paint_code] = @PaintCode,
			[notes] = @Notes,
			[organization_id] = @OrganizationId,
			[image] = @Image
		WHERE [asset_id] = @AssetId
		SET @ID = @AssetId
	END
END



GO

