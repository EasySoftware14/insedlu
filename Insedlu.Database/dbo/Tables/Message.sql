CREATE TABLE [dbo].[Message] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [userId]    INT           NULL,
    [firstName] NVARCHAR (50) NULL,
    [lastName]  NVARCHAR (50) NULL,
    [level]     INT           NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([id] ASC)
);

