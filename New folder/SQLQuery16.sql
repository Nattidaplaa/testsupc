/****** Script for SelectTopNRows command from SSMS  ******/
SELECT   [ITEMID]
		,[PRIMARYVENDORID]
		,[DATAAREAID]

  FROM [test].[dbo].[INVENTTABLE_DEV]

  WHERE ITEMID = 'P0100573' AND DATAAREAID = 'spc'
