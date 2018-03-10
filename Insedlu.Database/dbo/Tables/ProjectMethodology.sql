CREATE TABLE [dbo].[ProjectMethodology] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    [content]     NVARCHAR (MAX) NULL,
    [proj_id]     INT            NULL,
    CONSTRAINT [PK_ProjectMethodology] PRIMARY KEY CLUSTERED ([id] ASC)
);

