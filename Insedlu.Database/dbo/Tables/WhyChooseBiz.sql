CREATE TABLE [dbo].[WhyChooseBiz] (
    [id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [proj_id]    INT            NULL,
    [content]    NVARCHAR (MAX) NULL,
    [createdAt]  DATETIME       NULL,
    [modifiedAt] DATETIME       NULL,
    CONSTRAINT [PK_WhyChooseBiz] PRIMARY KEY CLUSTERED ([id] ASC)
);

