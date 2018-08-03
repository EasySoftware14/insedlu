CREATE TABLE [dbo].[ProjectCategory] (
    [id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50) NULL,
    [status]      INT           NULL,
    [created_at]  DATETIME      NULL,
    [modified_at] DATETIME      NULL,
    CONSTRAINT [PK_ProjectCategory] PRIMARY KEY CLUSTERED ([id] ASC)
);

