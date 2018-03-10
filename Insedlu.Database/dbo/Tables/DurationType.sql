CREATE TABLE [dbo].[DurationType] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_DurationType] PRIMARY KEY CLUSTERED ([id] ASC)
);

