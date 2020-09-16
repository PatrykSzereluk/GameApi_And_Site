﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Common].[Friends](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerPlayerId] [int] NOT NULL,
	[FriendPlayerId] [int] NOT NULL,
 CONSTRAINT [PK_Friends] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Common].[Friends]  WITH CHECK ADD  CONSTRAINT [FK_Friends_PlayerIdentity] FOREIGN KEY([OwnerPlayerId])
REFERENCES [Common].[PlayerIdentity] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [Common].[Friends] CHECK CONSTRAINT [FK_Friends_PlayerIdentity]
GO


