CREATE TABLE [dbo].[WorkLog] (
    [id]          BIGINT IDENTITY (1, 1) NOT NULL,
    [proj_id]     INT    NOT NULL,
    [date_logged] DATE   NULL,
    [user_id]     INT    NULL,
    CONSTRAINT [PK_WorkLog] PRIMARY KEY CLUSTERED ([id] ASC)
);

