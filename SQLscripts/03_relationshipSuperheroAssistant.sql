USE [SuperheroesDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE [dbo].[Assistant]  WITH CHECK ADD  CONSTRAINT [FK_Assistant_Superhero] FOREIGN KEY([Superhero_Id])
REFERENCES [dbo].[Superhero] ([Id])
GO

ALTER TABLE [dbo].[Assistant] CHECK CONSTRAINT [FK_Assistant_Superhero]
GO


