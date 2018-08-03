CREATE TABLE [dbo].[ProjectTeam] (
    [id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [proj_id]    INT            NULL,
    [content]    NVARCHAR (MAX) NULL,
    [createdAt]  DATETIME       NULL,
    [modifiedAt] DATETIME       NULL,
    CONSTRAINT [PK_ProjectTeam] PRIMARY KEY CLUSTERED ([id] ASC)
);

