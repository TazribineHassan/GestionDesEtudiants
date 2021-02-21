/*==============================================================*/
/* Nom de SGBD :  Microsoft SQL Server 2008                     */
/* Date de création :  14/01/2021 16:46:15                      */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('STUDENT')
            and   type = 'U')
   drop table STUDENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FILIERE')
            and   type = 'U')
   drop table FILIERE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USERS')
            and   type = 'U')
   drop table USERS
go

/*==============================================================*/
/* Table : FILIERE                                              */
/*==============================================================*/
create table FILIERE (
   IDFILIERE            int          IDENTITY(1,1)        not null,
   NOMFILIERE           text                 null,
   constraint PK_FILIERE primary key nonclustered (IDFILIERE)
)
go

/*==============================================================*/
/* Table : STUDENT                                              */
/*==============================================================*/
create table STUDENT (
   IDETUDIANT           int           IDENTITY(1,1)       not null,
   IDFILIERE            int                  not null,
   CNE                  text                 not null,
   NOM                  text                 null,
   PRENOM               text                 null,
   SEX                  text                 null,
   DATENAISSANCE        datetime             null,
   ADRESSE              text                 null,
   TELEPHONE            text                 null,
   constraint PK_STUDENT primary key nonclustered (IDETUDIANT),
   CONSTRAINT FK_FILIERE_STUDENT FOREIGN KEY (IDFILIERE)
        REFERENCES FILIERE (IDFILIERE)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
go

/*==============================================================*/
/* Table : USERS                                                */
/*==============================================================*/
create table [dbo].[USERS](
	[IdUser] [int] IDENTITY(1,1) not null,
	[USERNAME] [nchar](30) not null,
	[PASSWORD] [nchar](30) not null
)
go


INSERT INTO [dbo].[USERS]
           ([USERNAME]
           ,[PASSWORD])
     VALUES
           ('admin'
           ,'admin')
go

