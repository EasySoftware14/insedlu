CREATE TABLE [dbo].[ConfidentialityStatement] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [statement] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ConfidentialityStatement] PRIMARY KEY CLUSTERED ([id] ASC)
);

