--SELECT TOP (1000) T1.[ITEMBARCODE], 
--				  T1.[ITEMID], 
--				  T1.[INVENTDIMID], 
--				  T1.[UNITID], 
--				  T1.[SPC_PRICEGROUP3],
--	              T1.[SPC_ITEMNAME], 
--				  T1.[SPC_IMAGEPATH], 
--				  T1.[SPC_ITEMBUYERGROUPID], 
--	              T2.[PRIMARYVENDORID], 
--				  T3.[NAME], 
--				  T4.[DESCRIPTION]
--FROM  [Test_INVENTITEMBARCODE] T1
--INNER JOIN [Test_INVENTTABLE] T2 ON  T1.[ITEMID] = T2.[ITEMID]
--AND     T1.[DATAAREAID] = 'spc'
--INNER JOIN [Test_VENDTABLE] T3 ON T2.[PRIMARYVENDORID] = T3.[ACCOUNTNUM]
--AND     T2.[DATAAREAID] = 'spc'
--INNER JOIN [Test_DIMENSIONS] T4 ON T1.[SPC_ITEMBUYERGROUPID] = T4.[NUM]
--AND     T3.[DATAAREAID] = 'spc'
--AND     T4.[DATAAREAID] = 'spc'
--WHERE [ITEMBARCODE] = '0000000008341'


;WITH CTE AS
(
	SELECT [ITEMID], [INVENTDIMID]
	FROM [Test_INVENTITEMBARCODE]
	--WHERE [ITEMBARCODE] = '8992759124187'
	--WHERE [ITEMBARCODE] = '0000000111'
	WHERE [ITEMBARCODE] = '.1108'
)
SELECT TOP (1000) T1.[ITEMBARCODE], 
				  T1.[ITEMID], 
				  T1.[INVENTDIMID], 
				  T1.[UNITID], 
				  T1.[SPC_PRICEGROUP3],
	              T1.[SPC_ITEMNAME], 
				  T1.[SPC_IMAGEPATH], 
				  T1.[SPC_ITEMBUYERGROUPID],
				  T1.[SPC_ITEMACTIVE], 
	              T2.[PRIMARYVENDORID], 
				  T3.[NAME], 
				  T4.[DESCRIPTION]

FROM  [Test_INVENTITEMBARCODE] T1
INNER JOIN [Test_INVENTTABLE] T2 ON  T1.[ITEMID] = T2.[ITEMID]
AND     T1.[DATAAREAID] = 'spc'
INNER JOIN [Test_VENDTABLE] T3 ON T2.[PRIMARYVENDORID] = T3.[ACCOUNTNUM]
AND     T2.[DATAAREAID] = 'spc'
INNER JOIN [Test_DIMENSIONS] T4 ON T1.[SPC_ITEMBUYERGROUPID] = T4.[NUM]
AND     T3.[DATAAREAID] = 'spc'
AND     T4.[DATAAREAID] = 'spc'
INNER JOIN CTE ON CTE.[ITEMID] = T2.[ITEMID] 
AND  CTE.[INVENTDIMID] = T1.[INVENTDIMID]
--WHERE T1.[ITEMBARCODE] = '01'

DELETE [Test_INVENTITEMBARCODE]
WHERE [ITEMBARCODE] = '01'
AND [SPC_ITEMACTIVE] = '1'




UPDATE [Test_INVENTITEMBARCODE]
SET		[SPC_ITEMACTIVE] = '1'
		
WHERE [ITEMBARCODE] = '03'
AND	  [ITEMID] = 'P0089255'
AND   [INVENTDIMID] = 'DIM18-000232863'



SELECT *
FROM [Test_INVENTITEMBARCODE]
WHERE [ITEMBARCODE] = '03'
AND	  [ITEMID] = 'P0089255'
AND   [INVENTDIMID] = 'DIM18-000232863'