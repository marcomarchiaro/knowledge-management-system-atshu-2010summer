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
	[TimeStamp] [datetime] NOT NULL,
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
