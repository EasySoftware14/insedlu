CREATE TABLE [dbo].[MyStory] (
    [id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [story]       NVARCHAR (MAX) NULL,
    [user_id]     INT            NULL,
    [created_at]  DATETIME       NULL,
    [modified_at] DATETIME       NULL,
    CONSTRAINT [PK_MyStory] PRIMARY KEY CLUSTERED ([id] ASC)
);

