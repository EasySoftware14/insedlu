CREATE TABLE [dbo].[CompanyServices] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (100) NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    CONSTRAINT [PK_CompanyServices] PRIMARY KEY CLUSTERED ([id] ASC)
);

