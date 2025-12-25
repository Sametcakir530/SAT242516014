create table dbo.Logs_Table
(
    Id             int identity
        constraint PK_Logs_Table
            primary key,
    TableName      nvarchar(100),
    RowId          sql_variant,
    OldValue       nvarchar(max),
    NewValue       nvarchar(max),
    ActionType     nvarchar(50),
    ActionDateTime datetime
        constraint DF_Logs_Table_ActionDateTime default getdate()
)
go

