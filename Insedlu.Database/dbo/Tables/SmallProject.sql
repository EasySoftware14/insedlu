CREATE TABLE [dbo].[SmallProject] (
    [id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]          NVARCHAR (100) NULL,
    [department]    NVARCHAR (100) NULL,
    [administrator] INT            NULL,
    [duration]      NVARCHAR (50)  NULL,
    [created_at]    DATETIME       NULL,
    [modified_at]   DATETIME       NULL,
    [status]        INT            NULL,
    CONSTRAINT [PK_SmallProject] PRIMARY KEY CLUSTERED ([id] ASC)
);

