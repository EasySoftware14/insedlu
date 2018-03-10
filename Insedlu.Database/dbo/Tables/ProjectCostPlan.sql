CREATE TABLE [dbo].[ProjectCostPlan] (
    [id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [created_at]   DATETIME       NULL,
    [modified_at]  DATETIME       NULL,
    [proj_id]      INT            NULL,
    [deliverable]  NVARCHAR (MAX) NULL,
    [activity]     NVARCHAR (100) NULL,
    [billing_days] NVARCHAR (50)  NULL,
    [rate_per_day] NVARCHAR (50)  NULL,
    [total_cost]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ProjectCostPlan] PRIMARY KEY CLUSTERED ([id] ASC)
);

