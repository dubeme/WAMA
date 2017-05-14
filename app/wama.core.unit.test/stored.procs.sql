USE [wama.db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetCheckInAggregate]
GO

DROP PROCEDURE [dbo].[GetGeneralAggregate]
GO

-- =============================================
-- Author:		Dubem
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetCheckInAggregate] 
	-- Add the parameters for the stored procedure here
	@granularity int = 0,
	@startDate DATETIMEOFFSET,
	@endDate DATETIMEOFFSET
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @granularity = 1
	BEGIN
		-- HOURLY
		SELECT 
			COUNT([CheckInDateTime]) AS 'count'
			, MAX(FORMAT([CheckInDateTime], 'yyyy-MM-dd hh:00 tt')) AS 'time'
		FROM [wama.db].[dbo].[CheckInActivities]
		WHERE
			[CheckInDateTime] >= @startDate AND
			[CheckInDateTime] <= @endDate
		GROUP BY 
			DATEPART(HOUR, [CheckInDateTime])
			, DATEPART(DAYOFYEAR, [CheckInDateTime])
			, DATEPART(YEAR, [CheckInDateTime])
		ORDER BY 
			DATEPART(YEAR, [CheckInDateTime])
			, DATEPART(DAYOFYEAR, [CheckInDateTime])
			, DATEPART(HOUR, [CheckInDateTime])
	END
	ELSE IF @granularity = 2
	BEGIN
		-- DAILY
		SELECT 
			COUNT([CheckInDateTime]) AS 'count'
			, MAX(FORMAT([CheckInDateTime], 'yyyy-MM-dd')) AS 'time'
		FROM [wama.db].[dbo].[CheckInActivities]
		WHERE
			[CheckInDateTime] >= @startDate AND
			[CheckInDateTime] <= @endDate
		GROUP BY 
			DATEPART(DAYOFYEAR, [CheckInDateTime])
			, DATEPART(YEAR, [CheckInDateTime])
		ORDER BY 
			DATEPART(YEAR, [CheckInDateTime])
			, DATEPART(DAYOFYEAR, [CheckInDateTime])
	END
	ELSE IF @granularity = 3
	BEGIN
		-- WEEKLY
		SELECT 
			COUNT([CheckInDateTime]) AS 'count'
			, MAX(FORMAT([CheckInDateTime], 'yyyy-MM-dd')) AS 'time'
		FROM [wama.db].[dbo].[CheckInActivities]
		WHERE
			[CheckInDateTime] >= @startDate AND
			[CheckInDateTime] <= @endDate
		GROUP BY 
			DATEPART(WEEK, [CheckInDateTime])
			, DATEPART(YEAR, [CheckInDateTime])
		ORDER BY 
			DATEPART(YEAR, [CheckInDateTime])
			, DATEPART(WEEK, [CheckInDateTime])
	END
	ELSE IF @granularity = 4
	BEGIN
		-- MONTHLY
		SELECT 
			COUNT([CheckInDateTime]) AS 'count'
			, MAX(FORMAT([CheckInDateTime], 'yyyy-MM-dd')) AS 'time'
		FROM [wama.db].[dbo].[CheckInActivities]
		WHERE
			[CheckInDateTime] >= @startDate AND
			[CheckInDateTime] <= @endDate
		GROUP BY 
			DATEPART(MONTH, [CheckInDateTime])
			, DATEPART(YEAR, [CheckInDateTime])
		ORDER BY 
			DATEPART(YEAR, [CheckInDateTime])
			, DATEPART(MONTH, [CheckInDateTime])
	END
	ELSE IF @granularity = 5
	BEGIN
		-- YEARLY
		SELECT 
			COUNT([CheckInDateTime]) AS 'count'
			, MAX(FORMAT([CheckInDateTime], 'yyyy')) AS 'time'
		FROM [wama.db].[dbo].[CheckInActivities]
		WHERE
			[CheckInDateTime] >= @startDate AND
			[CheckInDateTime] <= @endDate
		GROUP BY DATEPART(YEAR, [CheckInDateTime])
		ORDER BY DATEPART(YEAR, [CheckInDateTime])
	END

END
GO


CREATE PROCEDURE GetGeneralAggregate 
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @today AS DATETIMEOFFSET = SYSUTCDATETIME();

	SELECT 
	(
		SELECT COUNT(*) 
		FROM [Certifications]
		WHERE DATEDIFF(DAY, @today, [ExpiresOn]) <= 0
	) AS 'expiredcerts',
	(
		SELECT COUNT(*) 
		FROM [Certifications] 
		WHERE (DATEDIFF(DAY, @today, [ExpiresOn]) BETWEEN 0 AND 7)
	) AS 'expiringcerts',
	(
		SELECT COUNT(*) 
		FROM [CheckInActivities] AS [ca] 
		LEFT JOIN [UserAccounts] AS [ca.Member] ON [ca].[MemberId] = [ca.Member].[MemberId] 
		WHERE (([ca.Member].[AccountType] <> 1) OR [ca.Member].[AccountType] IS NULL) AND (DATEDIFF(DAY, @today, [ca].[CheckInDateTime]) = 0)
	) AS 'nonpatroncheckins',
	(
		SELECT COUNT(*) 
		FROM [CheckInActivities] AS [ca] 
		LEFT JOIN [UserAccounts] AS [ca.Member] ON [ca].[MemberId] = [ca.Member].[MemberId] 
		WHERE ([ca.Member].[AccountType] = 1) AND (DATEDIFF(DAY, @today, [ca].[CheckInDateTime]) = 0)
	) AS 'patroncheckins',
	(
		SELECT COUNT(*) 
		FROM [UserAccounts] AS [ua] 
		WHERE ([ua].[AccountType] = 1) AND ([ua].[HasBeenApproved] = 0)
	) AS 'pendingapproval',
	(
		SELECT COUNT(*) 
		FROM [UserAccounts] AS [ua] 
		WHERE ([ua].[AccountType] = 1) AND ([ua].[IsSuspended] = 1)
	) AS 'suspended'

END
GO