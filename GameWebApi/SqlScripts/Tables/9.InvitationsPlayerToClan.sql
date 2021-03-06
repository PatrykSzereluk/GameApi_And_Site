﻿IF(EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[InvitationsPlayerToClan]') and [TYPE] = N'U'))
DROP TABLE [Common].[InvitationsPlayerToClan]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Common].[InvitationsPlayerToClan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerId] [int] NOT NULL,
	[ClanId] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Common].[InvitationsPlayerToClan]  WITH CHECK ADD  CONSTRAINT [FK_InvitationsPlayerToClan_Clans] FOREIGN KEY([ClanId])
REFERENCES [Common].[Clans] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [Common].[InvitationsPlayerToClan] CHECK CONSTRAINT [FK_InvitationsPlayerToClan_Clans]
GO

ALTER TABLE [Common].[InvitationsPlayerToClan]  WITH CHECK ADD  CONSTRAINT [FK_InvitationsPlayerToClan_PlayerIdentity] FOREIGN KEY([PlayerId])
REFERENCES [Common].[PlayerIdentity] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [Common].[InvitationsPlayerToClan] CHECK CONSTRAINT [FK_InvitationsPlayerToClan_PlayerIdentity]
GO