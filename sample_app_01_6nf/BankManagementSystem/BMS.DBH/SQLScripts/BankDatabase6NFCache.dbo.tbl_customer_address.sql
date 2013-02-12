IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_customer_address]')) 
   ALTER TABLE [dbo].[tbl_customer_address] 
   ENABLE  CHANGE_TRACKING
GO
