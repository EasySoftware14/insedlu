CREATE TABLE [dbo].[Client] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [name]           NVARCHAR (50)  NULL,
    [contact_number] NVARCHAR (12)  NULL,
    [status]         INT            NULL,
    [email]          NVARCHAR (100) NULL,
    [created_at]     DATETIME       NULL,
    [modified_at]    DATETIME       NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([id] ASC)
);

