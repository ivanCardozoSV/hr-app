BEGIN TRAN LoadAssigneess

INSERT INTO tasks.Assignees
SELECT 
	NEWID(),
	atm.Name,
	CURRENT_USER, 
	GETDATE(), 
	CURRENT_USER, 
	GETDATE(), 
	1
FROM (select distinct Name, AssetTeamMemberType_Code from [dbo].[AM_Asset_MemberNames]) as atm
WHERE atm.AssetTeamMemberType_Code in ('TLD', 'ANL')

COMMIT TRAN LoadAssigneess