CREATE TABLE [dbo].[Task] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    [body]        NVARCHAR (MAX) NULL,
    [user_id]     INT            NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([id] ASC)
);

