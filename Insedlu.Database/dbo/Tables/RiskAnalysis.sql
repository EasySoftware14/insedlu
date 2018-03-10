CREATE TABLE [dbo].[RiskAnalysis] (
    [id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [created_at]    DATETIME       NULL,
    [modified_at]   DATETIME       NULL,
    [risk_analysis] NVARCHAR (MAX) NULL,
    [proj_id]       INT            NULL,
    CONSTRAINT [PK_RiskAnalysis] PRIMARY KEY CLUSTERED ([id] ASC)
);

