USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_am_assets]    Script Date: 04/13/2012 12:53:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cust_salc_am_assets](
	[asset_id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
	[real] [bit] NOT NULL,
	[type_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[budget_id] [int] NOT NULL,
	[sale_vendor_id] [int] NOT NULL,
	[install_vendor_id] [int] NOT NULL,
	[asset_status_id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
	[active] [bit] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[manufacturer] [varchar](255) NOT NULL,
	[model] [varchar](255) NOT NULL,
	[serial_number] [varchar](255) NOT NULL,
	[acquisition_date] [date] NOT NULL,
	[install_date] [date] NOT NULL,
	[decommission_date] [date] NOT NULL,
	[warranty_expiration_date] [date] NOT NULL,
	[warranty_info] [text] NOT NULL,
	[size_x] [decimal](18, 0) NOT NULL,
	[size_y] [decimal](18, 0) NOT NULL,
	[paint_code] [varchar](50) NOT NULL,
	[notes] [text] NOT NULL,
	[organization_id] [int] NOT NULL,
	[image] [varchar](max) NULL,
 CONSTRAINT [PK_cust_salc_am_assets] PRIMARY KEY CLUSTERED 
(
	[asset_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

