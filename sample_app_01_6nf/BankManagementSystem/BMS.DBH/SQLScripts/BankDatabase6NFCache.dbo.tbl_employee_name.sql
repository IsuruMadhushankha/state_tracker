IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_employee_name]')) 
   ALTER TABLE [dbo].[tbl_employee_name] 
   ENABLE  CHANGE_TRACKING
GO
