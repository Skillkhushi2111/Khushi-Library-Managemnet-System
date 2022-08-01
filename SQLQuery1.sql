/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [bid]
      ,[bname]
      ,[bAuthor]
      ,[bPubli]
      ,[bDate]
      ,[bPrice]
      ,[bQuan]
  FROM [library].[dbo].[Newbook]