CREATE TABLE [dbo].[segmentpunt]
(
	[segmentID] INT NOT NULL , 
    [puntID] INT NOT NULL, 
    [seqnr] INT NOT NULL, 
    PRIMARY KEY ([segmentID], [puntID]), 
    CONSTRAINT [FK_segmentpunt_segment] FOREIGN KEY ([segmentID]) REFERENCES [segment]([id]) ,
	CONSTRAINT [FK_segmentpunt_punt] FOREIGN KEY ([puntID]) REFERENCES [punt]([id])
)
