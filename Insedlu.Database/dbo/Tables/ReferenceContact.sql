CREATE TABLE [dbo].[ReferenceContact] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [fullname]       NVARCHAR (150) NULL,
    [position]       NVARCHAR (100) NULL,
    [contact_number] NVARCHAR (20)  NULL,
    [email]          NVARCHAR (100) NULL,
    [address]        NVARCHAR (200) NULL,
    CONSTRAINT [PK_ReferenceContact] PRIMARY KEY CLUSTERED ([id] ASC)
);

