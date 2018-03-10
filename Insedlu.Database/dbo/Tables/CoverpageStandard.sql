CREATE TABLE [dbo].[CoverpageStandard] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [prepared_by] NVARCHAR (100) NULL,
    [address]     NVARCHAR (200) NULL,
    CONSTRAINT [PK_CoverpageStandard] PRIMARY KEY CLUSTERED ([id] ASC)
);

