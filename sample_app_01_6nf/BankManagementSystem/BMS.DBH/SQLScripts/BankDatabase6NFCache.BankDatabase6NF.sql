IF NOT EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'BankDatabase6NF')) 
   ALTER DATABASE [BankDatabase6NF] 
   SET  CHANGE_TRACKING = ON
GO
