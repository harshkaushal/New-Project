USE [Ekomsys]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetChild_Pages]    Script Date: 07/18/2014 01:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetChild_Pages]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Naveen Chandra Tiwari>
-- Create date: <17 July, 2014>
-- Description:	<Get all the child pages by Page Id>
-- =============================================
CREATE FUNCTION [dbo].[fn_GetChild_Pages]
(
	-- Add the parameters for the function here
	@Parent_Page_Id INT
)
RETURNS VARCHAR(1000)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @subPageValue VARCHAR(1000)=''''
	
	SELECT @subPageValue = ISNULL(@subPageValue,'''')+ CASE LEN(ISNULL(@subPageValue,'''')) WHEN 0 THEN '''' ELSE ''^'' END +
						   ISNULL((CONVERT(VARCHAR(10), Page_Id)+''~''+Name),'''')
	FROM tb_Page WHERE Parent_Page_Id = @Parent_Page_Id

	RETURN @subPageValue

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllPages_SubPages]    Script Date: 07/18/2014 01:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetAllPages_SubPages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Naveen Chandra Tiwari>
-- Create date: <17 July, 2014>
-- Description:	<Get pages and their sub pages>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAllPages_SubPages]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Page_Id,Name,ISNULL(Parent_Page_Id,0) Parent_Page_Id, Page_Content,
		   [dbo].[fn_GetChild_Pages](Page_Id) Child_Pages 
	FROM tb_Page
	WHERE Is_Active=1 AND Parent_Page_Id IS NULL
END
' 
END
GO
