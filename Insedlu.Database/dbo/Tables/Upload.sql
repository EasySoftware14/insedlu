CREATE TABLE [dbo].[Upload] (
    [id]               BIGINT          IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (MAX)  NULL,
    [file_location]    NVARCHAR (MAX)  NULL,
    [created_at]       DATETIME        NULL,
    [modified_at]      DATETIME        NULL,
    [data]             VARBINARY (MAX) NULL,
    [content_type]     NVARCHAR (MAX)  NULL,
    [user_id]          INT             NULL,
    [document_type_id] INT             NULL,
    CONSTRAINT [PK_Upload] PRIMARY KEY CLUSTERED ([id] ASC)
);

