USE [ArenaDB]
GO

/****** Object:  Table [dbo].[cust_salc_am_works]    Script Date: 04/13/2012 12:54:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cust_salc_am_works](
	[work_id] [int] IDENTITY(1,1) NOT NULL,
	[asset_id] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[completed_date] [datetime] NOT NULL,
	[budget_id] [int] NOT NULL,
	[schedule_id] [int] NOT NULL,
	[code_id] [int] NOT NULL,
	[work_status_id] [int] NOT NULL,
	[priority] [int] NOT NULL,
	[description] [text] NOT NULL,
 CONSTRAINT [PK_cust_salc_am_works] PRIMARY KEY CLUSTERED 
(
	[work_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

