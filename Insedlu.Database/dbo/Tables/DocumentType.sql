CREATE TABLE [dbo].[DocumentType] (
    [id]       BIGINT IDENTITY (1, 1) NOT NULL,
    [doc_type] INT    NULL,
    CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED ([id] ASC)
);

