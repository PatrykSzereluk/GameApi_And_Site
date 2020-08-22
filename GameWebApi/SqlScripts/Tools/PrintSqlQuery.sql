﻿IF(EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Tools].[PrintSqlQuery]') and [TYPE] = N'P'))
DROP PROCEDURE [Tools].[PrintSqlQuery]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [TOOLS].[PrintSqlQuery]
	@Query NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;

	--RETURN

	PRINT @Query
END
GO
