CREATE TABLE [dbo].[Department] (
    [id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([id] ASC)
);

