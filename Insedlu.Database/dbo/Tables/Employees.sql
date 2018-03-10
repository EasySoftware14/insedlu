CREATE TABLE [dbo].[Employees] (
    [worklog_id]      INT           NOT NULL,
    [start_date]      DATE          NULL,
    [end_start]       DATE          NULL,
    [cost]            INT           NULL,
    [no_of_employees] NVARCHAR (10) NULL,
    [employee_type]   NVARCHAR (50) NULL,
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [project_id]      INT           NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([id] ASC)
);

