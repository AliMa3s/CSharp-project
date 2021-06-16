CREATE TABLE [dbo].[knoop] (
    [Id]     INT NOT NULL,
    [puntID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_knoop_punt] FOREIGN KEY ([puntID]) REFERENCES [punt]([id])
);
