USE [wama.db]
GO

/****** Script for SelectTopNRows command from SSMS  ******/
USE [wama.db]
GO

Declare @Genders TABLE (name nvarchar(MAX))

INSERT INTO @Genders VALUES 
    ('1'),
    ('2'),
    ('3')

Declare @EmailDomains TABLE (name nvarchar(MAX))

INSERT INTO @EmailDomains VALUES 
    ('@sdstate.edu'),
    ('@jacks.sdstate.edu')

Declare @Names TABLE (name nvarchar(MAX))

INSERT INTO @Names VALUES 
    ('Mozell'),
    ('Recio'),
    ('Forest'),
    ('Lipka'),
    ('Cherrie'),
    ('Lippold'),
    ('Stefany'),
    ('Ciulla'),
    ('Renata'),
    ('Galyon'),
    ('Petrina'),
    ('Vogus'),
    ('German'),
    ('Durgin'),
    ('Shela'),
    ('Mulkey'),
    ('Maud'),
    ('Lux'),
    ('Phebe'),
    ('Heckert'),
    ('Maryann'),
    ('Avilez'),
    ('Elton'),
    ('Eis'),
    ('Wai'),
    ('Schlabach'),
    ('Aron'),
    ('Matas'),
    ('Dino'),
    ('Milhorn'),
    ('Aaron'),
    ('Barcelo'),
    ('Irena'),
    ('Atencio'),
    ('Kermit'),
    ('Finks'),
    ('Roslyn'),
    ('Schuld'),
    ('Beth'),
    ('Redinger'),
    ('Rosie'),
    ('Lipham'),
    ('Claretta'),
    ('Patenaude'),
    ('Floyd'),
    ('Modlin'),
    ('Lawerence'),
    ('Dammann'),
    ('Malcolm'),
    ('Weldon'),
    ('Elinore'),
    ('Abate'),
    ('Lynnette'),
    ('Castenada'),
    ('Harlan'),
    ('Maclin'),
    ('Alexia'),
    ('Howery'),
    ('Matha'),
    ('Jacoby'),
    ('Ursula'),
    ('Dipalma'),
    ('Bo'),
    ('Pummill'),
    ('Inocencia'),
    ('Foss'),
    ('Anitra'),
    ('Luedtke'),
    ('Alishia'),
    ('Hindman'),
    ('Penni'),
    ('Hollingshead'),
    ('Debra'),
    ('Arterburn'),
    ('Briana'),
    ('Courtois'),
    ('Marissa'),
    ('Cummings'),
    ('Chantal'),
    ('Doane'),
    ('Adelia'),
    ('Hoban'),
    ('Valorie'),
    ('Bonds'),
    ('Celine'),
    ('Mccawley'),
    ('Zenobia'),
    ('Preiss'),
    ('Marni'),
    ('Bea'),
    ('Annice'),
    ('Stuart'),
    ('Chanda'),
    ('Mccutchen'),
    ('Erick'),
    ('Stoner'),
    ('Alease'),
    ('Nguyen'),
    ('Lavada'),
    ('Shore')

DECLARE @IDs TABLE (MemnerId nvarchar(MAX))

DECLARE @JimmyJohnID AS INT = 2345678
DECLARE @JimmyJohnPassword AS VARCHAR(MAX) = 'password'

INSERT INTO [dbo].[UserAccounts]
           ([AccountType]
           ,[FirstName]
           ,[LastName]
           ,[MemberId]
           ,[__CreatedOn]
           ,[IsSuspended]
           ,[__LastUpdatedOn]
           ,[Gender]
           ,[HasBeenApproved]
           ,[MiddleName]
		   ,[Email])
OUTPUT inserted.MemberId INTO @IDs
VALUES
    (
        1,
        'John',
        'Doe',
        7654321,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        'Jane',
        'Smith',
        8765432,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876540,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876541,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876542,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876543,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876544,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876545,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876546,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876547,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876548,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        1,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        9876549,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        'Jimmy',
        'John',
        @JimmyJohnID,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780651,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780652,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780653,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780654,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780655,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780656,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780657,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780658,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780659,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        2,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6780650,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016540,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016549,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016548,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016547,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016546,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016545,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016544,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016543,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016542,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        4,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        2016541,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325141,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325142,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325143,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325144,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325145,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325146,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325147,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325148,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325149,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        8,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        6325140,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        16,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        8521472,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    ),
    (
        16,
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        8521473,
        SYSUTCDATETIME(),
        0,
		SYSUTCDATETIME(),
		(SELECT TOP 1 * FROM @Genders ORDER BY NEWID()),
		0,
		(SELECT TOP 1 * FROM @Names ORDER BY NEWID()),
        (SELECT (SELECT TOP 1 * FROM @Names ORDER BY NEWID()) + (SELECT TOP 1 * FROM @EmailDomains ORDER BY NEWID()))
    )

UPDATE [dbo].[UserAccounts]
SET 
    [HasBeenApproved] = 1
WHERE [AccountType] <> 1   
    
    
DECLARE db_cursor CURSOR FOR SELECT * FROM @IDs; 
DECLARE @memberId VARCHAR(MAX);
OPEN db_cursor;
FETCH NEXT FROM db_cursor INTO @memberId;
WHILE @@FETCH_STATUS = 0  
BEGIN
	DECLARE @time AS DATETIMEOFFSET = DATEADD(HOUR, -ABS(CHECKSUM(NewId()))%168, SYSUTCDATETIME());

	INSERT INTO [dbo].[CheckInActivities]
		([CheckInDateTime]
		,[MemberId]
		,[__CreatedOn]
		,[__LastUpdatedOn]
		,[IsCheckedIn])
     VALUES
	 (
		@time,
		@memberId,
		@time,
		@time,
		0
	);

	FETCH NEXT FROM db_cursor INTO @memberId;
END;
CLOSE db_cursor;
DEALLOCATE db_cursor;

SET @time = DATEADD(HOUR, -ABS(CHECKSUM(NewId()))%168, SYSUTCDATETIME())

INSERT INTO [dbo].[LogInCredentials]
	([HashedPassword]
	,[MemberId]
	,[RequiresPassword]
	,[__CreatedOn]
	,[__LastUpdatedOn])
    VALUES
	(
	@JimmyJohnPassword,
	@JimmyJohnID,
	1,
	@time,
	@time
);






GO

