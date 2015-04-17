create database eSupervisor
go
USE [eSupervisor]
GO
/****** Object: Table [dbo].[interactionType] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[interactionType](
[id] [int] IDENTITY(1,1) NOT NULL,
[name] [varchar](50) NULL,
CONSTRAINT [PK_interactionType] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[interactionType] ON
SET IDENTITY_INSERT [dbo].[interactionType] OFF
/****** Object: Table [dbo].[role] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[role](
[id] [int] IDENTITY(1,1) NOT NULL,
[name] [varchar](20) NULL,
CONSTRAINT [PK_staffRole] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[role] ON
INSERT [dbo].[role] ([id], [name]) VALUES (1, N'Authorised Staff')
INSERT [dbo].[role] ([id], [name]) VALUES (2, N'Teacher')
INSERT [dbo].[role] ([id], [name]) VALUES (3, N'Student')
SET IDENTITY_INSERT [dbo].[role] OFF
/****** Object: Table [dbo].[project] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[project](
[id] [int] IDENTITY(1,1) NOT NULL,
[name] [varchar](50) NULL,
[description] [nvarchar](100) NULL,
[startDate] [datetime] NULL,
[endDate] [datetime] NULL,
CONSTRAINT [PK_project] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object: Table [dbo].[user] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
[id] [int] IDENTITY(1,1) NOT NULL,
[firstName] [nvarchar](30) NULL,
[lastName] [nvarchar](30) NULL,
[dob] [date] NULL,
[email] [varchar](100) NULL,
[roleID] [int] NULL,
[loginCode] [char](10) NULL,
[loginPass] [varchar](30) NULL,
CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON
SET IDENTITY_INSERT [dbo].[user] OFF
/****** Object: Table [dbo].[post] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post](
[id] [int] IDENTITY(1,1) NOT NULL,
[authorID] [int] NULL,
[title] [nvarchar](100) NULL,
[_content] [text] NULL,
[postTime] [datetime] NULL,
[updateTime] [datetime] NULL,
CONSTRAINT [PK_post] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[post] ON
SET IDENTITY_INSERT [dbo].[post] OFF
/****** Object: Table [dbo].[message] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[message](
[id] [int] IDENTITY(1,1) NOT NULL,
[senderID] [int] NULL,
[receiverID] [int] NULL,
[_content] [nvarchar](500) NULL,
[time] [datetime] NULL,
CONSTRAINT [PK_message] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[message] ON
SET IDENTITY_INSERT [dbo].[message] OFF
/****** Object: Table [dbo].[allocation] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[allocation](
[id] [int] IDENTITY(1,1) NOT NULL,
[studentID] [int] NULL,
[supervisorID] [int] NULL,
[secondmarkerID] [int] NULL,
[projectID] [int] NULL,
CONSTRAINT [PK_allocation] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[allocation] ON
SET IDENTITY_INSERT [dbo].[allocation] OFF
/****** Object: Table [dbo].[meeting] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[meeting](
[id] [int] IDENTITY(1,1) NOT NULL,
[time] [datetime] NULL,
[type] [bit] NULL,
[detail] [nvarchar](200) NULL,
[createDate] [datetime] NULL,
[supervisorID] [int] NULL,
CONSTRAINT [PK_meeting] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 real 1 virtual' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'meeting', @level2type=N'COLUMN',@level2name=N'type'
GO
SET IDENTITY_INSERT [dbo].[meeting] ON
SET IDENTITY_INSERT [dbo].[meeting] OFF
/****** Object: Table [dbo].[interaction] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[interaction](
[id] [int] IDENTITY(1,1) NOT NULL,
[studentID] [int] NULL,
[interactionTypeID] [int] NULL,
[time] [datetime] NULL,
CONSTRAINT [PK_interaction] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[interaction] ON
SET IDENTITY_INSERT [dbo].[interaction] OFF
/****** Object: Table [dbo].[fileUpload] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fileUpload](
[id] [int] IDENTITY(1,1) NOT NULL,
[fileUri] [varchar](200) NULL,
[postID] [int] NULL,
CONSTRAINT [PK_fileUpload] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object: Table [dbo].[comment] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
[id] [int] IDENTITY(1,1) NOT NULL,
[commenterID] [int] NULL,
[time] [datetime] NULL,
[_content] [text] NULL,
[postID] [int] NULL,
CONSTRAINT [PK_comment] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object: Table [dbo].[meetingArrangement] Script Date: 04/17/2015 01:29:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[meetingArrangement](
[id] [int] IDENTITY(1,1) NOT NULL,
[meetingID] [int] NULL,
[studentID] [int] NULL,
CONSTRAINT [PK_meetingArrangement] PRIMARY KEY CLUSTERED 
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[meetingArrangement] ON
SET IDENTITY_INSERT [dbo].[meetingArrangement] OFF
/****** Object: Default [DF_meeting_type] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[meeting] ADD CONSTRAINT [DF_meeting_type] DEFAULT ((0)) FOR [type]
GO
/****** Object: Default [DF_message_time] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[message] ADD CONSTRAINT [DF_message_time] DEFAULT (getdate()) FOR [time]
GO
/****** Object: Default [DF_post_postTime] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[post] ADD CONSTRAINT [DF_post_postTime] DEFAULT (getdate()) FOR [postTime]
GO
/****** Object: Default [DF_post_updateTime] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[post] ADD CONSTRAINT [DF_post_updateTime] DEFAULT (getdate()) FOR [updateTime]
GO
/****** Object: ForeignKey [FK_allocation_project] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[allocation] WITH CHECK ADD CONSTRAINT [FK_allocation_project] FOREIGN KEY([projectID])
REFERENCES [dbo].[project] ([id])
GO
ALTER TABLE [dbo].[allocation] CHECK CONSTRAINT [FK_allocation_project]
GO
/****** Object: ForeignKey [FK_allocation_user_secondmarker] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[allocation] WITH CHECK ADD CONSTRAINT [FK_allocation_user_secondmarker] FOREIGN KEY([secondmarkerID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[allocation] CHECK CONSTRAINT [FK_allocation_user_secondmarker]
GO
/****** Object: ForeignKey [FK_allocation_user_student] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[allocation] WITH CHECK ADD CONSTRAINT [FK_allocation_user_student] FOREIGN KEY([studentID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[allocation] CHECK CONSTRAINT [FK_allocation_user_student]
GO
/****** Object: ForeignKey [FK_allocation_user_supervisor] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[allocation] WITH CHECK ADD CONSTRAINT [FK_allocation_user_supervisor] FOREIGN KEY([supervisorID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[allocation] CHECK CONSTRAINT [FK_allocation_user_supervisor]
GO
/****** Object: ForeignKey [FK_comment_post2] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[comment] WITH CHECK ADD CONSTRAINT [FK_comment_post2] FOREIGN KEY([postID])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comment_post2]
GO
/****** Object: ForeignKey [FK_comment_user] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[comment] WITH CHECK ADD CONSTRAINT [FK_comment_user] FOREIGN KEY([commenterID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comment_user]
GO
/****** Object: ForeignKey [FK_fileUpload_post] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[fileUpload] WITH CHECK ADD CONSTRAINT [FK_fileUpload_post] FOREIGN KEY([postID])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[fileUpload] CHECK CONSTRAINT [FK_fileUpload_post]
GO
/****** Object: ForeignKey [FK_interaction_interactionType] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[interaction] WITH CHECK ADD CONSTRAINT [FK_interaction_interactionType] FOREIGN KEY([interactionTypeID])
REFERENCES [dbo].[interactionType] ([id])
GO
ALTER TABLE [dbo].[interaction] CHECK CONSTRAINT [FK_interaction_interactionType]
GO
/****** Object: ForeignKey [FK_interaction_user_student] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[interaction] WITH CHECK ADD CONSTRAINT [FK_interaction_user_student] FOREIGN KEY([studentID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[interaction] CHECK CONSTRAINT [FK_interaction_user_student]
GO
/****** Object: ForeignKey [FK_meeting_user] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[meeting] WITH CHECK ADD CONSTRAINT [FK_meeting_user] FOREIGN KEY([supervisorID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[meeting] CHECK CONSTRAINT [FK_meeting_user]
GO
/****** Object: ForeignKey [FK_meetingArrangement_meeting] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[meetingArrangement] WITH CHECK ADD CONSTRAINT [FK_meetingArrangement_meeting] FOREIGN KEY([meetingID])
REFERENCES [dbo].[meeting] ([id])
GO
ALTER TABLE [dbo].[meetingArrangement] CHECK CONSTRAINT [FK_meetingArrangement_meeting]
GO
/****** Object: ForeignKey [FK_meetingArrangement_user] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[meetingArrangement] WITH CHECK ADD CONSTRAINT [FK_meetingArrangement_user] FOREIGN KEY([studentID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[meetingArrangement] CHECK CONSTRAINT [FK_meetingArrangement_user]
GO
/****** Object: ForeignKey [FK_message_receiver] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[message] WITH CHECK ADD CONSTRAINT [FK_message_receiver] FOREIGN KEY([receiverID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[message] CHECK CONSTRAINT [FK_message_receiver]
GO
/****** Object: ForeignKey [FK_message_sender] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[message] WITH CHECK ADD CONSTRAINT [FK_message_sender] FOREIGN KEY([senderID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[message] CHECK CONSTRAINT [FK_message_sender]
GO
/****** Object: ForeignKey [FK_post_user] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[post] WITH CHECK ADD CONSTRAINT [FK_post_user] FOREIGN KEY([authorID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [FK_post_user]
GO
/****** Object: ForeignKey [FK_user_role] Script Date: 04/17/2015 01:29:26 ******/
ALTER TABLE [dbo].[user] WITH CHECK ADD CONSTRAINT [FK_user_role] FOREIGN KEY([roleID])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO