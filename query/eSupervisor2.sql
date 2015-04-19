create eSupervisor
go
USE [eSupervisor]
GO
/****** Object: Table [dbo].[interactionType] Script Date: 04/18/2015 18:10:57 ******/
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
INSERT [dbo].[interactionType] ([id], [name]) VALUES (1, N'Send Message')
INSERT [dbo].[interactionType] ([id], [name]) VALUES (2, N'Create Post')
INSERT [dbo].[interactionType] ([id], [name]) VALUES (3, N'Update Post')
INSERT [dbo].[interactionType] ([id], [name]) VALUES (4, N'Upload File')
INSERT [dbo].[interactionType] ([id], [name]) VALUES (5, N'Comment')
SET IDENTITY_INSERT [dbo].[interactionType] OFF
/****** Object: Table [dbo].[role] Script Date: 04/18/2015 18:10:57 ******/
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
/****** Object: Table [dbo].[project] Script Date: 04/18/2015 18:10:57 ******/
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
/****** Object: Table [dbo].[user] Script Date: 04/18/2015 18:10:57 ******/
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
INSERT [dbo].[user] ([id], [firstName], [lastName], [dob], [email], [roleID], [loginCode], [loginPass]) VALUES (1, N'u1FName', N'u1LName', NULL, NULL, 3, N'aaa ', N'123')
INSERT [dbo].[user] ([id], [firstName], [lastName], [dob], [email], [roleID], [loginCode], [loginPass]) VALUES (2, N'u2FName', N'u2LName', NULL, NULL, 3, N'bbb ', N'123')
INSERT [dbo].[user] ([id], [firstName], [lastName], [dob], [email], [roleID], [loginCode], [loginPass]) VALUES (3, N'u3FName', N'u3LName', NULL, NULL, 2, N'ccc ', N'123')
INSERT [dbo].[user] ([id], [firstName], [lastName], [dob], [email], [roleID], [loginCode], [loginPass]) VALUES (4, N'Staff 1 FName', N'Staff 1 LName', NULL, NULL, 1, N'ddd ', N'123')
INSERT [dbo].[user] ([id], [firstName], [lastName], [dob], [email], [roleID], [loginCode], [loginPass]) VALUES (5, N'u5 FName', N'u5 LName', NULL, NULL, 2, N'eee ', N'123')
INSERT [dbo].[user] ([id], [firstName], [lastName], [dob], [email], [roleID], [loginCode], [loginPass]) VALUES (6, N'student', N'student', NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[user] ([id], [firstName], [lastName], [dob], [email], [roleID], [loginCode], [loginPass]) VALUES (7, N'student not allocate', N'student', NULL, NULL, 3, N'123 ', N'123')
SET IDENTITY_INSERT [dbo].[user] OFF
/****** Object: Table [dbo].[post] Script Date: 04/18/2015 18:10:57 ******/
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
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (8, 1, N'Post 1', N'gsdfgfdsafaweieq029fm3q290 2049382q 0943uq28u3q 08dh0a89 h0fh0asudfhasuidf 283u 0892fasdfa', CAST(0x0000A47D01183484 AS DateTime), CAST(0x0000A47D01183484 AS DateTime))
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (9, 1, N'fewfe23232', N'<h1><span style="font-family: ''comic sans ms'', sans-serif; font-size: xx-large;">fjsdioafjdiopjfawio f0jq0293 fq2j pasfijaio</span></h1>
<h1><span>fjsdioafjdiopjfawio f0jq0293 fq2j pasfijaio</span></h1>
<h1><span>fjsdioafjdiopjfawio f0jq0293 fq2j pasfijaio</span></h1>
<h1><!-- pagebreak --></h1>
<p><span><br /></span></p>
<p><span><br /></span></p>
<p><span style="font-family: ''comic sans ms'', sans-serif; font-size: xx-large;">feawfeawfeawfaweefadddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd</span></p>', CAST(0x0000A47D012BF659 AS DateTime), CAST(0x0000A47D012BF659 AS DateTime))
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (17, 1, N'This is my post', NULL, CAST(0x0000A47D0146E9EB AS DateTime), CAST(0x0000A47D0146E9EB AS DateTime))
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (18, 1, N'This is a new post', N'<p>Hello I want to tell you about something very special</p>', CAST(0x0000A47E00A77328 AS DateTime), CAST(0x0000A47E00A77328 AS DateTime))
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (19, 1, N'This is the post', N'<p>43242fsfssfs</p>', CAST(0x0000A47E00A91CA3 AS DateTime), CAST(0x0000A47E00A91CA3 AS DateTime))
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (20, 1, N'234234', N'<p>-09-09-09</p>', CAST(0x0000A47E00A96D4F AS DateTime), CAST(0x0000A47E00A96D4F AS DateTime))
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (21, 1, N' fasasfasfas', N'<p>3r2432</p>', CAST(0x0000A47E00AA001A AS DateTime), CAST(0x0000A47E00AA0101 AS DateTime))
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (22, 1, N'Post 1 bai` moi'' cho vui', N'<p>Hehe</p>', CAST(0x0000A47E0103458E AS DateTime), CAST(0x0000A47E0103458E AS DateTime))
INSERT [dbo].[post] ([id], [authorID], [title], [_content], [postTime], [updateTime]) VALUES (23, 1, N'Up 1 cai'' file cho vui', NULL, CAST(0x0000A47E010355A2 AS DateTime), CAST(0x0000A47E010355A2 AS DateTime))
SET IDENTITY_INSERT [dbo].[post] OFF
/****** Object: Table [dbo].[message] Script Date: 04/18/2015 18:10:57 ******/
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
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (1, 1, 2, N'a b gui cho c d', CAST(0x0000A4660083D600 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (2, 2, 1, N'c d gui cho a b', CAST(0x0000A466009450C0 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (3, 1, 2, N'a b gui cho c d ver 1', CAST(0x0000A46600A4CB80 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (4, 1, 2, N'a b gui cho c d ver 1', CAST(0x0000A46600A4CB80 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (5, 1, 2, N'a b gui cho c d ver 1', CAST(0x0000A46600A4CB80 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (7, 1, 2, N'a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10a b gui cho c d ver 10', CAST(0x0000A46600A4CB80 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (8, 2, 1, N'c d gui cho a ', CAST(0x0000A466009450C0 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (19, 2, 1, N'c d gui cho a b', CAST(0x0000A466009450C0 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (21, 1, 2, N'a b gui cho c d', CAST(0x0000A4660083D600 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (25, 1, 2, N'gui nua ne con', CAST(0x0000A46E0127809C AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (26, 1, 2, N'1 gui cho 2 tao gui cho may` ne`', CAST(0x0000A46E0128A5DF AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (27, 2, 1, N'2 gui lai cho 1 uh tao cung gui cho may ne`', CAST(0x0000A46E0128B660 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (28, 2, 1, N'fdasdfas', CAST(0x0000A46F00A97AE4 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (29, 2, 1, N'fdasfdas', CAST(0x0000A46F00AAB13A AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (32, 1, 2, N'sdfasdfa', CAST(0x0000A47000FCA30A AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (33, 1, 2, N'fack', CAST(0x0000A47000FCAA65 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (34, 2, 2, N'fdasdfa', CAST(0x0000A47000FD3028 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (36, 2, 2, N'fdasfdasfa', CAST(0x0000A47000FF080C AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (37, 2, 2, N'hello ban', CAST(0x0000A47001006694 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (38, 2, 2, N'hello again', CAST(0x0000A470010080B7 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (39, 2, 2, N'ew22323', CAST(0x0000A4700100E513 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (40, 2, 2, N'fsaf dsaf32 helllooo', CAST(0x0000A47001010D57 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (42, 2, 2, N'ghehehefdsafd fwaefa 1232', CAST(0x0000A470010171CA AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (43, 2, 2, N'hello how r u', CAST(0x0000A47001062D29 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (44, 1, 2, N'i''m fine', CAST(0x0000A47001063219 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (45, 2, 2, N'foeiawjoifea', CAST(0x0000A47001064995 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (46, 1, 2, N'1213 ok hello', CAST(0x0000A470010650F8 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (47, 2, 2, N'''', CAST(0x0000A47001067EDA AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (48, 1, 2, N'dgdfffgd', CAST(0x0000A4700106B3D4 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (49, 2, 2, N'cxzcxz', CAST(0x0000A4700106B9C7 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (50, 1, 2, N'vler cho may luon', CAST(0x0000A47901175C47 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (51, 1, 2, N'qua vai', CAST(0x0000A479011764CE AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (52, 1, 2, N'tu ki vkler ((:', CAST(0x0000A47901177392 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (53, 1, 2, N'dgdfffgd', CAST(0x0000A4750106B3D4 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (54, 1, 2, N'hi how are you?', CAST(0x0000A47B0023EBB8 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (55, 1, 2, N'hahaha', CAST(0x0000A47B0026DE2B AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (56, 1, 3, N'hihi', CAST(0x0000A47B0026E794 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (57, 1, 2, N'ehehe', CAST(0x0000A47B0027339C AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (58, 1, 3, N'hello sao roi` em yeu', CAST(0x0000A47B00273F16 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (59, 1, 3, N'van khoe chu'' ha', CAST(0x0000A47B002745CC AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (60, 1, 2, N'vi du gui tiep', CAST(0x0000A47B00286733 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (61, 1, 3, N'tao gui cho may` 1 phat'' nhe`', CAST(0x0000A47B0028C238 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (62, 1, 2, N'aaa', CAST(0x0000A47B002AE172 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (63, 1, 2, N'bbb', CAST(0x0000A47B002AE70C AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (64, 1, 2, N'ggg', CAST(0x0000A47B002B64B7 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (65, 1, 2, N'nn', CAST(0x0000A47B002B93ED AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (66, 1, 2, N'jojo', CAST(0x0000A47B002BC86D AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (67, 1, 2, N'jijoi', CAST(0x0000A47B002C0801 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (68, 1, 2, N'j9090j90', CAST(0x0000A47B002C0C94 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (69, 1, 2, N'p-0i-0i-0i', CAST(0x0000A47B002C11A6 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (70, 1, 2, N'89888', CAST(0x0000A47B002C5A24 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (71, 1, 2, N'fdasfdas', CAST(0x0000A47B002D573E AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (72, 1, 2, N'21312', CAST(0x0000A47B002EDC94 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (73, 1, 2, N'e2342432', CAST(0x0000A47B002F8518 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (74, 2, 1, N'may la cai'' do` dien', CAST(0x0000A47B0033628A AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (75, 2, 1, N'ngu qua''', CAST(0x0000A47B00337212 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (76, 2, 3, N'may qua'' ngu ', CAST(0x0000A47B00337984 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (77, 1, 2, N'vcxzvczxvczxvzx', CAST(0x0000A47B00A00B2E AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (78, 1, 3, N'vcxzvczxvczxvzx32131d', CAST(0x0000A47B00A00FE5 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (79, 1, 5, N'dfwafa', CAST(0x0000A47C009A7A03 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (80, 1, 3, N'gegrege', CAST(0x0000A47C009A859D AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (84, 1, 3, N'send cai'' choi', CAST(0x0000A47E010321F4 AS DateTime))
INSERT [dbo].[message] ([id], [senderID], [receiverID], [_content], [time]) VALUES (85, 1, 5, N'send cai'' choi cho vui', CAST(0x0000A47E010329AA AS DateTime))
SET IDENTITY_INSERT [dbo].[message] OFF
/****** Object: Table [dbo].[allocation] Script Date: 04/18/2015 18:10:57 ******/
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
INSERT [dbo].[allocation] ([id], [studentID], [supervisorID], [secondmarkerID], [projectID]) VALUES (12, 1, 5, 3, NULL)
INSERT [dbo].[allocation] ([id], [studentID], [supervisorID], [secondmarkerID], [projectID]) VALUES (13, 2, 3, 5, NULL)
INSERT [dbo].[allocation] ([id], [studentID], [supervisorID], [secondmarkerID], [projectID]) VALUES (14, 6, 3, 5, NULL)
INSERT [dbo].[allocation] ([id], [studentID], [supervisorID], [secondmarkerID], [projectID]) VALUES (15, 7, 3, 5, NULL)
SET IDENTITY_INSERT [dbo].[allocation] OFF
/****** Object: Table [dbo].[meeting] Script Date: 04/18/2015 18:10:57 ******/
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
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (11, CAST(0x0000A47400000000 AS DateTime), 0, N'fasfawfwfw', CAST(0x0000A47D00140E3C AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (12, CAST(0x0000A46D00000000 AS DateTime), 1, N'2342sgg3g', CAST(0x0000A47D00158565 AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (13, CAST(0x0000A47E00000000 AS DateTime), 0, N'4552k,t,t', CAST(0x0000A47D00159187 AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (14, CAST(0x0000A47300000000 AS DateTime), 1, N'3hgdfhdfhđ gsd gsd', CAST(0x0000A47D00171CD4 AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (15, CAST(0x0000A47400000000 AS DateTime), 0, N'431243124dfasfas', CAST(0x0000A47D009F288D AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (16, CAST(0x0000A47900000000 AS DateTime), 1, N'432432432432432', CAST(0x0000A47D00A29171 AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (17, CAST(0x0000A47A00000000 AS DateTime), 1, N'3333333', CAST(0x0000A47D00A327FA AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (18, CAST(0x0000A46D00000000 AS DateTime), NULL, N'0000', CAST(0x0000A47D00A4096B AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (19, CAST(0x0000A47B00000000 AS DateTime), 1, N'0000', CAST(0x0000A47D00A424F4 AS DateTime), 3)
INSERT [dbo].[meeting] ([id], [time], [type], [detail], [createDate], [supervisorID]) VALUES (20, CAST(0x0000A47900000000 AS DateTime), 0, N'90909090', CAST(0x0000A47D00A480E2 AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[meeting] OFF
/****** Object: Table [dbo].[interaction] Script Date: 04/18/2015 18:10:57 ******/
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
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (1, 1, 1, CAST(0x0000A45A00000000 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (2, 1, 1, CAST(0x0000A47100000000 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (3, 2, 1, CAST(0x0000A30300000000 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (11, 1, 1, CAST(0x0000A47B0028C238 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (12, 1, 1, CAST(0x0000A47B002AE172 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (13, 1, 1, CAST(0x0000A47B002AE70C AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (14, 1, 1, CAST(0x0000A47B002B64B7 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (15, 1, 1, CAST(0x0000A47B002B93EE AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (16, 1, 1, CAST(0x0000A47B002BC86D AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (17, 1, 1, CAST(0x0000A47B002C0801 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (18, 1, 1, CAST(0x0000A47B002C0C94 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (19, 1, 1, CAST(0x0000A47B002C11A6 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (20, 1, 1, CAST(0x0000A47B002C5A24 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (21, 1, 1, CAST(0x0000A47B002D573E AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (22, 1, 1, CAST(0x0000A47B002EDC94 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (23, 1, 1, CAST(0x0000A47B002F8518 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (24, 1, 1, CAST(0x0000A47B00A00B2F AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (25, 1, 1, CAST(0x0000A47B00A00FE5 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (26, 1, 1, CAST(0x0000A47C009A7A03 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (27, 1, 1, CAST(0x0000A47C009A859D AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (28, 1, 2, CAST(0x0000A47E00AA067B AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (29, 1, 5, CAST(0x0000A47E010308C2 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (30, 1, 1, CAST(0x0000A47E010321F4 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (31, 1, 1, CAST(0x0000A47E010329AA AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (32, 1, 2, CAST(0x0000A47E01034594 AS DateTime))
INSERT [dbo].[interaction] ([id], [studentID], [interactionTypeID], [time]) VALUES (33, 1, 4, CAST(0x0000A47E010355A5 AS DateTime))
SET IDENTITY_INSERT [dbo].[interaction] OFF
/****** Object: Table [dbo].[fileUpload] Script Date: 04/18/2015 18:10:57 ******/
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
SET IDENTITY_INSERT [dbo].[fileUpload] ON
INSERT [dbo].[fileUpload] ([id], [fileUri], [postID]) VALUES (12, N'E:\AAA_GREENWICH\FINAL YEAR\EWSD\eSupervisor\eSupervisor_Project\eSupervisor_Beta\Document\Files\Report.pdf', 23)
SET IDENTITY_INSERT [dbo].[fileUpload] OFF
/****** Object: Table [dbo].[comment] Script Date: 04/18/2015 18:10:57 ******/
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
SET IDENTITY_INSERT [dbo].[comment] ON
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (9, 1, CAST(0x0000A47D01275905 AS DateTime), N'comment 6', 8)
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (10, 1, CAST(0x0000A47D0127C12E AS DateTime), N'comment 7', 8)
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (11, 1, CAST(0x0000A47D0127E69C AS DateTime), N'comment 8', 8)
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (12, 1, CAST(0x0000A47D0127EF2A AS DateTime), N'a'' du` comment dc luon, vai~', 8)
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (13, 1, CAST(0x0000A47D0127F4D3 AS DateTime), N'qua'' ngon haha', 8)
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (14, 1, CAST(0x0000A47D012D930C AS DateTime), N'tai sao eo'' hien', 9)
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (15, 1, CAST(0x0000A47D012D9B1D AS DateTime), N'fdasfdas.', 9)
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (16, 3, CAST(0x0000A47D012FF10F AS DateTime), N'comment dc luon la qua'' ngon roi` kaka', 9)
INSERT [dbo].[comment] ([id], [commenterID], [time], [_content], [postID]) VALUES (18, 1, CAST(0x0000A47E010308BE AS DateTime), N'comment cai'' choi', 8)
SET IDENTITY_INSERT [dbo].[comment] OFF
/****** Object: Table [dbo].[meetingArrangement] Script Date: 04/18/2015 18:10:57 ******/
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
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (4, 11, 1)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (5, 11, 2)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (6, 11, 6)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (7, 12, 1)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (8, 12, 2)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (9, 13, 1)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (10, 13, 2)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (11, 13, 6)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (12, 14, 6)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (13, 15, 2)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (14, 16, 1)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (15, 16, 2)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (16, 17, 1)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (17, 17, 2)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (18, 18, 1)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (19, 19, 2)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (20, 20, 1)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (21, 20, 2)
INSERT [dbo].[meetingArrangement] ([id], [meetingID], [studentID]) VALUES (22, 20, 6)
SET IDENTITY_INSERT [dbo].[meetingArrangement] OFF
/****** Object: Default [DF_meeting_type] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[meeting] ADD CONSTRAINT [DF_meeting_type] DEFAULT ((0)) FOR [type]
GO
/****** Object: Default [DF_message_time] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[message] ADD CONSTRAINT [DF_message_time] DEFAULT (getdate()) FOR [time]
GO
/****** Object: Default [DF_post_postTime] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[post] ADD CONSTRAINT [DF_post_postTime] DEFAULT (getdate()) FOR [postTime]
GO
/****** Object: Default [DF_post_updateTime] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[post] ADD CONSTRAINT [DF_post_updateTime] DEFAULT (getdate()) FOR [updateTime]
GO
/****** Object: ForeignKey [FK_allocation_project] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[allocation] WITH CHECK ADD CONSTRAINT [FK_allocation_project] FOREIGN KEY([projectID])
REFERENCES [dbo].[project] ([id])
GO
ALTER TABLE [dbo].[allocation] CHECK CONSTRAINT [FK_allocation_project]
GO
/****** Object: ForeignKey [FK_allocation_user_secondmarker] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[allocation] WITH CHECK ADD CONSTRAINT [FK_allocation_user_secondmarker] FOREIGN KEY([secondmarkerID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[allocation] CHECK CONSTRAINT [FK_allocation_user_secondmarker]
GO
/****** Object: ForeignKey [FK_allocation_user_student] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[allocation] WITH CHECK ADD CONSTRAINT [FK_allocation_user_student] FOREIGN KEY([studentID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[allocation] CHECK CONSTRAINT [FK_allocation_user_student]
GO
/****** Object: ForeignKey [FK_allocation_user_supervisor] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[allocation] WITH CHECK ADD CONSTRAINT [FK_allocation_user_supervisor] FOREIGN KEY([supervisorID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[allocation] CHECK CONSTRAINT [FK_allocation_user_supervisor]
GO
/****** Object: ForeignKey [FK_comment_post2] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[comment] WITH CHECK ADD CONSTRAINT [FK_comment_post2] FOREIGN KEY([postID])
REFERENCES [dbo].[post] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comment_post2]
GO
/****** Object: ForeignKey [FK_comment_user] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[comment] WITH CHECK ADD CONSTRAINT [FK_comment_user] FOREIGN KEY([commenterID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_comment_user]
GO
/****** Object: ForeignKey [FK_fileUpload_post] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[fileUpload] WITH CHECK ADD CONSTRAINT [FK_fileUpload_post] FOREIGN KEY([postID])
REFERENCES [dbo].[post] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[fileUpload] CHECK CONSTRAINT [FK_fileUpload_post]
GO
/****** Object: ForeignKey [FK_interaction_interactionType] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[interaction] WITH CHECK ADD CONSTRAINT [FK_interaction_interactionType] FOREIGN KEY([interactionTypeID])
REFERENCES [dbo].[interactionType] ([id])
GO
ALTER TABLE [dbo].[interaction] CHECK CONSTRAINT [FK_interaction_interactionType]
GO
/****** Object: ForeignKey [FK_interaction_user_student] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[interaction] WITH CHECK ADD CONSTRAINT [FK_interaction_user_student] FOREIGN KEY([studentID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[interaction] CHECK CONSTRAINT [FK_interaction_user_student]
GO
/****** Object: ForeignKey [FK_meeting_user] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[meeting] WITH CHECK ADD CONSTRAINT [FK_meeting_user] FOREIGN KEY([supervisorID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[meeting] CHECK CONSTRAINT [FK_meeting_user]
GO
/****** Object: ForeignKey [FK_meetingArrangement_meeting] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[meetingArrangement] WITH CHECK ADD CONSTRAINT [FK_meetingArrangement_meeting] FOREIGN KEY([meetingID])
REFERENCES [dbo].[meeting] ([id])
GO
ALTER TABLE [dbo].[meetingArrangement] CHECK CONSTRAINT [FK_meetingArrangement_meeting]
GO
/****** Object: ForeignKey [FK_meetingArrangement_user] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[meetingArrangement] WITH CHECK ADD CONSTRAINT [FK_meetingArrangement_user] FOREIGN KEY([studentID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[meetingArrangement] CHECK CONSTRAINT [FK_meetingArrangement_user]
GO
/****** Object: ForeignKey [FK_message_receiver] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[message] WITH CHECK ADD CONSTRAINT [FK_message_receiver] FOREIGN KEY([receiverID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[message] CHECK CONSTRAINT [FK_message_receiver]
GO
/****** Object: ForeignKey [FK_message_sender] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[message] WITH CHECK ADD CONSTRAINT [FK_message_sender] FOREIGN KEY([senderID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[message] CHECK CONSTRAINT [FK_message_sender]
GO
/****** Object: ForeignKey [FK_post_user] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[post] WITH CHECK ADD CONSTRAINT [FK_post_user] FOREIGN KEY([authorID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [FK_post_user]
GO
/****** Object: ForeignKey [FK_user_role] Script Date: 04/18/2015 18:10:57 ******/
ALTER TABLE [dbo].[user] WITH CHECK ADD CONSTRAINT [FK_user_role] FOREIGN KEY([roleID])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO