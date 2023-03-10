/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ITEMBARCODE]
      ,[ITEMID]
      ,[INVENTDIMID]
      ,[UNITID]
	  ,[SPC_ITEMACTIVE]
      ,[SPC_PRICEGROUP3]
      ,[SPC_ITEMNAME]
      ,[SPC_IMAGEPATH]
      ,[SPC_ITEMBUYERGROUPID]
  FROM [test].[dbo].[Test_INVENTITEMBARCODE]

INSERT INTO [Test_INVENTITEMBARCODE]
(
		[ITEMBARCODE],
		[ITEMID], 
		[INVENTDIMID], 
		[UNITID], 
		[SPC_PRICEGROUP3],
		[SPC_ITEMNAME],
		[SPC_IMAGEPATH],
		[SPC_ITEMBUYERGROUPID]
		
)

VALUES
(
		@ITEMBARCODE,
		@ITEMID,
		@INVENTDIMID,
		@UNITID,
		@SPC_PRICEGROUP3,
		@SPC_ITEMNAME,
		@SPC_IMAGEPATH,
		@SPC_ITEMBUYERGROUPID
		
)


UPDATE [Test_INVENTITEMBARCODE]
SET		[SPC_PRICEGROUP3] = '500' ,
		[SPC_IMAGEPATH] = '////' 
		
WHERE [ITEMBARCODE] = '01'
AND	  [ITEMID] = 'P0089255'
AND   [INVENTDIMID] = 'DIM18-000232863'

SELECT *
FROM [Test_INVENTITEMBARCODE]
WHERE [ITEMBARCODE] = '01'
AND	  [ITEMID] = 'P0089255'
AND   [INVENTDIMID] = 'DIM18-000232863'






--เมื่อดับเบิ้ลคลิ๊ก ให้เด้งไปหน้าแก้ไขได้เลย โดยการดึงข้อมูลทั้งหมดมาจาก ฟอร์มที่ 2 --> ฟอร์ม 2 มาจากการค้นหา