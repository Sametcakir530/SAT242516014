create table dbo.Logs
(
    Id        int identity
        primary key,
    Timestamp datetime,
    Level     nvarchar(50),
    Category  nvarchar(200),
    Message   nvarchar(max),
    Exception nvarchar(max)
)
go

 