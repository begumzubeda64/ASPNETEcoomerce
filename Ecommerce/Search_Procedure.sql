SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,> GetBySearch 'IPhone'
-- =============================================
CREATE PROCEDURE GetBySearch
	@search nvarchar(max)=null
AS
BEGIN
	
	SELECT * from [dbo].[Tbl_Product] p
	left join [dbo].[Tbl_Category] c on p.CategoryId = c.CategoryId
	where
	p.ProductName LIKE CASE WHEN @search is not null then '%'+@search+'%' else p.ProductName end
	OR
	c.CategoryName LIKE CASE WHEN @search is not null then '%'+@search+'%' else c.CategoryName end
END
GO
