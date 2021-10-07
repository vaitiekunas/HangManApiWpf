CREATE TABLE [dbo].[records] (
    [user_id]     INT          IDENTITY (1, 1) NOT NULL,
    [user_name]   VARCHAR (50) NOT NULL,
    [user_points] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);

