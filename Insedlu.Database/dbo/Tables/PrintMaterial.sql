CREATE TABLE [dbo].[PrintMaterial] (
    [worklog_id] INT            NOT NULL,
    [start_date] DATE           NULL,
    [end_start]  DATE           NULL,
    [cost]       INT            NULL,
    [quantity]   NVARCHAR (100) NULL,
    [name]       NCHAR (10)     NULL,
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [project_id] INT            NULL,
    CONSTRAINT [PK_PrintMaterial] PRIMARY KEY CLUSTERED ([id] ASC)
);

