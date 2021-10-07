CREATE TABLE [dbo].[countries] (
    [country_id] INT          IDENTITY (1, 1) NOT NULL,
    [name]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([country_id] ASC)
);

