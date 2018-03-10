CREATE TABLE [dbo].[ProjectProjections] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [proj_id]        INT           NULL,
    [employees]      NVARCHAR (50) NULL,
    [vehicle]        NVARCHAR (50) NULL,
    [accomodation]   NVARCHAR (50) NULL,
    [print_material] NVARCHAR (50) NULL,
    [refreshments]   NVARCHAR (50) NULL,
    [telephone]      NVARCHAR (50) NULL,
    [wifi_data]      NVARCHAR (50) NULL,
    [status]         INT           NULL,
    [created_at]     DATETIME      NULL,
    [modified_at]    DATETIME      NULL,
    [user_id]        INT           NULL,
    CONSTRAINT [PK_ProjectProjections] PRIMARY KEY CLUSTERED ([id] ASC)
);

