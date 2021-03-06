﻿USE [MANAGEAPP]
GO

/****** Object:  Table [dbo].[T_COMP_INFO]    Script Date: 2018-12-11 오전 12:37:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_COMP_INFO](
	[COMP_SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[COMP_NAME] [nvarchar](128) NOT NULL,
	[COMP_DESCRIPTION] [nvarchar](1024) NULL,
	[COMP_REF] [nvarchar](256) NULL,
	[STANDARD_YEAR] [nvarchar](4) NULL,
	[DIAG_TYPE] [nvarchar](32) NOT NULL,
	[CONFIRM_YN] [bit] NULL,
	[USE_YN] [bit] NULL,
	[CREATE_USER_ID] [nvarchar](16) NULL,
	[CREATE_DT] [datetime] NULL,
	[UPDATE_USER_ID] [nvarchar](16) NULL,
	[UPDATE_DT] [datetime] NULL,
	[COMP_DETAIL_GUBUN] [nvarchar](32) NULL
 CONSTRAINT [PK_T_COMP_INFO] PRIMARY KEY CLUSTERED 
(
	[COMP_SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[T_COMP_INFO] ADD  DEFAULT ('') FOR [COMP_DETAIL_GUBUN]
GO


USE [MANAGEAPP]
GO

/****** Object:  Table [dbo].[T_COMP_INFO]    Script Date: 2018-12-11 오전 12:37:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_COMP_INFO](
	[COMP_SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[COMP_NAME] [nvarchar](128) NOT NULL,
	[COMP_DESCRIPTION] [nvarchar](1024) NULL,
	[COMP_REF] [nvarchar](256) NULL,
	[STANDARD_YEAR] [nvarchar](4) NULL,
	[DIAG_TYPE] [nvarchar](32) NOT NULL,
	[CONFIRM_YN] [bit] NULL,
	[USE_YN] [bit] NULL,
	[CREATE_USER_ID] [nvarchar](16) NULL,
	[CREATE_DT] [datetime] NULL,
	[UPDATE_USER_ID] [nvarchar](16) NULL,
	[UPDATE_DT] [datetime] NULL,
	[COMP_DETAIL_GUBUN] [nvarchar](32) DEFAULT ''
 CONSTRAINT [PK_T_COMP_INFO] PRIMARY KEY CLUSTERED 
(
	[COMP_SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


insert into MANAGEAPP.dbo.T_COMP_INFO (COMP_NAME, COMP_DESCRIPTION, COMP_REF, STANDARD_YEAR, DIAG_TYPE, CONFIRM_YN, USE_YN, CREATE_USER_ID, CREATE_DT, UPDATE_USER_ID, UPDATE_DT, COMP_DETAIL_GUBUN)
select
	COMP_NAME
	, COMP_DESCRIPTION
	, COMP_REF
	, STANDARD_YEAR
	, DIAG_TYPE
	, case when CONFIRM_YN = 'Y' then 1 else 0 end as CONFIRM_YN
	, case when USE_YN = 'Y' then 1 else 0 end as USE_YN
	, CREATE_USER_ID
	, CREATE_DT
	, UPDATE_USER_ID
	, UPDATE_DT
	, COMP_DETAIL_GUBUN
from PJSWORK.dbo.TCompInfo