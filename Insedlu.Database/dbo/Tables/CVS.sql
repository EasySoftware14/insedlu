CREATE TABLE [dbo].[CVS] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (150) NULL,
    [surname]          NVARCHAR (150) NULL,
    [credentials]      NVARCHAR (MAX) NULL,
    [position]         NVARCHAR (100) NULL,
    [responsibilities] NVARCHAR (MAX) NULL,
    [qualification]    NVARCHAR (150) NULL,
    CONSTRAINT [PK_CVS] PRIMARY KEY CLUSTERED ([id] ASC)
);

