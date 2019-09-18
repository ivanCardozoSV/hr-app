if(not exists(select top 1 1 from tasks.Assignees where ActiveDirectoryName = 'LShi'))
insert into tasks.Assignees
values (NEWID(), 'LShi', CURRENT_USER, GETDATE(), CURRENT_USER, GETDATE(), 1)

if(not exists(select top 1 1 from tasks.Assignees where ActiveDirectoryName = 'CRuyak'))
insert into tasks.Assignees
values (NEWID(), 'CRuyak', CURRENT_USER, GETDATE(), CURRENT_USER, GETDATE(), 1)

if(not exists(select top 1 1 from tasks.Assignees where ActiveDirectoryName = 'AFleming'))
insert into tasks.Assignees
values (NEWID(), 'AFleming', CURRENT_USER, GETDATE(), CURRENT_USER, GETDATE(), 1)