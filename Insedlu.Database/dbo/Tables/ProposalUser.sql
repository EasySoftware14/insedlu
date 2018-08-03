CREATE TABLE [dbo].[ProposalUser] (
    [id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [proj_id]     INT           NULL,
    [users]       NVARCHAR (50) NULL,
    [created_at]  DATETIME      NULL,
    [modified_at] DATETIME      NULL,
    CONSTRAINT [PK_ProposalUser] PRIMARY KEY CLUSTERED ([id] ASC)
);

