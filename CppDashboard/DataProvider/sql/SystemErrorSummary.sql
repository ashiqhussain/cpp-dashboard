
DECLARE @LogWindowInHours INT
SET @LogWindowInHours = [LogDurationWindow]

SELECT 'easyjet.CustomerPayments' AS [Service]
		,CONVERT(NVARCHAR(30), DATEADD(HOUR, -@LogWindowInHours, GETDATE()))  + ' --- ' + CAST (getdate() AS NVARCHAR(30)) AS Period
		,count(*) AS ErrorCount
		, ISNULL((SELECT TOP 1 '(' + cast(Id as varchar) + ') ' +'MSG --> ' + [Message] + ' # EX # -->' + [Exception]
			FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
				where context = 'easyjet.CustomerPayments'
				and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
				AND level IN ('FATAL','ERROR')
				AND MESSAGE NOT LIKE '%VerifyCard%'
				ORDER BY [DATE] DESC), '') AS LastError
FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
where context = 'easyjet.CustomerPayments'
	and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
	AND level IN ('FATAL','ERROR')
	AND MESSAGE NOT LIKE '%VerifyCard%'


UNION

SELECT 'easyJet.CustomerPayments.Monitoring' AS [Service]
		,CONVERT(NVARCHAR(30), DATEADD(HOUR, -@LogWindowInHours, GETDATE()))  + ' --- ' + CAST (getdate() AS NVARCHAR(30)) AS Period
		,count(*) AS ErrorCount
		, ISNULL((SELECT TOP 1 'MSG --> ' + [Message] + ' # EX # -->' + [Exception]
			FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
				where context = '(' + cast(Id as varchar) + ') ' +'easyjet.CustomerPayments.Monitoring'
				and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
				AND level IN ('FATAL','ERROR')
				ORDER BY [DATE] DESC), '') AS LastError
FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
where context = 'easyjet.CustomerPayments.Monitoring'
	and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
	AND level IN ('FATAL','ERROR')

UNION

SELECT 'easyJet.CustomerPayments.NotificationsProcessor' AS [Service]
		,CONVERT(NVARCHAR(30), DATEADD(HOUR, -@LogWindowInHours, GETDATE()))  + ' --- ' + CAST (getdate() AS NVARCHAR(30)) AS Period
		,count(*) AS ErrorCount
		, ISNULL((SELECT TOP 1 '(' + cast(Id as varchar) + ') ' +'MSG --> ' + [Message] + ' # EX # -->' + [Exception]
			FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
				where context = 'easyjet.CustomerPayments.NotificationsProcessor'
				and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
				AND level IN ('FATAL','ERROR')
				ORDER BY [DATE] DESC), '') AS LastError
FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
where context = 'easyjet.CustomerPayments.NotificationsProcessor'
	and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
	AND level IN ('FATAL','ERROR')


UNION

SELECT 'easyJet.CustomerPayments.OfflineProcessor' AS [Service]
		,CONVERT(NVARCHAR(30), DATEADD(HOUR, -@LogWindowInHours, GETDATE()))  + ' --- ' + CAST (getdate() AS NVARCHAR(30)) AS Period
		,count(*) AS ErrorCount
		, ISNULL((SELECT TOP 1 '(' + cast(Id as varchar) + ') ' +'MSG --> ' + [Message] + ' # EX # -->' + [Exception]
			FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
				where context = 'easyjet.CustomerPayments.OfflineProcessor'
				and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
				AND level IN ('FATAL','ERROR')
				ORDER BY [DATE] DESC), '') AS LastError
FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
where context = 'easyjet.CustomerPayments.OfflineProcessor'
	and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
	AND level IN ('FATAL','ERROR')

UNION

SELECT 'easyJet.CustomerPayments.OrphanPaymentInspector' AS [Service]
		,CONVERT(NVARCHAR(30), DATEADD(HOUR, -@LogWindowInHours, GETDATE()))  + ' --- ' + CAST (getdate() AS NVARCHAR(30)) AS Period
		,count(*) AS ErrorCount
		, ISNULL((SELECT TOP 1 '(' + cast(Id as varchar) + ') ' +'MSG --> ' + [Message] + ' # EX # -->' + [Exception]
			FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
				where context = 'easyjet.CustomerPayments.OrphanPaymentInspector'
				and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
				AND level IN ('FATAL','ERROR')
				ORDER BY [DATE] DESC), '') AS LastError
FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
where context = 'easyjet.CustomerPayments.OrphanPaymentInspector'
	and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
	AND level IN ('FATAL','ERROR')

UNION

SELECT 'easyJet.CustomerPayments.RefundProcessor' AS [Service]
		,CONVERT(NVARCHAR(30), DATEADD(HOUR, -@LogWindowInHours, GETDATE()))  + ' --- ' + CAST (getdate() AS NVARCHAR(30)) AS Period
		,count(*) AS ErrorCount
		, ISNULL((SELECT TOP 1 '(' + cast(Id as varchar) + ') ' +'MSG --> ' + [Message] + ' # EX # -->' + [Exception]
			FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
				where context = 'easyjet.CustomerPayments.RefundProcessor'
				and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
				AND level IN ('FATAL','ERROR')
				ORDER BY [DATE] DESC), '') AS LastError
FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
where context = 'easyjet.CustomerPayments.RefundProcessor'
	and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
	AND level IN ('FATAL','ERROR')

UNION

SELECT 'easyJet.CustomerPayments.FraudService' AS [Service]
		,CONVERT(NVARCHAR(30), DATEADD(HOUR, -@LogWindowInHours, GETDATE()))  + ' --- ' + CAST (getdate() AS NVARCHAR(30)) AS Period
		,count(*) AS ErrorCount
		, ISNULL((SELECT TOP 1 '(' + cast(Id as varchar) + ') ' +'MSG --> ' + [Message] + ' # EX # -->' + [Exception]
			FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
				where context = 'easyjet.CustomerPayments.FraudService'
				and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
				AND level IN ('FATAL','ERROR')
				ORDER BY [DATE] DESC), '') AS LastError
FROM [easyJetFramework].[logging].[Customerpayments_Log] (nolock)
where context = 'easyjet.CustomerPayments.FraudService'
	and [Date] BETWEEN DATEADD(HOUR, -@LogWindowInHours, GETDATE()) AND getdate()
	AND level IN ('FATAL','ERROR')
-- ###################################

