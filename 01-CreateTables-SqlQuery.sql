Create table Category(
[CategoryId]			[int]	IDENTITY(1,1)	NOT NULL,
[CategoryName]			[nvarchar](100)			NOT NULL,
[CategoryDescription]	[nvarchar](max)			NOT NULL,

CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
CONSTRAINT [UK_Category_CategoryName] UNIQUE NONCLUSTERED ([CategoryName] ASC)
)

GO

Create table Movie(
[MovieId]			[int]	IDENTITY(1,1)	NOT NULL,
[MovieName]			[nvarchar](100)			NOT NULL,
[MovieDescription]	[nvarchar](max)			NOT NULL,
[CategoryId]		[int]					NOT NULL,
[IsActive]			[bit]					NOT NULL	DEFAULT ((1)),

CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([MovieId] ASC),
CONSTRAINT [UK_Movie_MovieName] UNIQUE NONCLUSTERED ([MovieName] ASC),
CONSTRAINT [FK_Movie_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] (CategoryId)
)