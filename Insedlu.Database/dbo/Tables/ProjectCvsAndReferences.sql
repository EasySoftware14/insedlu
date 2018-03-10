CREATE TABLE [dbo].[ProjectCvsAndReferences] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [cvs]         NVARCHAR (20) NULL,
    [references]  NVARCHAR (20) NULL,
    [project_id]  INT           NULL,
    [created_at]  DATETIME      NULL,
    [modified_at] DATETIME      NULL,
    CONSTRAINT [PK_ProjectCvsAndReferences] PRIMARY KEY CLUSTERED ([id] ASC)
);

