/*
This script was created by Visual Studio on 9/27/2017 at 3:49 PM.
Run this script on amsappdbuat.AMS_App_UAT (CARLYLEDC\jpaez) to make it the same as localhost\SQLEXPRESS.AMS_APP_INT (CARLYLEDC\jpaez).
This script performs its actions in the following order:
1. Disable foreign-key constraints.
2. Perform DELETE commands. 
3. Perform UPDATE commands.
4. Perform INSERT commands.
5. Re-enable foreign-key constraints.
Please back up your target database before running this script.
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
/*Pointer used for text / image updates. This might not be needed, but is declared here just in case*/
DECLARE @pv binary(16)
BEGIN TRANSACTION
ALTER TABLE [tasks].[TaskStates] DROP CONSTRAINT [FK_TaskStates_TaskTypes_TaskTypeId]
ALTER TABLE [tasks].[TaskTypes] DROP CONSTRAINT [FK_TaskTypes_ClientSystems_ClientSystemId]
INSERT INTO [tasks].[ClientSystems] ([Id], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [Name], [Version], [ActiveDirectoryAccessList]) VALUES (N'63578e2e-0aff-4211-dcf6-08d505164608', N'dbo', '20170926 15:39:16.6500000', N'AMS System', N'dbo', '20170926 15:39:16.6500000', N'AMS', 0, N'AMSSvcProd')
INSERT INTO [tasks].[TaskTypes] ([Id], [ClientSystemId], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [MinAssigneesApproval], [Name], [Version]) VALUES (N'0fece886-7208-45eb-5d46-08d50516460e', N'63578e2e-0aff-4211-dcf6-08d505164608', N'Migration', '20170926 15:39:16.5522039', N'Early Sale period task type', N'dbo', '20170926 15:39:16.6700000', 0, N'Early Sale', 0)
INSERT INTO [tasks].[TaskTypes] ([Id], [ClientSystemId], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [MinAssigneesApproval], [Name], [Version]) VALUES (N'2b10f6b0-bcac-4106-5d45-08d50516460e', N'63578e2e-0aff-4211-dcf6-08d505164608', N'Migration', '20170926 15:39:16.5522012', N'Base Case period task type', N'dbo', '20170926 15:39:16.6700000', 0, N'Base Case', 0)
INSERT INTO [tasks].[TaskTypes] ([Id], [ClientSystemId], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [MinAssigneesApproval], [Name], [Version]) VALUES (N'bf04a20c-1543-41a0-5d44-08d50516460e', N'63578e2e-0aff-4211-dcf6-08d505164608', N'Migration', '20170926 15:39:16.5520584', N'Reporting period task type', N'dbo', '20170926 15:39:16.6700000', 0, N'Reporting', 0)
INSERT INTO [tasks].[TaskStates] ([Id], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [Name], [Step], [TaskTypeId], [Version]) VALUES (N'0b3878e2-51a7-4f6c-7f45-08d505164610', N'dbo', '20170926 15:39:16.6866667', NULL, N'dbo', '20170926 15:39:16.6866667', N'Not Uploaded', 0, N'2b10f6b0-bcac-4106-5d45-08d50516460e', 0)
INSERT INTO [tasks].[TaskStates] ([Id], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [Name], [Step], [TaskTypeId], [Version]) VALUES (N'0b559de5-fb67-452c-7f48-08d505164610', N'dbo', '20170926 15:39:16.6866667', NULL, N'dbo', '20170926 15:39:16.6866667', N'Uploaded', 1, N'0fece886-7208-45eb-5d46-08d50516460e', 0)
INSERT INTO [tasks].[TaskStates] ([Id], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [Name], [Step], [TaskTypeId], [Version]) VALUES (N'70f24b53-8b12-4bb2-7f47-08d505164610', N'dbo', '20170926 15:39:16.6866667', NULL, N'dbo', '20170926 15:39:16.6866667', N'Not Uploaded', 0, N'0fece886-7208-45eb-5d46-08d50516460e', 0)
INSERT INTO [tasks].[TaskStates] ([Id], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [Name], [Step], [TaskTypeId], [Version]) VALUES (N'a3b310a7-58f2-402e-7f44-08d505164610', N'dbo', '20170926 15:39:16.6866667', NULL, N'dbo', '20170926 15:39:16.6866667', N'Reporting', 0, N'bf04a20c-1543-41a0-5d44-08d50516460e', 0)
INSERT INTO [tasks].[TaskStates] ([Id], [CreatedBy], [CreatedDate], [Description], [LastModifiedBy], [LastModifiedDate], [Name], [Step], [TaskTypeId], [Version]) VALUES (N'afe1b742-6cbe-4364-7f46-08d505164610', N'dbo', '20170926 15:39:16.6866667', NULL, N'dbo', '20170926 15:39:16.6866667', N'Uploaded', 1, N'2b10f6b0-bcac-4106-5d45-08d50516460e', 0)
ALTER TABLE [tasks].[TaskStates]
    ADD CONSTRAINT [FK_TaskStates_TaskTypes_TaskTypeId] FOREIGN KEY ([TaskTypeId]) REFERENCES [tasks].[TaskTypes] ([Id])
ALTER TABLE [tasks].[TaskTypes]
    ADD CONSTRAINT [FK_TaskTypes_ClientSystems_ClientSystemId] FOREIGN KEY ([ClientSystemId]) REFERENCES [tasks].[ClientSystems] ([Id])
COMMIT TRANSACTION
