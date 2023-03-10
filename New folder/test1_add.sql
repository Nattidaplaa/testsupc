/****** Script for SelectTopNRows command from SSMS  ******/
INSERT INTO [NewTable_ADD]

SELECT TOP (1000) T1.[ITEMBARCODE], T1.[ITEMID], T1.[INVENTDIMID], T1.[UNITID], T1.[SPC_PRICEGROUP3]
	                                ,T1.[SPC_ITEMNAME], T1.[SPC_IMAGEPATH], T1.[SPC_ITEMBUYERGROUPID] 
	                                ,T2.[PRIMARYVENDORID], T3.[NAME], T4.[DESCRIPTION]
                            FROM  [Test_INVENTITEMBARCODE] T1
                            INNER JOIN [Test_INVENTTABLE] T2 ON  T1.[ITEMID] = T2.[ITEMID]
                            AND     T1.[DATAAREAID] = 'spc'
                            INNER JOIN [Test_VENDTABLE] T3 ON T2.[PRIMARYVENDORID] = T3.[ACCOUNTNUM]
                            AND     T2.[DATAAREAID] = 'spc'
                            INNER JOIN [Test_DIMENSIONS] T4 ON T1.[SPC_ITEMBUYERGROUPID] = T4.[NUM]
                            AND     T3.[DATAAREAID] = 'spc'
                            AND     T4.[DATAAREAID] = 'spc'

SELECT TOP (1000) [ITEMBARCODE]
      ,[ITEMID]
      ,[INVENTDIMID]
      ,[UNITID]
      ,[SPC_PRICEGROUP3]
      ,[SPC_ITEMNAME]
      ,[SPC_IMAGEPATH]
      ,[SPC_ITEMBUYERGROUPID]
      ,[PRIMARYVENDORID]
      ,[NAME]
      ,[DESCRIPTION]
  FROM [test].[dbo].[NewTable_ADD]