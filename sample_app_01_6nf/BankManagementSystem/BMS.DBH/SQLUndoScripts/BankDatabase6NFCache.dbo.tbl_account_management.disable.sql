IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_account_management]')) 
   ALTER TABLE [dbo].[tbl_account_management] 
   DISABLE  CHANGE_TRACKING
GO
