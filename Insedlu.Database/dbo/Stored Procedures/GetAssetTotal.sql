-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAssetTotal]  
@projId int,
@asset nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
		 
    -- Insert statements for procedure here
	if @asset = 'accommodation'
	SELECT sum(acc.cost) total from Accommodation acc 
	where acc.project_id = @projId 
	if @asset ='telephone'
	SELECT sum(tel.cost) from Telephone tel
	where tel.project_id = @projId
	if @asset = 'employee'
	SELECT sum(acc.cost) from Employees acc
	where acc.project_id = @projId
	if @asset ='print'
	SELECT sum(tel.cost) from PrintMaterial tel
	where tel.project_id = @projId
	if @asset = 'refreshment'
	SELECT sum(acc.cost) from Refreshment acc
	where acc.project_id = @projId
	if @asset ='vehicle'
	SELECT sum(tel.cost) from Vehicle tel
	where tel.project_id = @projId
	if @asset ='wifi'
	SELECT sum(tel.cost) from Wifi tel
	where tel.project_id = @projId

END
