CREATE TABLE [dbo].[ProjectPolicy] (
    [id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [policy_number] NVARCHAR (20)  NULL,
    [name]          NVARCHAR (50)  NULL,
    [created_at]    DATETIME       NULL,
    [modified_at]   DATETIME       NULL,
    [proj_id]       INT            NULL,
    [content]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ProjectPolicy] PRIMARY KEY CLUSTERED ([id] ASC)
);

