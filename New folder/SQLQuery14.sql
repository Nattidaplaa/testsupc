/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [DESCRIPTION]
      ,[NUM]
      ,[DIMENSIONCODE]
      ,[DATAAREAID]
     
  FROM [test].[dbo].[DIMENSIONS_DEV]

  --WHERE NUM = 'MN067' AND DATAAREAID = 'spc'