/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [ITEMBARCODE]
      ,[ITEMID]
      ,[INVENTDIMID]
      ,[BARCODESETUPID]
      ,[UNITID]
	  ,[SPC_ITEMACTIVE]	
      ,[SPC_ITEMNAME]
	  ,[SPC_IMAGEPATH]
      ,[DATAAREAID]
      ,[SPC_PRICEGROUP3]

  FROM [test].[dbo].[INVENTITEMBARCODE_DEV]

   WHERE ITEMBARCODE = '12108732' AND DATAAREAID = 'spc'