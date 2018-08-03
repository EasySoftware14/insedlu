CREATE TABLE [dbo].[ProjectImplementationTime] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [proj_id]     INT            NULL,
    [content]     NVARCHAR (MAX) NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    CONSTRAINT [PK_ProjectImplementationTime] PRIMARY KEY CLUSTERED ([id] ASC)
);

