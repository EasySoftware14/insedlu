CREATE TABLE [dbo].[ExecutiveSummary] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [proj_id]     INT            NOT NULL,
    [content]     NVARCHAR (MAX) NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    CONSTRAINT [PK_ExecutiveSummary] PRIMARY KEY CLUSTERED ([id] ASC)
);

