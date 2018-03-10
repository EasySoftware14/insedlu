CREATE TABLE [dbo].[Accommodation] (
    [worklog_id] INT            NOT NULL,
    [location]   NVARCHAR (100) NULL,
    [start_date] DATE           NULL,
    [end_start]  DATE           NULL,
    [cost]       INT            NULL,
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [project_id] INT            NULL,
    CONSTRAINT [PK_Accommodation] PRIMARY KEY CLUSTERED ([id] ASC)
);

