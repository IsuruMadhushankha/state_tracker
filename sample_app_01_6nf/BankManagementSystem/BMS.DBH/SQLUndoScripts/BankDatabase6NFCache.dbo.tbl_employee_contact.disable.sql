IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tbl_employee_contact]')) 
   ALTER TABLE [dbo].[tbl_employee_contact] 
   DISABLE  CHANGE_TRACKING
GO
