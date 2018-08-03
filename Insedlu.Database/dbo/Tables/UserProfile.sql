CREATE TABLE [dbo].[UserProfile] (
    [id]              BIGINT          NULL,
    [user_id]         INT             NOT NULL,
    [task_id]         INT             NULL,
    [profile_pic]     VARBINARY (MAX) NULL,
    [job_title]       NVARCHAR (50)   NULL,
    [department_id]   INT             NULL,
    [contact_number]  NVARCHAR (15)   NULL,
    [position]        NVARCHAR (200)  NULL,
    [biography]       NVARCHAR (MAX)  NULL,
    [cv]              VARBINARY (MAX) NULL,
    [past_experience] NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED ([user_id] ASC)
);

