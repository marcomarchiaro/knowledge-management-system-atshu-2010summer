SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Tag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Tag](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Resource]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Resource](
	[ResourceId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Resource_ResourceId]  DEFAULT (newid()),
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_Resource_1] PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Knowledge]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Knowledge](
	[KnowledgeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Content] [image] NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_Knowledge] PRIMARY KEY CLUSTERED 
(
	[KnowledgeId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KnowledgeClass]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KnowledgeClass](
	[KnowledgeClassId] [int] IDENTITY(1,1) NOT NULL,
	[FatherClassId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_KnowledgeClass] PRIMARY KEY CLUSTERED 
(
	[KnowledgeClassId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KnowledgeTagAssociation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KnowledgeTagAssociation](
	[KnowledgeTagId] [int] IDENTITY(1,1) NOT NULL,
	[KnowledgeId] [int] NULL,
	[TagId] [int] NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_KnowledgeTagAssociation] PRIMARY KEY CLUSTERED 
(
	[KnowledgeTagId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ResourceTagAssociation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_ResourceTagAssociation](
	[ResourceTagId] [int] IDENTITY(1,1) NOT NULL,
	[ResourceId] [uniqueidentifier] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_ResourceTagAssociation] PRIMARY KEY CLUSTERED 
(
	[ResourceTagId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Resource_URL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Resource_URL](
	[ResourceId] [uniqueidentifier] NOT NULL,
	[MIME] [nvarchar](50) NULL,
	[URL] [nvarchar](255) NULL,
	[SourceName] [nvarchar](50) NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
 CONSTRAINT [PK_Resource_URL] PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Resource_Binary]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Resource_Binary](
	[ResourceId] [uniqueidentifier] NOT NULL,
	[MIME] [nvarchar](20) NULL,
	[Binary] [image] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
 CONSTRAINT [PK_T_ResourceBinary] PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KnowledgeKnowledgeClassAssociation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KnowledgeKnowledgeClassAssociation](
	[KKCId] [int] IDENTITY(1,1) NOT NULL,
	[KnowledgeId] [int] NULL,
	[KnowledgeClassId] [int] NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_KnowledgeKnowledgeClassAssociation] PRIMARY KEY CLUSTERED 
(
	[KKCId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KnowledgeClass_KnowledgeClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[KnowledgeClass]'))
ALTER TABLE [dbo].[KnowledgeClass]  WITH CHECK ADD  CONSTRAINT [FK_KnowledgeClass_KnowledgeClass] FOREIGN KEY([FatherClassId])
REFERENCES [dbo].[KnowledgeClass] ([KnowledgeClassId])
GO
ALTER TABLE [dbo].[KnowledgeClass] CHECK CONSTRAINT [FK_KnowledgeClass_KnowledgeClass]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KnowledgeTagAssociation_Knowledge]') AND parent_object_id = OBJECT_ID(N'[dbo].[KnowledgeTagAssociation]'))
ALTER TABLE [dbo].[KnowledgeTagAssociation]  WITH CHECK ADD  CONSTRAINT [FK_KnowledgeTagAssociation_Knowledge] FOREIGN KEY([KnowledgeId])
REFERENCES [dbo].[Knowledge] ([KnowledgeId])
GO
ALTER TABLE [dbo].[KnowledgeTagAssociation] CHECK CONSTRAINT [FK_KnowledgeTagAssociation_Knowledge]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KnowledgeTagAssociation_T_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[KnowledgeTagAssociation]'))
ALTER TABLE [dbo].[KnowledgeTagAssociation]  WITH CHECK ADD  CONSTRAINT [FK_KnowledgeTagAssociation_T_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[T_Tag] ([TagId])
GO
ALTER TABLE [dbo].[KnowledgeTagAssociation] CHECK CONSTRAINT [FK_KnowledgeTagAssociation_T_Tag]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_ResourceTagAssociation_T_Resource]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_ResourceTagAssociation]'))
ALTER TABLE [dbo].[T_ResourceTagAssociation]  WITH CHECK ADD  CONSTRAINT [FK_T_ResourceTagAssociation_T_Resource] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[T_Resource] ([ResourceId])
GO
ALTER TABLE [dbo].[T_ResourceTagAssociation] CHECK CONSTRAINT [FK_T_ResourceTagAssociation_T_Resource]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_ResourceTagAssociation_T_Tag]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_ResourceTagAssociation]'))
ALTER TABLE [dbo].[T_ResourceTagAssociation]  WITH CHECK ADD  CONSTRAINT [FK_T_ResourceTagAssociation_T_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[T_Tag] ([TagId])
GO
ALTER TABLE [dbo].[T_ResourceTagAssociation] CHECK CONSTRAINT [FK_T_ResourceTagAssociation_T_Tag]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Resource_URL_T_Resource]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Resource_URL]'))
ALTER TABLE [dbo].[T_Resource_URL]  WITH CHECK ADD  CONSTRAINT [FK_T_Resource_URL_T_Resource] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[T_Resource] ([ResourceId])
GO
ALTER TABLE [dbo].[T_Resource_URL] CHECK CONSTRAINT [FK_T_Resource_URL_T_Resource]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_T_Resource_Binary_T_Resource]') AND parent_object_id = OBJECT_ID(N'[dbo].[T_Resource_Binary]'))
ALTER TABLE [dbo].[T_Resource_Binary]  WITH CHECK ADD  CONSTRAINT [FK_T_Resource_Binary_T_Resource] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[T_Resource] ([ResourceId])
GO
ALTER TABLE [dbo].[T_Resource_Binary] CHECK CONSTRAINT [FK_T_Resource_Binary_T_Resource]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KnowledgeKnowledgeClassAssociation_Knowledge]') AND parent_object_id = OBJECT_ID(N'[dbo].[KnowledgeKnowledgeClassAssociation]'))
ALTER TABLE [dbo].[KnowledgeKnowledgeClassAssociation]  WITH CHECK ADD  CONSTRAINT [FK_KnowledgeKnowledgeClassAssociation_Knowledge] FOREIGN KEY([KnowledgeId])
REFERENCES [dbo].[Knowledge] ([KnowledgeId])
GO
ALTER TABLE [dbo].[KnowledgeKnowledgeClassAssociation] CHECK CONSTRAINT [FK_KnowledgeKnowledgeClassAssociation_Knowledge]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KnowledgeKnowledgeClassAssociation_KnowledgeClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[KnowledgeKnowledgeClassAssociation]'))
ALTER TABLE [dbo].[KnowledgeKnowledgeClassAssociation]  WITH CHECK ADD  CONSTRAINT [FK_KnowledgeKnowledgeClassAssociation_KnowledgeClass] FOREIGN KEY([KnowledgeClassId])
REFERENCES [dbo].[KnowledgeClass] ([KnowledgeClassId])
GO
ALTER TABLE [dbo].[KnowledgeKnowledgeClassAssociation] CHECK CONSTRAINT [FK_KnowledgeKnowledgeClassAssociation_KnowledgeClass]
