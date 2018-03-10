CREATE TABLE [dbo].[DevelopmentPlans] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [content]     NVARCHAR (MAX) NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    [user_id]     INT            NULL,
    CONSTRAINT [PK_DevelopmentPlans] PRIMARY KEY CLUSTERED ([id] ASC)
);

