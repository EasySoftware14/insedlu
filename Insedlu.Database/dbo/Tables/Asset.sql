CREATE TABLE [dbo].[Asset] (
    [id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED ([id] ASC)
);

