IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_customer_name]')) 
   ALTER TABLE [dbo].[tbl_customer_name] 
   ENABLE  CHANGE_TRACKING
GO
