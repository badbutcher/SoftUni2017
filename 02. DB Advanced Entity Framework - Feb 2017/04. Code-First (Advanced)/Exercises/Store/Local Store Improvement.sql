USE [Store.StoreContext]
GO

ALTER TABLE Products
ALTER COLUMN Weight FLOAT NULL

ALTER TABLE Products
ALTER COLUMN Quantity FLOAT NULL

SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [DistributorName], [Description], [Price]) VALUES (1, N'Apple', N'BGTrade', N'It''s an apple', 0.99)
INSERT [dbo].[Products] ([Id], [Name], [DistributorName], [Description], [Price]) VALUES (2, N'Banana', N'BGTrade', N'It''s an banana', 1.49)
INSERT [dbo].[Products] ([Id], [Name], [DistributorName], [Description], [Price]) VALUES (3, N'Orange', N'UKTrade', N'It''s an orange', 1.99)
SET IDENTITY_INSERT [dbo].[Products] OFF
