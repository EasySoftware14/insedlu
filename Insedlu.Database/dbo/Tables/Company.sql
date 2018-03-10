CREATE TABLE [dbo].[Company] (
    [id]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [background]        NVARCHAR (MAX) NULL,
    [created_at]        DATETIME       NULL,
    [modified_at]       DATETIME       NULL,
    [mission_statement] NVARCHAR (MAX) NULL,
    [service_offering]  NVARCHAR (200) NULL,
    [proj_id]           INT            NULL,
    [headoffice]        NVARCHAR (300) NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([id] ASC)
);

