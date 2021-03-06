if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PersistentSubscribers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PersistentSubscribers]
GO

CREATE TABLE [dbo].[PersistentSubscribers] (
	[Address] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Operation] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Contract] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ID] [int] IDENTITY (1, 1) NOT NULL 
) ON [PRIMARY]
GO

INSERT INTO PersistentSubscribers (Address,Operation,Contract) Values ('http://localhost:7000/MyPersistentSubscriber1.svc','OnEvent1','IMyEvents')
INSERT INTO PersistentSubscribers (Address,Operation,Contract) Values ('http://localhost:7000/MyPersistentSubscriber2.svc','OnEvent2','IMyEvents')
INSERT INTO PersistentSubscribers (Address,Operation,Contract) Values ('http://localhost:7000/MyPersistentSubscriber3.svc','OnEvent3','IMyEvents')
GO


