CREATE TABLE [dbo].[Activity] (
    [worklog_id]        INT            NULL,
    [asset]             NVARCHAR (100) NULL,
    [asset_id]          INT            NULL,
    [id]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [cost]              NVARCHAR (10)  NULL,
    [location_name]     NVARCHAR (50)  NULL,
    [material_name]     NVARCHAR (50)  NULL,
    [material_quantity] NVARCHAR (20)  NULL,
    CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED ([id] ASC)
);

