USE [SuperheroesDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Superhero_Power](
	[Id] [int] NOT NULL,
	[Superhero_Id] [int] NOT NULL,
	[Power_Id] [int] NOT NULL,
 CONSTRAINT [PK_Superhero_Power] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Superhero_Power]  WITH CHECK ADD  CONSTRAINT [FK_Superhero_Power_Power] FOREIGN KEY([Power_Id])
REFERENCES [dbo].[Power] ([Id])
GO

ALTER TABLE [dbo].[Superhero_Power] CHECK CONSTRAINT [FK_Superhero_Power_Power]
GO

ALTER TABLE [dbo].[Superhero_Power]  WITH CHECK ADD  CONSTRAINT [FK_Superhero_Power_Superhero] FOREIGN KEY([Superhero_Id])
REFERENCES [dbo].[Superhero] ([Id])
GO

ALTER TABLE [dbo].[Superhero_Power] CHECK CONSTRAINT [FK_Superhero_Power_Superhero]
GO


