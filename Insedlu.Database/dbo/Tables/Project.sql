﻿CREATE TABLE [dbo].[Project] (
    [id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [description]      NVARCHAR (MAX) NULL,
    [created_at]       DATETIME       NULL,
    [modified_at]      DATETIME       NULL,
    [status]           INT            NULL,
    [user_id]          INT            NULL,
    [upload_id]        INT            NULL,
    [proj_cat_id]      INT            NULL,
    [name]             NVARCHAR (50)  NULL,
    [exec_summary_id]  INT            NULL,
    [company_id]       INT            NULL,
    [policy_id]        INT            NULL,
    [methodology_id]   INT            NULL,
    [team]             NVARCHAR (50)  NULL,
    [proj_reference]   INT            NULL,
    [cost_plan_id]     INT            NULL,
    [conclusion]       NVARCHAR (MAX) NULL,
    [risk_id]          INT            NULL,
    [duration]         INT            NULL,
    [project_type]     NVARCHAR (150) NULL,
    [coverpage_id]     INT            NULL,
    [jvCompany_id]     INT            NULL,
    [scope_id]         INT            NULL,
    [implement_id]     INT            NULL,
    [projectTeam_id]   INT            NULL,
    [bee_id]           INT            NULL,
    [whyChoose_id]     INT            NULL,
    [start_date]       DATE           NULL,
    [end_date]         DATE           NULL,
    [duration_type_id] INT            NULL,
    [proj_category_id] INT            NULL,
    [proj_envelop]     INT            NULL,
    [client_id]        INT            NULL,
    [is_completed]     BIT            NULL,
    [sector_id]        INT            NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([id] ASC)
);

