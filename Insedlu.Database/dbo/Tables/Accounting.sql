CREATE TABLE [dbo].[Accounting] (
    [id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [data]        NVARCHAR (MAX)  NULL,
    [created_at]  DATETIME        NULL,
    [modified_at] DATETIME        NULL,
    [binary_data] VARBINARY (MAX) NULL,
    [name]        NVARCHAR (50)   NULL,
    CONSTRAINT [PK_Accounting] PRIMARY KEY CLUSTERED ([id] ASC)
);

