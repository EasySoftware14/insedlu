CREATE TABLE [dbo].[User_Project] (
    [id]          BIGINT   IDENTITY (1, 1) NOT NULL,
    [proj_id]     INT      NULL,
    [user_id]     INT      NULL,
    [created_at]  DATETIME NULL,
    [modified_at] DATETIME NULL,
    CONSTRAINT [PK_User_Project] PRIMARY KEY CLUSTERED ([id] ASC)
);

