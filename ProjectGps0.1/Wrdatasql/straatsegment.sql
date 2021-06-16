CREATE TABLE [dbo].[straatsegment]
(
	[straatID] INT NOT NULL , 
    [segmentID] INT NOT NULL, 
    PRIMARY KEY ([segmentID], [straatID]), 
    CONSTRAINT [FK_straatsegment_straat] FOREIGN KEY ([straatID]) REFERENCES [straat]([id]),
	CONSTRAINT [FK_straatsegment_segment] FOREIGN KEY ([segmentID]) REFERENCES [segment]([id])
)
