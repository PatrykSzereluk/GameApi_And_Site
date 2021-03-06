﻿IF(EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Clans]') and [TYPE] = N'U'))
DROP TABLE [Common].[Clans]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Common].[Clans](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Acronym] [varchar](5) NOT NULL,
	[Name] [varchar](16) NOT NULL,
	[Experience] [int] NOT NULL,
	[AvatarId] [tinyint],
	[AvatarURL] [varchar](max)
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


