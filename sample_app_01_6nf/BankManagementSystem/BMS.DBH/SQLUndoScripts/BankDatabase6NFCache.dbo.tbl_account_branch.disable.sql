IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_account_branch]')) 
   ALTER TABLE [dbo].[tbl_account_branch] 
   DISABLE  CHANGE_TRACKING
GO
