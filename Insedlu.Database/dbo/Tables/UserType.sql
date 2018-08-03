CREATE TABLE [dbo].[UserType] (
    [id]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [name]   NVARCHAR (50) NULL,
    [status] INT           NULL,
    CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([id] ASC)
);

