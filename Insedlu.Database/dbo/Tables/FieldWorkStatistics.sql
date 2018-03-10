CREATE TABLE [dbo].[FieldWorkStatistics] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (100) NULL,
    [worklog_id]  INT            NULL,
    [start_date]  DATE           NULL,
    [end_date]    DATE           NULL,
    [pulse_count] NCHAR (10)     NULL,
    [project_id]  INT            NULL,
    CONSTRAINT [PK_FieldWorkStatistics] PRIMARY KEY CLUSTERED ([id] ASC)
);

