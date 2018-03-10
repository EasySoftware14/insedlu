CREATE TABLE [dbo].[ProjectScopeOfWork] (
    [id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [proj_id]      INT            NULL,
    [content]      NVARCHAR (MAX) NULL,
    [created_at]   DATETIME       NULL,
    [modified_at]  DATETIME       NULL,
    [aim]          NVARCHAR (MAX) NULL,
    [purpose]      NVARCHAR (MAX) NULL,
    [deliverables] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ProjectScopeOfWork] PRIMARY KEY CLUSTERED ([id] ASC)
);

