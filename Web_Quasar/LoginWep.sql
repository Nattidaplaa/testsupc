/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [EMPLOYEE],
       [PASSWORD]
FROM [test].[dbo].[Test_LoginEmployee]


--เพิ่มข้อมูล
INSERT INTO [Test_LoginEmployee] 
							(
								[EMPLOYEE],
								[PASSWORD]	
							)
							
VALUES('4444','4444')


--ค้นหาข้อมูล
SELECT [EMPLOYEE],
       [PASSWORD]
FROM [Test_LoginEmployee]
WHERE [EMPLOYEE] = COALESCE(NULLIF('{EMPLOYEE}',''), [EMPLOYEE])
AND   [PASSWORD] = COALESCE(NULLIF('{PASSWORD}',''), [PASSWORD])

--สร้าง api เพื่อส่งข้อมูลไป+สร้าง model ใหม่สำหรับเก็บค่า / ตัวนี้
