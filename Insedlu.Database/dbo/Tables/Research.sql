CREATE TABLE [dbo].[Research] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NULL,
    [data]        NVARCHAR (MAX) NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    [proj_id]     INT            NULL,
    CONSTRAINT [PK_Research] PRIMARY KEY CLUSTERED ([id] ASC)
);

