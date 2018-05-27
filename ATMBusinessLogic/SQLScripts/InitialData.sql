
set identity_insert [LocalATM].[dbo].[Clients] on

INSERT INTO [LocalATM].[dbo].[Clients] ([ClientID],[FirstName],[LastName],[Birthday],[Phone])
VALUES (1, 'ATM','ATM', '1900-01-01','')
	, (2,'Leonore','Walter-Sauer', '1971-06-11','+49(545)-6888355')
	, (3,'Klara','Kern', '1999-01-01','+49(656)-5338742')	
	, (4,'Friederike','Kisler', '1980-01-01','+49(656)-0222223')

set identity_insert [LocalATM].[dbo].[Clients] off

INSERT INTO [LocalATM].[dbo].[Address] ([ClientID],[Country],[State],[City],[Address])
VALUES 
	  (2, 'Germany', 'Berlin', '', '832 Virginia Hollow'),
	  (3, 'Bolivia', 'Santa Cruz', '', 'Boulevard Fulleda No. 802'),
	  (4, 'Canada', 'Territorios del Noroeste', '', '753 Polk Drive')
	
GO
INSERT INTO [LocalATM].[dbo].[Card] ([CardID], [ClientID], [PinCode], [Ballance])
VALUES 
	  ('0000000000000000', 1, '0000','0')
	, ('1111111111111111', 2, '1111','0'), ('1111111111111112', 2, '1112','0'), ('1111111111111113', 2, '1113','0')
	, ('2222222222222221', 3, '2221','0'), ('2222222222222222', 3, '2222','0')
	, ('3333333333333331', 4, '3331','0')

GO
INSERT INTO [LocalATM].[dbo].[OperationsType] ([Type])
VALUES 
	  ('+'),
	  ('-')
GO
INSERT INTO [LocalATM].[dbo].[Operations] ([OutID],[InId],[Amount])
VALUES 
	  ('0000000000000000','1111111111111111', 1255.67)
	, ('0000000000000000','2222222222222221', 100.00)
	, ('0000000000000000','3333333333333331', 1000.00)
	, ('1111111111111111','1111111111111112', 10.55)
	, ('1111111111111111','1111111111111113', 1000.00)
	, ('1111111111111111','2222222222222222', 33.00)
GO
INSERT INTO [LocalATM].[dbo].[OperationsDetails] ([OperationId],[CardID],[Amount],[OperationType],[Balance])
VALUES 
	  (1, '1111111111111111', 1255.67, 1,1255.67)
	, (1, '0000000000000000', 1255.67, 2, -1255.67)
	, (2, '2222222222222221', 100.00, 1, 100.00)
	, (2, '0000000000000000', 100.00, 2, -1355.67)
	, (3, '3333333333333331', 1000.00, 1, 1000.00)
	, (3, '0000000000000000', 1000.00, 2, -2355.67)
	, (4, '1111111111111112', 10.55, 1, 10.55)
	, (4, '1111111111111111', 10.55, 2, 1245.12)
	, (5, '1111111111111113', 1000.00, 1, 1000.00)
	, (5, '1111111111111111', 1000.00, 2, 245.12)
	, (6, '2222222222222222', 33.00, 1, 33.00)
	, (6, '1111111111111111', 33.00, 2, 212.12)

GO

-- Update ballance
;with cteIn as 
(
	select InId as cardNo, debet = sum(Amount)
	from Operations
	group by InId
)
, cteOut as 
(
	select OutID as cardNo, kredit = sum(Amount)
	from Operations
	group by OutID
)
, cteBallance as
(
	select c.CardID, newBallance = isnull(debet, 0) - isnull(kredit, 0)
	from Card c
		left join cteIn i on c.CardID = i.cardNo
		left join cteOut o on c.CardID = o.cardNo
)
update Card
set Ballance = newBallance
from Card inner join cteBallance on Card.CardID = cteBallance.CardID
GO