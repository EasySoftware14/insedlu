CREATE TABLE [dbo].[Vehicle] (
    [worklog_id] INT            NOT NULL,
    [start_date] DATE           NULL,
    [end_start]  DATE           NULL,
    [cost]       INT            NULL,
    [mileage]    NVARCHAR (100) NULL,
    [type]       NVARCHAR (50)  NULL,
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [project_id] INT            NULL,
    CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([id] ASC)
);

