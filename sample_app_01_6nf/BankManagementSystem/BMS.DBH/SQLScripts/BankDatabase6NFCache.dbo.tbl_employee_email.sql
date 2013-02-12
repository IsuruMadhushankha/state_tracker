IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_employee_email]')) 
   ALTER TABLE [dbo].[tbl_employee_email] 
   ENABLE  CHANGE_TRACKING
GO
