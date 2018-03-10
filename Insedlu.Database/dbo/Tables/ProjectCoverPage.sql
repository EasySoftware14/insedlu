CREATE TABLE [dbo].[ProjectCoverPage] (
    [id]                  BIGINT         IDENTITY (1, 1) NOT NULL,
    [created_at]          DATETIME       NULL,
    [modified_at]         DATETIME       NULL,
    [content]             NVARCHAR (MAX) NULL,
    [proj_id]             INT            NULL,
    [prepared_for]        NVARCHAR (150) NULL,
    [reason_for_proposal] NVARCHAR (150) NULL,
    [date_submitted]      DATE           NULL,
    CONSTRAINT [PK_ProjectCoverPage] PRIMARY KEY CLUSTERED ([id] ASC)
);

