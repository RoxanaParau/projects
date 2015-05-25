SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([ID], [Username], [Password], [Email], [role_ID]) VALUES (1, N'Test1', N'a94a8fe5ccb19ba61c4c0873d391e987982fbbd3', N'test1@test.coom', 1)
INSERT INTO [dbo].[User] ([ID], [Username], [Password], [Email], [role_ID]) VALUES (2, N'Test2', N'a94a8fe5ccb19ba61c4c0873d391e987982fbbd3', N'test2@test.coom', 2)
INSERT INTO [dbo].[User] ([ID], [Username], [Password], [Email], [role_ID]) VALUES (3, N'Test3', N'a94a8fe5ccb19ba61c4c0873d391e987982fbbd3', N'test3@test.coom', 3)
SET IDENTITY_INSERT [dbo].[User] OFF
