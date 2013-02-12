IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_branch_contact]')) 
   ALTER TABLE [dbo].[tbl_branch_contact] 
   ENABLE  CHANGE_TRACKING
GO
