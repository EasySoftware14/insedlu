CREATE TABLE [dbo].[Notification] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NULL,
    [project_id]  INT            NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    [status]      INT            NULL,
    [body]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([id] ASC)
);

