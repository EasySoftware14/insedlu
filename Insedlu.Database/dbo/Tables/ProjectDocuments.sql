CREATE TABLE [dbo].[ProjectDocuments] (
    [id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (100)  NULL,
    [doc_type]    NVARCHAR (MAX)  NULL,
    [proj_id]     INT             NULL,
    [file]        VARBINARY (MAX) NULL,
    [created_at]  DATETIME        NULL,
    [modified_at] DATETIME        NULL,
    [location]    NVARCHAR (200)  NULL,
    CONSTRAINT [PK_ProjectDocuments] PRIMARY KEY CLUSTERED ([id] ASC)
);

