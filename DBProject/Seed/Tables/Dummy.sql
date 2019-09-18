CREATE TABLE [seed].[Dummies] (
	-- Entity
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [Version]              BIGINT           NOT NULL,
    [CreatedBy]            NVARCHAR (MAX)   DEFAULT (user_name()) NULL,
    [CreatedDate]          DATETIME2 (7)    DEFAULT (getdate()) NOT NULL,
    [LastModifiedBy]       NVARCHAR (MAX)   DEFAULT (user_name()) NULL,
    [LastModifiedDate]     DATETIME2 (7)    DEFAULT (getdate()) NOT NULL,
	-- DescriptiveEntity
    [Name]                 NVARCHAR (MAX)   NULL,
    [Description]          NVARCHAR (MAX)   NULL,
	-- Entity
    [TestValue]			   NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Dummies] PRIMARY KEY CLUSTERED ([Id] ASC)
);
