CREATE TABLE [dbo].[References] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [client_name]     NVARCHAR (100) NULL,
    [project_details] NVARCHAR (MAX) NULL,
    [date_undertaken] NVARCHAR (50)  NULL,
    [project_value]   NVARCHAR (200) NULL,
    [contact_id]      INT            NULL,
    CONSTRAINT [PK_References] PRIMARY KEY CLUSTERED ([id] ASC)
);

