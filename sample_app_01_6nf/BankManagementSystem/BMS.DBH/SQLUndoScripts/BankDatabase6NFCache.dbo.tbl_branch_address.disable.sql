IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_branch_address]')) 
   ALTER TABLE [dbo].[tbl_branch_address] 
   DISABLE  CHANGE_TRACKING
GO
