CREATE TABLE [dbo].[ProjectProposal] (
    [id]            INT             IDENTITY (1, 1) NOT NULL,
    [proj_id]       INT             NULL,
    [name]          NVARCHAR (250)  NULL,
    [document_type] NVARCHAR (MAX)  NULL,
    [file]          VARBINARY (MAX) NULL,
    [created_at]    DATETIME        NULL,
    [modified_at]   DATETIME        NULL,
    CONSTRAINT [PK_ProjectProposal] PRIMARY KEY CLUSTERED ([id] ASC)
);

