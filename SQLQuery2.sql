CREATE TABLE [dbo].[Questions] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [text]    NVARCHAR (MAX) NULL,
    [ans1]    NVARCHAR (50)  NULL,
    [ans2]    NVARCHAR (50)  NULL,
    [ans3]    NVARCHAR (50)  NULL,
    [correct] NVARCHAR (50)  NULL,
    [gr]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

