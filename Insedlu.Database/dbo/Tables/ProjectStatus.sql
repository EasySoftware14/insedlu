CREATE TABLE [dbo].[ProjectStatus] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_ProjectStatus] PRIMARY KEY CLUSTERED ([id] ASC)
);

