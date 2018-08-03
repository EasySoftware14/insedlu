CREATE TABLE [dbo].[Logging] (
    [id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (50)  NULL,
    [department]       NVARCHAR (100) NULL,
    [duration]         INT            NULL,
    [created_at]       DATETIME       NULL,
    [modified_at]      DATETIME       NULL,
    [logger]           INT            NULL,
    [project_id]       INT            NULL,
    [duration_type_id] INT            NULL,
    CONSTRAINT [PK_Logging] PRIMARY KEY CLUSTERED ([id] ASC)
);

