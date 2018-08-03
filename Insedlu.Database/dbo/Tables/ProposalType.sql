CREATE TABLE [dbo].[ProposalType] (
    [id]   INT            IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (150) NULL,
    CONSTRAINT [PK_ProposalType] PRIMARY KEY CLUSTERED ([id] ASC)
);

