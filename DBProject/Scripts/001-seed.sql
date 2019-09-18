INSERT INTO [seed].[Dummies]
           ([Id]
           ,[Version]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[LastModifiedBy]
           ,[LastModifiedDate]
           ,[Name]
           ,[Description]
           ,[TestValue])
     VALUES
           (newid()--<Id, uniqueidentifier,>
           ,1--<Version, bigint,>
           ,1--<CreatedBy, nvarchar(max),>
           ,getdate()--<CreatedDate, datetime2(7),>
           ,null--<LastModifiedBy, nvarchar(max),>
           ,getdate()--<LastModifiedDate, datetime2(7),>
           ,'first'--<Name, nvarchar(max),>
           ,'first dummy'--<Description, nvarchar(max),>
           ,newid()--<TestValue, nvarchar(max),>
		   )
GO

INSERT INTO [seed].[Dummies]
           ([Id]
           ,[Version]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[LastModifiedBy]
           ,[LastModifiedDate]
           ,[Name]
           ,[Description]
           ,[TestValue])
     VALUES
           (newid()--<Id, uniqueidentifier,>
           ,1--<Version, bigint,>
           ,1--<CreatedBy, nvarchar(max),>
           ,getdate()--<CreatedDate, datetime2(7),>
           ,null--<LastModifiedBy, nvarchar(max),>
           ,getdate()--<LastModifiedDate, datetime2(7),>
           ,'second'--<Name, nvarchar(max),>
           ,'second dummy'--<Description, nvarchar(max),>
           ,newid()--<TestValue, nvarchar(max),>
		   )
GO

INSERT INTO [seed].[Dummies]
           ([Id]
           ,[Version]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[LastModifiedBy]
           ,[LastModifiedDate]
           ,[Name]
           ,[Description]
           ,[TestValue])
     VALUES
           (newid()--<Id, uniqueidentifier,>
           ,1--<Version, bigint,>
           ,1--<CreatedBy, nvarchar(max),>
           ,getdate()--<CreatedDate, datetime2(7),>
           ,null--<LastModifiedBy, nvarchar(max),>
           ,getdate()--<LastModifiedDate, datetime2(7),>
           ,'third'--<Name, nvarchar(max),>
           ,'third dummy'--<Description, nvarchar(max),>
           ,newid()--<TestValue, nvarchar(max),>
		   )
GO
INSERT INTO [seed].[Dummies]
           ([Id]
           ,[Version]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[LastModifiedBy]
           ,[LastModifiedDate]
           ,[Name]
           ,[Description]
           ,[TestValue])
     VALUES
           (newid()--<Id, uniqueidentifier,>
           ,1--<Version, bigint,>
           ,1--<CreatedBy, nvarchar(max),>
           ,getdate()--<CreatedDate, datetime2(7),>
           ,null--<LastModifiedBy, nvarchar(max),>
           ,getdate()--<LastModifiedDate, datetime2(7),>
           ,'forth'--<Name, nvarchar(max),>
           ,'forth dummy'--<Description, nvarchar(max),>
           ,newid()--<TestValue, nvarchar(max),>
		   )
GO



