CREATE TABLE [dbo].[User] (
    [id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]               NVARCHAR (50)  NULL,
    [surname]            NVARCHAR (50)  NULL,
    [email]              NVARCHAR (100) NULL,
    [password]           NVARCHAR (150) NULL,
    [recovery_question]  BIGINT         NULL,
    [recovery_answer]    NVARCHAR (MAX) NULL,
    [created_at]         DATETIME       NOT NULL,
    [modified_at]        DATETIME       NOT NULL,
    [temporary_password] NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [status]             INT            NULL,
    [contact_number]     NVARCHAR (20)  NULL,
    [project_id]         BIGINT         NULL,
    [user_type_id]       INT            NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([id] ASC)
);

