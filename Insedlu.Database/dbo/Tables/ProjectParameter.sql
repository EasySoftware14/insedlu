CREATE TABLE [dbo].[ProjectParameter] (
    [project_id]  INT      NOT NULL,
    [variable_id] INT      NULL,
    [create_at]   DATETIME NULL,
    [modified_at] DATETIME NULL,
    [created_by]  INT      NULL,
    CONSTRAINT [PK_ProjectParameter] PRIMARY KEY CLUSTERED ([project_id] ASC)
);

