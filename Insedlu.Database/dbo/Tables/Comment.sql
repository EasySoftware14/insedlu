CREATE TABLE [dbo].[Comment] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [proj_id]     INT            NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    [comment]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([id] ASC)
);

