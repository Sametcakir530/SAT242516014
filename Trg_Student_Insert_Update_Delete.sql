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


create or alter trigger Trg_Student_Insert_Update_Delete
    on Student
    after insert, update, delete
    as
begin

    set nocount on;

    declare @tableName nvarchar(100) = 'Student'
    declare @rowid int =
        (
            select coalesce(i.Id, d.Id, 0)
            from inserted i
                     full join deleted d on i.Id = d.Id
        )

    declare @actiontype varchar(10) =
        (
            select case
                       when i.Id is not null and d.Id is null then 'insert'
                       when i.Id is not null and d.Id is not null then 'update'
                       when i.Id is null and d.Id is not null then 'delete'
                       end
            from inserted i
                     full join deleted d on i.Id = d.Id
        )

    declare @oldvalues nvarchar(max) = (
                                           select *
                                           from deleted
                                           for json path
                                       )
    declare @newvalues nvarchar(max) = (
                                           select *
                                           from inserted
                                           for json path
                                       )

    insert into Logs_Table (TableName, RowId, ActionType, OldValue, NewValue)
    values (@tableName, 
            @rowid, 
            @actiontype,
            @oldvalues, @newvalues)
end
go
 