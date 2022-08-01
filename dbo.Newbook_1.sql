CREATE TABLE [dbo].[Newbook] (
    [id]      VARCHAR (250) NOT NULL,
    [bname]   VARCHAR (250) NULL,
    [bAuthor] VARCHAR (250) NULL,
    [bPubli]  VARCHAR (250) NULL,
    [bDate]   DATE          NULL,
    [bPrice]  BIGINT        NULL,
    [bQuan]   BIGINT        NULL,
    CONSTRAINT [PK_Newbook] PRIMARY KEY CLUSTERED ([id] ASC)
);

