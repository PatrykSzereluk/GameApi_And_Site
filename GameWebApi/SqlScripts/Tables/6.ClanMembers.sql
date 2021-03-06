﻿IF(EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[ClanMembers]') and [TYPE] = N'U'))
DROP TABLE [Common].[ClanMembers]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Common].[ClanMembers](
	[ClanId] [int] NOT NULL,
	[PlayerId] [int] NOT NULL,
	[Function] [tinyint] NOT NULL,
	[DateOfJoin] [date] NOT NULL,
 CONSTRAINT [PK_ClanMembers] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Common].[ClanMembers]  WITH CHECK ADD  CONSTRAINT [FK_ClanMembers_Clans] FOREIGN KEY([ClanId])
REFERENCES [Common].[Clans] ([ID])
GO

ALTER TABLE [Common].[ClanMembers] CHECK CONSTRAINT [FK_ClanMembers_Clans]
GO

ALTER TABLE [Common].[ClanMembers]  WITH CHECK ADD  CONSTRAINT [FK_ClanMembers_PlayerIdentity] FOREIGN KEY([PlayerId])
REFERENCES [Common].[PlayerIdentity] ([ID])
GO

ALTER TABLE [Common].[ClanMembers] CHECK CONSTRAINT [FK_ClanMembers_PlayerIdentity]
GO

