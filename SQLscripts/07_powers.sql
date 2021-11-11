USE [SuperheroesDB]
GO

INSERT INTO [dbo].[Power]
           (Name
           ,Description)
     VALUES
           ( 'Flying'
           , 'Allows hero to fly')
GO

INSERT INTO [dbo].[Power]
           (Name
           ,Description)
     VALUES
           ( 'Climbing'
           , 'Allows hero climb flat walls')
GO

INSERT INTO [dbo].[Power]
           (Name
           ,Description)
     VALUES
           ( 'Shooting net'
           , 'Allows hero to use net')
GO

INSERT INTO [dbo].[Power]
           (Name
           ,Description)
     VALUES
           ( 'Burning ray'
           , 'Allows hero to use burning ray from eyes')
GO

INSERT INTO [dbo].[Superhero_Power]
           (Superhero_Id
           ,Power_Id)
     VALUES
           ( 1
           ,1)
GO

INSERT INTO [dbo].[Superhero_Power]
           (Superhero_Id
           ,Power_Id)
     VALUES
           ( 1
           ,2)
GO

INSERT INTO [dbo].[Superhero_Power]
           (Superhero_Id
           ,Power_Id)
     VALUES
           ( 2
           ,1)
GO

INSERT INTO [dbo].[Superhero_Power]
           (Superhero_Id
           ,Power_Id)
     VALUES
           ( 3
           ,3)
GO

INSERT INTO [dbo].[Superhero_Power]
           (Superhero_Id
           ,Power_Id)
     VALUES
           ( 2
           ,4)
GO
