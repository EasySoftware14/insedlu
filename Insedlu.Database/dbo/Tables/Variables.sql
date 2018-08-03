CREATE TABLE [dbo].[Variables] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (100) NULL,
    [access_key] NCHAR (3)      NULL,
    CONSTRAINT [PK_Variables] PRIMARY KEY CLUSTERED ([id] ASC)
);

