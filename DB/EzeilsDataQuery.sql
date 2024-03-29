/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[ProductAttributeMappingId]
      ,[AttributeValueTypeId]
      ,[AssociatedProductId]
      ,[Name]
      ,[ColorSquaresRgb]
      ,[BarCode]
      ,[ImageSquaresPictureId]
      ,[PriceAdjustment]
      ,[PriceAdjustmentUsePercentage]
      ,[WeightAdjustment]
      ,[Cost]
      ,[CustomerEntersQty]
      ,[Quantity]
      ,[IsPreSelected]
      ,[DisplayOrder]
      ,[PictureId]
  FROM [Zeils_Commerce].[dbo].[ProductAttributeValue]

  -- select Sku, StockQuantity --
  SELECT Sku, StockQuantity FROM Product WHERE Id = '86'
  -- set Sku --
  UPDATE Product SET Sku = '8032EJ1564' WHERE Id = '86'
  -- set StockQuantity --
  UPDATE Product SET StockQuantity = '1000' WHERE Id = '86'

  -- 02 december 2020 --
  -- set BarCode --
  UPDATE ProductAttributeValue SET BarCode = '0016AC0003' WHERE Id = '38'
  -- set Quantity --
  UPDATE ProductAttributeValue SET Quantity = '12' WHERE Id = '38'
  -- select Id, Quantity --
  SELECT Id, Quantity FROM ProductAttributeValue WHERE BarCode = '0016AC0003'