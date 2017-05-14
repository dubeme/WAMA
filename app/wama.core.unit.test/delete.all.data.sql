USE [wama.db]
GO

BEGIN TRANSACTION

DELETE FROM [dbo].[Certifications];
DELETE FROM [dbo].[CheckInActivities];
DELETE FROM [dbo].[LogInCredentials];
DELETE FROM [dbo].[UserAccounts];
DELETE FROM [dbo].[Waivers];

ROLLBACK TRANSACTION;